using EnergomerWebApp.Database.Xml.Centroids;
using EnergomerWebApp.Database.Xml.Fields;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace EnergomerWebApp.Database
{
    public class KmlReader
    {
        public static Task<Xml.Fields.kml> ReadFields(string path)
        {
            return Read<Xml.Fields.kml>(path);
        }

        public static Task<Xml.Centroids.kml> ReadCentroids(string path)
        {
            return Read<Xml.Centroids.kml>(path);
        }

        public async static Task<T> Read<T>(string path)
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
