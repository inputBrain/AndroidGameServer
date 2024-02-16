using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.Server.UseCase;

namespace ProjectX.Server.Host.Controllers;

[ApiController]
public abstract class AbstractBaseController<T> : ControllerBase
{
    protected readonly ILogger<T> Logger;

    protected readonly IUseCaseContainer UseCase;
    
    
    protected AbstractBaseController(ILogger<T> logger, IUseCaseContainer useCase)
    {
        Logger = logger;
        UseCase = useCase;
    }
}