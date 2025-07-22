using EnergomerWebApp.Domain.Entity;
using GeoCoordinatePortable;

namespace EnergomerWebApp.Application.Services
{
    public interface IFieldService
    {
        Field[] GetFields();

        double GetArea(int id);

        double Distance(GeoCoordinate point, int centerId);

        Field[] GetFields(GeoCoordinate point);
    }
}
