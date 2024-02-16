namespace ProjectX.Server.UseCase;

public class UseCaseContainer : IUseCaseContainer
{
    public IUserUseCase UserUseCase { get; }
    
    
    public UseCaseContainer(IUserUseCase userUseCase)
    {
        UserUseCase = userUseCase;
    }
}