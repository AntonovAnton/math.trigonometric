#if NET11_0_OR_GREATER

using System.Numerics;

namespace MathTrigonometric.Tests;

// ReSharper disable once InconsistentNaming
public partial class MathTrigTests
{
    public static readonly TheoryData<string> GenericComplexFunctions =
    [
        "Sin", "Cos", "Tan", "Csc", "Sec", "Cot",
        "Asin", "Acos", "Atan", "Acsc", "Asec", "Acot",
        "Sinh", "Cosh", "Tanh", "Csch", "Sech", "Coth",
        "Asinh", "Acosh", "Atanh", "Acsch", "Asech", "Acoth"
    ];

    private static readonly (double Re, double Im)[] FiniteInputs =
    [
        (2d, 3d), (2d, -3d), (-2d, 3d), (-2d, -3d),
        (1d, 0d), (-1d, 0d), (0.5d, 0.5d), (-0.5d, 0.25d), (0.3d, -1.7d)
    ];

    private static readonly (double Re, double Im)[] EdgeInputs =
    [
        (0d, 0d), (1d, 0d), (-1d, 0d),
        (double.NaN, 0d), (0d, double.NaN),
        (double.PositiveInfinity, 0d), (double.NegativeInfinity, 0d),
        (0d, double.PositiveInfinity), (0d, double.NegativeInfinity),
        (2d, double.PositiveInfinity), (2d, double.NegativeInfinity),
        (double.PositiveInfinity, 2d), (double.NegativeInfinity, 2d),
        (double.PositiveInfinity, double.NegativeInfinity), (double.NegativeInfinity, double.PositiveInfinity)
    ];

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexDecimal64_MatchesDouble(string function)
        => AssertMatchesDouble<Decimal64>(function, FiniteInputs, 1e-12);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexDecimal128_MatchesDouble(string function)
        => AssertMatchesDouble<Decimal128>(function, FiniteInputs, 1e-12);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexDecimal32_MatchesDouble(string function)
        => AssertMatchesDouble<Decimal32>(function, FiniteInputs, 1e-4);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexFloat_MatchesDouble(string function)
        => AssertMatchesDouble<float>(function, FiniteInputs, 1e-4);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexHalf_MatchesDouble(string function)
        => AssertMatchesDouble<Half>(function, FiniteInputs, 4e-3);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexBFloat16_MatchesDouble(string function)
        => AssertMatchesDouble<BFloat16>(function, FiniteInputs, 3e-2);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexDouble_EqualsComplex(string function)
        => AssertMatchesDouble<double>(function, FiniteInputs, 1e-15);

    [Theory]
    [MemberData(nameof(GenericComplexFunctions))]
    public void MathTrig_GenericComplexDecimal64_EdgeCasesMatchDouble(string function)
        => AssertMatchesDouble<Decimal64>(function, EdgeInputs, 1e-12);

    [Fact]
    public void MathTrig_GenericComplexDecimal64_ExactIdentities()
    {
        var zero = Complex<Decimal64>.Zero;
        Assert.Equal(Complex<Decimal64>.Zero, MathTrig.Sin(zero));
        Assert.Equal(Complex<Decimal64>.One, MathTrig.Cos(zero));
        Assert.Equal(Complex<Decimal64>.Zero, MathTrig.Tan(zero));
        Assert.Equal(Complex<Decimal64>.One, MathTrig.Sec(zero));
        Assert.Equal(Complex<Decimal64>.Zero, MathTrig.Sinh(zero));
        Assert.Equal(Complex<Decimal64>.One, MathTrig.Cosh(zero));
        Assert.Equal(Complex<Decimal64>.Zero, MathTrig.Tanh(zero));
        Assert.Equal(Complex<Decimal64>.One, MathTrig.Sech(zero));
        Assert.Equal(new Complex<Decimal64>(Decimal64.Pi / (Decimal64)2, Decimal64.Zero), MathTrig.Acot(zero));
    }

    private static void AssertMatchesDouble<T>(string function, (double Re, double Im)[] inputs, double tolerance)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        foreach (var (re, im) in inputs)
        {
            var expected = ApplyDouble(function, new Complex(re, im));
            var actual = ApplyGeneric(function, new Complex<T>(T.CreateTruncating(re), T.CreateTruncating(im)));

            AssertClose(expected.Real, double.CreateTruncating(actual.Real), tolerance,
                $"{function}({re}, {im}) real part for {typeof(T).Name}");
            AssertClose(expected.Imaginary, double.CreateTruncating(actual.Imaginary), tolerance,
                $"{function}({re}, {im}) imaginary part for {typeof(T).Name}");
        }
    }

    private static void AssertClose(double expected, double actual, double tolerance, string message)
    {
        if (double.IsNaN(expected) || double.IsInfinity(expected))
        {
            Assert.True(expected.Equals(actual), $"{message}: expected {expected}, actual {actual}");
            return;
        }

        var diff = Math.Abs(expected - actual);
        Assert.True(diff <= tolerance * Math.Max(1d, Math.Abs(expected)),
            $"{message}: expected {expected:R}, actual {actual:R}, diff {diff:E3}");
    }

    private static Complex ApplyDouble(string function, Complex z) => function switch
    {
        "Sin" => MathTrig.Sin(z),
        "Cos" => MathTrig.Cos(z),
        "Tan" => MathTrig.Tan(z),
        "Csc" => MathTrig.Csc(z),
        "Sec" => MathTrig.Sec(z),
        "Cot" => MathTrig.Cot(z),
        "Asin" => MathTrig.Asin(z),
        "Acos" => MathTrig.Acos(z),
        "Atan" => MathTrig.Atan(z),
        "Acsc" => MathTrig.Acsc(z),
        "Asec" => MathTrig.Asec(z),
        "Acot" => MathTrig.Acot(z),
        "Sinh" => MathTrig.Sinh(z),
        "Cosh" => MathTrig.Cosh(z),
        "Tanh" => MathTrig.Tanh(z),
        "Csch" => MathTrig.Csch(z),
        "Sech" => MathTrig.Sech(z),
        "Coth" => MathTrig.Coth(z),
        "Asinh" => MathTrig.Asinh(z),
        "Acosh" => MathTrig.Acosh(z),
        "Atanh" => MathTrig.Atanh(z),
        "Acsch" => MathTrig.Acsch(z),
        "Asech" => MathTrig.Asech(z),
        "Acoth" => MathTrig.Acoth(z),
        _ => throw new ArgumentOutOfRangeException(nameof(function), function, null)
    };

    private static Complex<T> ApplyGeneric<T>(string function, Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T> => function switch
    {
        "Sin" => MathTrig.Sin(z),
        "Cos" => MathTrig.Cos(z),
        "Tan" => MathTrig.Tan(z),
        "Csc" => MathTrig.Csc(z),
        "Sec" => MathTrig.Sec(z),
        "Cot" => MathTrig.Cot(z),
        "Asin" => MathTrig.Asin(z),
        "Acos" => MathTrig.Acos(z),
        "Atan" => MathTrig.Atan(z),
        "Acsc" => MathTrig.Acsc(z),
        "Asec" => MathTrig.Asec(z),
        "Acot" => MathTrig.Acot(z),
        "Sinh" => MathTrig.Sinh(z),
        "Cosh" => MathTrig.Cosh(z),
        "Tanh" => MathTrig.Tanh(z),
        "Csch" => MathTrig.Csch(z),
        "Sech" => MathTrig.Sech(z),
        "Coth" => MathTrig.Coth(z),
        "Asinh" => MathTrig.Asinh(z),
        "Acosh" => MathTrig.Acosh(z),
        "Atanh" => MathTrig.Atanh(z),
        "Acsch" => MathTrig.Acsch(z),
        "Asech" => MathTrig.Asech(z),
        "Acoth" => MathTrig.Acoth(z),
        _ => throw new ArgumentOutOfRangeException(nameof(function), function, null)
    };
}

#endif