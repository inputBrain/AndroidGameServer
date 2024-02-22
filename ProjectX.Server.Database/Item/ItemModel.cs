using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectX.Server.Database.ItemInventory;

namespace ProjectX.Server.Database.Item;

public class ItemModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public ItemGrade ItemGrade { get; set; }
    
    public List<ItemInventoryModel> ItemInventory { get; set; }
}