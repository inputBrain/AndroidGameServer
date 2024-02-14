using ProjectX.Server.Database.User;

namespace ProjectX.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
}