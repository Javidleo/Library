using Library.API.Dtos;
using Library.API.ViewModels;
using Library.Domain.Models;
using Library.Infrustructure;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserBookController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public UserBookController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserBook(UserBookDto dto)
    {
        var userbook = new UserBook()
        {
            Id = dto.Id,
            UserId = dto.UserId,
            BookId = dto.BookId
        };
        _dbContext.UserBooks.Add(userbook);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserBook(UpdateUserBookDto dto)
    {
        var userbook = _dbContext.UserBooks.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (userbook == null)
            return NotFound("UserBook not found");

        userbook.Id = dto.Id;
        userbook.UserId = dto.UserId;
        userbook.BookId = dto.BookId;

        _dbContext.UserBooks.Update(userbook);
        await _dbContext.SaveChangesAsync();

        return NoContent();

    }
    [HttpPatch]
    public async Task<IActionResult> ChangingUserBook(ChangeUserBookDto dto)
    {
        var userbook = _dbContext.UserBooks.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (userbook == null)
            return NotFound("UserBook not found");

        userbook.Id = dto.Id;
        userbook.UserId = dto.UserId;

        _dbContext.UserBooks.Update(userbook);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteUserBook(int Id)
    {
        var userbook = _dbContext.UserBooks.Where(i => i.Id == Id).FirstOrDefault();
        if (userbook == null)
            return NotFound("UserBook not found");

        _dbContext.UserBooks.Remove(userbook);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
