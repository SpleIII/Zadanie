using HelloDotnet;
using Xunit;

namespace HelloDotnet.Tests;

public class GreetingTests
{
    [Fact]
    public void Greet_ReturnsHello()
    {
        Assert.Equal("Hello, .NET!", Greeting.Greet(".NET"));
    }

    [Fact]
    public void SumRange_1_to_10_is_55()
    {
        Assert.Equal(55, Greeting.SumRange(1, 10));
    }

    [Fact]
    public void SumRange_1_to_100_is_5050()
    {
        Assert.Equal(5050, Greeting.SumRange(1, 100));
    }
}
