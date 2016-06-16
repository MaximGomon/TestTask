using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class UserModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Login is required")]
        [MinLength(5, ErrorMessage = "Login must have more that 5 characters")]
        [MaxLength(50, ErrorMessage = "Login must have less that 50 characters")]
        [Display(Name = "User Login")]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [MaxLength(150, ErrorMessage = "First Name must have less that 150 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(150, ErrorMessage = "Last Name must have less that 150 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(15, ErrorMessage = "Phone must have less that 15 characters")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"(.+)(@)([a-w]+)\.([a-w]+)", ErrorMessage = "Email has wrong format")]
        [MaxLength(100, ErrorMessage = "Email must have less that 100 characters")]
        public string Email { get; set; }
        [MinLength(20, ErrorMessage = "Address must have more that 20 characters")]
        [MaxLength(500, ErrorMessage = "Address must have lest that 500 characters")]
        public string Address { get; set; }
    }
}