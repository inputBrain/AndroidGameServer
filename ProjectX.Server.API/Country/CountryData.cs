using System.Text.Json.Serialization;

namespace ProjectX.Server.API.Country;

public class CountryData
{
    [JsonPropertyName("country")]
    public string Country { get; set; }
    
    [JsonPropertyName("capital")]
    public string Capital { get; set; }

    [JsonPropertyName("color")]
    public CountryColor CountryColor { get; set; }

    [JsonPropertyName("capitalTilePosition")]
    public TilePosition TilePosition { get; set; }
}