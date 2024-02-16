using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Server.Database.User.Resource;

public class ResourceModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public UserModel User { get; set; }
    
    public int Bronze { get; set; }
    
    public int Silver { get; set; }
    
    public int Gold { get; set; }
    
    public int DonatCrystal { get; set; }


    public static ResourceModel CreateEmpty()
    {
        return new ResourceModel()
        {
            Bronze = 100,
            Silver = 0,
            Gold = 0,
            DonatCrystal = 500
        };
    }
}