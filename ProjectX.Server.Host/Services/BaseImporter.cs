using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Utf8Json;
using Utf8Json.Resolvers;

namespace ProjectX.Server.Host.Services;

public class BaseImporter<T>
{
    protected readonly ILogger _logger;
    
    
    public BaseImporter(ILogger logger)
    {
        _logger = logger;
    }

    async protected Task<List<T>> ReadFromFile<T>(string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);
        if (File.Exists(fullPath) == false)
        {
            _logger.LogError($"Importing file does not exist in \"{fullPath}\"");
            return null;
        }

        var bytes = await File.ReadAllBytesAsync(filePath);
        var reader = new JsonReader(bytes);
        
        var fileFormatter = new FileInfoFormatter<T>();
        
        var listData = fileFormatter.DeserializeList(ref reader, StandardResolver.AllowPrivateCamelCase);
        return listData;
    }
}