using System.Threading.Tasks;

namespace ProjectX.Server.Database.CountryTileData;

public interface ICountryTileDataRepository
{
    Task<CountryTileDataModel> Create(
        string country,
        string capital,
        int xCapitalTileCoordinate,
        int yCapitalTileCoordinate,
        int zCapitalTileCoordinate,
        byte rColor,
        byte gColor,
        byte bColor,
        byte aColor
    );

    Task<CountryTileDataModel> Update(CountryTileDataModel model);

    Task<CountryTileDataModel?> FindOneByCountry(string name);
}