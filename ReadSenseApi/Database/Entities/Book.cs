using System.ComponentModel.DataAnnotations;

namespace ReadSenseApi.Database.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? Author { get; set; }

        [MaxLength(300)]
        public string? ContentUrl { get; set; }

        [MaxLength(300)]
        public string? ImageUrl { get; set; }

        public List<ReadingHistory> ReadingHistories { get; set; } = new List<ReadingHistory>();
    }
}
