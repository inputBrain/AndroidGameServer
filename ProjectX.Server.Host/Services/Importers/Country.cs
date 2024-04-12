using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectX.Server.API.Country;
using ProjectX.Server.Database.CountryTileData;

namespace ProjectX.Server.Host.Services.Importers;

public class Country : BaseImporter<CountryTileDataModel>
{
    private readonly ICountryTileDataRepository _countryTileDataRepository;
    
    public Country(ILogger logger, ICountryTileDataRepository countryTileDataRepository) : base(logger)
    {
        _countryTileDataRepository = countryTileDataRepository;
    }


    public async Task ImportCountries(string filePath)
    {
        var countriesList = await ReadFromFile<CountryData>(filePath);

        if (countriesList.Count == 0)
        {
            _logger.LogError($"Count of data in imported file is equal 0");
            return;
        }

        foreach (var data in countriesList)
        {
            await _processCountryJson(data);
        }
    }


    private async Task<CountryTileDataModel> _processCountryJson(CountryData data)
    {
        var dbModel = await _countryTileDataRepository.FindOneByCountry(data.Country);
        if (dbModel != null)
        {
            _logger.LogWarning($"Country: {data.Country} was skipped. Country is already exist");
            return null;
        }
        
        var model = await _countryTileDataRepository.Create(
            data.Country,
            data.Capital,
            data.TilePosition.X,
            data.TilePosition.Y,
            data.TilePosition.Z,
            data.CountryColor.R,
            data.CountryColor.G,
            data.CountryColor.B,
            data.CountryColor.A
        );

        
        _logger.LogWarning($"Country: {model.Country} has been created");

        return model;
    }
}