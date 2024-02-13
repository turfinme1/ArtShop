using ArtShop.Web.ViewModels.Artwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Services.Contracts
{
    public interface IArtworkService
    {
        Task AddAsync(ArtworkViewModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<ArtworkViewModel>> GetAllAsync();
        Task<ArtworkViewModel?> GetByIdAsync(int id);
        Task UpdateAsync(ArtworkViewModel model);
    }
}
