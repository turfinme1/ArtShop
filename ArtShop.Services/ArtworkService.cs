using ArtShop.Data.Common.Repositories;
using ArtShop.Data.Models;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.Artwork;
using Microsoft.EntityFrameworkCore;

namespace ArtShop.Services
{
    public class ArtworkService(IRepository<Artwork> repository)
        : IArtworkService
    {
        public async Task<IEnumerable<ArtworkViewModel>> GetAllAsync()
        {
            return await repository
                .All()
                .Select(a => new ArtworkViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Summary = a.Summary,
                    Description = a.Description,
                    OverallRatingScore = a.OverallRatingScore,
                    Price = a.Price,
                    Quantity = a.Quantity,
                    CreatorId = a.CreatorId
                })
                .ToListAsync();
        }

        public async Task<ArtworkViewModel?> GetByIdAsync(int id)
        {
            return await repository.All()
                .Where(a => a.Id == id)
                .Select(a => new ArtworkViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Summary = a.Summary,
                    Description = a.Description,
                    OverallRatingScore = a.OverallRatingScore,
                    Price = a.Price,
                    Quantity = a.Quantity,
                    CreatorId = a.CreatorId
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(ArtworkViewModel model)
        {
            var entity = new Artwork()
            {
                Id = model.Id,
                Name = model.Name,
                Summary = model.Summary,
                Description = model.Description,
                OverallRatingScore = model.OverallRatingScore,
                Price = model.Price,
                Quantity = model.Quantity,
                CreatorId = model.CreatorId,
                CreatedOn = DateTime.UtcNow
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ArtworkViewModel model)
        {
            var entity = await repository.All().FirstOrDefaultAsync(a => a.Id == model.Id);

            if (entity is null)
            {
                throw new ArgumentException();
            }

            repository.Update(entity);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await repository.All().FirstOrDefaultAsync(a => a.Id == id);

            if (entity is null)
            {
                throw new ArgumentException();
            }

            repository.Delete(entity);
            await repository.SaveChangesAsync();
        }
    }
}
