using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public interface IBookService
    {
        IEnumerable<Database.Entities.Book> GetAll();
        Database.Entities.Book? GetById(int id);
        IEnumerable<BookWithReadingHistory> GetAllBooksWithReadingHistoryByUserId(int userId);
    }
}
