using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ReadSenseApi.Database
{
    public class ReadSenseDBContext : DbContext
    {
        public ReadSenseDBContext(DbContextOptions<ReadSenseDBContext> options) : base(options)
        {
        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Device> Devices { get; set; }
        public DbSet<Entities.Environment> Environments { get; set; }
        public DbSet<Entities.ReadSettingsEvent> ReadSettingsEvents { get; set; }
        public DbSet<Entities.Book> Books { get; set; }
        public DbSet<Entities.ReadingHistory> ReadingHistories { get; set; }
        public DbSet<Entities.ScrollingEvent> ScrollingEvents { get; set; }

        // generate seed data for books
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Book>().HasData(
                               new Entities.Book { Id = 1, Title = "The Little Prince", Author = "Antoine de Saint-Exupéry", ContentUrl = "/books/TheLittlePrince.html", ImageUrl = "/images/TheLittlePrince.jpg" }, // The Little Prince by Antoine de Saint-Exupéry
                               new Entities.Book { Id = 2, Title = "The Alchemist", Author = "PAULO COELHO", ContentUrl = "/books/Alchemist.html", ImageUrl = "/images/alchemist.jpg" }, // The Alchemist by PAULO COELHO
                               new Entities.Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ContentUrl = "/books/TheGreatGatsby.html", ImageUrl = "/images/TheGreatGatsBY.jpg" }, // The Great Gatsby by F. Scott Fitzgerald
                               new Entities.Book { Id = 4, Title = "The Catcher in the Rye", Author = "J. D. Salinger", ContentUrl = "/books/TheCatcherInTheRye.html", ImageUrl = "/images/The_Catcher_in_the_Rye.jpg" }, // The Catcher in the Rye by J. D. Salinger
                               new Entities.Book { Id = 5, Title = "Totto-Chan: The Little Girl at the Window", Author = "Tetsuko Kuroyanagi", ContentUrl = "/books/TottoChan.html", ImageUrl = "/images/Totto-Chan.jpg" }, // Totto-Chan: The Little Girl at the Window by Tetsuko Kuroyanagi
                               new Entities.Book { Id = 6, Title = "1948", Author = "George Orwell", ContentUrl = "/books/1984.html", ImageUrl = "/images/1984.jpg" }, //1948 by George Orwell
                               new Entities.Book { Id = 7, Title = "LITTLE WOMEN", Author = "Louisa May Alcott", ContentUrl = "/books/LittleWoman.html", ImageUrl = "/images/LittleWomen.jpg" }, //LITTLE WOMEN by Louisa May Alcott
                               new Entities.Book { Id = 8, Title = "Great Expectations", Author = "Charles Dickens", ContentUrl = "/books/GreatExpectations.html", ImageUrl = "/images/GreatExpectations.jpg" }, //Great Expectations by Charles Dickens
                               new Entities.Book { Id = 9, Title = "Of Mice and Men", Author = "John Steinbeck", ContentUrl = "/books/OfMiceandMen.html", ImageUrl = "/images/OfMiceandMen.jpg" }, //Of Mice and Men by John Steinbeck
                               new Entities.Book { Id = 10, Title = "Interpreter of Maladies", Author = "Jhumpa Lahiri", ContentUrl = "/books/InterpreterofMaladies.html", ImageUrl = "/images/InterpreterofMaladies.jpg" }, //Interpreter of Maladies by Jhumpa Lahiri
                               new Entities.Book { Id = 11, Title = "Robinson Crusoe", Author = "Daniel Defoe", ContentUrl = "/books/RobinsonCrusoe.html", ImageUrl = "/images/RobinsonCrusoe.jpg" }, //Robinson Crusoe by Daniel Defoe
                               new Entities.Book { Id = 12, Title = "Gulliver's Travels", Author = "Jonathan Swift", ContentUrl = "/books/GulivarsTravel.html", ImageUrl = "/images/Gulliverstravel.jpg" } //Gulliver's Travels by Jonathan Swift
                       );
        }

    }
}
