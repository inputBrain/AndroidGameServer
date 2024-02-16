using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User;
using ProjectX.Server.Firebase;
using ProjectX.Server.Model.SocialIdentity;

namespace ProjectX.Server.UseCase;

public class UserUseCase(
    ILogger<UserUseCase> logger,
    IUserRepository userRepository,
    ISocialIdentityRepository socialIdentityRepository,
    FirebaseService firebaseService
) : IUserUseCase
{

    public async Task<UserModel?> LoginByFirebase(string token)
    {
        var socialUser = await firebaseService.GetUserInfo(token);
        if (socialUser == null)
        {
            throw new Exception("Invalid firebase token");
        }

        var user = await userRepository.FindByUid(socialUser.Uid);
        if (user == null)
        {
            user = await userRepository.CreateModel(socialUser.FirstName, socialUser.LastName, socialUser.Phone, socialUser.AvatarUrl, DateTime.Now);
            await socialIdentityRepository.Create(user.Id, socialUser.Uid, SocialType.Google, DateTime.Now);
        }

        return user;
    }
}