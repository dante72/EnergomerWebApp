namespace EnergomerWebApp.Services
{
    public interface IHashDataService
    {
        Database.Xml.Centroids.kml Centroids {  get; }
        Database.Xml.Fields.kml Fields { get; }
        Task UpdateData();
    }
}
