namespace MathTrigonometric.Tests;

// ReSharper disable once InconsistentNaming

public partial class MathTrigTests
{
    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(-MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI / 3, -0.866025448f)]
    [InlineData(-MathF.PI / 4, -0.70710678118654757d)]
    [InlineData(-MathF.PI / 6, -0.49999999999999994d)]
    [InlineData(0d, 0d)]
    [InlineData(1d, 0.8414709848078965d)]
    [InlineData(MathF.PI / 6, 0.49999999999999994d)]
    [InlineData(MathF.PI / 4, 0.70710678118654757d)]
    [InlineData(MathF.PI / 3, 0.866025448f)]
    [InlineData(MathF.PI / 2, 1d)]
    [InlineData(-MathF.PI, 8.74227766E-08d)]
    [InlineData(MathF.PI, -8.74227766E-08f)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_SinFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Sin(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, 1d)]
    [InlineData(-MathF.PI / 2, -4.37113883E-08f)]
    [InlineData(-MathF.PI / 3, 0.49999997f)]
    [InlineData(-MathF.PI / 4, 0.70710678118654757d)]
    [InlineData(-MathF.PI / 6, 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(1d, 0.54030230586813977d)]
    [InlineData(MathF.PI / 6, 0.86602540378443871d)]
    [InlineData(MathF.PI / 4, 0.70710678118654757d)]
    [InlineData(MathF.PI / 3, 0.49999997f)]
    [InlineData(MathF.PI / 2, -4.37113883E-08f)]
    [InlineData(-MathF.PI, -1d)]
    [InlineData(MathF.PI, -1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CosFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Cos(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, float.Epsilon)]
    //[InlineData(-MathF.PI / 2, -16331239353195370d)] // (undefined)
    [InlineData(-MathF.PI / 3, -1.73205101f)]
    [InlineData(-MathF.PI / 4, -1.000000043711391f)]
    [InlineData(-MathF.PI / 6, -0.57735025882720947f)]
    [InlineData(0d, 0d)]
    [InlineData(1d, 1.5574077246549023f)]
    [InlineData(MathF.PI / 6, 0.57735025882720947f)]
    [InlineData(MathF.PI / 4, 1.000000043711391f)]
    [InlineData(MathF.PI / 3, 1.73205101f)]
    //[InlineData(MathF.PI / 2, 16331239353195370d)]
    [InlineData(-MathF.PI, -8.74227766E-08f)]
    [InlineData(MathF.PI, 8.74227766E-08f)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_TanFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Tan(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(-MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI / 3, 1 / -0.8660254037844386d)]
    [InlineData(-MathF.PI / 4, 1 / -0.70710678118654757d)]
    [InlineData(-MathF.PI / 6, 1 / -0.49999999999999994d)]
    [InlineData(0d, float.NaN)]
    [InlineData(MathF.PI / 6, 1 / 0.49999999999999994d)]
    [InlineData(MathF.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(MathF.PI / 3, 1 / 0.8660254037844386d)]
    [InlineData(MathF.PI / 2, 1d)]
    //[InlineData(-MathF.PI, 1 / -1.2246467991473532E-16d)]
    //[InlineData(MathF.PI, 1 / 1.2246467991473532E-16d)]
    [InlineData(MathF.PI + MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI - MathF.PI / 2, 1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CscFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Csc(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, 1d)]
    //[InlineData(-MathF.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-MathF.PI / 3, 2.00000024f)]
    [InlineData(-MathF.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(-MathF.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(MathF.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(MathF.PI / 4, 1 / 0.70710678118654757d)]
    [InlineData(MathF.PI / 3, 2.00000024f)]
    //[InlineData(MathF.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-MathF.PI, -1d)]
    [InlineData(MathF.PI, -1d)]
    [InlineData(-2 * MathF.PI, 1d)]
    [InlineData(2 * MathF.PI, 1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_SecFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Sec(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(-MathF.PI / 2, 4.37113883E-08f)]
    [InlineData(-MathF.PI / 3, -0.577350199f)]
    [InlineData(-MathF.PI / 4, -1d)]
    [InlineData(-MathF.PI / 6, -1.73205078f)]
    [InlineData(0d, float.NaN)]
    [InlineData(MathF.PI / 6, 1.73205078f)]
    [InlineData(MathF.PI / 4, 1d)]
    [InlineData(MathF.PI / 3, 0.577350199f)]
    [InlineData(MathF.PI / 2, -4.37113883E-08f)]
    //[InlineData(-MathF.PI, 8165619676597685d)]
    //[InlineData(MathF.PI, -8165619676597685d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CotFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.Cot(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(0.5d, 0.52359877559829893d)] //PI / 6
    [InlineData(1d, MathF.PI / 2)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, -0.52359877559829893d)] //PI / 6
    [InlineData(-1d, -MathF.PI / 2)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AsinFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Asin(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, MathF.PI / 2)]
    [InlineData(float.Epsilon, MathF.PI / 2 - float.Epsilon)]
    [InlineData(0.5d, 1.0471975511965979d)] //PI / 3
    [InlineData(1d, 0d)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(-1d, MathF.PI)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AcosFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Acos(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(0.5d, 0.46364760900080609d)]
    [InlineData(1d, MathF.PI / 4)]
    [InlineData(2d, 1.1071487177940904d)]
    [InlineData(float.PositiveInfinity, MathF.PI / 2)]
    [InlineData(-0.5d, -0.46364760900080609d)]
    [InlineData(-1d, -MathF.PI / 4)]
    [InlineData(-2d, -1.1071487177940904d)]
    [InlineData(float.NegativeInfinity, -MathF.PI / 2)]
    public void MathTrig_AtanFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Atan(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, MathF.PI / 2)]
    [InlineData(2d, 0.52359877559829893d)] //PI / 6
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, -MathF.PI / 2)]
    [InlineData(-2d, -0.52359877559829893d)] //PI / 6
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcscFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Acsc(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.0471975511965979d)] //PI / 3
    [InlineData(float.PositiveInfinity, MathF.PI / 2)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, MathF.PI)]
    [InlineData(-2d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(float.NegativeInfinity, MathF.PI / 2)]
    public void MathTrig_AsecFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Asec(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, MathF.PI / 2)]
    [InlineData(float.Epsilon, MathF.PI / 2 - float.Epsilon)]
    [InlineData(0.5f, 1.1071487177940904d)]
    [InlineData(1d, MathF.PI / 4)]
    [InlineData(2d, 0.46364760900080609d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5f, 2.03444386f)]
    [InlineData(-1d, MathF.PI - MathF.PI / 4)]
    [InlineData(-2d, MathF.PI - 0.46364760900080609d)]
    [InlineData(float.NegativeInfinity, MathF.PI)]
    public void MathTrig_AcotFloat_ExpectedValue(float d, float expectedValue)
    {
        var value = MathTrig.Acot(d);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(0.5d, 0.52109530549374738d)]
    [InlineData(1d, 1.1752011936438014d)]
    [InlineData(2d, 3.6268604078470186d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, -0.52109530549374738d)]
    [InlineData(-1d, -1.1752011936438014d)]
    [InlineData(-2d, -3.6268604078470186d)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_SinhFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Sinh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(float.Epsilon, 1d)]
    [InlineData(0.5d, 1.1276259652063807d)]
    [InlineData(1d, 1.5430806348152437d)]
    [InlineData(2d, 3.7621956910836314d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, 1.1276259652063807d)]
    [InlineData(-1d, 1.5430806348152437d)]
    [InlineData(-2d, 3.7621956910836314d)]
    [InlineData(float.NegativeInfinity, float.PositiveInfinity)]
    public void MathTrig_CoshFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Cosh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(0.5d, 0.46211715726000974d)]
    [InlineData(1d, 0.76159415595576485d)]
    [InlineData(2d, 0.9640275800758169d)]
    [InlineData(float.PositiveInfinity, 1d)]
    [InlineData(-0.5d, -0.46211715726000974d)]
    [InlineData(-1d, -0.76159415595576485d)]
    [InlineData(-2d, -0.9640275800758169d)]
    [InlineData(float.NegativeInfinity, -1d)]
    public void MathTrig_TanhFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Tanh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(0.5d, 1.91903484f)]
    [InlineData(1d, 1 / 1.1752011936438014d)]
    [InlineData(2d, 1 / 3.6268604078470186d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, -1.91903484f)]
    [InlineData(-1d, 1 / -1.1752011936438014d)]
    [InlineData(-2d, 1 / -3.6268604078470186d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_CschFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Csch(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(float.Epsilon, 1d)]
    [InlineData(0.5d, 1 / 1.1276259652063807d)]
    [InlineData(1d, 0.648054242f)]
    [InlineData(2d, 1 / 3.7621956910836314d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, 1 / 1.1276259652063807d)]
    [InlineData(-1d, 0.648054242f)]
    [InlineData(-2d, 1 / 3.7621956910836314d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_SechFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Sech(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(0.5d, 1 / 0.46211715726000974d)]
    [InlineData(1d, 1 / 0.76159415595576485d)]
    [InlineData(2d, 1 / 0.9640275800758169d)]
    [InlineData(float.PositiveInfinity, 1d)]
    [InlineData(-0.5d, 1 / -0.46211715726000974d)]
    [InlineData(-1d, 1 / -0.76159415595576485d)]
    [InlineData(-2d, 1 / -0.9640275800758169d)]
    [InlineData(float.NegativeInfinity, -1d)]
    public void MathTrig_CothFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Coth(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, 0d)]
    [InlineData(0.5d, 0.481211841f)]
    [InlineData(1d, 0.881373644f)]
    [InlineData(2d, 1.4436354751788103d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, -0.481211841f)]
    [InlineData(-1d, -0.881373644f)]
    [InlineData(-2d, -1.4436354751788103d)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_AsinhFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Asinh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.3169578969248166d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AcoshFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Acosh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, 0d)]
    [InlineData(0.5d, 0.54930614433405489d)]
    [InlineData(1d, float.PositiveInfinity)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, -0.54930614433405489d)]
    [InlineData(-1d, float.NegativeInfinity)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AtanhFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Atanh(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(0.5d, 1.4436354751788103d)]
    [InlineData(1d, 0.881373644f)]
    [InlineData(2d, 0.481211841f)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, -1.4436354751788103d)]
    [InlineData(-1d, -0.881373644f)]
    [InlineData(-2d, -0.481211841f)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcschFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Acsch(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.PositiveInfinity)]
    [InlineData(0.5d, 1.3169578969248166d)]
    [InlineData(1d, 0d)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AsechFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Asech(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(float.Epsilon, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, float.NaN)]
    [InlineData(2d, 0.54930614433405489d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, -0.54930614433405489d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcothFloat_ExpectedValue(float x, float expectedValue)
    {
        var value = MathTrig.Acoth(x);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, 0)]
    [InlineData(2.8161741812951053E-322d, float.Epsilon)]
    [InlineData(30, MathF.PI / 6)]
    [InlineData(45, MathF.PI / 4)]
    [InlineData(90, MathF.PI / 2)]
    [InlineData(180, MathF.PI)]
    [InlineData(360, 2 * MathF.PI)]
    [InlineData(-30, -MathF.PI / 6)]
    [InlineData(-45, -MathF.PI / 4)]
    [InlineData(-90, -MathF.PI / 2)]
    [InlineData(-180, -MathF.PI)]
    [InlineData(-360, -2 * MathF.PI)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_DegreesToRadiansFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.DegreesToRadians(a);

        Assert.Equal(expectedValue, value, float.Epsilon);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(float.Epsilon, float.Epsilon)]
    [InlineData(MathF.PI / 4, 45)]
    [InlineData(MathF.PI / 2, 90)]
    [InlineData(MathF.PI, 180)]
    [InlineData(2 * MathF.PI, 360)]
    [InlineData(-MathF.PI / 4, -45)]
    [InlineData(-MathF.PI / 2, -90)]
    [InlineData(-MathF.PI, -180)]
    [InlineData(-2 * MathF.PI, -360)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_RadiansToDegreesFloat_ExpectedValue(float a, float expectedValue)
    {
        var value = MathTrig.RadiansToDegrees(a);

        Assert.Equal(expectedValue, value, (float)Half.Epsilon);
    }
}