using EnergomerWebApp.Domain.Fields;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Application.Services
{
    public interface ICalculationService
    {
        bool CheckField(Field field, GeoCoordinate point);
    }
}
