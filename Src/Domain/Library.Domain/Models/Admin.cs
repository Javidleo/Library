using System.ComponentModel;

namespace Library.Domain
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }
        public List<User> Users { get; set; }
    }
    

}
