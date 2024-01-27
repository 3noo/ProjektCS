using Microsoft.EntityFrameworkCore;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services
{

    public class BooksService:IBookService
    {
        private AppDbContext _dbContext;
        
        public BooksService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Books>> GetBooksAsync()
        {
            var allBooks = await _dbContext.Books.ToListAsync();
            return allBooks;
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            var bookFromDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return bookFromDb;
        }

        public async Task PostBookAsync(PostBookDto books)
        {
            var newBook = new Books()
            {
                Title = books.Title,
                Author = books.Author,
                Genre = books.Genre
                
            };

            await _dbContext.Books.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Books> UpdateBookAsync(int id, PutBookDto book)
        {
            var booksFromDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(booksFromDb != null)
            {
                booksFromDb.Author = book.Author;
                booksFromDb.Title = book.Title;
                booksFromDb.Genre = book.Genre;

                await _dbContext.SaveChangesAsync();
            }

            return booksFromDb;
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            var bookFromDb = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookFromDb != null)
            {
                _dbContext.Books.Remove(bookFromDb);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}