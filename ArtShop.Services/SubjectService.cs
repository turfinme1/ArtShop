using ArtShop.Data.Common.Repositories;
using ArtShop.Data.Models;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.Subject;
using Microsoft.EntityFrameworkCore;

namespace ArtShop.Services
{
    public class SubjectService(IRepository<Subject> repository)
        : ISubjectService
    {
        public async Task<IEnumerable<SubjectViewModel>> GetAllAsync()
        {
            return await repository
                .All()
                .Select(s => new SubjectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();
        }

        public async Task<SubjectViewModel?> GetByIdAsync(int id)
        {
            return await repository
                .All()
                .Where(s => s.Id == id)
                .Select(s => new SubjectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .FirstOrDefaultAsync();
        }
    }
}
