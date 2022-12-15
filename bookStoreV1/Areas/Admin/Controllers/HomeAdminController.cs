using bookStoreV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookStoreV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        public IActionResult IndexAdmin()
        {
            return View();
        }

        [Route("CreateBook")]
        public IActionResult CreateBook()
        {
            return View();
        }

        [Route("CreateBook")]
        [HttpPost]
        public IActionResult CreateBook(CreateBookViewModel createBook)
        {

            return View();
        }
    }
}
