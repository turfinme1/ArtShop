using ArtShop.Web.ViewModels.Artwork;

namespace ArtShop.Services.Contracts
{
    public interface IArtworkImageStoreService
    {
        Task GetByIdAsync(int id);

        Task<MongoDB.Bson.ObjectId> UploadAsync(byte[] bytes);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
