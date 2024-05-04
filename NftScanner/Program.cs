using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NftScanner;
using NftScanner.Wrapper;

//Configure application
var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

//Configure dependency injection
var serviceProvider = new ServiceCollection()
  .AddSingleton<AppSettings>()
  .AddScoped<IBlockFrost, BlockFrost>()
  .AddScoped<IIPFSGateway, IPFSGateway>()
  .AddScoped<Process>()
  .AddHttpClient()
  .BuildServiceProvider();

//Load application setting
var setting = serviceProvider.GetService<AppSettings>();
if (setting != null && config != null)
{
  setting.BlockFrostApiKey = config.GetValue<string>("BlockFrost:apiKey") ?? string.Empty;
  setting.BlockFrostBaseUrl = config.GetValue<string>("BlockFrost:BaseUrl") ?? string.Empty;
  setting.IPFSBaseUrl = config.GetValue<string>("IPFS:BaseUrl") ?? string.Empty;
}

//Execute main process
Console.WriteLine("Application start!");
Process? process = serviceProvider.GetService<Process>();
if (process == default) return;
await process.Run(args);
Console.WriteLine("Application end!");
