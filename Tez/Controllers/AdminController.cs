
using Microsoft.AspNetCore.Mvc;
using Tez.Filter;

namespace Tez.Controllers
{
    [UserFilter]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPost()
        {
            return View();
        }

    }
}
