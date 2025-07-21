using GeoCoordinatePortable;

namespace EnergomerWebApp.Domain.Fields
{
    public class Locations
    {
        public GeoCoordinate Center { get; set; }
        public GeoCoordinate[] Polygon { get; set; }
    }
}
