using StorePay.Infra.Models;

namespace StorePay.Services
{
    public interface ITokenService
    {
        UserToken BuildToken(string email);
    }
}
