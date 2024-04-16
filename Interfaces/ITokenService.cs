using fiap_jwt_api.Model;

namespace fiap_jwt_api.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(Users users);
    }
}
