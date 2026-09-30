namespace MathTrigonometric.Tests;

// ReSharper disable once InconsistentNaming

public partial class MathTrigTests
{
    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)] //Half.Epsilon
    [InlineData(-MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI / 3, -0.8657f)]
    [InlineData(-MathF.PI / 4, -0.707f)]
    [InlineData(-MathF.PI / 6, -0.4998f)]
    [InlineData(0d, 0d)]
    [InlineData(1d, 0.8414709848078965d)]
    [InlineData(MathF.PI / 6, 0.4998f)]
    [InlineData(MathF.PI / 4, 0.707f)]
    [InlineData(MathF.PI / 3, 0.8657f)]
    [InlineData(MathF.PI / 2, 1d)]
    [InlineData(-MathF.PI, -0.0009675f)]
    [InlineData(MathF.PI, 0.0009675f)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_SinHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Sin(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, 1d)]
    [InlineData(-MathF.PI / 2, 0.0004838f)]
    [InlineData(-MathF.PI / 3, 0.5005f)]
    [InlineData(-MathF.PI / 4, 0.7075f)]
    [InlineData(-MathF.PI / 6, 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(1d, 0.54030230586813977d)]
    [InlineData(MathF.PI / 6, 0.86602540378443871d)]
    [InlineData(MathF.PI / 4, 0.7075f)]
    [InlineData(MathF.PI / 3, 0.5005f)]
    [InlineData(MathF.PI / 2, 0.0004838f)]
    [InlineData(-MathF.PI, -1d)]
    [InlineData(MathF.PI, -1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CosHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Cos(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)]
    //[InlineData(-MathF.PI / 2, -16331239353195370d)] // (undefined)
    [InlineData(-MathF.PI / 3, -1.7295f)]
    [InlineData(-MathF.PI / 4, -0.9995f)]
    [InlineData(-MathF.PI / 6, -0.57735025882720947f)]
    [InlineData(0d, 0d)]
    [InlineData(1d, 1.557f)]
    [InlineData(MathF.PI / 6, 0.57735025882720947f)]
    [InlineData(MathF.PI / 4, 0.9995f)]
    [InlineData(MathF.PI / 3, 1.7295f)]
    //[InlineData(MathF.PI / 2, 16331239353195370d)]
    [InlineData(-MathF.PI, 0.0009675f)]
    [InlineData(MathF.PI, -0.0009675f)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_TanHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Tan(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(-MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI / 3, -1.155f)]
    [InlineData(-MathF.PI / 4, -1.414f)]
    [InlineData(-MathF.PI / 6, -2.002f)]
    [InlineData(0d, float.NaN)]
    [InlineData(MathF.PI / 6, 2.002f)]
    [InlineData(MathF.PI / 4, 1.414f)]
    [InlineData(MathF.PI / 3, 1.155f)]
    [InlineData(MathF.PI / 2, 1d)]
    //[InlineData(-MathF.PI, 1 / -1.2246467991473532E-16d)]
    //[InlineData(MathF.PI, 1 / 1.2246467991473532E-16d)]
    [InlineData(MathF.PI + MathF.PI / 2, -1d)]
    [InlineData(-MathF.PI - MathF.PI / 2, 1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CscHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Csc(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, 1d)]
    //[InlineData(-MathF.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-MathF.PI / 3, 1.998f)]
    [InlineData(-MathF.PI / 4, 1 / 0.7075f)]
    [InlineData(-MathF.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(0d, 1d)]
    [InlineData(MathF.PI / 6, 1 / 0.86602540378443871d)]
    [InlineData(MathF.PI / 4, 1 / 0.7075f)]
    [InlineData(MathF.PI / 3, 1.998f)]
    //[InlineData(MathF.PI / 2, 1 / 6.123233995736766E-17d)]
    [InlineData(-MathF.PI, -1d)]
    [InlineData(MathF.PI, -1d)]
    [InlineData(-2 * MathF.PI, 1d)]
    [InlineData(2 * MathF.PI, 1d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_SecHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Sec(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(-MathF.PI / 2, -0.0004838f)]
    [InlineData(-MathF.PI / 3, -0.578f)]
    [InlineData(-MathF.PI / 4, -1.001f)]
    [InlineData(-MathF.PI / 6, -1.733f)]
    [InlineData(0d, float.NaN)]
    [InlineData(MathF.PI / 6, 1.733f)]
    [InlineData(MathF.PI / 4, 1.001f)]
    [InlineData(MathF.PI / 3, 0.578f)]
    [InlineData(MathF.PI / 2, 0.0004838f)]
    //[InlineData(-MathF.PI, 8165619676597685d)]
    //[InlineData(MathF.PI, -8165619676597685d)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_CotHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.Cot(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)]
    [InlineData(0.5d, 0.52359877559829893d)] //PI / 6
    [InlineData(1d, MathF.PI / 2)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, -0.52359877559829893d)] //PI / 6
    [InlineData(-1d, -MathF.PI / 2)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AsinHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Asin(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, MathF.PI / 2)]
    [InlineData(5.9604645E-08f, MathF.PI / 2 - 5.9604645E-08f)]
    [InlineData(0.5d, 1.0471975511965979d)] //PI / 3
    [InlineData(1d, 0d)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(-1d, MathF.PI)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AcosHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Acos(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)]
    [InlineData(0.5d, 0.46364760900080609d)]
    [InlineData(1d, MathF.PI / 4)]
    [InlineData(2d, 1.1071487177940904d)]
    [InlineData(float.PositiveInfinity, MathF.PI / 2)]
    [InlineData(-0.5d, -0.46364760900080609d)]
    [InlineData(-1d, -MathF.PI / 4)]
    [InlineData(-2d, -1.1071487177940904d)]
    [InlineData(float.NegativeInfinity, -MathF.PI / 2)]
    public void MathTrig_AtanHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Atan(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, MathF.PI / 2)]
    [InlineData(2d, 0.52359877559829893d)] //PI / 6
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, -MathF.PI / 2)]
    [InlineData(-2d, -0.52359877559829893d)] //PI / 6
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcscHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Acsc(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.0471975511965979d)] //PI / 3
    [InlineData(float.PositiveInfinity, MathF.PI / 2)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, MathF.PI)]
    [InlineData(-2d, 2 * 1.0471975511965979d)] //2PI / 3
    [InlineData(float.NegativeInfinity, MathF.PI / 2)]
    public void MathTrig_AsecHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Asec(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, MathF.PI / 2)]
    [InlineData(5.9604645E-08f, MathF.PI / 2 - 5.9604645E-08f)]
    [InlineData(0.5d, 1.1071487177940904d)]
    [InlineData(1d, MathF.PI / 4)]
    [InlineData(2d, 0.46364760900080609d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, 2.033f)]
    [InlineData(-1d, MathF.PI - MathF.PI / 4)]
    [InlineData(-2d, MathF.PI - 0.46364760900080609d)]
    [InlineData(float.NegativeInfinity, MathF.PI)]
    public void MathTrig_AcotHalf_ExpectedValue(Half d, Half expectedValue)
    {
        var value = MathTrig.Acot(d);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)]
    [InlineData(0.5d, 0.52109530549374738d)]
    [InlineData(1d, 1.1752011936438014d)]
    [InlineData(2d, 3.6268604078470186d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, -0.52109530549374738d)]
    [InlineData(-1d, -1.1752011936438014d)]
    [InlineData(-2d, -3.6268604078470186d)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_SinhHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Sinh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(5.9604645E-08f, 1d)]
    [InlineData(0.5d, 1.1276259652063807d)]
    [InlineData(1d, 1.5430806348152437d)]
    [InlineData(2d, 3.7621956910836314d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, 1.1276259652063807d)]
    [InlineData(-1d, 1.5430806348152437d)]
    [InlineData(-2d, 3.7621956910836314d)]
    [InlineData(float.NegativeInfinity, float.PositiveInfinity)]
    public void MathTrig_CoshHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Cosh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 5.9604645E-08f)]
    [InlineData(0.5d, 0.46211715726000974d)]
    [InlineData(1d, 0.76159415595576485d)]
    [InlineData(2d, 0.9640275800758169d)]
    [InlineData(float.PositiveInfinity, 1d)]
    [InlineData(-0.5d, -0.46211715726000974d)]
    [InlineData(-1d, -0.76159415595576485d)]
    [InlineData(-2d, -0.9640275800758169d)]
    [InlineData(float.NegativeInfinity, -1d)]
    public void MathTrig_TanhHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Tanh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(0.5d, 1.91903484f)]
    [InlineData(1d, 1 / 1.1752011936438014d)]
    [InlineData(2d, 1 / 3.6268604078470186d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, -1.91903484f)]
    [InlineData(-1d, 1 / -1.1752011936438014d)]
    [InlineData(-2d, 1 / -3.6268604078470186d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_CschHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Csch(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 1d)]
    [InlineData(5.9604645E-08f, 1d)]
    [InlineData(0.5d, 1 / 1.1276259652063807d)]
    [InlineData(1d, 0.648054242f)]
    [InlineData(2d, 1 / 3.7621956910836314d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, 1 / 1.1276259652063807d)]
    [InlineData(-1d, 0.648054242f)]
    [InlineData(-2d, 1 / 3.7621956910836314d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_SechHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Sech(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(0.5d, 1 / 0.46211715726000974d)]
    [InlineData(1d, 1.3125f)]
    [InlineData(2d, 1 / 0.9640275800758169d)]
    [InlineData(float.PositiveInfinity, 1d)]
    [InlineData(-0.5d, 1 / -0.46211715726000974d)]
    [InlineData(-1d, -1.3125f)]
    [InlineData(-2d, 1 / -0.9640275800758169d)]
    [InlineData(float.NegativeInfinity, -1d)]
    public void MathTrig_CothHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Coth(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 0d)]
    [InlineData(0.5d, 0.481211841f)]
    [InlineData(1d, 0.881373644f)]
    [InlineData(2d, 1.4436354751788103d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, -0.481211841f)]
    [InlineData(-1d, -0.881373644f)]
    [InlineData(-2d, -1.4436354751788103d)]
    [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
    public void MathTrig_AsinhHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Asinh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, 0d)]
    [InlineData(2d, 1.3169578969248166d)]
    [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AcoshHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Acosh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, 0d)]
    [InlineData(5.9604645E-08f, 0d)]
    [InlineData(0.5d, 0.54930614433405489d)]
    [InlineData(1d, float.PositiveInfinity)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, -0.54930614433405489d)]
    [InlineData(-1d, float.NegativeInfinity)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AtanhHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Atanh(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(0.5d, 1.4436354751788103d)]
    [InlineData(1d, 0.881373644f)]
    [InlineData(2d, 0.481211841f)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, -1.4436354751788103d)]
    [InlineData(-1d, -0.881373644f)]
    [InlineData(-2d, -0.481211841f)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcschHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Acsch(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.PositiveInfinity)]
    [InlineData(0.5d, 1.3169578969248166d)]
    [InlineData(1d, 0d)]
    [InlineData(2d, float.NaN)]
    [InlineData(float.PositiveInfinity, float.NaN)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, float.NaN)]
    [InlineData(float.NegativeInfinity, float.NaN)]
    public void MathTrig_AsechHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Asech(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0d, float.NaN)]
    [InlineData(5.9604645E-08f, float.NaN)]
    [InlineData(0.5d, float.NaN)]
    [InlineData(1d, float.NaN)]
    [InlineData(2d, 0.54930614433405489d)]
    [InlineData(float.PositiveInfinity, 0d)]
    [InlineData(-0.5d, float.NaN)]
    [InlineData(-1d, float.NaN)]
    [InlineData(-2d, -0.54930614433405489d)]
    [InlineData(float.NegativeInfinity, 0d)]
    public void MathTrig_AcothHalf_ExpectedValue(Half x, Half expectedValue)
    {
        var value = MathTrig.Acoth(x);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0f, 0f)]
    [InlineData(5.9604645E-08f, 0f)]
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
    public void MathTrig_DegreesToRadiansHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.DegreesToRadians(a);

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(float.NaN, float.NaN)]
    [InlineData(0f, 0f)]
    [InlineData(5.9604645E-08f, 3.4E-06f)]
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
    public void MathTrig_RadiansToDegreesHalf_ExpectedValue(Half a, Half expectedValue)
    {
        var value = MathTrig.RadiansToDegrees(a);

        Assert.Equal(expectedValue, value);
    }
}