using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadSenseApi.Database.Entities
{
    [Index(nameof(UserId), nameof(BookId), IsUnique = true)]
    public class ReadingHistory
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public int PTagIndex { get; set; }

        public DateTimeOffset? Inserted { get; set; }
        public DateTimeOffset? LastUpdated { get; set;}

        public User? User { get; init; }
        public Book? Book { get; init; }
    }
}
