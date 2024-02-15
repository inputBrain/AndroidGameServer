namespace ProjectX.Server.Firebase;

public class FirebaseUser
{
    public string Uid { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string AvatarUrl { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public FirebaseProvider FirebaseProvider { get; set; }


    public FirebaseUser(
        FirebaseProvider firebaseProvider,
        string uid,
        string firstName,
        string lastName,
        string? email,
        string? phone,
        string? avatarUrl
    )
    {
        Uid = uid;
        Email = email;
        Phone = phone;
        AvatarUrl = avatarUrl;
        FirstName = firstName;
        LastName = lastName;
        FirebaseProvider = firebaseProvider;
    }
}