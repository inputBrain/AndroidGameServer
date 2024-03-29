using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User.Inventory;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database.User;

public class UserModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? AvatarUrl { get; set; }

    public ResourceModel Resource { get; set; }

    public SocialIdentityModel SocialIdentity { get; set; }
    
    public InventoryModel Inventory { get; set; }

    public DateTime CreatedAt { get; set; }


    public static UserModel CreateModel(string? firstName, string? lastName, string? phone, string? avatarUrl, DateTime createdAt)
    {
        return new UserModel()
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            AvatarUrl = avatarUrl,
            Resource = ResourceModel.CreateEmpty(),
            SocialIdentity = new SocialIdentityModel(),
            Inventory = new InventoryModel(),
            CreatedAt = createdAt,
        };
    }
}