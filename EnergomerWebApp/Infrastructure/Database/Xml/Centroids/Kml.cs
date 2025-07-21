namespace EnergomerWebApp.Database.Xml.Centroids
{
    public partial class kmlDocumentFolderPlacemark
    {
        public int Id => ExtendedData.SchemaData.SimpleData.First(sd => sd.name == "fid").Value;

        public double Size => ExtendedData.SchemaData.SimpleData.First(sd => sd.name == "size").Value;

    }

    public partial class kml
    {
        public kmlDocumentFolderPlacemark[] Placemark => Document.Folder.Placemark;
    }
}
