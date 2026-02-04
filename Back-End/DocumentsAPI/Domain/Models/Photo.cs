using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; } = default!;
        public string Url { get; set; } = default!;
    }
}
