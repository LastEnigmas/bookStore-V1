using bookStoreV1.ViewModels;

namespace bookStoreV1.Core.Services
{
    public interface IBookService
    {
        bool CreateBooks(CreateBookViewModel book);
        bool IsBookCreate(int myBookId);
        AdminAllBooks GetAllBooks(int pageId , string bookName , string author );
        void Save();
    }
}
