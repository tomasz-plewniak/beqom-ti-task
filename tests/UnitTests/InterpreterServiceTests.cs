using ApplicationCore;
using Environment = ApplicationCore.Environment;

namespace UnitTests;

public class InterpreterServiceTests
{
    private InterpreterService _interpreterService;
    
    public InterpreterServiceTests()
    {
        _interpreterService = new InterpreterService(new Environment());
    }
    
    [Fact]
    public void Tokenize_ShouldSplitExpressionIntoTokens()
    {
        var input = "(define a 10)";
        var expectedTokens = new List<string> { "(", "define", "a", "10", ")" };

       var tokens = _interpreterService.Tokenize(input);

       tokens.Should().BeEquivalentTo(expectedTokens, options => options.WithStrictOrdering());
    }
}