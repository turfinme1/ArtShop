using ArtShop.Data.Common.Repositories;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace ArtShop.Services
{
    public class UserService(IRepository<IdentityUser> repository) : IUserService
    {
        public async Task<CreatorViewModel?> GetByIdAsync(int id)
        {   
            throw new NotImplementedException();
        }
    }
}
