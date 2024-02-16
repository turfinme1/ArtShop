using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels.Artwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtShop.Web.Controllers
{
    public class ArtworkController(
        IArtworkService artworkService,
        IStyleService styleService,
        ISubjectService subjectService)
        : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var model = await artworkService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var model = await artworkService.GetByIdAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new ArtworkFormViewModel();
            model.Styles = await styleService.GetAllAsync();
            model.Subjects = await subjectService.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArtworkFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Styles = await styleService.GetAllAsync();
                model.Subjects = await subjectService.GetAllAsync();
                return View(model);
            }

            var creatorId = GetUserId();
            model.CreatorId = creatorId!;

            await artworkService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await artworkService.GetByIdAsFormViewModelAsync(id);

            if (model is null)
            {
                return NotFound();
            }

            model.Styles = await styleService.GetAllAsync();
            model.Subjects = await subjectService.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ArtworkFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Styles = await styleService.GetAllAsync();
                model.Subjects = await subjectService.GetAllAsync();
                return View(model);
            }

            await artworkService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await artworkService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
