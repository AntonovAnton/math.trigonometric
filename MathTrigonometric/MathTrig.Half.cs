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
        => Sin<Half>(a);

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
        => Cos<Half>(a);

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
        => Tan<Half>(a);

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
        => Csc<Half>(a);

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
        => Sec<Half>(a);

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
        => Cot<Half>(a);

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
        => Asin<Half>(d);

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
        => Acos<Half>(d);

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
        => Atan<Half>(d);

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
        => Acsc<Half>(d);

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
        => Asec<Half>(d);

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
        => Acot<Half>(d);

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
        => Sinh<Half>(x);

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
        => Cosh<Half>(x);

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
        => Tanh<Half>(x);

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
        => Csch<Half>(x);

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
        => Sech<Half>(x);

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
        => Coth<Half>(x);

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
        => Asinh<Half>(x);

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
        => Acosh<Half>(x);

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
        => Atanh<Half>(x);

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
        => Acsch<Half>(x);

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
        => Asech<Half>(x);

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
        => Acoth<Half>(x);

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
}

#endif