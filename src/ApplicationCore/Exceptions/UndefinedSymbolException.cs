namespace ApplicationCore.Exceptions;

public class UndefinedSymbolException : Exception
{
    public UndefinedSymbolException()
    {
    }

    public UndefinedSymbolException(string message)
        : base(message)
    {
    }

    public UndefinedSymbolException(string message, Exception inner)
        : base(message, inner)
    {
    } 
}
