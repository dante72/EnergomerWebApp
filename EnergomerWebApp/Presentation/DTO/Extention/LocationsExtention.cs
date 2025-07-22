namespace EnergomerWebApp.DTO.Extention
{
    public static class LocationsExtention
    {
        public static Locations ToDto(this Domain.Entity.Locations locations)
        {
            return new Locations()
            {
                Center = [locations.Center.Latitude, locations.Center.Longitude],
                Polygon = locations.Polygon.Select(p => new double[] { p.Latitude, p.Longitude }).ToArray()
            };
        }
    }
}
