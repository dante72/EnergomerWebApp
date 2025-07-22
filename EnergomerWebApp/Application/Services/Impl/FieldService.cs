using EnergomerWebApp.Domain.Entity;
using EnergomerWebApp.Domain.Service;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Application.Services.Impl
{
    public class FieldService : IFieldService
    {
        private readonly ILogger<FieldService> _logger;
        private readonly ICalculationService _calculationService;
        Domain.Service.IFieldService _fieldService;

        public FieldService(
            ILogger<FieldService> logger,
            Domain.Service.IFieldService fieldService,
            ICalculationService calculationService)
        {
            _logger = logger;
            _calculationService = calculationService;
            _fieldService = fieldService;
        }

        public Field[] GetFields() => _fieldService.GetFields().ToArray();

        public double? GetArea(int id)
        {
            return _fieldService.GetFields().FirstOrDefault(pm => pm.Id == id)?.Size;
        }

        public double Distance(GeoCoordinate point, int centerId)
        {
            var center = _fieldService.GetFields().FirstOrDefault(pm => pm.Id == centerId);

            return point.GetDistanceTo(center?.Locations.Center);
        }

        public Field[] GetFields(GeoCoordinate point)
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
