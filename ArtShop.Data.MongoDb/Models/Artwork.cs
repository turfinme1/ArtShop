using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtShop.Data.ImageStore.Models
{
    public class Artwork
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Image { get; set; } = null!;
    }
}
