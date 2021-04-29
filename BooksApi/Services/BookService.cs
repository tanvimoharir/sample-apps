//Adding the BookService class for defining CRUD operations
using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

//the BookService class uses the following MongoDB.Driver memebers to perform
//CRUD operations against the database

namespace BooksApi.Services
{
    public class BookService
    {
        //IMongoDatabse represents the mongo databse for perfoming operations.
        //We use below the generic GetCollection<TDocument>(collection) method on the interface to gain access to data
        //in specific collection.Perform CRUD operations against the collection after this method is called
        //In the GetCollection<TDocument>(collection) method call collection represents the collection name and TDocument 
        //represents the CLR object type stored in the collection
        //GetCollection<TDocument>(collection) returns a MongoCollection object representing the collection
        private readonly IMongoCollection<Books> _books;
        //MongoClient reads the server instance for performing database operations
        //The consrructor of this class is provided in the MongoDb connection string
        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client=new MongoClient(settings.ConnectionString);
            var database=client.GetDatabase(settings.DatabaseName);

            _books=database.GetCollection<Books>(settings.BooksCollectionName);
        }
        public List<Books> Get()=>_books.Find(Books=>true).ToList();
        // => is an operator
        //The => token is supported in two forms: as the lambda operator
        // and as a separator of a member name and the member implementation
        // in an expression body definition.
        public Books Get(string id)=>_books.Find<Books>(book=>book.Id==id).FirstOrDefault();
        //still unclear on the => operator
        //Find<TDocument> returns all documents in the collection matching provided search critera
        public Books Create(Books book)
        {
           //Inserts the provided object as a new document in the collection
            _books.InsertOne(book);
            return book;
        }

        //replaceone replaces the single document matching the provided search criteria with the provided object
        public void Update(string id,Books bookIn)=>_books.ReplaceOne(bookIn=>bookIn.Id==id,bookIn);
        //Deletes a single document matching the provided search criteria
        public void Remove(Books bookIn)=>_books.DeleteOne(book=>book.Id==bookIn.Id);
        public void Remove(string id)=>_books.DeleteOne(Books=>Books.Id==id);
    }
}
//In the above code an IBookstoreDatabaseSettings instance is retrieved from DI via
//contructor injection. This technique provides access to the appsettings.json
//configuration values