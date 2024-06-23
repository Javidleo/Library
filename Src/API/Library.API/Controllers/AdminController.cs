using Library.API.Dtos;
using Library.Domain;
using Library.Infrustructure;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public AdminController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var admins = _dbContext.Admins.ToList();

        return Ok(admins);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var admin = _dbContext.Admins.FirstOrDefault(i => i.Id == id);
        if (admin is null)
            return NotFound();

        return Ok(admin);
    }


    [HttpPost]
    public async Task<IActionResult> CreateAdmin(AdminDto dto)
    {
        var admin = new Admin()
        {
            Name = dto.Name,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            UserName = dto.UserName,
            Password = dto.Password
        };

        _dbContext.Admins.Add(admin);
        await _dbContext.SaveChangesAsync();

        // no content is for post, delete, put or patch request(based on scenario) 
        // the main reason we are using NoContent is because this api doesn't have anything to return.
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> ReplaceAdmin(UpdateAdminDto dto)
    {
        var admin = _dbContext.Admins.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (admin == null)
            return NotFound("no admin found");

        admin.Name = dto.Name;
        admin.LastName = dto.LastName;
        admin.NationalCode = dto.NationalCode;
        admin.UserName = dto.UserName;
        admin.Password = dto.Password;

        _dbContext.Admins.Update(admin);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch]
    public async Task<IActionResult> RenameAdmin(AdminRenameDto dto)
    {
        var admin = _dbContext.Admins.Where(i => i.Id == dto.Id).FirstOrDefault();
        if (admin == null)
            return NotFound("no admin found");

        admin.Name = dto.FirstName;
        admin.LastName = dto.LastName;

        _dbContext.Admins.Update(admin);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var admin = _dbContext.Admins.Where(i => i.Id == id).FirstOrDefault();
        if (admin == null)
            return NotFound("no admin found");

        _dbContext.Admins.Remove(admin);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
