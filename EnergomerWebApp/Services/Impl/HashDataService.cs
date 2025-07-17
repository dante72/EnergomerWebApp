using EnergomerWebApp.Database;

namespace EnergomerWebApp.Services.Impl
{
    public class HashDataService : IHashDataService
    {
        private readonly ILogger<HashDataService> _logger;
        private const string CENTROIDS_PATH = @".\Database\source\centroids.kml";
        private const string FIELDS_PATH = @".\Database\source\fields.kml";


        private Lazy<Database.Xml.Centroids.kml> lazyCentroids = new(() => GetCentroids().Result);
        private Lazy<Database.Xml.Fields.kml> lazyFields = new(() => GetFields().Result);

        public Database.Xml.Centroids.kml Centroids => lazyCentroids.Value;
        public Database.Xml.Fields.kml Fields => lazyFields.Value;

        public HashDataService(ILogger<HashDataService> logger)
        {
            _logger = logger;
        }

        private async static Task<Database.Xml.Centroids.kml> GetCentroids()
        {
            return await KmlReader.ReadCentroids(CENTROIDS_PATH);
        }

        private async static Task<Database.Xml.Fields.kml> GetFields()
        {
            return await KmlReader.ReadFields(FIELDS_PATH);
        }

        public Task UpdateData()
        {
            lock (this)
            {
                lazyCentroids = new(() => GetCentroids().Result);
                lazyFields = new(() => GetFields().Result);
            }

            return Task.CompletedTask;
        }
    }
}
