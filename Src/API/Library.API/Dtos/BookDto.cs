namespace Library.API.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
}
public class UpdateBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
}
public class RenameBook
{
    public int Id { get; set; }
    public string Title { get; set; }

}