namespace EnergomerWebApp.DTO.Extention
{
    public static class FieldExtention
    {
        public static Field ToDto(this Domain.Entity.Field field)
        {
            return new Field()
            {
                Id = field.Id,
                Name = field.Name,
                Size = field.Size,
                Locations = field.Locations.ToDto()
            };
        }

        public static Field[] ToDto(this Domain.Entity.Field[] fields)
        {
            return fields.Select(f => f.ToDto()).ToArray();
        }
    }
}
