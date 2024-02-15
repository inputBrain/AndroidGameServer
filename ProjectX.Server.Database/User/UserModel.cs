using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectX.Server.Database.SocialIdentity;
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
    
    public DateTime CreatedAt { get; set; }
}