using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectX.Server.Database.ItemInventory;

namespace ProjectX.Server.Database.User.Inventory;

public class InventoryModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public UserModel User { get; set; }
    
    List<ItemInventoryModel> ItemInventory { get; set; }
}