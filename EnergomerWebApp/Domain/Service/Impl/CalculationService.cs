using EnergomerWebApp.Domain.Entity;
using GeoCoordinatePortable;
using NetTopologySuite.Geometries;

namespace EnergomerWebApp.Domain.Service.Impl
{
    public class CalculationService : ICalculationService
    {   
        private const double EPS = 1e-14;
        private readonly ILogger<CalculationService> _logger;

        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }
        public bool CheckField(Field field, GeoCoordinate geoPoint)
        {
            _logger.LogDebug($"Field: {field}");
            _logger.LogDebug($"Point: {geoPoint}");

            var point = ToPoint(geoPoint);
            var center = ToPoint(field.Locations.Center);
            var polygon = field.Locations.Polygon.Select(ToPoint).ToArray();

            Sort(polygon);

            return PointIsInside(polygon, point, center);
        }

        private void Sort(Point[] coords)
        {
            for (var i = 0; i < coords.Count() - 1; i++)
            {
                int? index = null;
                double minDistance = 0;
                for (var j = i + 1; j < coords.Count(); j++)
                {
                    var distance = coords[i].Distance(coords[j]);

                    if (index == null || distance < minDistance)
                    {
                        minDistance = distance;
                        index = j;
                    }
                }

                if (index != null)
                {
                    var tmp = coords[i + 1];
                    coords[i + 1] = coords[index.Value];
                    coords[index.Value] = tmp;
                }
            }
        }

        public bool PointIsInside(Point[] points, Point currentPoint, Point centerPoint)
        {
            if (points.Any(p => Math.Abs(currentPoint.Distance(p)) < EPS) || Math.Abs(currentPoint.Distance(centerPoint)) < EPS)
                return true;

            List<Point> crossPoints = new List<Point>();

            for (var i = 0; i < points.Count(); i++)
            {
                var p1 = points[i];
                var p2 = points[(i + 1) % points.Count()];
                var resultPoint = CrossLines(p1, p2, currentPoint, centerPoint);
                if (resultPoint != null && PointIsOnSegment(p1, p2, resultPoint) && PointIsOnRay(centerPoint, currentPoint, resultPoint))
                {
                    crossPoints.Add(resultPoint);
                }
            }

            return crossPoints.Count % 2 == 1;
        }

        //y = k1 * x + b1
        //y = k2 * x + b2

        //k1 = (y2 - y1) / (x2 - x1)
        //k2 = (y4 - y3) / (x4 - x3)

        public Point? CrossLines(Point p1, Point p2, Point p3, Point p4)
        {
            Point result = null;

            if (Math.Abs(p2.X - p1.X) < EPS || Math.Abs(p4.X - p3.X) < EPS)
            {
                if (Math.Abs(p2.X - p1.X) < EPS && Math.Abs(p4.X - p3.X) < EPS)
                    return null;

                if (Math.Abs(p2.X - p1.X) < EPS)
                {
                    double X = p1.X;
                    double k2 = (p4.Y - p3.Y) / (p4.X - p3.X);
                    double b2 = p3.Y - k2 * p3.X;
                    double Y = k2 * X + b2;

                    result = new Point(X, Y);

                } else if (Math.Abs(p4.X - p3.X) < EPS)
                {
                    double X = p3.X;
                    double k1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                    double b1 = p1.Y - k1 * p1.X;
                    double Y = k1 * X + b1;

                    result = new Point(X, Y);
                }
            }
            else
            {
                double k1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                double k2 = (p4.Y - p3.Y) / (p4.X - p3.X);

                if (Math.Abs(k1 - k2) < EPS)
                    return null;

                double X = (k2 - k1) / (p1.Y - p3.Y);
                double b2 = p3.Y - k2 * p3.X;
                double Y = k2 * X + b2;

                result = new Point(X, Y);

            }

            if (result != null)
                return result;

            return null;
        }

        private bool PointIsOnSegment(Point p1, Point p2, Point result)
        {
            return Math.Min(p1.X, p2.X) <= result.X && result.X <= Math.Max(p1.X, p2.X) && Math.Min(p1.Y, p2.Y) <= result.Y && result.Y <= Math.Max(p1.Y, p2.Y);
        }

        private bool PointIsOnRay(Point center, Point current, Point result)
        {
            return (current.X >= result.X && current.X >= center.X || current.X <= result.X && current.X <= center.X)
                && (current.Y >= result.Y && current.Y >= center.Y || current.Y <= result.Y && current.Y <= center.Y);
        }

        private Point ToPoint(GeoCoordinate geoPoint) => new Point(geoPoint.Latitude, geoPoint.Longitude);
        
    }
}
