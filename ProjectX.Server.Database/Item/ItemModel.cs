using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Server.Database.Item;

public class ItemModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public ItemGrade ItemGrade { get; set; }
}