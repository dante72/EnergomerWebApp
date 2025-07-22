using EnergomerWebApp.Domain.Entity;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Domain.Service
{
    public interface ICalculationService
    {
        bool CheckField(Field field, GeoCoordinate point);
    }
}
