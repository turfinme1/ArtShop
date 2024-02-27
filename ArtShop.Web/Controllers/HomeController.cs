using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Sockets;
using ArtShop.Services.Contracts;
using ArtShop.Web.ViewModels;
using MongoDB.Bson;

namespace ArtShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArtworkImageStoreService _imageService;

        public HomeController(ILogger<HomeController> logger, IArtworkImageStoreService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddImage(IEnumerable<IFormFile> files)
        {
            foreach (var file in files.Where(f => f.Length > 0))
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    var id = await _imageService.UploadAsync(fileBytes);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
