using ArtShop.Data.Common.Repositories;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace ArtShop.Services
{
    public class CreatorService(IRepository<IdentityUser> repository) : ICreatorService
    {
        public async Task<CreatorViewModel?> GetByIdAsync(int id)
        {   
            throw new NotImplementedException();
        }
    }
}
