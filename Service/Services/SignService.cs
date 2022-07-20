using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Service.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmectricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
