using Core.Dtos;
using SharedLibrary.Dtos;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateToken(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Task<Response<ClientTokenDto>> CreateClientToken(ClientLoginDto clientLoginDto);
    }
}
