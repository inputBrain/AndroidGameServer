using System;

namespace ProjectX.Server.Firebase;

public class FirebaseProvider
{
    public FirebaseProviderType FirebaseProviderType { get; set; }

    public string ProviderUid { get; set; }

    
    public FirebaseProvider(FirebaseProviderType firebaseProviderType, string providerUid)
    {
        FirebaseProviderType = firebaseProviderType;
        ProviderUid = providerUid;
    }


    public static FirebaseProvider Create(string provider, string providerUid)
    {
        switch (provider)
        {
            case "google.com":
                return new FirebaseProvider(FirebaseProviderType.Google, providerUid);
        }
        throw new ArgumentException("Error: tried to create provider with providerUid: " + providerUid);
    }
}