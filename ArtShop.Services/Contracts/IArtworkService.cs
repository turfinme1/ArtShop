using ArtShop.Web.ViewModels.Artwork;

namespace ArtShop.Services.Contracts
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkViewModel>> GetAllAsync();

        Task<ArtworkViewModel?> GetByIdAsync(int id);

        Task<ArtworkFormViewModel?> GetByIdAsFormViewModelAsync(int id);
        
        Task AddAsync(ArtworkFormViewModel model);
        
        Task UpdateAsync(ArtworkFormViewModel model);
        
        Task DeleteAsync(int id);
    }
}
