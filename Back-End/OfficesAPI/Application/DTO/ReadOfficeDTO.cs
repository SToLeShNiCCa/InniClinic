using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.DTO
{
    public class ReadOfficeDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        public string Address { get; set; } = default!;
        public string PhotoID { get; set; } = default!;
        public string RegistryPhoneNumber { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
