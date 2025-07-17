using GeoCoordinatePortable;

namespace EnergomerWebApp.Fields
{
    public class Locations
    {
        public GeoCoordinate Center { get; set; }
        public GeoCoordinate[] Polygon { get; set; }
    }
}
