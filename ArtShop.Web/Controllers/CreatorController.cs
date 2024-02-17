using ArtShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtShop.Web.Controllers
{
    public class CreatorController(ICreatorService creatorService) 
        : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(int id)
        {
            var model = await creatorService.GetByIdAsync(id);
            return View(model);
        }
    }
}
