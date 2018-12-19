using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public ICollection<BookAuthors> BookAuthors { get; set; }
        public ICollection<BookRating> BookRatings { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string ImagePath { get; set; }
        public ICollection<BookAuthors> BookAuthors { get; set; }
    }

    public class BookRating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public Book Book { get; set; }
        public string UserId { get; set; }
    }

    public class BookAuthors
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BookAuthorId { get; set; }
        public Author Author { get; set; }
    }
}
