using EnergomerWebApp.Database.Xml.Centroids;

namespace EnergomerWebApp.Infrastructure.Impl
{
    public class CentroidRepository : IRepository<kml>
    {
        private const string CENTROIDS_PATH = @".\source\centroids.kml";

        public async Task<kml> Get()
        {
            return await KmlReader.Read<kml>(CENTROIDS_PATH);
        }
    }
}
