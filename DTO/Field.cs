using Newtonsoft.Json;

namespace EnergomerWebApp.DTO
{
    public class Field
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "size")]
        public double Size { get; set; }

        [JsonProperty(PropertyName = "locations")]
        public Locations Locations { get; set; }
    }
}
