using EnergomerWebApp.Application.Services;
using EnergomerWebApp.DTO;
using EnergomerWebApp.DTO.Extention;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;

namespace EnergomerWebApp.Presentation.Controllers
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

        [HttpGet("GetFields")]
        public IEnumerable<Field> GetFields()
        {
            var fields = _fieldService.GetFields();
            return fields.ToDto();
        }

        [HttpGet("PointInsideFields/{latitude}&{longitude}")]
        public IActionResult GetFields(double latitude, double longitude)
        {
            GeoCoordinate point = new GeoCoordinate(latitude, longitude);

            var result = _fieldService.GetFields(point).Select(f => new { f.Id, f.Name }).ToArray();

            return Ok(result.Length == 0 ? false : result);
        }


        [HttpGet("GetArea/{fieldId}")]
        public double? GetArea(int fieldId)
        {
            return _fieldService.GetArea(fieldId);
        }

        [HttpGet("GetDistance/{latitude}&{longitude}&{centerId}")]
        public double? GetDistance(double latitude, double longitude, int centerId)
        {
            GeoCoordinate point = new GeoCoordinate(latitude, longitude);
            return _fieldService.Distance(point, centerId);
        }
    }
}
