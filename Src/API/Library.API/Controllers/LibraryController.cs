using Library.API.Dtos;
using Library.Domain;
using Library.Infrustructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public LibraryController (LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
    {
        if (_dbContext.Admins == null)
        {
            return NotFound();
        }
        return await _dbContext.Admins.ToListAsync();
    }

    [HttpGet("{Admin}")]
    public async Task<ActionResult<Admin>> GetAdmin(int Id, ActionResult<Admin> admin)
    {
        if (_dbContext.Admins == null)
        {
            return NotFound();
        }

        var Admin= await _dbContext.Admins.FindAsync(Id);
        if (Admin == null)
        {
            return NotFound();
        }

        return admin;
    }

    [HttpPost("Admin")]
    public async Task<ActionResult<AdminDto>> CreateAdminDto(AdminDto adminDto)
    {
        var admin = new Admin()
        {
            Name = adminDto.Name,
            LastName = adminDto.LastName,
            UserName = adminDto.UserName,
            Password = adminDto.Password,
            NationalCode = adminDto.NationalCode
        };
        _dbContext.Admins.Add(admin);
        await _dbContext.SaveChangesAsync();
        
        return NoContent(); 
    }
    [HttpPost("{User}")]
    public async Task<ActionResult<UserDto>> CreateUserDto(UserDto userDto)
    {
        var user = new User()
        {
            Name = userDto.Name,
            LastName = userDto.LastName,
            NationalCode = userDto.NationalCode,
            Address = userDto.Address
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
        

}
 