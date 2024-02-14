using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.Artwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtShop.Web.Controllers
{
    public class ArtworkController(IArtworkService service)
        : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var model = await service.GetByIdAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArtworkViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArtworkViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var creatorId = GetUserId();
            model.CreatorId = creatorId!;

            await service.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await service.GetByIdAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ArtworkViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
