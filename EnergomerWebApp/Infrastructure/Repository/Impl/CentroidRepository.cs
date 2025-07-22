using EnergomerWebApp.Database.Xml.Centroids;
using EnergomerWebApp.Infrastructure.Database.Xml;

namespace EnergomerWebApp.Infrastructure.Repository.Impl
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
