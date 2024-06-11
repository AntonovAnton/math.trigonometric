namespace MathTrigonometric.Tests;

public class MathTrigTests
{
    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(-Math.PI / 2, -1d)]
    [InlineData(-Math.PI / 3, -0.8660254037844386d)]
    [InlineData(-Math.PI / 4, -0.70710678118654757d)]
    [InlineData(-Math.PI / 6, -0.49999999999999994d)]
    [InlineData(0d, 0d)]
    [InlineData(Math.PI / 6, 0.49999999999999994d)]
    [InlineData(Math.PI / 4, 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 0.8660254037844386d)]
    [InlineData(Math.PI / 2, 1d)]
    [InlineData(-Math.PI, -1.2246467991473532E-16d)]
    [InlineData(Math.PI, 1.2246467991473532E-16d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Sin_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Sin(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 1d)]
    [InlineData(-Math.PI / 2, 6.123233995736766E-17d)]
    [InlineData(-Math.PI / 3, 0.50000000000000011d)]
    [InlineData(-Math.PI / 4, 0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(Math.PI / 6, 0.86602540378443871d)]
    [InlineData(Math.PI / 4, 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 0.50000000000000011d)]
    [InlineData(Math.PI / 2, 6.123233995736766E-17d)]
    [InlineData(-Math.PI, -1d)]
    [InlineData(Math.PI, -1d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Cos_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Cos(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(-Math.PI / 2, -16331239353195370d)]
    [InlineData(-Math.PI / 3, -1.7320508075688767d)]
    [InlineData(-Math.PI / 4, -1d)]
    [InlineData(-Math.PI / 6, -0.57735026918962562d)]
    [InlineData(0d, 0d)]
    [InlineData(Math.PI / 6, 0.57735026918962562d)]
    [InlineData(Math.PI / 4, 1d)]
    [InlineData(Math.PI / 3, 1.7320508075688767d)]
    [InlineData(Math.PI / 2, 16331239353195370d)]
    [InlineData(-Math.PI, -1.2246467991473532E-16d / -1d)]
    [InlineData(Math.PI, 1.2246467991473532E-16d / -1d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Tan_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Tan(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(-Math.PI / 2, -1d)]
    [InlineData(-Math.PI / 3, 1 / -0.8660254037844386d)]
    [InlineData(-Math.PI / 4, 1 / -0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 1 / -0.49999999999999994d)]
    [InlineData(0d, double.NaN)]
    [InlineData(Math.PI / 6, 1 / 0.49999999999999994d)]
    [InlineData(Math.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 1 / 0.8660254037844386d)]
    [InlineData(Math.PI / 2, 1d)]
    [InlineData(-Math.PI, 1 / -1.2246467991473532E-16d)]
    [InlineData(Math.PI, 1 / 1.2246467991473532E-16d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Csc_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Csc(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 1d)]
    [InlineData(-Math.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-Math.PI / 3, 1 / 0.50000000000000011d)]
    [InlineData(-Math.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(Math.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(Math.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 1 / 0.50000000000000011d)]
    [InlineData(Math.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-Math.PI, -1d)]
    [InlineData(Math.PI, -1d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Sec_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Sec(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(-Math.PI / 2, -1 / 16331239353195370d)]
    [InlineData(-Math.PI / 3, -1 / 1.7320508075688767d)]
    [InlineData(-Math.PI / 4, -1d)]
    [InlineData(-Math.PI / 6, -1 / 0.57735026918962562d)]
    [InlineData(0d, double.NaN)]
    [InlineData(Math.PI / 6, 1 / 0.57735026918962562d)]
    [InlineData(Math.PI / 4, 1d)]
    [InlineData(Math.PI / 3, 1 / 1.7320508075688767d)]
    [InlineData(Math.PI / 2, 1 / 16331239353195370d)]
    [InlineData(-Math.PI, -1d / -1.2246467991473532E-16d)]
    [InlineData(Math.PI, -1d / 1.2246467991473532E-16d)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Cot_ExpectedValue(double a, double expectedValue)
    {
        var value = MathTrig.Cot(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(0.5d, 0.52359877559829893d)] //PI / 6
    [InlineData(1d, Math.PI / 2)]
    [InlineData(2d, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(-0.5d, -0.52359877559829893d)] //PI / 6
    [InlineData(-1d, -Math.PI / 2)]
    [InlineData(-2d, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Arcsin_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arcsin(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, Math.PI / 2)]
    [InlineData(double.Epsilon, Math.PI / 2 - double.Epsilon)]
    [InlineData(0.5d, 1.0471975511965979d)] //PI / 3
    [InlineData(1d, 0d)]
    [InlineData(2d, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NaN)]
    [InlineData(-0.5d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(-1d, Math.PI)]
    [InlineData(-2d, double.NaN)]
    [InlineData(double.NegativeInfinity, double.NaN)]
    public void MathTrig_Arccos_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arccos(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(0.5d, 0.46364760900080609d)]
    [InlineData(1d, Math.PI / 4)]
    [InlineData(2d, 1.1071487177940904d)]
    [InlineData(double.PositiveInfinity, Math.PI / 2)]
    [InlineData(-0.5d, -0.46364760900080609d)]
    [InlineData(-1d, -Math.PI / 4)]
    [InlineData(-2d, -1.1071487177940904d)]
    [InlineData(double.NegativeInfinity, -Math.PI / 2)]
    public void MathTrig_Arctan_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arctan(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.NaN)]
    [InlineData(0.5d, double.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.0471975511965979d)] //PI / 3
    [InlineData(double.PositiveInfinity, Math.PI / 2)]
    [InlineData(-0.5d, double.NaN)]
    [InlineData(-1d, Math.PI)]
    [InlineData(-2d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(double.NegativeInfinity, Math.PI / 2)]
    public void MathTrig_Arcsec_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arcsec(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.NaN)]
    [InlineData(0.5d, double.NaN)]
    [InlineData(1d, Math.PI / 2)]
    [InlineData(2d, 0.52359877559829893d)] //PI / 6
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, double.NaN)]
    [InlineData(-1d, -Math.PI / 2)]
    [InlineData(-2d, -0.52359877559829893d)] //PI / 6
    [InlineData(double.NegativeInfinity, 0d)]
    public void MathTrig_Arccsc_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arccsc(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, Math.PI / 2)]
    [InlineData(double.Epsilon, Math.PI / 2 - double.Epsilon)]
    [InlineData(0.5d, 1.1071487177940904d)]
    [InlineData(1d, Math.PI / 4)]
    [InlineData(2d, 0.46364760900080609d)]
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, Math.PI - 1.1071487177940904d)]
    [InlineData(-1d, Math.PI - Math.PI / 4)]
    [InlineData(-2d, Math.PI - 0.46364760900080609d)]
    [InlineData(double.NegativeInfinity, Math.PI)]
    public void MathTrig_Arccot_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arccot(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(0.5d, 0.52109530549374738d)]
    [InlineData(1d, 1.1752011936438014d)]
    [InlineData(2d, 3.6268604078470186d)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(-0.5d, -0.52109530549374738d)]
    [InlineData(-1d, -1.1752011936438014d)]
    [InlineData(-2d, -3.6268604078470186d)]
    [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
    public void MathTrig_Sinh_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Sinh(e);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(double.Epsilon, 1d)]
    [InlineData(0.5d, 1.1276259652063807d)]
    [InlineData(1d, 1.5430806348152437d)]
    [InlineData(2d, 3.7621956910836314d)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(-0.5d, 1.1276259652063807d)]
    [InlineData(-1d, 1.5430806348152437d)]
    [InlineData(-2d, 3.7621956910836314d)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity)]
    public void MathTrig_Cosh_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Cosh(e);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(double.Epsilon, double.Epsilon)]
    [InlineData(0.5d, 0.46211715726000974d)]
    [InlineData(1d, 0.76159415595576485d)]
    [InlineData(2d, 0.9640275800758169d)]
    [InlineData(double.PositiveInfinity, 1d)]
    [InlineData(-0.5d, -0.46211715726000974d)]
    [InlineData(-1d, -0.76159415595576485d)]
    [InlineData(-2d, -0.9640275800758169d)]
    [InlineData(double.NegativeInfinity, -1d)]
    public void MathTrig_Tanh_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Tanh(e);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(0.5d, 1 / 0.52109530549374738d)]
    [InlineData(1d, 1 / 1.1752011936438014d)]
    [InlineData(2d, 1 / 3.6268604078470186d)]
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, 1 / -0.52109530549374738d)]
    [InlineData(-1d, 1 / -1.1752011936438014d)]
    [InlineData(-2d, 1 / -3.6268604078470186d)]
    [InlineData(double.NegativeInfinity, 0d)]
    public void MathTrig_Csch_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Csch(e);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(double.Epsilon, 1d)]
    [InlineData(0.5d, 1 / 1.1276259652063807d)]
    [InlineData(1d, 1 / 1.5430806348152437d)]
    [InlineData(2d, 1 / 3.7621956910836314d)]
    [InlineData(double.PositiveInfinity, 0d)]
    [InlineData(-0.5d, 1 / 1.1276259652063807d)]
    [InlineData(-1d, 1 / 1.5430806348152437d)]
    [InlineData(-2d, 1 / 3.7621956910836314d)]
    [InlineData(double.NegativeInfinity, 0d)]
    public void MathTrig_Sech_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Sech(e);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0d, double.NaN)]
    [InlineData(double.Epsilon, double.PositiveInfinity)]
    [InlineData(0.5d, 1 / 0.46211715726000974d)]
    [InlineData(1d, 1 / 0.76159415595576485d)]
    [InlineData(2d, 1 / 0.9640275800758169d)]
    [InlineData(double.PositiveInfinity, 1d)]
    [InlineData(-0.5d, 1 / -0.46211715726000974d)]
    [InlineData(-1d, 1 / -0.76159415595576485d)]
    [InlineData(-2d, 1 / -0.9640275800758169d)]
    [InlineData(double.NegativeInfinity, -1d)]
    public void MathTrig_Coth_ExpectedValue(double e, double expectedValue)
    {
        var value = MathTrig.Coth(e);

        Assert.Equal(expectedValue, value);
    }

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
    public void MathTrig_Arsinh_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arsinh(d);

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
    public void MathTrig_Arcosh_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arcosh(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, double.NaN)]
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
    public void MathTrig_Artanh_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Artanh(d);

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
    public void MathTrig_Arsech_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arsech(d);

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
    public void MathTrig_Arcsch_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arcsch(d);

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
    public void MathTrig_Arcoth_ExpectedValue(double d, double expectedValue)
    {
        var value = MathTrig.Arcoth(d);

        Assert.Equal(expectedValue, value);
    }
}