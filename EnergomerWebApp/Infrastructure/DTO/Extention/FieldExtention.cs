using System.Runtime.CompilerServices;

namespace EnergomerWebApp.DTO.Extention
{
    public static class FieldExtention
    {
        public static Field ToDto(this Domain.Fields.Field field)
        {
            return new Field()
            {
                Id = field.Id,
                Name = field.Name,
                Size = field.Size,
                Locations = field.Locations.ToDto()
            };
        }

        public static Field[] ToDto(this Domain.Fields.Field[] fields)
        {
            return fields.Select(f => f.ToDto()).ToArray();
        }
    }
}
