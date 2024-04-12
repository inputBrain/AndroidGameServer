using Microsoft.Extensions.Logging;
using ProjectX.Server.Database;

namespace ProjectX.Server.Host.Services.Importers;

public static class Factory
{
    public static Country CreateCountry(PostgreSqlContext context, ILogger<Country> logger)
    {
        return new Country(logger, context.Db.CountryTileDataRepository);
    }
}