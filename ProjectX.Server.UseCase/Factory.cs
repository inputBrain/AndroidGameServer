using Microsoft.Extensions.Logging;
using ProjectX.Server.Database;
using ProjectX.Server.Firebase;

namespace ProjectX.Server.UseCase;

public static class Factory
{
    public static IUseCaseContainer Create(ILoggerFactory loggerFactory, IDatabaseContainer databaseContainer, FirebaseService firebaseService)
    {
        return new UseCaseContainer(
            new UserUseCase(
                loggerFactory.CreateLogger<UserUseCase>(),
                databaseContainer.UserRepository,
                databaseContainer.SocialIdentityRepository,
                firebaseService
            )
        );
    }
}