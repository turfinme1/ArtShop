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
                    Price = a.Price,
                    Quantity = a.Quantity,
                    YearMade = a.YearMade,
                    Height = a.Height,
                    Width = a.Width,
                    Depth = a.Depth,
                    IsFramed = a.IsFramed,
                    Subject = a.Subject.Name,
                    Style = a.Style.Name,
                    CreatorName = a.Creator.UserName
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
                    Price = a.Price,
                    Quantity = a.Quantity,
                    YearMade = a.YearMade,
                    Height = a.Height,
                    Width = a.Width,
                    Depth = a.Depth,
                    IsFramed = a.IsFramed,
                    Subject = a.Subject.Name,
                    Style = a.Style.Name,
                    CreatorName = a.Creator.UserName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ArtworkFormViewModel?> GetByIdAsFormViewModelAsync(int id)
        {
            return await repository.All()
                .Where(a => a.Id == id)
                .Select(a => new ArtworkFormViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Summary = a.Summary,
                    Description = a.Description,
                    Price = a.Price,
                    Quantity = a.Quantity,
                    YearMade = a.YearMade,
                    Height = a.Height,
                    Width = a.Width,
                    Depth = a.Depth,
                    IsFramed = a.IsFramed,
                    StyleId = a.StyleId,
                    SubjectId = a.SubjectId,
                })
                .FirstOrDefaultAsync();
        }


        public async Task AddAsync(ArtworkFormViewModel model)
        {   
            var entity = new Artwork()
            {
                Id = model.Id,
                Name = model.Name,
                Summary = model.Summary,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                CreatedOn = DateTime.UtcNow,
                YearMade = model.YearMade,
                Height = model.Height,
                Width = model.Width,
                Depth = model.Depth,
                IsFramed = model.IsFramed,
                StyleId = model.StyleId,
                SubjectId = model.SubjectId,
                CreatorId = model.CreatorId,
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ArtworkFormViewModel model)
        {
            var entity = await repository.All().FirstOrDefaultAsync(a => a.Id == model.Id);

            if (entity is null)
            {
                throw new ArgumentException();
            }

            entity.Name = model.Name;
            entity.Summary = model.Summary;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Quantity = model.Quantity;
            entity.YearMade = model.YearMade;
            entity.Height = model.Height;
            entity.Width = model.Width;
            entity.Depth = model.Depth;
            entity.IsFramed = model.IsFramed;
            entity.StyleId = model.StyleId;
            entity.SubjectId = model.SubjectId;

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
