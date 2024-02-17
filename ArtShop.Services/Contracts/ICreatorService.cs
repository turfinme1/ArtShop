using ArtShop.Web.ViewModels.User;

namespace ArtShop.Services.Contracts
{
    public interface ICreatorService
    {
        Task<CreatorViewModel?> GetByIdAsync(int id);
    }
}
