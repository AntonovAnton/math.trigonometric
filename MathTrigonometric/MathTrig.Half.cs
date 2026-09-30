#if NET8_0_OR_GREATER

using System;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;

public static partial class MathTrig
{
    #region Fundamental Trigonometric Functions

    /// <summary>
    ///     Sine of the angle is ratio of the opposite leg to hypotenuse.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The sine of the input angle in range: [-1, 1].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Sin(Half a)
        => Half.Sin(a);

    /// <summary>
    ///     Cosine of the angle is ratio of the adjacent leg to hypotenuse.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosine of the input angle in range: [-1, 1].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Cos(Half a)
        => Half.Cos(a);

    /// <summary>
    ///     Tangent of the angle is ratio of the opposite leg to adjacent one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The tangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Tan(Half a)
    {
        var cos = Half.Cos(a);
        if (cos == Half.Zero)
            return Half.NaN;

        return Half.Sin(a) / cos;
    }

    /// <summary>
    ///     Cosecant of the angle is ratio of the hypotenuse to opposite leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosecant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Csc(Half a)
    {
        var sin = Half.Sin(a);
        if (sin == Half.Zero)
            return Half.NaN;

        return Half.One / sin;
    }

    /// <summary>
    ///     Secant of the angle is ratio of the hypotenuse to adjacent leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The secant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Sec(Half a)
    {
        var cos = Half.Cos(a);
        if (cos == Half.Zero)
            return Half.NaN;

        return Half.One / cos;
    }

    /// <summary>
    ///     Cotangent of the angle is ratio of the adjacent leg to opposite one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cotangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Cot(Half a)
    {
        var sin = Half.Sin(a);
        if (sin == Half.Zero)
            return Half.NaN;

        return Half.Cos(a) / sin;
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine is inverse of the <see cref="Sin(Half)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Asin(Half d)
        => Half.Asin(d);

    /// <summary>
    ///     Arc cosine is inverse of the <see cref="Cos(Half)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acos(Half d)
        => Half.Acos(d);

    /// <summary>
    ///     Arc tangent is inverse of the <see cref="Tan(Half)" /> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (−π/2, π/2).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Half.NaN" />,
    ///     −π/2 if <paramref name="d" /> equals <see cref="F:System.Half.NegativeInfinity" />,
    ///     π/2 if <paramref name="d" /> equals <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Atan(Half d)
        => Half.Atan(d);

    /// <summary>
    ///     Arc cosecant is inverse of the <see cref="Csc(Half)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, 0)∪(0, π/2].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Half.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns 0 if <paramref name="d" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acsc(Half d)
        => Half.Asin(Half.One / d);

    /// <summary>
    ///     Arc secant is inverse of the <see cref="Sec(Half)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π/2)∪(π/2, π].
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Half.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns π/2 if <paramref name="d" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Asec(Half d)
        => Half.Acos(Half.One / d);

    /// <summary>
    ///     Arc cotangent is inverse of the <see cref="Coth(Half)" />> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (0, π).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Half.NaN" />,
    ///     π if <paramref name="d" /> equals <see cref="F:System.Half.NegativeInfinity" />,
    ///     0 if <paramref name="d" /> equals <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acot(Half d)
    {
        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return Half.Pi - Half.Atan(Half.One / -d);

        return Half.Atan(Half.One / d);
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine is defined as Sinh(x) = (e^x − e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />,
    ///     <see cref="F:System.Half.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NegativeInfinity" />,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Sinh(Half x)
        => Half.Sinh(x);

    /// <summary>
    ///     Hyperbolic cosine is defined as Cosh(x) = (e^x + e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: [1, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NegativeInfinity" />,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Cosh(Half x)
        => Half.Cosh(x);

    /// <summary>
    ///     Hyperbolic tangent is defined as Tanh(x) = (e^x − e^−x)/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (-1, 1).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />,
    ///     -1 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Tanh(Half x)
        => Half.Tanh(x);

    /// <summary>
    ///     Hyperbolic cosecant is defined as Csch(x) = 2/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Csch(Half x)
    {
        var sin = Half.Sinh(x);
        if (sin == Half.Zero)
            return Half.NaN;

        return Half.One / sin;
    }

    /// <summary>
    ///     Hyperbolic secant is defined as Sech(x) = 2/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (0, 1].
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Sech(Half x)
    {
        var cos = Half.Cosh(x);
        return Half.One / cos;
    }

    /// <summary>
    ///     Hyperbolic cotangent is defined as Coth(x) = (e^x + e^−x)/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -1)∪(1, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" /> or 0.
    ///     This method returns -1 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Coth(Half x)
    {
        if (x == Half.Zero)
            return Half.NaN;

        return Half.One / Half.Tanh(x);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh(Half)" /> function is defined as Arsinh(x) = ln[x + √(x^2 +
    ///     1)].
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />,
    ///     <see cref="F:System.Half.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NegativeInfinity" />,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Asinh(Half x)
    {
        if (Half.IsInfinity(x))
            return x;

        //the Trigonometric Symmetry is applied: arsinh(−x)=−arsinh(x)
        if (IsNegative(x))
            return -Half.Log(-x + Half.Sqrt(x * x + Half.One));

        return Half.Log(x + Half.Sqrt(x * x + Half.One));
    }

    /// <summary>
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh(Half)" /> function is defined as Arcosh(x) = ln[x + √(x^2
    ///     - 1)].
    /// </summary>
    /// <param name="x">Value in range: [1, +∞).</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" />,
    ///     <see cref="F:System.Half.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NegativeInfinity" />,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acosh(Half x)
    {
        if (x < Half.One)
            return Half.NaN;

        return Half.Log(x + Half.Sqrt(x * x - Half.One));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh(Half)" /> function
    ///     is defined as Artanh(x) = ln[(1 + x)/(1 − x)]/2.
    /// </summary>
    /// <param name="x">Value in range: (-1, 1).</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    ///     This method returns <see cref="F:System.Half.NegativeInfinity" /> if <paramref name="x" /> equals -1,
    ///     <see cref="F:System.Half.PositiveInfinity" /> if <paramref name="x" /> equals 1.
    /// </returns>
    public static Half Atanh(Half x)
    {
        if (Half.Abs(x + Half.One) < Half.Epsilon)
            return Half.NegativeInfinity;

        if (Half.Abs(x - Half.One) < Half.Epsilon)
            return Half.PositiveInfinity;

        if (Half.Abs(x) > Half.One)
            return Half.NaN;

        return Half.Log((Half.One + x) / (Half.One - x)) / (Half)2;
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Cosh(Half)" /> function
    ///     is defined as Arcsch(x) = ln[1/x + √(1/(x^2) + 1)].
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Half.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acsch(Half x)
    {
        if (x == Half.Zero)
            return Half.NaN;

        //the Trigonometric Symmetry is applied: arcsch(−x)=−arcsch(x)
        if (IsNegative(x))
            return -Half.Log(Half.One / -x + Half.Sqrt(Half.One / (x * x) + Half.One));

        return Half.Log(Half.One / x + Half.Sqrt(Half.One / (x * x) + Half.One));
    }

    /// <summary>
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech(Half)" /> function
    ///     is defined as Arsech(x) = ln([1 + √(1 − x^2)]/x).
    /// </summary>
    /// <param name="x">Value in range: (0, 1].</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NaN" />, <see cref="F:System.Half.NegativeInfinity" />,
    ///     <see cref="F:System.Half.PositiveInfinity" />, or 0.
    /// </returns>
    public static Half Asech(Half x)
    {
        if (x <= Half.Zero || x > Half.One)
            return Half.NaN;

        return Half.Log(Half.One / x + Half.Sqrt(Half.One / (x * x) - Half.One));
    }

    /// <summary>
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth(Half)" /> function
    ///     is defined as Arcoth(x) = ln[(1 + x)/(x − 1)]/2.
    /// </summary>
    /// <param name="x">Value in range: (−∞, -1)∪(1, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Half.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Half.NaN" />, or <paramref name="x" /> in range: [-1, 1].
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Half.NegativeInfinity" />
    ///     or <see cref="F:System.Half.PositiveInfinity" />.
    /// </returns>
    public static Half Acoth(Half x)
    {
        if (Half.IsInfinity(x))
            return Half.Zero;

        if (Half.Abs(x) <= Half.One)
            return Half.NaN;

        return Half.Log((x + Half.One) / (x - Half.One)) / (Half)2;
    }

    #endregion

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static Half DegreesToRadians(Half degrees)
        => Half.DegreesToRadians(degrees);

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static Half RadiansToDegrees(Half radians)
        => Half.RadiansToDegrees(radians);

    private static bool IsNegative(Half d)
        => Half.IsNegative(d);
}

#endif