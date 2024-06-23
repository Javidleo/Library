using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Admin Admin { get; set; }
    public int AdminId {  get; set; }      
    public List<UserBook> UserBooks { get; set; }
}
