using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//1
namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        //Her bir ürüne ait olan verilerini girdik.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        [BsonIgnore]//  =>  yani MongoDB'de bu alan yokmuş gibi çalışır.
        //Burada ise ilişkili bir tablo yaptık.
        public Category Category { get; set; }


    }
}
