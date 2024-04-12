using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Server.Database.CountryTileData;

public class CountryTileDataModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Capital { get; set; }

    [Required]
    public int XCapitalTileCoordinate { get; set; }

    [Required]
    public int YCapitalTileCoordinate { get; set; }

    [Required]
    public int ZCapitalTileCoordinate { get; set; }

    [Required]
    public byte RColor { get; set; }

    [Required]
    public byte GColor { get; set; }

    [Required]
    public byte BColor { get; set; }

    [Required]
    public byte AColor { get; set; }


    public static CountryTileDataModel CreateModel(
        string country,
        string capital,
        int xCapitalTileCoordinate,
        int yCapitalTileCoordinate,
        int zCapitalTileCoordinate,
        byte rColor,
        byte gColor,
        byte bColor,
        byte aColor
    )
    {
        return new CountryTileDataModel()
        {
            Country = country,
            Capital = capital,
            XCapitalTileCoordinate = xCapitalTileCoordinate,
            YCapitalTileCoordinate = yCapitalTileCoordinate,
            ZCapitalTileCoordinate = zCapitalTileCoordinate,
            RColor = rColor,
            GColor = gColor,
            BColor = bColor,
            AColor = aColor
        };
    }
}