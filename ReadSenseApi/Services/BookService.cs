using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public class BookService(ReadSenseDBContext context) : IBookService
    {
        public IEnumerable<Database.Entities.Book> GetAll()
        {
            return context.Books.IsNullOrEmpty() ? new List<Database.Entities.Book>() : context.Books;
        }

        public Database.Entities.Book? GetById(int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BookWithReadingHistory> GetAllBooksWithReadingHistoryByUserId(int userId)
        {
            return context.Books.Include(
                        book => book.ReadingHistories.Where(readingHistory => readingHistory.UserId == userId)
                    ).Select(book => BookWithReadingHistory.FromBookAndReadingHistory(book)).AsEnumerable()
                    .OrderByDescending(b => b.LastUpdated);
                    
        }

    }
}
