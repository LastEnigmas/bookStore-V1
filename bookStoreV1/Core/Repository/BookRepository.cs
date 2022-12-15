using bookStoreV1.Core.Services;
using bookStoreV1.DbContextFolder;
using bookStoreV1.Models;
using bookStoreV1.ViewModels;

namespace bookStoreV1.Core.Repository
{
    public class BookRepository : IBookService
    {
        private readonly MyDbContext _db;
        public BookRepository( MyDbContext db)
        {
            _db = db;
        }
        public bool CreateBooks(CreateBookViewModel book)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                IsExist = book.IsExist,
                IsDiscount = false,
                PubTitle = book.PubTitle,
                BookImage = book.BookImageTitle,
            };
            return true;
        }
    }
}
