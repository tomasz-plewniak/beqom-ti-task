using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace ApplicationCore;

public class Environment : IEnvironment
{
    private readonly ILogger<Environment> _logger;
    
    private Dictionary<string, object> symbols = new();

    public Environment(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Environment>();
    }
    
    public object Get(string name)
    {
        if (symbols.TryGetValue(name, out var value))
        {
            return value;
        }

        throw new UndefinedSymbolException($"Undefined symbol: {name}");    
    }

    public void Set(string name, object value)
    {
        symbols[name] = value;
    }
}
