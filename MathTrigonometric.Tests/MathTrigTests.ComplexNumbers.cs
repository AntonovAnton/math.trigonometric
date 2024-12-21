using System.Numerics;

namespace MathTrigonometric.Tests;

// ReSharper disable once InconsistentNaming
public partial class MathTrigTests
{
    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.Epsilon, 0d)]
    [InlineData(-Math.PI / 2, 0d, -1d, 0)]
    [InlineData(-Math.PI / 3, 0d, -0.8660254037844386d, 0d)]
    [InlineData(-Math.PI / 4, 0d, -0.70710678118654757d, 0d)]
    [InlineData(-Math.PI / 6, 0d, -0.49999999999999994d, 0d)]
    [InlineData(0d, 0d, 0d, 0d)]
    [InlineData(1d, 0d, 0.8414709848078965d, 0d)]
    [InlineData(Math.PI / 6, 0d, 0.49999999999999994d, 0d)]
    [InlineData(Math.PI / 4, 0d, 0.70710678118654757d, 0d)]
    [InlineData(Math.PI / 3, 0d, 0.8660254037844386d, 0d)]
    [InlineData(Math.PI / 2, 0d, 1d, 0d)]
    [InlineData(-Math.PI, 0d, -1.2246467991473532E-16d, 0d)]
    [InlineData(Math.PI, 0d, 1.2246467991473532E-16d, 0d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.PositiveInfinity, double.NegativeInfinity)]
    [InlineData(2d, double.NegativeInfinity, double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(2d, 3d, 9.15449914691143d, -4.168906959966565d)]
    [InlineData(2d, -3d, 9.15449914691143d, 4.168906959966565d)]
    [InlineData(-2d, 3d, -9.15449914691143d, -4.168906959966565d)]
    [InlineData(-2d, -3d, -9.15449914691143d, 4.168906959966565d)]
    //[InlineData(0.01, 711.0, 3.0E+306, double.PositiveInfinity)]
    public void MathTrig_SinComplexNumbers_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Sin(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, 1d)]
    [InlineData(-Math.PI / 2, 0d, 6.123233995736766E-17d)]
    [InlineData(-Math.PI / 3, 0d, 0.50000000000000011d)]
    [InlineData(-Math.PI / 4, 0d, 0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 0d, 0.86602540378443871d)]
    [InlineData(0d, 0d, 1d)]
    [InlineData(1d, 0d, 0.54030230586813977d)]
    [InlineData(Math.PI / 6, 0d, 0.86602540378443871d, 0d)]
    [InlineData(Math.PI / 4, 0d, 0.70710678118654757d, 0d)]
    [InlineData(Math.PI / 3, 0d, 0.50000000000000011d, 0d)]
    [InlineData(Math.PI / 2, 0d, 6.123233995736766E-17d, 0d)]
    [InlineData(-Math.PI, 0d, -1d)]
    [InlineData(Math.PI, 0d, -1d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NegativeInfinity, double.NegativeInfinity)]
    [InlineData(2d, double.NegativeInfinity, double.NegativeInfinity, double.PositiveInfinity)]
    [InlineData(2d, 3d, -4.189625690968807d, -9.109227893755337d)]
    [InlineData(2d, -3d, -4.189625690968807d, 9.109227893755337d)]
    [InlineData(-2d, 3d, -4.189625690968807d, 9.109227893755337d)]
    [InlineData(-2d, -3d, -4.189625690968807d, -9.109227893755337d)]
    public void MathTrig_CosComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Cos(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.Epsilon)]
    [InlineData(-Math.PI / 2, 0d, double.NegativeInfinity, double.NaN)]
    [InlineData(-Math.PI / 3, 0d, -1.7320508075688767d)]
    [InlineData(-Math.PI / 4, 0d, -1d)]
    [InlineData(-Math.PI / 6, 0d, -0.5773502691896257d)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(1d, 0d, 1.5574077246549021d)]
    [InlineData(Math.PI / 6, 0d, 0.5773502691896257d, 0d)]
    [InlineData(Math.PI / 4, 0d, 1d, 0d)]
    [InlineData(Math.PI / 3, 0d, 1.7320508075688767d, 0d)]
    [InlineData(Math.PI / 2, 0d, double.PositiveInfinity, double.NaN)]
    [InlineData(-Math.PI, 0d, -1.2246467991473532E-16d / -1d)]
    [InlineData(Math.PI, 0d, 1.2246467991473532E-16d / -1d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0, 1)]
    [InlineData(2d, double.NegativeInfinity, 0, -1)]
    [InlineData(2d, 3d, -0.0037640256415042484, 1.0032386273536098)]
    [InlineData(2d, -3d, -0.0037640256415042484, -1.0032386273536098)]
    [InlineData(-2d, 3d, 0.0037640256415042484, 1.0032386273536098)]
    [InlineData(-2d, -3d, 0.0037640256415042484, -1.0032386273536098)]
    public void MathTrig_TanComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Tan(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(-Math.PI / 2, 0d, -1d)]
    [InlineData(-Math.PI / 3, 0d, 1 / -0.8660254037844386d)]
    [InlineData(-Math.PI / 4, 0d, 1 / -0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 0d, 1 / -0.49999999999999994d)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(Math.PI / 6, 0d, 1 / 0.49999999999999994d)]
    [InlineData(Math.PI / 4, 0d, 1 / 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 0d, 1 / 0.8660254037844386d)]
    [InlineData(Math.PI / 2, 0d, 1d, 0d)]
    [InlineData(-Math.PI, 0d, 1 / -1.2246467991473532E-16d)]
    [InlineData(Math.PI, 0d, 1 / 1.2246467991473532E-16d)]
    [InlineData(Math.PI + Math.PI / 2, 0d, -1d)]
    [InlineData(-Math.PI - Math.PI / 2, 0d, 1d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0)]
    [InlineData(2d, double.NegativeInfinity, 0)]
    [InlineData(2d, 3d, 0.09047320975320743, 0.041200986288574125)]
    [InlineData(2d, -3d, 0.09047320975320743, -0.041200986288574125)]
    [InlineData(-2d, 3d, -0.09047320975320743, 0.041200986288574125)]
    [InlineData(-2d, -3d, -0.09047320975320743, -0.041200986288574125)]
    public void MathTrig_CscComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Csc(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, 1d)]
    [InlineData(-Math.PI / 2, 0d, 1 / 6.123233995736766E-17d)]
    [InlineData(-Math.PI / 3, 0d, 1 / 0.50000000000000011d)]
    [InlineData(-Math.PI / 4, 0d, 1 / 0.70710678118654757d)]
    [InlineData(-Math.PI / 6, 0d, 1 / 0.86602540378443871d)]
    [InlineData(0d, 0d, 1d)]
    [InlineData(Math.PI / 6, 0d, 1 / 0.86602540378443871d)]
    [InlineData(Math.PI / 4, 0d, 1 / 0.70710678118654757d)]
    [InlineData(Math.PI / 3, 0d, 1 / 0.50000000000000011d)]
    [InlineData(Math.PI / 2, 0d, 1 / 6.123233995736766E-17d)]
    [InlineData(-Math.PI, 0d, -1d)]
    [InlineData(Math.PI, 0d, -1d)]
    [InlineData(-2 * Math.PI, 0d, 1d)]
    [InlineData(2 * Math.PI, 0d, 1d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0)]
    [InlineData(2d, double.NegativeInfinity, 0)]
    [InlineData(2d, 3d, -0.041674964411144266, 0.0906111371962376)]
    [InlineData(2d, -3d, -0.041674964411144266, -0.0906111371962376)]
    [InlineData(-2d, 3d, -0.041674964411144266, -0.0906111371962376)]
    [InlineData(-2d, -3d, -0.041674964411144266, 0.0906111371962376)]
    public void MathTrig_SecComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Sec(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(-Math.PI / 2, 0d, -1 / 16331239353195370d)]
    [InlineData(-Math.PI / 3, 0d, -1 / 1.7320508075688767d)]
    [InlineData(-Math.PI / 4, 0d, -1d)]
    [InlineData(-Math.PI / 6, 0d, -1 / 0.57735026918962562d)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(Math.PI / 6, 0d, 1 / 0.57735026918962562d)]
    [InlineData(Math.PI / 4, 0d, 1d, 0d)]
    [InlineData(Math.PI / 3, 0d, 1 / 1.7320508075688767d)]
    [InlineData(Math.PI / 2, 0d, 1 / 16331239353195370d)]
    [InlineData(-Math.PI, 0d, -1d / -1.2246467991473532E-16d)]
    [InlineData(Math.PI, 0d, -1d / 1.2246467991473532E-16d)]
    [InlineData(double.PositiveInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 0d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0, -1)]
    [InlineData(2d, double.NegativeInfinity, 0, 1)]
    [InlineData(2d, 3d, -0.003739710376336932, -0.9967577965693583)]
    [InlineData(2d, -3d, -0.003739710376336932, 0.9967577965693583)]
    [InlineData(-2d, 3d, 0.003739710376336932, -0.9967577965693583)]
    [InlineData(-2d, -3d, 0.003739710376336932, 0.9967577965693583)]
    public void MathTrig_CotComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Cot(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, double.Epsilon)]
    [InlineData(0.5d, 0d, 0.52359877559829893d)] //PI / 6
    [InlineData(1d, 0d, Math.PI / 2)]
    [InlineData(2d, 0d, Math.PI / 2, 1.3169578969248166d)]
    [InlineData(-0.5d, 0d, -0.52359877559829893d)] //PI / 6
    [InlineData(-1d, 0d, -Math.PI / 2, 0d)]
    [InlineData(-2d, 0d, -Math.PI / 2, 1.3169578969248166d)]
    [InlineData(double.PositiveInfinity, 0d, Math.PI / 2, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, -Math.PI / 2, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, 2d, Math.PI / 2, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 2d, -Math.PI / 2, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0, double.PositiveInfinity)]
    [InlineData(2d, double.NegativeInfinity, 0, double.NegativeInfinity)]
#if NET9_0_OR_GREATER
    [InlineData(2d, 3d, 0.5706527843210994, 1.9833870299165355)]
    [InlineData(2d, -3d, 0.5706527843210994, -1.9833870299165355)]
    [InlineData(-2d, 3d, -0.5706527843210994, 1.9833870299165355)]
    [InlineData(-2d, -3d, -0.5706527843210994, -1.9833870299165355)]
#else
    [InlineData(2d, 3d, 0.5706527843210993, 1.9833870299165357)]
    [InlineData(2d, -3d, 0.5706527843210993, -1.9833870299165357)]
    [InlineData(-2d, 3d, -0.5706527843210993, 1.9833870299165357)]
    [InlineData(-2d, -3d, -0.5706527843210993, -1.9833870299165357)]
#endif
    public void MathTrig_AsinComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Asin(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, Math.PI / 2)]
    [InlineData(double.Epsilon, 0d, Math.PI / 2 - double.Epsilon)]
    [InlineData(0.5d, 0d, 1.0471975511965979d)] //PI / 3
    [InlineData(1d, 0d, 0d)]
    [InlineData(2d, 0d, 0d, 1.3169578969248166d)]
    [InlineData(-0.5d, 0d, Math.PI * 2 / 3)]
    [InlineData(-1d, 0d, Math.PI)]
    [InlineData(-2d, 0d, Math.PI, 1.3169578969248166d)]
    [InlineData(double.PositiveInfinity, 0d, 0d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, Math.PI, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, 2d, 0d, double.NegativeInfinity)]
    [InlineData(double.NegativeInfinity, 2d, Math.PI, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, Math.PI / 2, double.NegativeInfinity)]
    [InlineData(2d, double.NegativeInfinity, Math.PI / 2, double.PositiveInfinity)]
#if NET9_0_OR_GREATER
    [InlineData(2d, 3d, 1.0001435424737972, -1.9833870299165355)]
    [InlineData(2d, -3d, 1.0001435424737972, 1.9833870299165355)]
    [InlineData(-2d, 3d, 2.141449111115996, -1.9833870299165355)]
    [InlineData(-2d, -3d, 2.141449111115996, 1.9833870299165355)]
#else
    [InlineData(2d, 3d, 1.0001435424737972, -1.9833870299165357)]
    [InlineData(2d, -3d, 1.0001435424737972, 1.9833870299165357)]
    [InlineData(-2d, 3d, 2.141449111115996, -1.9833870299165357)]
    [InlineData(-2d, -3d, 2.141449111115996, 1.9833870299165357)]
#endif
    public void MathTrig_AcosComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acos(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, double.Epsilon)]
    [InlineData(0.5d, 0d, 0.46364760900080609d)]
    [InlineData(1d, 0d, Math.PI / 4)]
    [InlineData(2d, 0d, 1.1071487177940904d)]
    [InlineData(-0.5d, 0d, -0.46364760900080609d)]
    [InlineData(-1d, 0d, -Math.PI / 4)]
    [InlineData(-2d, 0d, -1.1071487177940904d)]
    [InlineData(double.PositiveInfinity, 0d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 0d, -Math.PI / 2)]
    [InlineData(double.PositiveInfinity, 2d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 2d, -Math.PI / 2)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, Math.PI / 2)]
    [InlineData(2d, double.NegativeInfinity, -Math.PI / 2)]
    [InlineData(2d, 3d, 1.4099210495965755, 0.22907268296853878)]
    [InlineData(2d, -3d, 1.4099210495965755, -0.22907268296853878)]
    [InlineData(-2d, 3d, -1.4099210495965755, 0.22907268296853878)]
    [InlineData(-2d, -3d, -1.4099210495965755, -0.22907268296853878)]
    public void MathTrig_AtanComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Atan(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, Math.PI / 2, double.PositiveInfinity)]
    [InlineData(double.Epsilon * 10000000000000000, 0d, Math.PI / 2, 708.2918576140364d)]
    [InlineData(-double.Epsilon, 0d, -Math.PI / 2, double.PositiveInfinity)]
    [InlineData(0.5d, 0d, Math.PI / 2, 1.3169578969248166d)]
    [InlineData(1d, 0d, Math.PI / 2)]
    [InlineData(2d, 0d, 0.52359877559829893d)] //PI / 6
    [InlineData(-0.5d, 0d, -Math.PI / 2, 1.3169578969248166d)]
    [InlineData(-1d, 0d, -Math.PI / 2)]
    [InlineData(-2d, 0d, -0.52359877559829893d)] //PI / 6
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, 0d)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, 0d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0)]
    [InlineData(2d, double.NegativeInfinity, 0)]
    [InlineData(2d, 3d, 0.150385604327862, -0.23133469857397337)]
    [InlineData(2d, -3d, 0.150385604327862, 0.23133469857397337)]
    [InlineData(-2d, 3d, -0.150385604327862, -0.23133469857397337)]
    [InlineData(-2d, -3d, -0.150385604327862, 0.23133469857397337)]
    public void MathTrig_AcscComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acsc(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, 0d, double.PositiveInfinity)]
    [InlineData(0.5d, 0d, 0d, 1.3169578969248166d)]
    [InlineData(1d, 0d, 0d)]
    [InlineData(2d, 0d, 1.0471975511965979d)] //PI / 3
    [InlineData(-0.5d, 0d, Math.PI, 1.3169578969248166d)]
    [InlineData(-1d, 0d, Math.PI)]
    [InlineData(-2d, 0d, Math.PI * 2 / 3)]
    [InlineData(double.PositiveInfinity, 0d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 0d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, 2d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 2d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, Math.PI / 2)]
    [InlineData(2d, double.NegativeInfinity, Math.PI / 2)]
    [InlineData(2d, 3d, 1.4204107224670346, 0.23133469857397337)]
    [InlineData(2d, -3d, 1.4204107224670346, -0.23133469857397337)]
    [InlineData(-2d, 3d, 1.7211819311227585, 0.23133469857397337)]
    [InlineData(-2d, -3d, 1.7211819311227585, -0.23133469857397337)]
    public void MathTrig_AsecComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Asec(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, Math.PI / 2)]
    [InlineData(double.Epsilon, 0d, Math.PI / 2 - double.Epsilon)]
    [InlineData(1E-10, 0d, 1.5707963266948965d, 0)]
    [InlineData(-1E-10, 0d, Math.PI - 1.5707963266948965d, 0)]
    [InlineData(-double.Epsilon, 0d, Math.PI / 2 - double.Epsilon)]
    [InlineData(0.5d, 0d, 1.1071487177940904d)]
    [InlineData(1d, 0d, Math.PI / 4)]
    [InlineData(2d, 0d, 0.46364760900080609d)]
    [InlineData(-0.5d, 0d, Math.PI - 1.1071487177940904d)]
    [InlineData(-1d, 0d, Math.PI - Math.PI / 4)]
    [InlineData(-2d, 0d, Math.PI - 0.46364760900080609d)]
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, Math.PI)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, Math.PI)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, 0.16087527719832112, -0.22907268296853883)]
    [InlineData(2d, -3d, 0.16087527719832112, 0.22907268296853883)]
    [InlineData(-2d, 3d, 2.980717376391472, -0.22907268296853883)]
    [InlineData(-2d, -3d, 2.980717376391472, 0.22907268296853883)]
    public void MathTrig_AcotComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acot(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, double.Epsilon)]
    [InlineData(1E-10, 0d, 1E-10)]
    [InlineData(-1E-10, 0d, -1E-10)]
    [InlineData(0.5d, 0d, 0.52109530549374738d)]
    [InlineData(1d, 0d, 1.1752011936438014d)]
    [InlineData(2d, 0d, 3.6268604078470186d)]
    [InlineData(10, 0d, 11013.232874703393, 0d)]
    [InlineData(100, 0d, 1.3440585709080678E+43d, 0d)]
    [InlineData(-0.5d, 0d, -0.52109530549374738d)]
    [InlineData(-1d, 0d, -1.1752011936438014d)]
    [InlineData(-2d, 0d, -3.6268604078470186d)]
    [InlineData(double.PositiveInfinity, 0d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, 2d, double.NegativeInfinity, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 2d, double.PositiveInfinity, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, -3.5905645899857794d, 0.5309210862485197d)]
    [InlineData(2d, -3d, -3.5905645899857794d, -0.5309210862485197d)]
    [InlineData(-2d, 3d, 3.5905645899857794d, 0.5309210862485197d)]
    [InlineData(-2d, -3d, 3.5905645899857794d, -0.5309210862485197d)]
    public void MathTrig_SinhComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Sinh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 1d)]
    [InlineData(double.Epsilon, 0d, 1d)]
    [InlineData(0.5d, 0d, 1.1276259652063807d)]
    [InlineData(1d, 0d, 1.5430806348152437d)]
    [InlineData(2d, 0d, 3.7621956910836314d)]
    [InlineData(-0.5d, 0d, 1.1276259652063807d)]
    [InlineData(-1d, 0d, 1.5430806348152437d)]
    [InlineData(-2d, 0d, 3.7621956910836314d)]
    [InlineData(double.PositiveInfinity, 0d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, 2d, double.NegativeInfinity, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 2d, double.NegativeInfinity, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, -3.7245455049153224, 0.5118225699873845)]
    [InlineData(2d, -3d, -3.7245455049153224, -0.5118225699873845)]
    [InlineData(-2d, 3d, -3.7245455049153224, -0.5118225699873845)]
    [InlineData(-2d, -3d, -3.7245455049153224, 0.5118225699873845)]
    public void MathTrig_CoshComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Cosh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, double.Epsilon)]
    [InlineData(0.5d, 0d, 0.46211715726000974d)]
    [InlineData(1d, 0d, 0.76159415595576485d)]
    [InlineData(2d, 0d, 0.9640275800758169d)]
    [InlineData(-0.5d, 0d, -0.46211715726000974d)]
    [InlineData(-1d, 0d, -0.76159415595576485d)]
    [InlineData(-2d, 0d, -0.9640275800758169d)]
    [InlineData(double.PositiveInfinity, 0d, 1d)]
    [InlineData(double.NegativeInfinity, 0d, -1d)]
    [InlineData(double.PositiveInfinity, 2d, 1d)]
    [InlineData(double.NegativeInfinity, 2d, -1d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, 0.9653858790221331, -0.009884375038322494)]
    [InlineData(2d, -3d, 0.9653858790221331, 0.009884375038322494)]
    [InlineData(-2d, 3d, -0.9653858790221331, -0.009884375038322494)]
    [InlineData(-2d, -3d, -0.9653858790221331, 0.009884375038322494)]
    public void MathTrig_TanhComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Tanh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(0.5d, 0d, 1 / 0.52109530549374738d)]
    [InlineData(1d, 0d, 1 / 1.1752011936438014d)]
    [InlineData(2d, 0d, 1 / 3.6268604078470186d)]
    [InlineData(-0.5d, 0d, 1 / -0.52109530549374738d)]
    [InlineData(-1d, 0d, 1 / -1.1752011936438014d)]
    [InlineData(-2d, 0d, 1 / -3.6268604078470186d)]
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, 0d)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, 0d)]
    [InlineData(double.PositiveInfinity, -2d, 0d)]
    [InlineData(double.NegativeInfinity, -2d, 0d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, -0.2725486614629402, -0.04030057885689153)]
    [InlineData(2d, -3d, -0.2725486614629402, 0.04030057885689153)]
    [InlineData(-2d, 3d, 0.2725486614629402, -0.04030057885689153)]
    [InlineData(-2d, -3d, 0.2725486614629402, 0.04030057885689153)]
    public void MathTrig_CschComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Csch(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 1d)]
    [InlineData(double.Epsilon, 0d, 1d)]
    [InlineData(0.5d, 0d, 1 / 1.1276259652063807d)]
    [InlineData(1d, 0d, 1 / 1.5430806348152437d)]
    [InlineData(2d, 0d, 1 / 3.7621956910836314d)]
    [InlineData(-0.5d, 0d, 1 / 1.1276259652063807d)]
    [InlineData(-1d, 0d, 1 / 1.5430806348152437d)]
    [InlineData(-2d, 0d, 1 / 3.7621956910836314d)]
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, 0d)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, 0d)]
    [InlineData(double.PositiveInfinity, -2d, 0d)]
    [InlineData(double.NegativeInfinity, -2d, 0d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, -0.2635129751583893, -0.036211636558768516)]
    [InlineData(2d, -3d, -0.2635129751583893, 0.036211636558768516)]
    [InlineData(-2d, 3d, -0.2635129751583893, 0.036211636558768516)]
    [InlineData(-2d, -3d, -0.2635129751583893, -0.036211636558768516)]
    public void MathTrig_SechComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Sech(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(0.5d, 0d, 1 / 0.46211715726000974d)]
    [InlineData(1d, 0d, 1 / 0.76159415595576485d)]
    [InlineData(2d, 0d, 1 / 0.9640275800758169d)]
    [InlineData(-0.5d, 0d, 1 / -0.46211715726000974d)]
    [InlineData(-1d, 0d, 1 / -0.76159415595576485d)]
    [InlineData(-2d, 0d, 1 / -0.9640275800758169d)]
    [InlineData(double.PositiveInfinity, 0d, 1d)]
    [InlineData(double.NegativeInfinity, 0d, -1d)]
    [InlineData(double.PositiveInfinity, 2d, 1d)]
    [InlineData(double.NegativeInfinity, 2d, -1d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(2d, 3d, 1.0357466377649955, 0.0106047834703371)]
    [InlineData(2d, -3d, 1.0357466377649955, -0.0106047834703371)]
    [InlineData(-2d, 3d, -1.0357466377649955, 0.0106047834703371)]
    [InlineData(-2d, -3d, -1.0357466377649955, -0.0106047834703371)]
    public void MathTrig_CothComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Coth(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, 0d)]
    [InlineData(0.5d, 0d, 0.48121182505960347d)]
    [InlineData(1d, 0d, 0.88137358701954294d)]
    [InlineData(2d, 0d, 1.4436354751788103d)]
    [InlineData(-0.5d, 0d, -0.48121182505960347d)]
    [InlineData(-1d, 0d, -0.88137358701954294d)]
    [InlineData(-2d, 0d, -1.4436354751788103d)]
    [InlineData(double.PositiveInfinity, 0d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, 2d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 2d, double.NegativeInfinity)]
#if NET9_0_OR_GREATER
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, -Math.PI / 4)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NegativeInfinity, Math.PI / 4)]
#else
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
#endif
    [InlineData(2d, double.PositiveInfinity, double.PositiveInfinity, Math.PI / 4)]
    [InlineData(2d, double.NegativeInfinity, double.PositiveInfinity, -Math.PI / 4)]
    [InlineData(double.MinValue, 0d, double.NegativeInfinity)]
    [InlineData(double.MaxValue, 0d, double.PositiveInfinity)]
    [InlineData(2d, 3d, 1.9686379257930964, 0.9646585044076028)]
    [InlineData(2d, -3d, 1.9686379257930964, -0.9646585044076028)]
    [InlineData(-2d, 3d, -1.9686379257930964, 0.9646585044076028)]
    [InlineData(-2d, -3d, -1.9686379257930964, -0.9646585044076028)]
    public void MathTrig_AsinhComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Asinh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d, Math.PI / 2)]
    [InlineData(double.Epsilon, 0d, 0d, Math.PI / 2)]
    [InlineData(1d, 0d, 0d)]
    [InlineData(2d, 0d, 1.3169578969248166d)]
    [InlineData(-1d, 0d, 0d, Math.PI)]
    [InlineData(-2d, 0d, -1.3169578969248164d, Math.PI)]
    [InlineData(double.PositiveInfinity, 0d, double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity, 0d, double.PositiveInfinity, double.NaN)]
    [InlineData(double.PositiveInfinity, 2d, double.PositiveInfinity, Math.PI / 4)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)] //∞−2∞i−∞^2
    [InlineData(2d, double.PositiveInfinity, double.PositiveInfinity, Math.PI / 4)]
    [InlineData(2d, double.NegativeInfinity, double.PositiveInfinity, -Math.PI / 4)]
    [InlineData(double.MinValue, 0d, double.PositiveInfinity)]
    [InlineData(double.MaxValue, 0d, double.PositiveInfinity)]
    [InlineData(2d, 3d, 1.9833870299165355, 1.0001435424737972)]
    [InlineData(2d, -3d, 1.9833870299165355, -1.0001435424737972)]
#if NET9_0_OR_GREATER
    [InlineData(0.5d, 0d, -1.1102230246251565E-16, Math.PI / 3)]
    [InlineData(-0.5d, 0d, -1.1102230246251565E-16, 2.0943951023931957d)]
    [InlineData(-2d, double.PositiveInfinity, double.PositiveInfinity, double.NaN)]
    [InlineData(-200d, double.PositiveInfinity, double.PositiveInfinity, double.NaN)]
    [InlineData(-2d, double.NegativeInfinity, double.PositiveInfinity, double.NaN)]
    [InlineData(-200d, double.NegativeInfinity, double.PositiveInfinity, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.PositiveInfinity, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity, -Math.PI / 4)]
    [InlineData(-2d, 3d, -1.9833870299165357, -2.1414491111159957)]
    [InlineData(-2d, -3d, -1.9833870299165357, 2.1414491111159957)]
#else
    [InlineData(0.5d, 0d, 0d, Math.PI / 3)]
    [InlineData(-0.5d, 0d, 0d, 2.0943951023931957d)]
    [InlineData(-2d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(-200d, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(-2d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(-200d, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, 2d, double.NaN, double.NaN)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(-2d, 3d, -1.9833870299165355, -2.1414491111159957)]
    [InlineData(-2d, -3d, -1.9833870299165355, 2.1414491111159957)]
#endif
    public void MathTrig_AcoshComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acosh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d)]
    [InlineData(double.Epsilon, 0d, 0d)]
    [InlineData(1d, 0d, double.PositiveInfinity)]
    [InlineData(2d, 0d, 0.5493061443340549, -Math.PI / 2)]
    [InlineData(0.5d, 0d, 0.54930614433405489d)]
    [InlineData(-0.5d, 0d, -0.54930614433405489d)]
    [InlineData(-1d, 0d, double.NegativeInfinity)]
    [InlineData(-2d, 0d, -0.5493061443340549, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, 0d, 0d, -Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 0d, 0d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, 2d, 0d, -Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 2d, 0d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0d, Math.PI / 2)]
    [InlineData(2d, double.NegativeInfinity, 0d, -Math.PI / 2)]
    [InlineData(double.MinValue, 0d, 0d, Math.PI / 2)]
    [InlineData(double.MaxValue, 0d, 0d, -Math.PI / 2)]
    [InlineData(-2d, double.PositiveInfinity, 0d, Math.PI / 2)]
    [InlineData(-200d, double.PositiveInfinity, 0d, Math.PI / 2)]
    [InlineData(-2d, double.NegativeInfinity, 0d, -Math.PI / 2)]
    [InlineData(-200d, double.NegativeInfinity, 0d, -Math.PI / 2)]
    [InlineData(2d, 3d, 0.14694666622552977, 1.3389725222944935)]
    [InlineData(2d, -3d, 0.14694666622552977, -1.3389725222944935)]
    [InlineData(-2d, 3d, -0.14694666622552977, 1.3389725222944935)]
    [InlineData(-2d, -3d, -0.14694666622552977, -1.3389725222944935)]
    public void MathTrig_AtanhComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Atanh(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(-double.Epsilon, 0d, double.NegativeInfinity)]
    [InlineData(0.5d, 0d, 1.4436354751788103d)]
    [InlineData(1d, 0d, 0.88137358701954294d)]
    [InlineData(2d, 0d, 0.48121182505960347d)]
    [InlineData(-0.5d, 0d, -1.4436354751788103d)]
    [InlineData(-1d, 0d, -0.88137358701954294d)]
    [InlineData(-2d, 0d, -0.48121182505960347d)]
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, 0d)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, 0d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, 0d)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, 0d)]
    [InlineData(2d, double.PositiveInfinity, 0d)]
    [InlineData(2d, double.NegativeInfinity, 0d)]
    [InlineData(double.MinValue, 0d, 0d)]
    [InlineData(double.MaxValue, 0d, 0d)]
    [InlineData(-2d, double.PositiveInfinity, 0d)]
    [InlineData(-200d, double.PositiveInfinity, 0d)]
    [InlineData(-2d, double.NegativeInfinity, 0d)]
    [InlineData(-200d, double.NegativeInfinity, 0d)]
#if NET9_0_OR_GREATER
    [InlineData(2d, 3d, 0.15735549884498545, -0.22996290237720785)]
    [InlineData(2d, -3d, 0.15735549884498545, 0.22996290237720785)]
    [InlineData(-2d, 3d, -0.15735549884498545, -0.22996290237720785)]
    [InlineData(-2d, -3d, -0.15735549884498545, 0.22996290237720785)]
#else
    [InlineData(2d, 3d, 0.15735549884498526, -0.22996290237720785)]
    [InlineData(2d, -3d, 0.15735549884498526, 0.22996290237720785)]
    [InlineData(-2d, 3d, -0.15735549884498526, -0.22996290237720785)]
    [InlineData(-2d, -3d, -0.15735549884498526, 0.22996290237720785)]
#endif
    public void MathTrig_AcschComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acsch(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, double.NaN, double.NaN)]
    [InlineData(double.Epsilon, 0d, double.PositiveInfinity)]
    [InlineData(-double.Epsilon, 0d, double.PositiveInfinity, Math.PI)]
    [InlineData(0.5d, 0d, 1.3169578969248166d)]
    [InlineData(1d, 0d, 0d)]
    [InlineData(-0.5d, 0d, -1.3169578969248164d, Math.PI)]
    [InlineData(-1d, 0d, 0d, Math.PI)]
#if NET9_0_OR_GREATER
    [InlineData(2d, 0d, -1.1102230246251565E-16, Math.PI / 3)]
    [InlineData(-2d, 0d, -1.1102230246251565E-16, 2.0943951023931957d)] //2PI / 3
#else
    [InlineData(2d, 0d, 0d, Math.PI / 3)]
    [InlineData(-2d, 0d, 0d, 2.0943951023931957d)] //2PI / 3
#endif
    [InlineData(double.PositiveInfinity, 0d, 0d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 0d, 0d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, 2d, 0d, Math.PI / 2)]
    [InlineData(double.NegativeInfinity, 2d, 0d, Math.PI / 2)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)] //∞−2∞i−∞^2
    [InlineData(2d, double.PositiveInfinity, 0d, -Math.PI / 2)]
    [InlineData(2d, double.NegativeInfinity, 0d, Math.PI / 2)]
    [InlineData(double.MinValue, 0d, 0d, Math.PI / 2)]
    [InlineData(double.MaxValue, 0d, 0d, Math.PI / 2)]
    [InlineData(-2d, double.PositiveInfinity, 0d, -Math.PI / 2)]
    [InlineData(-200d, double.PositiveInfinity, 0d, -Math.PI / 2)]
    [InlineData(-2d, double.NegativeInfinity, 0d, Math.PI / 2)]
    [InlineData(-200d, double.NegativeInfinity, 0d, Math.PI / 2)]
    [InlineData(2d, 3d, 0.23133469857397337, -1.4204107224670346)]
    [InlineData(2d, -3d, 0.23133469857397337, 1.4204107224670346)]
    [InlineData(-2d, 3d, -0.23133469857397346, 1.7211819311227585)]
    [InlineData(-2d, -3d, -0.23133469857397346, -1.7211819311227585)]
    public void MathTrig_AsechComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Asech(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(double.NaN, 0d, double.NaN, double.NaN)]
    [InlineData(0d, 0d, 0d, -Math.PI / 2)]
    [InlineData(double.Epsilon, 0d, 0d, -Math.PI / 2)]
    [InlineData(0.5d, 0d, 0.5493061443340549, -Math.PI / 2)]
    [InlineData(1d, 0d, double.PositiveInfinity)]
    [InlineData(2d, 0d, 0.54930614433405489d)]
    [InlineData(-0.5d, 0d, -0.5493061443340549, -Math.PI / 2)]
    [InlineData(-1d, 0d, double.NegativeInfinity)]
    [InlineData(-2d, 0d, -0.54930614433405489d)]
    [InlineData(double.PositiveInfinity, 0d, 0d)]
    [InlineData(double.NegativeInfinity, 0d, 0d)]
    [InlineData(double.PositiveInfinity, 2d, 0d)]
    [InlineData(double.NegativeInfinity, 2d, 0d)]
    [InlineData(double.PositiveInfinity, double.NegativeInfinity, double.NaN, double.NaN)]
    [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN)]
    [InlineData(2d, double.PositiveInfinity, 0d)]
    [InlineData(2d, double.NegativeInfinity, 0d)]
    [InlineData(double.MinValue, 0d, 0d)]
    [InlineData(double.MaxValue, 0d, 0d)]
    [InlineData(-2d, double.PositiveInfinity, 0d)]
    [InlineData(-200d, double.PositiveInfinity, 0d)]
    [InlineData(-2d, double.NegativeInfinity, 0d)]
    [InlineData(-200d, double.NegativeInfinity, 0d)]
    [InlineData(2d, 3d, 0.14694666622552977, -0.23182380450040305)]
    [InlineData(2d, -3d, 0.14694666622552977, 0.23182380450040305)]
    [InlineData(-2d, 3d, -0.14694666622552977, -0.23182380450040305)]
    [InlineData(-2d, -3d, -0.14694666622552977, 0.23182380450040305)]
    public void MathTrig_AcothComplexParam_ExpectedValue(double a, double b, double expectedReal, double expectedImaginary = 0)
    {
        var expectedValue = new Complex(expectedReal, expectedImaginary);

        var value = MathTrig.Acoth(new Complex(a, b));

        Assert.Equal(expectedValue, value);
    }
}