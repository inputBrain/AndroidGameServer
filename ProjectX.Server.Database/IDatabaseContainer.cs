using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
    IResourceRepository ResourceRepository { get; }
    
    ISocialIdentityRepository SocialIdentityRepository { get; }
    
}