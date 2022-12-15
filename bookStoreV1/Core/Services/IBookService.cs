using bookStoreV1.ViewModels;

namespace bookStoreV1.Core.Services
{
    public interface IBookService
    {
        bool CreateBooks(CreateBookViewModel book);
    }
}
