namespace ApplicationCore.Interfaces;

public interface IInterpreterService
{
    object Atom(string token);

    object Eval(object ast);
    
    object Parse(List<string> tokens);
    
    List<string> Tokenize(string input);

    object RunInterpreter(string input);
}