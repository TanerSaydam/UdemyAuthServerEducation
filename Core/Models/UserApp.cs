using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Models
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
