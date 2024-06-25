using Library.Domain;
using Library.Domain.Models;
using Library.Infrustructure.Migrations;
using Microsoft.Identity.Client;

namespace Library.API.Services.Users;
public interface IUserService
{
    
}
public class UserService : IUserService
{
    public void Add (string name,string lastName)
    {
        var user = new User()
        {
            Name = name,
            LastName = lastName
        };
    
    }

}
