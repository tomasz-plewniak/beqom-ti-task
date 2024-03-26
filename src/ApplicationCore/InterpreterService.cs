using ApplicationCore.Interfaces;

namespace ApplicationCore;

public class InterpreterService(IEnvironment environment) : IInterpreterService
{
    public object Atom(string token)
    {
        if (double.TryParse(token, out var result))
        {
            return result;
        }
        return token;    }

    public object Eval(object ast)
    {
        if (ast is string symbol)
        {
            return environment.Get(symbol);
        }
        else if (ast is List<object> expr)
        {
            if (expr.Count == 0)
            {
                // An empty list evaluates to null.
                return null;
            }

            var op = expr[0] as string; // The operator (or function name) is the first element.

            if (op == "define")
            {
                // Special handling for 'define'.
                var varName = expr[1] as string;
                var value = Eval(expr[2]);
                environment.Set(varName, value);
                return value;
            }
            else
            {
                // For other operators, evaluate the arguments and then apply the operator.
                var args = new List<object>();
                for (int i = 1; i < expr.Count; i++)
                {
                    args.Add(Eval(expr[i]));
                }

                // Apply the operation to the evaluated arguments.
                return Apply(op, args);
            }
        }
        else
        {
            // It's not a list or a symbol, so it must be a constant.
            return ast;
        }
    }


    public object Parse(List<string> tokens)
    {
        if (tokens.Count == 0)
        {
            throw new Exception("Unexpected EOF");
        }

        var token = tokens[0];
        tokens.RemoveAt(0);

        if (token == "(")
        {
            var L = new List<object>();
            while (tokens[0] != ")")
            {
                L.Add(Parse(tokens));
            }
            tokens.RemoveAt(0); // Remove ")"
            return L;
        }
        else if (token == ")")
        {
            throw new Exception("Unexpected )");
        }
        else
        {
            return Atom(token);
        }    }

    public List<string> Tokenize(string input)
    {
        return new List<string>(input.Replace("(", " ( ").Replace(")", " ) ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public object RunInterpreter(string input)
    {
        var tokens = Tokenize(input);
        var ast = Parse(tokens);
        var evaluationResult = Eval(ast);

        return evaluationResult;
    }

    private object Apply(string op, List<object> args)
    {
        // Handle the arithmetic operations
        switch (op)
        {
            case "+":
                return (double)args[0] + (double)args[1];
            case "-":
                return (double)args[0] - (double)args[1];
            case "*":
                return (double)args[0] * (double)args[1];
            case "/":
                return (double)args[0] / (double)args[1];
            default:
                throw new Exception($"Unknown operator: {op}");
        }
    }
}