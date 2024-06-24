namespace Library.API.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public int AdminId { get; set; }
}
public class UpdateUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public int AdminId { get; set; }
}

