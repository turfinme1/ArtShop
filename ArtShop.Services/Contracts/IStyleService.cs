using ArtShop.Web.ViewModels.Artwork;
using ArtShop.Web.ViewModels.Style;

namespace ArtShop.Services.Contracts
{
    public interface IStyleService
    {
        Task<IEnumerable<StyleViewModel>> GetAllAsync();

        Task<StyleViewModel?> GetByIdAsync(int id);
    }
}
