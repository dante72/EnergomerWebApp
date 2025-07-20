using EnergomerWebApp.Fields;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Services.Impl
{
    public class FieldService : IFieldService
    {
        private readonly ILogger<FieldService> _logger;
        private readonly IDataService _hashData;
        private readonly ICalculationService _calculationService;
        public FieldService(ILogger<FieldService> logger, IDataService hashData, ICalculationService calculationService)
        {
            _logger = logger;
            _hashData = hashData;
            _calculationService = calculationService;
        }

        public Field[] GetFields()
        {
            return _hashData.Fields.Placemark.Select(pm => new Field()
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
            var placemark = _hashData.Centroids.Placemark
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
            return _hashData.Fields.Placemark.FirstOrDefault(pm => pm.Id == id)?.Size;
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
