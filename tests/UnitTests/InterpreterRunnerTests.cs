using ApplicationCore;
using ApplicationCore.Interfaces;
using NSubstitute;

namespace UnitTests;

public class InterpreterRunnerTests
{
    private InterpreterRunner _runner;
    private IEnvironment _environmentMock;
    
    public InterpreterRunnerTests()
    {
        _environmentMock = Substitute.For<IEnvironment>();
        _runner = new InterpreterRunner(new InterpreterService(_environmentMock));
    }
    
    [Theory]
    [InlineData("(+ 1 2)", 3)]
    [InlineData("(+ 1 1)", 2)]
    [InlineData("(+ 20 2)", 22)]
    public void Run_ShouldHandleSimpleAdd(string input, int expected)
    {
        var runnerResult = _runner.Run(input);

        runnerResult.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("(- 1 2)", -1)]
    [InlineData("(- 1 1)", 0)]
    [InlineData("(- 20 2)", 18)]
    public void Run_ShouldHandleSimpleSubtract(string input, int expected)
    {
        var runnerResult = _runner.Run(input);

        runnerResult.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("(* 1 2)", 2)]
    [InlineData("(* 1 1)", 1)]
    [InlineData("(* 20 2)", 40)]
    public void Run_ShouldHandleSimpleMultiply(string input, int expected)
    {
        var runnerResult = _runner.Run(input);

        runnerResult.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("(/ 10 2)", 5)]
    [InlineData("(/ 20 1)", 20)]
    [InlineData("(/ 100 2)", 50)]
    public void Run_ShouldHandleSimpleDivision(string input, int expected)
    {
        var runnerResult = _runner.Run(input);

        runnerResult.Should().Be(expected);
    }
}