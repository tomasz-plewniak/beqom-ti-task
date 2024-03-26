using ApplicationCore.Exceptions;
using Environment = ApplicationCore.Environment;

namespace UnitTests;

public class EnvironmentTests
{
    [Theory]
    [InlineData("x", 10)]
    [InlineData("y", 20)]
    [InlineData("z", 30)]
    [InlineData("t", 40)]
    [InlineData("p", 50)]
    public void Set_ShouldStoreVariableValue(string name, int value)
    {
        var env = new Environment();
        env.Set(name, value);

        var retrievedValue = env.Get(name);
        retrievedValue.Should().Be(value);
    }
    
    [Fact]
    public void Get_ShouldThrowIfVariableIsUndefined()
    {
        var env = new Environment();

        env.Invoking(e => e.Get("undefinedVar"))
            .Should().Throw<UndefinedSymbolException>()
            .WithMessage("Undefined symbol: undefinedVar");
    }
}
