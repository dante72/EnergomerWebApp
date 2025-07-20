namespace EnergomerWebApp.Services
{
    public interface IDataService
    {
        Database.Xml.Centroids.kml Centroids {  get; }
        Database.Xml.Fields.kml Fields { get; }
    }
}
