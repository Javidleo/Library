namespace Library.Domain;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }

    /// <summary>
    /// Expiration Holds the Date Value for when User Registration will get expired.
    /// </summary>
    public DateTime Expiration { get; set; }
}
