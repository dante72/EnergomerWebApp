using EnergomerWebApp.Fields;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Services
{
    public interface IFieldService
    {
        Field[] GetFields();

        double? GetArea(int id);

        double Distance(GeoCoordinate point, int centerId);

        Field[] GetFields(GeoCoordinate point);
    }
}
