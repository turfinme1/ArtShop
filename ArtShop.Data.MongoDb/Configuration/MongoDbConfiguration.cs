namespace ArtShop.Data.ImageStore.Configuration
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; } = null!;

        public  string DatabaseName { get; set; } = null!;

        public  string CollectionName { get; set; } = null!;
    }
}
