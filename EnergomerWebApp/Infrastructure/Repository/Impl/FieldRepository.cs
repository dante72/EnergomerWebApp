using EnergomerWebApp.Database.Xml.Fields;
using EnergomerWebApp.Infrastructure.Database.Xml;

namespace EnergomerWebApp.Infrastructure.Repository.Impl
{
    public class FieldRepository : IRepository<kml>
    {
        private const string FIELDS_PATH = @".\source\fields.kml";
        public async Task<kml> Get()
        {
            return await KmlReader.Read<kml>(FIELDS_PATH);
        }
    }
}
