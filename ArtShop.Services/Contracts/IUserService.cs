using ArtShop.Web.ViewModels.User;

namespace ArtShop.Services.Contracts
{
    public interface IUserService
    {
        Task<CreatorViewModel?> GetByIdAsync(int id);
    }
}
