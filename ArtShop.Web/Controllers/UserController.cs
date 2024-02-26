using ArtShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtShop.Web.Controllers
{
    public class UserController(IUserService userService) 
        : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(int id)
        {
            var model = await userService.GetByIdAsync(id);
            return View(model);
        }
    }
}
