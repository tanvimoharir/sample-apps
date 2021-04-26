namespace BooksApi.Models
{
    public class BookstoreDatabaseSettings:IBookstoreDatabaseSettings
    {
        public string BooksCollectionName{ get; set; }
        public string ConnectionString{ get; set; }
        public string DatabaseName{ get; set; }
    }

    public interface IBookstoreDatabaseSettings
    {
        string BooksCollectionName{ get; set; }
        string ConnectionString{ get; set; }
        string DatabaseName{ get; set; }
    }
}
//The preceeding BookstoreDatabaseSettings class is used to store the appsettings.json file's BookstoreDatabaseSettings property values
//The json and C# property names are named identical to ease the mapping process