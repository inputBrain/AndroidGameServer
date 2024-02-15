namespace ProjectX.Server.Model.SocialIdentity;

public interface ISocialIdentity
{
    int Id { get; }
    
    string Uid { get; }
    
    SocialType SocialType { get; }
}