#if NET8_0_OR_GREATER

using System.Numerics;
using System.Runtime.CompilerServices;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;

/*
 * Generic real overloads for .NET 8 and higher, written once against IFloatingPointIeee754<T>.
 * They serve float, Half and, on newer runtimes, BFloat16, Decimal32, Decimal64 and Decimal128.
 * double calls keep binding to the non-generic double overloads (an exact non-generic match is preferred).
 * For types narrower than double, functions built from several operations delegate to the double overloads
 * (see IsNarrowerThanDouble), exactly as the former float and Half overloads did.
 */
public static partial class MathTrig
{
    #region Fundamental Trigonometric Functions

    /// <summary>
    ///     Sine of the angle is ratio of the opposite leg to hypotenuse.
    /// </summary>
    /// <typeparam name="T">
    ///     The floating-point type, for example <see cref="float" /> or <see cref="System.Half" />.
    /// </typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The sine of the input angle in range: [-1, 1].
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Sin<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Sin(a);

    /// <summary>
    ///     Cosine of the angle is ratio of the adjacent leg to hypotenuse.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosine of the input angle in range: [-1, 1].
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Cos<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Cos(a);

    /// <summary>
    ///     Tangent of the angle is ratio of the opposite leg to adjacent one.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The tangent of the input angle (any real number).
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Tan<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var cos = T.Cos(a);
        return T.IsZero(cos) ? T.NaN : T.Sin(a) / cos;
    }

    /// <summary>
    ///     Cosecant of the angle is ratio of the hypotenuse to opposite leg.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosecant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Csc<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var sin = T.Sin(a);
        return T.IsZero(sin) ? T.NaN : T.One / sin;
    }

    /// <summary>
    ///     Secant of the angle is ratio of the hypotenuse to adjacent leg.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The secant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Sec<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var cos = T.Cos(a);
        return T.IsZero(cos) ? T.NaN : T.One / cos;
    }

    /// <summary>
    ///     Cotangent of the angle is ratio of the adjacent leg to opposite one.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cotangent of the input angle (any real number).
    ///     This method returns NaN if <paramref name="a" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Cot<T>(T a)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var sin = T.Sin(a);
        return T.IsZero(sin) ? T.NaN : T.Cos(a) / sin;
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine is inverse of the <see cref="Sin{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns NaN if <paramref name="d" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Asin<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Asin(d);

    /// <summary>
    ///     Arc cosine is inverse of the <see cref="Cos{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns NaN if <paramref name="d" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static T Acos<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Acos(d);

    /// <summary>
    ///     Arc tangent is inverse of the <see cref="Tan{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (−π/2, π/2).
    ///     This method returns NaN if <paramref name="d" /> equals NaN,
    ///     −π/2 if <paramref name="d" /> equals NegativeInfinity, π/2 if <paramref name="d" /> equals PositiveInfinity.
    /// </returns>
    public static T Atan<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Atan(d);

    /// <summary>
    ///     Arc cosecant is inverse of the <see cref="Csc{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, 0)∪(0, π/2].
    ///     This method returns NaN if <paramref name="d" /> equals NaN, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns 0 if <paramref name="d" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Acsc<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Acsc(double.CreateTruncating(d)));

        var a = T.Abs(d);
        if (!(a >= T.One))
            return T.NaN;

        // asin(1/d) = atan(1/√(d² − 1)); a − 1 is exact near 1, where asin(1/d) would amplify the rounding of 1/d
        return T.CopySign(T.Atan2(T.One, T.Sqrt(a - T.One) * T.Sqrt(a + T.One)), d);
    }

    /// <summary>
    ///     Arc secant is inverse of the <see cref="Sec{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π/2)∪(π/2, π].
    ///     This method returns NaN if <paramref name="d" /> equals NaN, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns π/2 if <paramref name="d" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Asec<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Asec(double.CreateTruncating(d)));

        var a = T.Abs(d);
        if (!(a >= T.One))
            return T.NaN;

        // acos(1/d) = atan2(√(d² − 1), sign(d)); a − 1 is exact near 1, where acos(1/d) would amplify the rounding of 1/d
        return T.Atan2(T.Sqrt(a - T.One) * T.Sqrt(a + T.One), T.CopySign(T.One, d));
    }

    /// <summary>
    ///     Arc cotangent is inverse of the <see cref="Cot{T}(T)" /> function.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (0, π).
    ///     This method returns NaN if <paramref name="d" /> equals NaN,
    ///     π if <paramref name="d" /> equals NegativeInfinity, 0 if <paramref name="d" /> equals PositiveInfinity.
    /// </returns>
    public static T Acot<T>(T d)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        // the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (T.IsNegative(d))
            return T.Pi - T.Atan(T.One / -d);

        return T.Atan(T.One / d);
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine is defined as Sinh(x) = (e^x − e^−x)/2.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns NaN if <paramref name="x" /> equals NaN,
    ///     NegativeInfinity if <paramref name="x" /> equals NegativeInfinity,
    ///     PositiveInfinity if <paramref name="x" /> equals PositiveInfinity.
    /// </returns>
    public static T Sinh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Sinh(x);

    /// <summary>
    ///     Hyperbolic cosine is defined as Cosh(x) = (e^x + e^−x)/2.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: [1, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN,
    ///     PositiveInfinity if <paramref name="x" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Cosh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Cosh(x);

    /// <summary>
    ///     Hyperbolic tangent is defined as Tanh(x) = (e^x − e^−x)/(e^x + e^−x).
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (-1, 1).
    ///     This method returns NaN if <paramref name="x" /> equals NaN,
    ///     -1 if <paramref name="x" /> equals NegativeInfinity, 1 if <paramref name="x" /> equals PositiveInfinity.
    /// </returns>
    public static T Tanh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Tanh(x);

    /// <summary>
    ///     Hyperbolic cosecant is defined as Csch(x) = 2/(e^x − e^−x).
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN or 0.
    ///     This method returns 0 if <paramref name="x" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Csch<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Csch(double.CreateTruncating(x)));

        // where sinh x overflows, csch x = 2e^−|x| / (1 − e^−2|x|) = ±2e^−|x| to full precision
        var sinh = T.Sinh(x);
        if (T.IsInfinity(sinh))
            return T.CopySign(Two<T>() * T.Exp(-T.Abs(x)), x);

        return T.IsZero(sinh) ? T.NaN : T.One / sinh;
    }

    /// <summary>
    ///     Hyperbolic secant is defined as Sech(x) = 2/(e^x + e^−x).
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (0, 1].
    ///     This method returns NaN if <paramref name="x" /> equals NaN.
    ///     This method returns 0 if <paramref name="x" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Sech<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Sech(double.CreateTruncating(x)));

        // where cosh x overflows, sech x = 2e^−|x| / (1 + e^−2|x|) = 2e^−|x| to full precision
        var cosh = T.Cosh(x);
        return T.IsInfinity(cosh) ? Two<T>() * T.Exp(-T.Abs(x)) : T.One / cosh;
    }

    /// <summary>
    ///     Hyperbolic cotangent is defined as Coth(x) = (e^x + e^−x)/(e^x − e^−x).
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -1)∪(1, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN or 0.
    ///     This method returns -1 if <paramref name="x" /> equals NegativeInfinity,
    ///     1 if <paramref name="x" /> equals PositiveInfinity.
    /// </returns>
    public static T Coth<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.IsZero(x) ? T.NaN : T.One / T.Tanh(x);

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh{T}(T)" /> function is defined as
    ///     Arsinh(x) = ln[x + √(x^2 + 1)].
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns NaN if <paramref name="x" /> equals NaN,
    ///     NegativeInfinity if <paramref name="x" /> equals NegativeInfinity,
    ///     PositiveInfinity if <paramref name="x" /> equals PositiveInfinity.
    /// </returns>
    public static T Asinh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => IsNarrowerThanDouble<T>() ? T.CreateTruncating(Asinh(double.CreateTruncating(x))) : RealAsinh(x);

    /// <summary>
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh{T}(T)" /> function is defined as
    ///     Arcosh(x) = ln[x + √(x^2 - 1)].
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: [1, +∞).</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN or NegativeInfinity,
    ///     PositiveInfinity if <paramref name="x" /> equals PositiveInfinity.
    /// </returns>
    public static T Acosh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Acosh(double.CreateTruncating(x)));

        if (!(x >= T.One))
            return T.NaN;

        // ln(x + √(x² − 1)) overflows for large x and loses precision near 1
        if (x > LargeThreshold<T>())
            return T.Log(x) + LogTwo<T>();

        var t = x - T.One;
        return Log1p(t + T.Sqrt(t * (t + Two<T>())));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh{T}(T)" /> function
    ///     is defined as Artanh(x) = ln[(1 + x)/(1 − x)]/2.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (-1, 1).</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns NaN if <paramref name="x" /> equals NaN, NegativeInfinity, or PositiveInfinity.
    ///     This method returns NegativeInfinity if <paramref name="x" /> equals -1,
    ///     PositiveInfinity if <paramref name="x" /> equals 1.
    /// </returns>
    public static T Atanh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Atanh(double.CreateTruncating(x)));

        var a = T.Abs(x);
        if (!(a <= T.One))
            return T.NaN;

        if (a == T.One)
            return T.CopySign(T.PositiveInfinity, x);

        // ln[(1 + x)/(1 − x)]/2 = log1p(2|x|/(1 − |x|))/2 with the sign of x; accurate for small |x|
        return T.CopySign(Log1p(Two<T>() * a / (T.One - a)) / Two<T>(), x);
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Csch{T}(T)" /> function
    ///     is defined as Arcsch(x) = ln[1/x + √(1/(x^2) + 1)].
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -0)∪(0, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN or 0.
    ///     This method returns 0 if <paramref name="x" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Acsch<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Acsch(double.CreateTruncating(x)));

        if (T.IsZero(x))
            return T.NaN;

        // arcsch x = arsinh(1/x); where 1/|x| overflows use ln(2/|x|) directly
        var a = T.Abs(x);
        var r = T.One / a;
        return T.CopySign(T.IsInfinity(r) ? LogTwo<T>() - T.Log(a) : RealAsinh(r), x);
    }

    /// <summary>
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech{T}(T)" /> function
    ///     is defined as Arsech(x) = ln([1 + √(1 − x^2)]/x).
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (0, 1].</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN, NegativeInfinity, PositiveInfinity, or 0.
    /// </returns>
    public static T Asech<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Asech(double.CreateTruncating(x)));

        if (!(x > T.Zero && x <= T.One))
            return T.NaN;

        // ln([1 + √(1 − x²)]/x) = log1p(√((1 − x)(1 + x))) − ln x: no overflow for tiny x, no cancellation near 1
        return Log1p(T.Sqrt((T.One - x) * (T.One + x))) - T.Log(x);
    }

    /// <summary>
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth{T}(T)" /> function
    ///     is defined as Arcoth(x) = ln[(1 + x)/(x − 1)]/2.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="x">Value in range: (−∞, -1)∪(1, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns NaN if <paramref name="x" /> equals NaN, or <paramref name="x" /> in range: [-1, 1].
    ///     This method returns 0 if <paramref name="x" /> equals NegativeInfinity or PositiveInfinity.
    /// </returns>
    public static T Acoth<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (IsNarrowerThanDouble<T>())
            return T.CreateTruncating(Acoth(double.CreateTruncating(x)));

        var a = T.Abs(x);
        if (!(a > T.One))
            return T.NaN;

        // ln[(x + 1)/(x − 1)]/2 = log1p(2/(|x| − 1))/2 with the sign of x; |x| − 1 is exact near 1
        return T.CopySign(Log1p(Two<T>() / (a - T.One)) / Two<T>(), x);
    }

    #endregion

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static T DegreesToRadians<T>(T degrees)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.DegreesToRadians(degrees);

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <typeparam name="T">The floating-point type.</typeparam>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static T RadiansToDegrees<T>(T radians)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.RadiansToDegrees(radians);

    #region Generic helpers

    /// <summary>
    ///     True for float, Half, BFloat16 and Decimal32: compound formulas are then evaluated by the double overload,
    ///     whose extra precision and range give correctly rounded results for the narrow type.
    ///     The JIT folds this to a constant for each T.
    /// </summary>
    private static bool IsNarrowerThanDouble<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Unsafe.SizeOf<T>() < sizeof(double);

    private static T Two<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.One + T.One;

    private static T LogTwo<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Log(Two<T>());

    /// <summary>
    ///     √MaxValue / 4: below it intermediate squares cannot overflow, above it the asymptotic forms
    ///     (e.g. log(2x)) are exact to working precision.
    /// </summary>
    private static T LargeThreshold<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Sqrt(T.MaxValue) / T.CreateTruncating(4);

    /// <summary>log(1 + x), accurate for small x (T.LogP1 is not, for some types).</summary>
    private static T Log1p<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsPositiveInfinity(x))
            return x;

        var u = T.One + x;
        if (u == T.One)
            return x;

        return T.Log(u) * x / (u - T.One);
    }

    /// <summary>asinh x, accurate for small and large |x|.</summary>
    private static T RealAsinh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var a = T.Abs(x);
        var r = a > LargeThreshold<T>()
            ? T.Log(a) + LogTwo<T>()
            : Log1p(a + a * a / (T.One + T.Sqrt(T.One + a * a)));

        return T.CopySign(r, x);
    }

    #endregion
}

#endif
