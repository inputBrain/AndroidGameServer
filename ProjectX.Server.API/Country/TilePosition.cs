using System.Text.Json.Serialization;

namespace ProjectX.Server.API.Country;

public class TilePosition
{
    [JsonPropertyName("x")]
    public int X { get; set; }
    
    [JsonPropertyName("y")]
    public int Y { get; set; }
    
    [JsonPropertyName("z")]
    public int Z { get; set; }
}