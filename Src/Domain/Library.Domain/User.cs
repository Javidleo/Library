using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain;
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }
    public Admin Admin { get; set; }
    public int AdminId { get; set; }
    public List<UserBook> UserBooks { get; set; }
    
}
