using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

//1
namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        //MongoDB'de id'ler birer string olarak tutulur ve bunları dönüştürmek için ise
        //Bir metot kullanırız.
        //Kategori isimleri tutuluyor.

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
