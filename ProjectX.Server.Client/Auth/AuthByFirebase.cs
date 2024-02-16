using System.ComponentModel.DataAnnotations;

namespace ProjectX.Server.Client.Auth;

public sealed class AuthByFirebase
{
    [Required]
    public string FirebaseToken { get; set; }


    public sealed class Response : AbstractResponse
    {
        public Payload.User.User User { get; }


        public Response(Payload.User.User user)
        {
            User = user;
        }
    }
}