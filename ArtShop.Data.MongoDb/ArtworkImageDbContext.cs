using ArtShop.Data.ImageStore.Configuration;
using ArtShop.Data.ImageStore.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ArtShop.Data.ImageStore
{
    public class ArtworkImageDbContext
    {
        public readonly IMongoCollection<Artwork> ArtworkCollection;
        public readonly IMongoDatabase Database;

        public ArtworkImageDbContext(IOptions<MongoDbConfiguration> config)
        {   
            var client = new MongoClient(config.Value.ConnectionString);

            Database = client.GetDatabase(config.Value.DatabaseName);

            var artworkCollection = Database.GetCollection<Artwork>(config.Value.CollectionName);

            ArtworkCollection = artworkCollection;
        }

    }
}
