using bookStoreV1.Core.Creator;
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
                Discount = 0,
                BookImage = "",
                MyBookId = CreateMyBookId.CreateId(),
                Price = book.Price,
            };



            if(book.BookImageFile != null)
            {
                string path = "";
                string newImageName = NameGenerator.GenerateUniqCode();
                newBook.BookImage = newImageName; 
                book.BookImageTitle = newImageName + ".jpg";
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", book.BookImageTitle);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    book.BookImageFile.CopyTo(stream);
                    newBook.BookImage = book.BookImageTitle;
                }
            }

            _db.Books.Add(newBook);
            Save();
            bool result = IsBookCreate(newBook.MyBookId);
            return result ;
        }

        public AdminAllBooks GetAllBooks(int pageId, string bookName, string author)
        {
            IQueryable<Book> result = _db.Books;

            if (!string.IsNullOrEmpty(bookName))
            {
                result = result.Where(u => u.Title == bookName);
            }
            if (!string.IsNullOrEmpty(author))
            {
                result = result.Where(u => u.Author == author);
            }

            int take = 15; 
            int skip = (pageId - 1 )* take;

            AdminAllBooks allBokks = new AdminAllBooks();
            allBokks.CurrentPage = pageId;
            allBokks.Books = result.OrderBy(u => u.Created).Skip(skip).Take(take).ToList();

            return allBokks;
        }

        public bool IsBookCreate(int myBookId)
        {
            return _db.Books.Any(x => x.MyBookId == myBookId);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
