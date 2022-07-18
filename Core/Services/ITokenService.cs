using Core.Configuration;
using Core.Dtos;
using Core.Models;

namespace Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp user);
        ClientTokenDto CreateClientToken(Client client);
    }
}
