using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set; }
        // Id is required for mapping Common language Runtime(CLR) object to Mongodb collection
        // the annotation [bsonid] indicates this property as document's primary key
        // [BsonRepresntation(BsonType.ObjectId)] is to allow passing the parameter as type string instal of Objectid mongo handles conversion from string to objectid
        [BsonElement("Name")]
        public string Bookname{ get; set; }

        public decimal Price{ get; set; }

        public string Category { get; set; }

        public string Author{ get; set; } 
    }
}