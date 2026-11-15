using System;
using System.Numerics;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;

/// <summary>
///     This class provides implementations of all trigonometric functions, including basic trigonometric functions (sin,
///     cos, tan, asin, acos, atan), their hyperbolic counterparts (sinh, cosh, tanh, asinh, acosh, atanh), and are missing
///     in .NET: cot, sec, csc, acot, asec, acsc, coth, sech, csch, acoth, asech, acsch.
/// </summary>
public static partial class MathTrig
{
    #region Fundamental Trigonometric Functions

    /// <summary>
    ///     Sine of the angle is ratio of the opposite leg to hypotenuse.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The sine of the input angle in range: [-1, 1].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Sin(double a)
        => Math.Sin(a);

    /// <summary>
    ///     Cosine of the angle is ratio of the adjacent leg to hypotenuse.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosine of the input angle in range: [-1, 1].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Cos(double a)
        => Math.Cos(a);

    /// <summary>
    ///     Tangent of the angle is ratio of the opposite leg to adjacent one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The tangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Tan(double a)
    {
        var cos = Math.Cos(a);
        if (cos == 0.0)
            return double.NaN;

        return Math.Sin(a) / cos;
    }

    /// <summary>
    ///     Cosecant of the angle is ratio of the hypotenuse to opposite leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosecant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Csc(double a)
    {
        var sin = Math.Sin(a);
        if (sin == 0.0)
            return double.NaN;

        return 1.0 / sin;
    }

    /// <summary>
    ///     Secant of the angle is ratio of the hypotenuse to adjacent leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The secant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Sec(double a)
    {
        var cos = Math.Cos(a);
        if (cos == 0.0)
            return double.NaN;

        return 1.0 / cos;
    }

    /// <summary>
    ///     Cotangent of the angle is ratio of the adjacent leg to opposite one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cotangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Cot(double a)
    {
        var sin = Math.Sin(a);
        if (sin == 0.0)
            return double.NaN;

        return Math.Cos(a) / sin;
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine is inverse of the <see cref="Sin(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Asin(double d)
        => Math.Asin(d);

    /// <summary>
    ///     Arc cosine is inverse of the <see cref="Cos(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acos(double d)
        => Math.Acos(d);

    /// <summary>
    ///     Arc tangent is inverse of the <see cref="Tan(double)" /> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (−π/2, π/2).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Double.NaN" />,
    ///     −π/2 if <paramref name="d" /> equals <see cref="F:System.Double.NegativeInfinity" />,
    ///     π/2 if <paramref name="d" /> equals <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Atan(double d)
        => Math.Atan(d);

    /// <summary>
    ///     Arc cosecant is inverse of the <see cref="Csc(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, 0)∪(0, π/2].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns 0 if <paramref name="d" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acsc(double d)
    {
        var a = Math.Abs(d);
        if (!(a >= 1.0))
            return double.NaN;

        // asin(1/d) = atan(1/√(d² − 1)); a − 1 is exact near 1, where asin(1/d) would amplify the rounding of 1/d
        return CopySign(Math.Atan2(1.0, Math.Sqrt(a - 1.0) * Math.Sqrt(a + 1.0)), d);
    }

    /// <summary>
    ///     Arc secant is inverse of the <see cref="Sec(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π/2)∪(π/2, π].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns π/2 if <paramref name="d" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Asec(double d)
    {
        var a = Math.Abs(d);
        if (!(a >= 1.0))
            return double.NaN;

        // acos(1/d) = atan2(√(d² − 1), sign(d)); a − 1 is exact near 1, where acos(1/d) would amplify the rounding of 1/d
        return Math.Atan2(Math.Sqrt(a - 1.0) * Math.Sqrt(a + 1.0), IsNegative(d) ? -1.0 : 1.0);
    }

    /// <summary>
    ///     Arc cotangent is inverse of the <see cref="Coth(double)" />> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (0, π).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Double.NaN" />,
    ///     π if <paramref name="d" /> equals <see cref="F:System.Double.NegativeInfinity" />,
    ///     0 if <paramref name="d" /> equals <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acot(double d)
    {
        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return Math.PI - Math.Atan(1.0 / -d);

        return Math.Atan(1.0 / d);
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine is defined as Sinh(x) = (e^x − e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />,
    ///     <see cref="F:System.Double.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NegativeInfinity" />,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Sinh(double x)
        => Math.Sinh(x);

    /// <summary>
    ///     Hyperbolic cosine is defined as Cosh(x) = (e^x + e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: [1, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NegativeInfinity" />,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Cosh(double x)
        => Math.Cosh(x);

    /// <summary>
    ///     Hyperbolic tangent is defined as Tanh(x) = (e^x − e^−x)/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (-1, 1).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />,
    ///     -1 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Tanh(double x)
        => Math.Tanh(x);

    /// <summary>
    ///     Hyperbolic cosecant is defined as Csch(x) = 2/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Csch(double x)
    {
        // for |x| > 20, csch x = 2e^−|x| / (1 − e^−2|x|) = ±2e^−|x| to full precision, also where sinh x overflows
        var a = Math.Abs(x);
        if (a > 20.0)
            return CopySign(2.0 * Math.Exp(-a), x);

        var sin = Math.Sinh(x);
        if (sin == 0.0)
            return double.NaN;

        return 1.0 / sin;
    }

    /// <summary>
    ///     Hyperbolic secant is defined as Sech(x) = 2/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (0, 1].
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Sech(double x)
    {
        // for |x| > 20, sech x = 2e^−|x| / (1 + e^−2|x|) = 2e^−|x| to full precision, also where cosh x overflows
        var a = Math.Abs(x);
        if (a > 20.0)
            return 2.0 * Math.Exp(-a);

        var cos = Math.Cosh(x);
        return 1.0 / cos;
    }

    /// <summary>
    ///     Hyperbolic cotangent is defined as Coth(x) = (e^x + e^−x)/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -1)∪(1, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" /> or 0.
    ///     This method returns -1 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Coth(double x)
    {
        if (x == 0.0)
            return double.NaN;

        return 1.0 / Math.Tanh(x);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh(double)" /> function is defined as Arsinh(x) = ln[x + √(x^2 +
    ///     1)].
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />,
    ///     <see cref="F:System.Double.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NegativeInfinity" />,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Asinh(double x)
        => RealAsinh(x);

    /// <summary>
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh(double)" /> function is defined as Arcosh(x) = ln[x + √(x^2
    ///     - 1)].
    /// </summary>
    /// <param name="x">Value in range: [1, +∞).</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" />,
    ///     <see cref="F:System.Double.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NegativeInfinity" />,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acosh(double x)
    {
        if (!(x >= 1.0))
            return double.NaN;

        // ln(x + √(x² − 1)) overflows for large x and loses precision near 1
        if (x > 1e8)
            return Math.Log(x) + Ln2;

        var t = x - 1.0;
        return Log1p(t + Math.Sqrt(t * (t + 2.0)));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh(double)" /> function
    ///     is defined as Artanh(x) = ln[(1 + x)/(1 − x)]/2.
    /// </summary>
    /// <param name="x">Value in range: (-1, 1).</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    ///     This method returns <see cref="F:System.Double.NegativeInfinity" /> if <paramref name="x" /> equals -1,
    ///     <see cref="F:System.Double.PositiveInfinity" /> if <paramref name="x" /> equals 1.
    /// </returns>
    public static double Atanh(double x)
    {
        var a = Math.Abs(x);
        if (!(a <= 1.0))
            return double.NaN;

        if (a == 1.0)
            return CopySign(double.PositiveInfinity, x);

        // ln[(1 + x)/(1 − x)]/2 = log1p(2|x|/(1 − |x|))/2 with the sign of x; accurate for small |x|
        return CopySign(Log1p(2.0 * a / (1.0 - a)) / 2.0, x);
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Cosh(double)" /> function
    ///     is defined as Arcsch(x) = ln[1/x + √(1/(x^2) + 1)].
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Double.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acsch(double x)
    {
        if (x == 0.0)
            return double.NaN;

        // arcsch x = arsinh(1/x); for tiny |x| use ln(2/|x|) directly, since 1/x may overflow
        var a = Math.Abs(x);
        return CopySign(a < 1e-8 ? Ln2 - Math.Log(a) : RealAsinh(1.0 / a), x);
    }

    /// <summary>
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech(double)" /> function
    ///     is defined as Arsech(x) = ln([1 + √(1 − x^2)]/x).
    /// </summary>
    /// <param name="x">Value in range: (0, 1].</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     <see cref="F:System.Double.PositiveInfinity" />, or 0.
    /// </returns>
    public static double Asech(double x)
    {
        if (!(x > 0.0 && x <= 1.0))
            return double.NaN;

        // ln([1 + √(1 − x²)]/x) = log1p(√((1 − x)(1 + x))) − ln x: no overflow for tiny x, no cancellation near 1
        return Log1p(Math.Sqrt((1.0 - x) * (1.0 + x))) - Math.Log(x);
    }

    /// <summary>
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth(double)" /> function
    ///     is defined as Arcoth(x) = ln[(1 + x)/(x − 1)]/2.
    /// </summary>
    /// <param name="x">Value in range: (−∞, -1)∪(1, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Double.NaN" />, or <paramref name="x" /> in range: [-1, 1].
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Double.NegativeInfinity" />
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acoth(double x)
    {
        var a = Math.Abs(x);
        if (!(a > 1.0))
            return double.NaN;

        // ln[(x + 1)/(x − 1)]/2 = log1p(2/(|x| − 1))/2 with the sign of x; |x| − 1 is exact near 1
        return CopySign(Log1p(2.0 / (a - 1.0)) / 2.0, x);
    }

    #endregion

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static double DegreesToRadians(double degrees)
        => degrees * Math.PI / 180.0;

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static double RadiansToDegrees(double radians)
        => radians * 180.0 / Math.PI;

    private static bool IsNegative(double d)
        => BitConverter.DoubleToInt64Bits(d) < 0;
}