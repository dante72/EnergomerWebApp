using EnergomerWebApp.Domain.Fields;
using EnergomerWebApp.Infrastructure;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Application.Services.Impl
{
    public class FieldService : IFieldService
    {
        private readonly ILogger<FieldService> _logger;
        private readonly IRepository<Database.Xml.Centroids.kml> _centroids;
        private readonly IRepository<Database.Xml.Fields.kml> _fields;
        private readonly ICalculationService _calculationService;

        private Lazy<Database.Xml.Centroids.kml> lazyCentroids;
        private Lazy<Database.Xml.Fields.kml> lazyFields;
        public FieldService(
            ILogger<FieldService> logger,
            IRepository<Database.Xml.Centroids.kml> centroids,
            IRepository<Database.Xml.Fields.kml> fields,
            ICalculationService calculationService)
        {
            _logger = logger;
            _fields = fields;
            _centroids = centroids;
            _calculationService = calculationService;
            lazyCentroids = new(_centroids.Get().Result);
            lazyFields = new(_fields.Get().Result);
        }

        public Field[] GetFields()
        {
            return lazyFields.Value.Placemark.Select(pm => new Field()
            {
                Id = pm.Id,
                Name = pm.name,
                Size = pm.Size,
                Locations = new Locations()
                {
                    Center = GetCenter(pm.Id),
                    Polygon = GetGeoCoordinates(pm.Polygon.outerBoundaryIs.LinearRing.coordinates)
                }
            }).ToArray();
        }

        private GeoCoordinate GetCenter(int id)
        {
            var placemark = lazyCentroids.Value.Placemark
                .First(pm => pm.Id == id);

            return GetGeoCoordinates(placemark.Point.coordinates)[0];
        }

        private GeoCoordinate[] GetGeoCoordinates(string coordString)
        {
            var geoCoordinates = new List<GeoCoordinate>();
            string[] coords = coordString.Split(" ");
            foreach (var coord in coords)
            {
                var latlon = coord.Split(",");
                double latitude = double.Parse(latlon[0].Replace(".", ","));
                double longitude = double.Parse(latlon[1].Replace(".", ","));
                var geoCoordinate = new GeoCoordinate(latitude, longitude);
                geoCoordinates.Add(geoCoordinate);
            }

            return geoCoordinates.ToArray();
        }

        public double? GetArea(int id)
        {
            return lazyFields.Value.Placemark.FirstOrDefault(pm => pm.Id == id)?.Size;
        }

        public double Distance(GeoCoordinate point, int centerId)
        {
            var center = GetCenter(centerId);

            return point.GetDistanceTo(center);
        }

        public Field[] GetFields (GeoCoordinate point)
        {
            var allFields = GetFields();
            var results = new List<Field>();

            foreach (var field in allFields)
            {
                if (_calculationService.CheckField(field, point))
                    results.Add(field);
            }

            return results.ToArray();
        }
    }
}
