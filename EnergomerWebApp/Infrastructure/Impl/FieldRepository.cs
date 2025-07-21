using EnergomerWebApp.Database.Xml.Fields;


namespace EnergomerWebApp.Infrastructure.Impl
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
