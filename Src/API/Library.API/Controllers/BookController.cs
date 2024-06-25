using Library.API.Dtos;
using Library.API.ViewModels;
using Library.Domain.Models;
using Library.Infrustructure;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public BookController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = _dbContext.Books
                    .Select(i => new BookVm()
                    {
                        Id = i.Id,
                        Title = i.Title
                    })
                    .ToList();

        return Ok(books);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var books = _dbContext.Books
                    .Select(i => new BookVm()
                    {
                        Id = i.Id,
                        Title = i.Title
                    }).FirstOrDefault(i => i.Id == id);
        if (books == null)
            return NotFound("Book not found");

        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(BookDto dto)
    {
        var book = new Book()
        {
            Title = dto.Title,
            Publisher = dto.Publisher,
            Price = dto.Price
        };
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookDto dto)
    {
        var book = _dbContext.Books.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (book == null)
            return NotFound("Book not found");

        book.Title = dto.Title;
        book.Publisher = dto.Publisher;
        book.Price = dto.Price;

        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();

        return NoContent();

    }

    [HttpPatch]
    public async Task<IActionResult> RenameBook(RenameBook dto)
    {
        var book = _dbContext.Books.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (book == null)
            return NotFound("Book not found");

        book.Title = dto.Title;

        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBook(int Id)
    {
        var book = _dbContext.Books.Where(i => i.Id == Id).FirstOrDefault();
        if (book == null)
            return NotFound("Book not found");

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
