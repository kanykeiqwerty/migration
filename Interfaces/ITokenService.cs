


using MigrationApi.Models;

namespace MigrationApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}