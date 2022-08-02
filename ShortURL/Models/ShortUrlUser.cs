using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShortURL.Models
{
    public class ShortUrlUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string longUrl { get; set; } = null!;

        public string shortUrl { get; set; } = null!;

    }
}