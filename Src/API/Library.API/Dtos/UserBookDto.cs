namespace Library.API.Dtos;

public class UserBookDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
}
public class UpdateUserBookDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
}
public class ChangeUserBookDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
}
