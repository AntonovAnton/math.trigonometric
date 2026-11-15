using System.Numerics;

namespace MathTrigonometric.Tests;

// Property-based checks for the complex functions: principal values, inverse identities,
// signed-zero branch-cut conventions (IEEE 754 / ISO C99 Annex G) and numerical robustness.
// ReSharper disable once InconsistentNaming
public partial class MathTrigTests
{
    private static readonly double[] GridValues = [-3d, -1.5d, -1d, -0.5d, -1e-3d, 0.25d, 0.9d, 1.1d, 2d, 10d];

    public static TheoryData<double, double> ComplexGrid()
    {
        var data = new TheoryData<double, double>();
        foreach (var a in GridValues)
        foreach (var b in GridValues)
            data.Add(a, b);
        return data;
    }

    private static void AssertComplexClose(Complex expected, Complex actual, double tolerance = 1e-12)
    {
        var scale = Math.Max(1d, Complex.Abs(expected));
        Assert.True(Complex.Abs(expected - actual) <= tolerance * scale, $"expected {expected}, actual {actual}");
    }

    [Theory]
    [MemberData(nameof(ComplexGrid))]
    public void MathTrig_ComplexInverseFunctions_ArePrincipalValues(double a, double b)
    {
        var z = new Complex(a, b);

        var asin = MathTrig.Asin(z);
        Assert.InRange(asin.Real, -Math.PI / 2, Math.PI / 2);

        var acos = MathTrig.Acos(z);
        Assert.InRange(acos.Real, 0d, Math.PI);

        var atan = MathTrig.Atan(z);
        Assert.InRange(atan.Real, -Math.PI / 2, Math.PI / 2);

        var asinh = MathTrig.Asinh(z);
        Assert.InRange(asinh.Imaginary, -Math.PI / 2, Math.PI / 2);

        var acosh = MathTrig.Acosh(z);
        Assert.True(acosh.Real >= 0d, $"Acosh({z}) = {acosh} has a negative real part");
        Assert.InRange(acosh.Imaginary, -Math.PI, Math.PI);

        var atanh = MathTrig.Atanh(z);
        Assert.InRange(atanh.Imaginary, -Math.PI / 2, Math.PI / 2);

        var asech = MathTrig.Asech(z);
        Assert.True(asech.Real >= 0d, $"Asech({z}) = {asech} has a negative real part");

        var acot = MathTrig.Acot(z);
        Assert.InRange(acot.Real, 0d, Math.PI);
    }

    [Theory]
    [MemberData(nameof(ComplexGrid))]
    public void MathTrig_ComplexInverseFunctions_InvertTheirFunctions(double a, double b)
    {
        var z = new Complex(a, b);

        AssertComplexClose(z, MathTrig.Sin(MathTrig.Asin(z)));
        AssertComplexClose(z, MathTrig.Cos(MathTrig.Acos(z)));
        AssertComplexClose(z, MathTrig.Tan(MathTrig.Atan(z)));
        AssertComplexClose(z, MathTrig.Csc(MathTrig.Acsc(z)));
        AssertComplexClose(z, MathTrig.Sec(MathTrig.Asec(z)));
        AssertComplexClose(z, MathTrig.Cot(MathTrig.Acot(z)));
        AssertComplexClose(z, MathTrig.Sinh(MathTrig.Asinh(z)));
        AssertComplexClose(z, MathTrig.Cosh(MathTrig.Acosh(z)));
        AssertComplexClose(z, MathTrig.Tanh(MathTrig.Atanh(z)));
        AssertComplexClose(z, MathTrig.Csch(MathTrig.Acsch(z)));
        AssertComplexClose(z, MathTrig.Sech(MathTrig.Asech(z)));
        AssertComplexClose(z, MathTrig.Coth(MathTrig.Acoth(z)));
    }

    [Theory]
    [MemberData(nameof(ComplexGrid))]
    public void MathTrig_ComplexInverseFunctions_SatisfyIdentities(double a, double b)
    {
        var z = new Complex(a, b);

        // acos z = π/2 − asin z, and acot z = π/2 − atan z (real part in [0, π])
        AssertComplexClose(Math.PI / 2 - MathTrig.Asin(z), MathTrig.Acos(z));
        AssertComplexClose(Math.PI / 2 - MathTrig.Atan(z), MathTrig.Acot(z));

        // asinh z = −i asin(iz), atanh z = −i atan(iz)
        var iz = new Complex(-b, a);
        var asin = MathTrig.Asin(iz);
        AssertComplexClose(new Complex(asin.Imaginary, -asin.Real), MathTrig.Asinh(z));
        var atan = MathTrig.Atan(iz);
        AssertComplexClose(new Complex(atan.Imaginary, -atan.Real), MathTrig.Atanh(z));
    }

    public static TheoryData<string, double> BranchCutPoints()
    {
        var data = new TheoryData<string, double>();
        foreach (var fn in new[] { "Asin", "Acos", "Atanh", "Acosh", "Acsc", "Asec", "Acoth", "Asech" })
        foreach (var x in new[] { -3d, -2d, -0.5d, 0.5d, 2d, 3d })
            data.Add(fn, x);
        return data;
    }

    // On a real-axis branch cut, x + i0 and x − i0 give the limits from above and from below,
    // so the results are complex conjugates of each other (C99: f(conj z) = conj f(z)).
    [Theory]
    [MemberData(nameof(BranchCutPoints))]
    public void MathTrig_ComplexBranchCut_SignOfZeroSelectsSide(string fn, double x)
    {
        Func<Complex, Complex> f = fn switch
        {
            "Asin" => MathTrig.Asin, "Acos" => MathTrig.Acos, "Atanh" => MathTrig.Atanh, "Acosh" => MathTrig.Acosh,
            "Acsc" => MathTrig.Acsc, "Asec" => MathTrig.Asec, "Acoth" => MathTrig.Acoth, "Asech" => MathTrig.Asech,
            _ => throw new ArgumentOutOfRangeException(nameof(fn))
        };

        var above = f(new Complex(x, 0d));
        var below = f(new Complex(x, -0d));

        Assert.Equal(Complex.Conjugate(above), below);

        // the +0 value is the limit from the upper half-plane
        AssertComplexClose(f(new Complex(x, 1e-12)), above, 1e-9);
    }

    [Fact]
    public void MathTrig_ComplexAcosh_NegativeRealAxis_IsPrincipalValue()
    {
        // acosh(−0.5) = i·2π/3 and acosh(−2) = ln(2 + √3) + iπ
        AssertComplexClose(new Complex(0d, 2 * Math.PI / 3), MathTrig.Acosh(new Complex(-0.5, 0d)));
        AssertComplexClose(new Complex(Math.Log(2 + Math.Sqrt(3)), Math.PI), MathTrig.Acosh(new Complex(-2d, 0d)));
    }

    [Fact]
    public void MathTrig_Complex_TinyArguments_KeepFullPrecision()
    {
        const double t = 1e-20;
        Assert.Equal(new Complex(t, 0d), MathTrig.Asin(new Complex(t, 0d)));
        Assert.Equal(new Complex(t, 0d), MathTrig.Atan(new Complex(t, 0d)));
        Assert.Equal(new Complex(t, 0d), MathTrig.Asinh(new Complex(t, 0d)));
        Assert.Equal(new Complex(t, 0d), MathTrig.Atanh(new Complex(t, 0d)));
        Assert.Equal(new Complex(0d, t), MathTrig.Asinh(new Complex(0d, t)));
        Assert.Equal(new Complex(0d, t), MathTrig.Tan(new Complex(0d, t)));

        // cot z ≈ 1/z: the denominator sin² x + sinh² y must not underflow
        AssertComplexClose(new Complex(5e199, -5e199), MathTrig.Cot(new Complex(1e-200, 1e-200)));
        Assert.Equal(new Complex(double.PositiveInfinity, 0d), MathTrig.Coth(new Complex(double.Epsilon, 0d)));
    }

    [Fact]
    public void MathTrig_Complex_LargeArguments_DoNotOverflowOrCancel()
    {
        // asinh(+0 − iY) = ln 2Y − iπ/2: the naive log(z + √(z² + 1)) cancels to log(0)
        AssertComplexClose(new Complex(Math.Log(2e150), -Math.PI / 2), MathTrig.Asinh(new Complex(0d, -1e150)));

        // acosh(±MaxValue) = ln(2·MaxValue) (+ iπ), not ∞
        var lnTwoMax = Math.Log(2) + Math.Log(double.MaxValue);
        AssertComplexClose(new Complex(lnTwoMax, 0d), MathTrig.Acosh(new Complex(double.MaxValue, 0d)));
        AssertComplexClose(new Complex(lnTwoMax, Math.PI), MathTrig.Acosh(new Complex(-double.MaxValue, 0d)));

        // sin(0.01 + 711i): the real part 0.01·cosh 711 ≈ 3e306 is finite although cosh 711 alone overflows
        var sin = MathTrig.Sin(new Complex(0.01, 711d));
        Assert.Equal(Math.Log(Math.Sin(0.01)) + 711d - Math.Log(2), Math.Log(sin.Real), 12);
        Assert.Equal(double.PositiveInfinity, sin.Imaginary);
    }

    [Fact]
    public void MathTrig_RealInverseHyperbolic_ExtremeArguments_AreAccurate()
    {
        // ln(x + √(x² ± 1)) overflows for large x and cancels for tiny x
        Assert.Equal(Math.Log(2e200), MathTrig.Asinh(1e200), 14);
        Assert.Equal(-Math.Log(2e200), MathTrig.Asinh(-1e200), 14);
        Assert.Equal(Math.Log(2e200), MathTrig.Acosh(1e200), 14);
        Assert.Equal(1e-20, MathTrig.Asinh(1e-20));
        Assert.Equal(1e-20, MathTrig.Atanh(1e-20));
        Assert.Equal(1e-20, MathTrig.Acoth(1e20));
        Assert.Equal(1e-20, MathTrig.Acsch(1e20));
        Assert.Equal(Math.Log(2e200), MathTrig.Acsch(1e-200), 14);
        Assert.Equal(Math.Log(2e200), MathTrig.Asech(1e-200), 14);

        // near 1, a − 1 is exact: acosh(1 + t) ≈ √(2t), acsc(1 + t) ≈ π/2 − √(2t), asec(1 + t) ≈ √(2t)
        const double x = 1 + 1e-12;
        const double t = x - 1; // exact: 1.000088900582341E-12
        Assert.Equal(Math.Sqrt(2 * t) * (1 - t / 12), MathTrig.Acosh(x), 1e-21);
        Assert.Equal(Math.Sqrt(2 * t) * (1 - 5 * t / 12), MathTrig.Asec(x), 1e-21);
        Assert.Equal(Math.PI / 2 - Math.Sqrt(2 * t) * (1 - 5 * t / 12), MathTrig.Acsc(x), 1e-15);

        // csch and sech beyond the overflow of sinh and cosh: 2e^−|x|
        Assert.Equal(2 * Math.Exp(-720d), MathTrig.Sech(720d));
        Assert.Equal(-2 * Math.Exp(-720d), MathTrig.Csch(-720d));
        Assert.Equal((float)(2 * Math.Exp(-100d)), MathTrig.Csch(100f));
        Assert.Equal((float)(2 * Math.Exp(-100d)), MathTrig.Sech(100f));
    }

    [Fact]
    public void MathTrig_ComplexTan_NearPole_IsAccurate()
    {
        // the double closest to π/2 is not a pole: tan(1.5707963267948966) = 1.633123935319537E+16
        Assert.Equal(new Complex(1.633123935319537E+16, 0d), MathTrig.Tan(new Complex(Math.PI / 2, 0d)));

        // tan(π/2 + 1e-10 i): cos² x + sinh² y is evaluated without cancellation.
        // With δ = π/2 − x = cos x (to full precision), tan(x + iy) = cot(δ − iy) = 1/(δ − iy) · (1 + O(|δ − iy|²)),
        // so the expected value is (δ + iy)/(δ² + y²) to within 1e-20 relative. The runtime's Complex.Sin/Complex.Cos
        // is not used as the reference: its quotient is inaccurate this close to the pole on some .NET versions.
        const double y = 1e-10;
        var delta = Math.Cos(Math.PI / 2);
        var expected = new Complex(delta, y) / (delta * delta + y * y);
        AssertComplexClose(expected, MathTrig.Tan(new Complex(Math.PI / 2, y)), 1e-14);
    }
}