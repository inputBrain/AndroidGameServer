using ProjectX.Server.Client.Payload.Resource;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Client.Codec;

public static class ResourceCodec
{
    public static Resource EncodeResource(ResourceModel dbModel)
    {
        return new Resource()
        {
            Id = dbModel.Id,
            Bronze = dbModel.Bronze,
            Silver = dbModel.Silver,
            Gold = dbModel.Gold,
            DonatCrystal = dbModel.DonatCrystal
        };
    }
}