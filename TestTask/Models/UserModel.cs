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
        [Display(Name = "User Login")]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"(.+)(@)([a-w]+)\.([a-w]+)", ErrorMessage = "Email has wrong format")]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}