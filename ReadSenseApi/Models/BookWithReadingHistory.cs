using ReadSenseApi.Database.Entities;

namespace ReadSenseApi.Models
{
    public class BookWithReadingHistory
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? ContentUrl { get; set; }

        public string? ImageUrl { get; set; }
        
        public int? PTagIndex { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public static BookWithReadingHistory FromBookAndReadingHistory(Book book)
        {
            return new BookWithReadingHistory
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ContentUrl = book.ContentUrl,
                ImageUrl = book.ImageUrl,
                PTagIndex = book.ReadingHistories.FirstOrDefault()?.PTagIndex,
                LastUpdated = book.ReadingHistories.FirstOrDefault()?.LastUpdated
            };
        }
    }
}
