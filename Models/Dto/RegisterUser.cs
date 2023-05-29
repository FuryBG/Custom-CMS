using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Dto
{
    public class RegisterUser : LoginUser
    {
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string RepeatPassword { get; set; }
    }
}
