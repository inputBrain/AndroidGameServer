using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Client.Auth;
using ProjectX.Server.Client.Codec;
using ProjectX.Server.UseCase;

namespace ProjectX.Server.Host.Controllers.Client;

public class AuthController : AbstractClientController<AuthController>
{
    public AuthController(ILogger<AuthController> logger, IUseCaseContainer useCase) : base(logger, useCase)
    {
    }


    [HttpPost]
    [AllowAnonymous]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(AuthByFirebase.Response), 200)]
    public async Task<IActionResult> LoginByFirebase([FromBody] AuthByFirebase request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest("Auth Error");
        }

        var userModel = await UseCase.UserUseCase.LoginByFirebase(request.FirebaseToken);

        return Ok(new AuthByFirebase.Response(UserCodec.EncodeUser(userModel)));
    }
}