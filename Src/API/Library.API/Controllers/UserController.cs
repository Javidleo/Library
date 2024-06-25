using Library.API.Dtos;
using Library.API.ViewModels;
using Library.Domain;
using Library.Infrustructure;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public UserController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = _dbContext.Users
                   .Select(i => new UserVm()
                   {
                       Id = i.Id,
                       Name = i.Name,
                       LastName = i.LastName
                   })
                   .ToList();

        return Ok(users);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var users = _dbContext.Users
                    .Select(i => new UserVm()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        LastName = i.LastName
                    }).FirstOrDefault(i => i.Id == id);
        if (users == null)
            return NotFound("User not found");

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto dto)
    {
        var user = new User()
        {
            Name = dto.Name,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            Address = dto.Address,
            AdminId = dto.AdminId
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
    {
        var user = _dbContext.Users.Where(i => i.Id == dto.Id).FirstOrDefault();
        {
            if (user == null)
                return NotFound("User not found");
        }
        user.Name = dto.Name;
        user.LastName = dto.LastName;
        user.NationalCode = dto.NationalCode;
        user.Address = dto.Address;
        user.AdminId = dto.AdminId;

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    [HttpPatch]
    public async Task<IActionResult> RenameUser(UserRenameDto dto)
    {
        var user = _dbContext.Users.Where(i => i.Id == dto.Id).FirstOrDefault();
        {
            if (user == null)
                return NotFound("User not found");
        }
        user.Name = dto.Name;
        user.LastName = dto.LastName;

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteUser(int Id)
    {
        var user = _dbContext.Users.Where(i => i.Id == Id).FirstOrDefault();
        if (user == null)
        {
            return NotFound("User not found");
        }
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}

