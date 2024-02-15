using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
    public IResourceRepository ResourceRepository { get; }
}