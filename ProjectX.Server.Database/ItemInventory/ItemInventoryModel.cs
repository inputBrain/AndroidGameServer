using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectX.Server.Database.Item;
using ProjectX.Server.Database.User.Inventory;

namespace ProjectX.Server.Database.ItemInventory;

public class ItemInventoryModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int ItemId { get; set; }
    
    [ForeignKey("ItemId")]
    public ItemModel ItemModel { get; set; }

    public int InventoryId { get; set; }

    [ForeignKey("InventoryId")]
    public InventoryModel Inventory { get; set; }
    
    public int Amount { get; set; }
}