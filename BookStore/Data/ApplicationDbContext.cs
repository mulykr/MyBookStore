using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class BookDbContext : DbContext
    {
        public BookDbContext()
        {

        }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> BookAuthors { get; set; }
        public DbSet<BookAuthors> BookAuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<BookAuthors>().HasKey(bab => new {bab.BookId, bab.BookAuthorId});

            modelBuilder.Entity<BookAuthors>()
                .HasOne<Book>(sc => sc.Book)
                .WithMany(s => s.BookAuthors)
                .HasForeignKey(sc => sc.BookAuthorId);


            modelBuilder.Entity<BookAuthors>()
                .HasOne<Author>(sc => sc.Author)
                .WithMany(s => s.BookAuthors)
                .HasForeignKey(sc => sc.BookId);
        }
        
    }
}
