using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public Admin Admin { get; set; }
    public int AdminId { get; set; }
    public List<UserBook> UserBooks { get; set; }

}
