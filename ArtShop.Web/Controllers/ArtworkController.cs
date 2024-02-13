using ArtShop.Services;
using ArtShop.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtShop.Web.Controllers
{
    public class ArtworkController(IArtworkService service)
        : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var model =await service.GetAllAsync();
            return View(model);
        }

        // GET: ArtworkController/Details/5
        [AllowAnonymous]

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtworkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtworkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtworkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtworkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtworkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtworkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
