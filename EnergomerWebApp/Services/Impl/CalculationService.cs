using EnergomerWebApp.Fields;
using GeoCoordinatePortable;
using NetTopologySuite.Geometries;
using NetTopologySuite.Mathematics;

namespace EnergomerWebApp.Services.Impl
{
    public class CalculationService : ICalculationService
    {   
        private const double EPS = 1e-10;
        private readonly ILogger<CalculationService> _logger;

        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }
        public bool CheckField(Field field, GeoCoordinate point)
        {
            _logger.LogDebug("Field: ", field);
            _logger.LogDebug("Point: ", point);

            if (field.Locations.Polygon.Contains(point) || field.Locations.Center == point)
            {
                return true;
            }    

            var radiusVectors = field.Locations.Polygon.Select(ToVector).ToArray();
            var currentRadiusVector = ToVector(point);
            var sortedRadiusVectors = Sort(radiusVectors);

            _logger.LogDebug("radiusVectors: ", radiusVectors);

            if (CheckCoplanarity(sortedRadiusVectors, currentRadiusVector))
            {
                return true;
            }

            var centerRadiusVector = ToVector(field.Locations.Center);

            return PointIsInside(sortedRadiusVectors, currentRadiusVector, centerRadiusVector);
        }

        private bool PointIsInside(Vector3D[] radiusVectors, Vector3D currentRadiusVector, Vector3D centerRadiusVector)
        {
            var points = CreateProjectionOnOXY(radiusVectors);
            var currentPoint = CreateProjectionOnOXY(currentRadiusVector);
            var centerPoint = CreateProjectionOnOXY(centerRadiusVector);

            return PointIsInside(points, currentPoint, centerPoint);

        }

        public bool PointIsInside(Point[] points, Point currentPoint, Point centerPoint)
        {
            if (points.Contains(currentPoint) || currentPoint == centerPoint)
                return true;

            HashSet<Point> crossPoints = new HashSet<Point>();

            for (var i = 0; i < points.Count(); i++)
            {
                var resultPoint = CrossLines(points[i], points[(i + 1) % points.Count()], currentPoint, centerPoint);
                if (resultPoint != null 
                    && ResultPointIsOnRay(currentPoint, centerPoint, resultPoint) 
                    && PointIsOnSegment(points[i], points[(i + 1) % points.Count()], resultPoint))
                    crossPoints.Add(resultPoint);
            }

            return crossPoints.Count == 1;
        }

        public Point? CrossLines(Point p1, Point p2, Point p3, Point p4)
        {
            double k;
            if (Math.Abs(p2.Y - p1.Y) > EPS)
            {
                double q = (p2.X - p1.X) / (p1.Y - p2.Y);
                double sn = (p3.X - p4.X) + (p3.Y - p4.Y) * q;

                if (Math.Abs(sn) < EPS)
                    return null;

                double fn = (p3.X - p1.X) + (p3.Y - p1.Y) * q;
                
                k = fn / sn;
            } else
            {
                if (Math.Abs(p3.Y - p4.Y) < EPS)
                    return null;

                k = (p3.Y - p1.Y) / (p3.Y - p4.Y);
            }

            var result = new Point(p3.X + (p4.X - p3.X) * k, p3.Y + (p4.Y - p3.Y) * k);

            return result;
        }
        private bool PointIsOnSegment(Point p1, Point p2, Point result)
        {
            return Math.Abs(p2.X - p1.X) >= Math.Abs(p2.X - result.X) + Math.Abs(p1.X - result.X)
                && Math.Abs(p2.Y - p1.Y) >= Math.Abs(p2.Y - result.Y) + Math.Abs(p1.Y - result.Y);
        }

        private bool ResultPointIsOnRay(Point current, Point center, Point result)
        {
            return ((center.X >= current.X && current.X >= result.X) || (center.X <= current.X && current.X <= result.X))
                && ((center.Y >= current.Y && current.Y >= result.Y) || (center.Y <= current.Y && current.Y <= result.Y));
        }

        private Point[] CreateProjectionOnOXY(Vector3D[] radiusVectors)
        {
            return radiusVectors.Select(p => new Point(p.X, p.Y, 0)).ToArray();
        }
        private Point CreateProjectionOnOXY(Vector3D radiusVector) => new Point(radiusVector.X, radiusVector.Y, 0);

        private bool CheckCoplanarity(Vector3D[] radiusVectors, Vector3D currentRadiusVector)
        {
            for (int i = 0; i < radiusVectors.Count(); i++)
            {
                if (CheckCoplanarity(radiusVectors[i], radiusVectors[(i + 1) % radiusVectors.Count()], currentRadiusVector))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckCoplanarity(Vector3D v1, Vector3D v2, Vector3D v3)
        {
            return Math.Abs((v1 * v2).Dot(v3)) < EPS;
        }

        private Vector3D[] Sort(Vector3D[] vectors)
        {
            for (var i = 0; i < vectors.Count() - 1; i++)
            {
                int? index = null;
                double minDistance = 0;
                for (var j = i + 1; j < vectors.Count(); j++)
                {
                    var distance = (vectors[i] - vectors[j]).Length();

                    if (index == null || distance < minDistance)
                    {
                        minDistance = distance;
                        index = j;
                    }
                }

                if (index != null)
                {
                    var tmp = vectors[i + 1];
                    vectors[i + 1] = vectors[index.Value];
                    vectors[index.Value] = tmp;
                }
            }

            return vectors;
        }

        private Vector3D ToVector(GeoCoordinate point)
        {
            double alfa = point.Longitude * (Math.PI / 180.0);
            double beta = point.Latitude * (Math.PI / 180.0);
            double X = Math.Cos(alfa) * Math.Cos(beta);
            double Y = Math.Sin(alfa) * Math.Cos(beta);
            double Z = Math.Sin(beta);

            return new Vector3D(X, Y, Z);
        }
    }
}
