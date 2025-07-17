using EnergomerWebApp.Fields;
using GeoCoordinatePortable;
using NetTopologySuite.Geometries;
using NetTopologySuite.Mathematics;

namespace EnergomerWebApp.Services.Impl
{
    public class CalculationService : ICalculationService
    {
        private const double EPS = 0.0001;
        public bool CheckField(Field field, GeoCoordinate point)
        {
            var radiusVectors = field.Locations.Polygon.Select(ToVector).ToArray();
            var currentRadiusVector = ToVector(point);
            var sortedRadiusVectors = Sort(radiusVectors);

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
            int crossPoints = 0;

            for (var i = 0; i < points.Count(); i++)
            {
                if (CrossLines(points[i], points[(i + 1) % points.Count()], currentPoint, centerPoint) != null)
                    crossPoints++;
            }

            return crossPoints == 1;
        }

        private Point? CrossLines(Point p1, Point p2, Point p3, Point p4)
        {
            double a1 = p2.Y - p1.Y;
            double a2 = p4.Y - p3.Y;

            double b1 = p1.X - p2.X;
            double b2 = p3.X - p4.X;

            double k = a1 * b2 - a2 * b1;

            if (Math.Abs(k) > EPS)
            {
                double c1 = p2.X * p1.Y - p1.X * p2.Y;
                double c2 = p4.X * p3.Y - p3.X * p3.Y;

                return new Point(-(c1 * b2 - c2 * b1) / k, -(a1 * c2 - a2 * c1) / k);
            }

            return null;
        }

        private bool CheckCrossPoint(Point p1, Point p2, Point result)
        {
            return Math.Abs(p2.X - p1.X) >= Math.Abs(p2.X - result.X) + Math.Abs(p1.X - result.X)
                && Math.Abs(p2.Y - p1.Y) >= Math.Abs(p2.Y - result.Y) + Math.Abs(p1.Y - result.Y);
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

        private bool CheckCoplanarity(Vector3D v1, Vector3D v2, Vector3D v3)
        {
            return (v1 * v2).Dot(v3) == 0;
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
                    var tmp = vectors[i];
                    vectors[i] = vectors[index.Value];
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
