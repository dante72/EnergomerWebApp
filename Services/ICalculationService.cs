using EnergomerWebApp.Fields;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Services
{
    public interface ICalculationService
    {
        bool CheckField(Field field, GeoCoordinate point);
    }
}
