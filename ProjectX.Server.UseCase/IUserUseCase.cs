using System.Threading.Tasks;
using ProjectX.Server.Database.User;

namespace ProjectX.Server.UseCase;

public interface IUserUseCase
{
    Task<UserModel?> LoginByFirebase(string token);
}