using System.Text.Json.Serialization;

namespace ProjectX.Server.API.Country;

public class CountryColor
{
    [JsonPropertyName("R")]
    public byte R { get; set; }
    
    [JsonPropertyName("G")]
    public byte G { get; set; }
    
    [JsonPropertyName("B")]
    public byte B { get; set; }
    
    [JsonPropertyName("A")]
    public byte A { get; set; }
}