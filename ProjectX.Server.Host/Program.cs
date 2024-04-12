using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using ProjectX.Server.Host.ConsoleCommands;

namespace ProjectX.Server.Host;

public class Program
{
    public static async Task Main(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var webHost = BuildWebHost(args);
        var commandLineApplication = new CommandLineApplication(false);

        var catapult = commandLineApplication.Command(
            "command",
            config =>
            {
                config.OnExecute(
                    () =>
                    {
                        config.ShowHelp();
                        return 1;
                    }
                );
                config.HelpOption("-? | -h | --help");
            }
        );
        
        ImportCountries.Register(catapult, webHost);
        
        
        await InitWebServices(webHost);
            
    }
        
    private static async Task<int> InitWebServices(IWebHost webHost)
    {
        await Task.WhenAll(
            webHost.RunAsync()
        );
        await Task.WhenAll(
            webHost.StopAsync()
        );
        Environment.Exit(0);
        return 0;
    }
        
    public static IWebHost BuildWebHost(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}