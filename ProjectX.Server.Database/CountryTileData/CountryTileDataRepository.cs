using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.CountryTileData;

public class CountryTileDataRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<CountryTileDataModel>(context, loggerFactory), ICountryTileDataRepository
{
    public async Task<CountryTileDataModel> Create(
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
        var model = CountryTileDataModel.CreateModel(
            country,
            capital,
            xCapitalTileCoordinate,
            yCapitalTileCoordinate,
            zCapitalTileCoordinate,
            rColor,
            gColor,
            bColor,
            aColor
        );

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("CountryTileDataModel is not created");
        }

        return result;
    }
    
    
    public async Task<CountryTileDataModel> Update(CountryTileDataModel model)
    {
         var result = await UpdateModelAsync(model);
         if (result == 0)
         {
             throw new Exception("CountryTileDataModel is not updated");
         }
         return model;
    }


    public async Task<CountryTileDataModel?> FindOneByCountry(string name)
    {
        var model = await DbModel.FirstOrDefaultAsync(x => x.Country == name);
        return model;
    }
}