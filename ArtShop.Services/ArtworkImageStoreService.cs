using ArtShop.Data.ImageStore;
using ArtShop.Services.Contracts;
using MongoDB.Driver.GridFS;

namespace ArtShop.Services
{
    public class ArtworkImageStoreService : IArtworkImageStoreService
    {
        private readonly ArtworkImageDbContext _context;

        public ArtworkImageStoreService(ArtworkImageDbContext context)
        {
            _context = context;
        }

        public async Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MongoDB.Bson.ObjectId> UploadAsync(byte[] bytes)
        {
            GridFSBucket bucket = new GridFSBucket(_context.Database);

            return await bucket.UploadFromBytesAsync("file1", bytes);
        }

        public async Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
