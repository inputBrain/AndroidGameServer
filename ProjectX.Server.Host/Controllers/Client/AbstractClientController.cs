using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.Server.UseCase;

namespace ProjectX.Server.Host.Controllers.Client;

[ApiController]
[Authorize]
[Produces("application/json")]
[Route("api/[action]/[controller]")]
public abstract class AbstractClientController<T> : AbstractBaseController<T>
{
    protected AbstractClientController(ILogger<T> logger, IUseCaseContainer useCase) : base(logger, useCase)
    {
    }
}