using System.ComponentModel;

namespace Library.Domain
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; } 
        public List<Book> Books {  get; set; }     
    }
}
