using ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Environment = ApplicationCore.Environment;


var serviceProvider = new ServiceCollection()
    .AddLogging(builder => builder.AddConsole())
    .AddSingleton<IEnvironment, Environment>()
    .BuildServiceProvider();

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();

logger.LogInformation("Starting application");

var environment = serviceProvider.GetService<IEnvironment>();

environment.Set("test", "hehe");

var result = environment.Get("test");

logger.LogInformation("End");