using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
