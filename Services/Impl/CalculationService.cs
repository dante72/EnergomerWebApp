using EnergomerWebApp.Fields;
using GeoCoordinatePortable;
using System.Numerics;

namespace EnergomerWebApp.Services.Impl
{
    public class CalculationService : ICalculationService
    {
        private const double EPS = 0.0001;
        public bool CheckField(Field field, GeoCoordinate point)
        {
            var vectors = field.Locations.Polygon.Select(ToVector).ToArray();
            var checkPoint = ToVector(point);
            var sortedVectors = Sort(vectors);

            if (CheckCoplanarity(sortedVectors, checkPoint))
            {
                return true;
            }

            var center = ToVector(field.Locations.Center);

            return PointIsInside(sortedVectors, checkPoint, center);
        }

        private bool PointIsInside(Vector3[] vectors, Vector3 currentPoint, Vector3 center)
        {
            var points = CreateProjectionOnOXY(vectors);
            var checkPoint = CreateProjectionOnOXY(currentPoint);
            var centerPoint = CreateProjectionOnOXY(center);
            int crossPoints = 0;

            for (var i = 0; i < points.Count(); i++)
            {
                if (CrossLines(points[i], points[(i + 1) % points.Count()], checkPoint, centerPoint) != null)
                    crossPoints++;
            }

            return crossPoints == 1;
        }

        private Vector2? CrossLines(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float a1 = p2.Y - p1.Y;
            float a2 = p4.Y - p3.Y;

            float b1 = p1.X - p2.X;
            float b2 = p3.X - p4.X;

            float k = a1 * b2 - a2 * b1;

            if (Math.Abs(k) > EPS)
            {
                float c1 = p2.X * p1.Y - p1.X * p2.Y;
                float c2 = p4.X * p3.Y - p3.X * p3.Y;

                return new Vector2(-(c1 * b2 - c2 * b1) / k, -(a1 * c2 - a2 * c1) / k);
            }

            return null;
        }

        private bool CheckCrossPoint(Vector2 p1, Vector2 p2, Vector2 result)
        {
            return Math.Abs(p2.X - p1.X) >= Math.Abs(p2.X - result.X) + Math.Abs(p1.X - result.X)
                && Math.Abs(p2.Y - p1.Y) >= Math.Abs(p2.Y - result.Y) + Math.Abs(p1.Y - result.Y);
        }

        private Vector2[] CreateProjectionOnOXY(Vector3[] points)
        {
            return points.Select(p => new Vector2(p.X, p.Y)).ToArray();
        }

        private Vector2 CreateProjectionOnOXY(Vector3 p) => new Vector2(p.X, p.Y);

        private bool CheckCoplanarity(Vector3[] vectors, Vector3 currentVector)
        {
            for (int i = 0; i < vectors.Count(); i++)
            {
                if (CheckCoplanarity(vectors[i], vectors[(i + 1) % vectors.Count()], currentVector))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckCoplanarity(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            return Vector3.Dot(v1 * v2, v3) == 0f;
        }

        private Vector3[] Sort(Vector3[] vectors)
        {
            for (var i = 0; i < vectors.Count() - 1; i++)
            {
                int? index = null;
                float minDistance = 0;
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

        private Vector3 ToVector(GeoCoordinate point)
        {

            double alfa = point.Longitude * (Math.PI / 180.0);
            double beta = point.Latitude * (Math.PI / 180.0);
            return new Vector3()
            {
                X = (float)(Math.Cos(alfa) * Math.Cos(beta)),
                Y = (float)(Math.Sin(alfa) * Math.Cos(beta)),
                Z = (float)Math.Sin(beta)
            };
        }
    }
}
