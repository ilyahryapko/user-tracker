using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserTracker.DAL.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId DocumentId { get; set; }
    }
}