using bookStoreV1.Core.Services;
using bookStoreV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookStoreV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly IBookService _bookService;
        public HomeAdminController( IBookService bookService)
        {
             _bookService = bookService;
        }
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
            bool result = _bookService.CreateBooks(createBook);
            ViewBag.IsCreate = result;
            return View();
        }


        [Route("ShowAllBook")]
        public IActionResult ShowAllBook(int pageId , string bookname , string author )
        {
            AdminAllBooks allBooks = new AdminAllBooks();
            allBooks = _bookService.GetAllBooks(pageId, bookname, author);
            return View(allBooks);
        }

    }
}
