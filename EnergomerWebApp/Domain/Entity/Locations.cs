using GeoCoordinatePortable;

namespace EnergomerWebApp.Domain.Entity
{
    public class Locations
    {
        public GeoCoordinate Center { get; set; }
        public GeoCoordinate[] Polygon { get; set; }
    }
}
