using ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace ApplicationCore;

public class InterpreterRunner(IInterpreterService interpreterService) : IInterpreterRunner
{
    public object Run(string input)
    {
        var tokens = interpreterService.Tokenize(input);
        var ast = interpreterService.Parse(tokens);
        var evaluationResult = interpreterService.Eval(ast);

        return evaluationResult;
    }
}