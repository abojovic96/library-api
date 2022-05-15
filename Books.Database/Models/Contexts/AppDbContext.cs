using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Models.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Fantasy" },
                new Genre() { Id = 2, Name = "Thriller" },
                new Genre() { Id = 3, Name = "Drama" },
                new Genre() { Id = 4, Name = "Horror" },
                new Genre() { Id = 5, Name = "Sci-fi" },
                new Genre() { Id = 6, Name = "Science" },
                new Genre() { Id = 7, Name = "Phylosophy" },
                new Genre() { Id = 8, Name = "Other" }
                );

            builder.Entity<Author>().HasData(
                new Author() { Id = 1, FirstName = "Alber", LastName = "Camus"},
                new Author() { Id = 2, FirstName = "Stephen", LastName = "Hawking"},
                new Author() { Id = 3, FirstName = "J.R.R.", LastName = "Tolkien"}
                );
            base.OnModelCreating(builder);

            builder.Entity<Book>().HasData(
                    new Book()
                    {
                        Id = 1,
                        Title = "Myth of Sisyphus",
                        Price = 19.99,
                        AuthorId = 1,
                        GenreId = 7,
                        Summery = "The Myth of Sisyphus, philosophical essay by Albert Camus, published in French in 1942 as Le " +
                        "Mythe de Sisyphe. Published in the same year as Camus’s novel " +
                        "L’Étranger (The Stranger), The Myth of Sisyphus contains a sympathetic analysis of contemporary nih" +
                        "ilism and touches on the nature of the absurd. Together the two works" +
                        " established his reputation, and they are often seen as thematically complementary.",
                        Cover = "https://m.media-amazon.com/images/I/51SM+Bv+WeL.jpg"
                    },
                    new Book()
                    {
                        Id = 2,
                        Title = "A Brief History of Time",
                        Price = 9.99,
                        AuthorId = 2,
                        GenreId = 6,
                        Summery = "In A Brief History of Time, Hawking writes in non-technical terms about the structure, origin, development and" +
                        " eventual fate of the Universe, which is the object of study of astronomy and modern physics. He talks about basic concepts " +
                        "like space and time, basic building blocks that make up the Universe (such as quarks) and the fundamental forces that govern" +
                        " it (such as gravity). He writes about cosmological phenomena such as the Big Bang and black holes.",
                        Cover = "https://productimages.worldofbooks.com/0593060504.jpg"
                    },
                    new Book()
                    {
                        Id = 3,
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        Price = 14.99,
                        AuthorId = 3,
                        GenreId = 1,
                        Summery = "Set in Middle-earth, the story tells of the Dark Lord Sauron, who seeks the One Ring, which contains part of his soul," +
                        " in order to return to power. The Ring has found its way to the young hobbit Frodo Baggins. The fate of Middle-earth hangs in the" +
                        " balance as Frodo and eight companions (who form the Fellowship of the Ring) begin their journey to Mount Doom in the land of Mordor," +
                        " the only place where the Ring can be destroyed.",
                        Cover = "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif"
                    }
                );
        }
    }
}
