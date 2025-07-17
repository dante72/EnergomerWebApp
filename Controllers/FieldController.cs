using EnergomerWebApp.Database;
using EnergomerWebApp.DTO.Extention;
using EnergomerWebApp.Fields;
using EnergomerWebApp.Services;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EnergomerWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FieldController : ControllerBase
    {

        private readonly ILogger<FieldController> _logger;
        private readonly IFieldService _fieldService;
        public FieldController(ILogger<FieldController> logger, IFieldService fieldService)
        {
            _logger = logger;
            _fieldService = fieldService;
        }

        [HttpGet]
        public IEnumerable<DTO.Field> Get()
        {
            var fields = _fieldService.GetFields();
            return fields.ToDto();
        }

        [HttpGet("{latitude}&{longitude}")]
        public IEnumerable<DTO.Field> Get(double latitude, double longitude)
        {
            GeoCoordinate point = new GeoCoordinate(latitude, longitude);
            return _fieldService.GetFields(point).ToDto();
        }


        [HttpGet("{fieldId}")]
        public double? GetArea(int fieldId)
        {
            return _fieldService.GetArea(fieldId);
        }

        [HttpGet("{latitude}&{longitude}&{centerId}")]
        public double? GetDistance(double latitude, double longitude, int centerId)
        {
            GeoCoordinate point = new GeoCoordinate(latitude, longitude);
            return _fieldService.Distance(point, centerId);
        }
    }
}
