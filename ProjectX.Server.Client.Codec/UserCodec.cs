using ProjectX.Server.Client.Payload.User;
using ProjectX.Server.Database.User;

namespace ProjectX.Server.Client.Codec;

public static class UserCodec
{
    public static User EncodeUser(UserModel dbModel)
    {
        return new User
        {
            Id = dbModel.Id,
            FirstName = dbModel.FirstName,
            LastName = dbModel.LastName,
            Phone = dbModel.Phone,
            AvatarUrl = dbModel.AvatarUrl,
            // Resource = ResourceCodec.EncodeResource(dbModel.Resource)
        };
    }
}