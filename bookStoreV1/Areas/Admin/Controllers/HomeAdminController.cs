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

        #region Main_Page
        public IActionResult IndexAdmin() => View();
        #endregion

        #region Create_Book

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

        #endregion

        #region Show_all_book

        [Route("ShowAllBook")]
        public IActionResult ShowAllBook(int pageId = 1, string bookname = "", string author = "")
        {
            AdminAllBooks allBooks = new AdminAllBooks();
            allBooks = _bookService.GetAllBooks(pageId, bookname, author);
            return View(allBooks);
        }

        #endregion

        #region Delete_And_Edit

        #endregion





    }
}
