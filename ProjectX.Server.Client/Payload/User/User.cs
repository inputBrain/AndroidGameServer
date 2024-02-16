namespace ProjectX.Server.Client.Payload.User;

public sealed class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string AvatarUrl { get; set; }
    
    public Resource.Resource Resource { get; set; }
}