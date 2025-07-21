using System.Xml.Serialization;
using Xml = EnergomerWebApp.Database.Xml;

namespace EnergomerWebApp.Infrastructure.Impl
{
    public class KmlReader
    {
        public static async Task<T> Read<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string xmlString = await File.ReadAllTextAsync(path);

            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
