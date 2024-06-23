using Library.Domain;

namespace Library.API.Dtos;

public class UserDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
}
