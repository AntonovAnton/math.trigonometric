namespace MathTrigonometric.Tests;

public class MathTrigTests
{
    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, 0d)]
    [InlineData(0.5d, 0.48121182505960347d)]
    [InlineData(1d, 0.88137358701954294d)]
    [InlineData(2d, 1.4436354751788103d)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(-0.5d, -0.48121182505960347d)]
    [InlineData(-1d, -0.88137358701954294d)]
    [InlineData(-2d, -1.4436354751788103d)]
    [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
    public void MathTrig_Arsinh_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Arsinh(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.NaN)]
    [InlineData(0.5d, double.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.3169578969248166d)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(-0.5d, double.NaN)]
    [InlineData(-1d, double.NaN)]
    [InlineData(-2d, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Arcosh_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Arcosh(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN,double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, 0d)]
    [InlineData(0.5d, 0.54930614433405489d)]
    [InlineData(1d, double.PositiveInfinity)]
    [InlineData(2d, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(-0.5d, -0.54930614433405489d)]
    [InlineData(-1d, double.NegativeInfinity)]
    [InlineData(-2d, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Artanh_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Artanh(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.NaN)]
    [InlineData(0.5d, double.NaN)]
    [InlineData(1d, double.NaN)]
    [InlineData(2d, 0.54930614433405489d)]
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, double.NaN)]
    [InlineData(-1d, double.NaN)]
    [InlineData(-2d, -0.54930614433405489d)]
    [InlineData(double.NegativeInfinity, 0)]
    public void MathTrig_Arcoth_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Arcoth(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(0.5d, 1.3169578969248166d)]
    [InlineData(1d, 0d)]
    [InlineData(2d, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(-0.5d, double.NaN)]
    [InlineData(-1d, double.NaN)]
    [InlineData(-2d, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Arsech_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Arsech(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(0.5d, 1.4436354751788103d)]
    [InlineData(1d, 0.88137358701954294d)]
    [InlineData(2d, 0.48121182505960347d)]
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, -1.4436354751788103d)]
    [InlineData(-1d, -0.88137358701954294d)]
    [InlineData(-2d, -0.48121182505960347d)]
    [InlineData(double.NegativeInfinity, 0d)]
    public void MathTrig_Arcsch_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Arcsch(a);

        Assert.Equal(expectedValue, value);
    }
}