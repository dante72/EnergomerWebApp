using EnergomerWebApp.Domain.Entity;

namespace EnergomerWebApp.Domain.Service
{
    public interface IFieldService
    {
        IEnumerable<Field> GetFields();
    }
}
