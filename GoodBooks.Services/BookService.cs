using System;
using System.Collections.Generic;
using System.Linq;
using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext _db;
        public BookService(GoodBooksDbContext db)
        {
            _db = db;
        }

        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var bookToDeleted = _db.Books.Find(bookId);
            if (bookToDeleted != null)
            {
                _db.Remove(bookToDeleted);
            }

            throw new InvalidOperationException("Can't delete book that dosen't exist");
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return _db.Books.Find(bookId);
        }
    }
}
