using Microsoft.Build.Framework;
using WebApplication1.DataAccess;

namespace WebApplication1.Models.Dto
{
    public class LoginUser : User
    {
        public string? ReturnUrl { get; set; }
    }
}
