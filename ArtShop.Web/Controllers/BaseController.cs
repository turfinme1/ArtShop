using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtShop.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
