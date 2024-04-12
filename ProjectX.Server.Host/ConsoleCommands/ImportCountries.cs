using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Database;
using ProjectX.Server.Host.Services.Importers;

namespace ProjectX.Server.Host.ConsoleCommands;

internal sealed class ImportCountries
{
    private const string CommandName = "ImportCountries";

    private readonly IWebHost _host;

    private readonly string _filePath;
    
    
    private ImportCountries(IWebHost host, string filePath)
    {
        _host = host;
        _filePath = filePath;
    }

    private int Execute()
    {
        Console.WriteLine($"Import countries from path: {_filePath}");

        var serviceScopeFactory = (IServiceScopeFactory) _host.Services.GetService(typeof(IServiceScopeFactory))!;
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var services = scope.ServiceProvider;
            if (File.Exists(_filePath) == false)
            {
                Console.WriteLine($"Importing file does not exist in \"{Path.GetFullPath(_filePath)} {_filePath}\"");
                return 1;
            }

            using (var context = services.GetRequiredService<PostgreSqlContext>())
            {
                var importer = Factory.CreateCountry(context, scope.ServiceProvider.GetRequiredService<ILogger<Country>>());
                importer.ImportCountries(_filePath).Wait();
            }
        }
        return 0;
    }


    public static void Register(CommandLineApplication app, IWebHost host)
    {
        app.Command(
            CommandName,
            c =>
            {
                c.Description = "Importing countries data from json file by filePath";
                c.HelpOption("-?|-h|--help");
                var filePathArg = c.Argument("filePath", "file with data to import");

                c.OnExecute(
                    () =>
                    {
                        if (filePathArg.Value != null)
                        {
                            var command = new ImportCountries(host, filePathArg.Value);
                            return command.Execute();
                        }
                        c.ShowHelp();
                        return 1;
                    }
                );
            }
        );
    }
}