using ArtShop.Data.Common.Repositories;
using ArtShop.Data.Models;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.Style;
using Microsoft.EntityFrameworkCore;


namespace ArtShop.Services
{
    public class StyleService(IRepository<Style> repository)
        : IStyleService
    {
        public async Task<IEnumerable<StyleViewModel>> GetAllAsync()
        {
            return await repository
                .All()
                .Select(s => new StyleViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();
        }

        public async Task<StyleViewModel?> GetByIdAsync(int id)
        {
            return await repository
                .All()
                .Where(s => s.Id == id)
                .Select(s => new StyleViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .FirstOrDefaultAsync();
        }
    }
}
