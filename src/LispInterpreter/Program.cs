using ApplicationCore;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Environment = ApplicationCore.Environment;


var serviceProvider = new ServiceCollection()
    .AddLogging(builder => builder.AddConsole())
    .AddSingleton<IEnvironment, Environment>()
    .AddTransient<IInterpreterService, InterpreterService>()
    .AddTransient<IInterpreterRunner, InterpreterRunner>()
    .BuildServiceProvider();

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();

logger.LogInformation("Starting application");

var interpreter = serviceProvider.GetService<IInterpreterRunner>()!;

var input = "(* 4 5)";
object result = interpreter.Run(input);

Console.WriteLine($"Result: {result}");

var define = "(define a 10)";
var defTestInput = "(+ a 5)";

interpreter.Run(define);
object defTestResult = interpreter.Run(defTestInput);

Console.WriteLine($"Result: {defTestResult}");

logger.LogInformation("End");