using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}