using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    public List<UserBook> UserBooks { get; set; }
}
