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
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Sin(float a)
        => Sin<float>(a);

    /// <summary>
    ///     Cosine of the angle is ratio of the adjacent leg to hypotenuse.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosine of the input angle in range: [-1, 1].
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Cos(float a)
        => Cos<float>(a);

    /// <summary>
    ///     Tangent of the angle is ratio of the opposite leg to adjacent one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The tangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Tan(float a)
        => Tan<float>(a);

    /// <summary>
    ///     Cosecant of the angle is ratio of the hypotenuse to opposite leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cosecant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Csc(float a)
        => Csc<float>(a);

    /// <summary>
    ///     Secant of the angle is ratio of the hypotenuse to adjacent leg.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The secant of the input angle in range: (-∞, -1] ∪ [1, ∞).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Sec(float a)
        => Sec<float>(a);

    /// <summary>
    ///     Cotangent of the angle is ratio of the adjacent leg to opposite one.
    /// </summary>
    /// <param name="a">Angle in radians (any real number).</param>
    /// <returns>
    ///     The cotangent of the input angle (any real number).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="a" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Cot(float a)
        => Cot<float>(a);

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine is inverse of the <see cref="Sin(float)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Asin(float d)
        => Asin<float>(d);

    /// <summary>
    ///     Arc cosine is inverse of the <see cref="Cos(float)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acos(float d)
        => Acos<float>(d);

    /// <summary>
    ///     Arc tangent is inverse of the <see cref="Tan(float)" /> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (−π/2, π/2).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Single.NaN" />,
    ///     −π/2 if <paramref name="d" /> equals <see cref="F:System.Single.NegativeInfinity" />,
    ///     π/2 if <paramref name="d" /> equals <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Atan(float d)
        => Atan<float>(d);

    /// <summary>
    ///     Arc cosecant is inverse of the <see cref="Csc(float)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, 0)∪(0, π/2].
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Single.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns 0 if <paramref name="d" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acsc(float d)
        => Acsc<float>(d);

    /// <summary>
    ///     Arc secant is inverse of the <see cref="Sec(float)" /> function.
    /// </summary>
    /// <param name="d">Value in range: (-∞, -1] ∪ [1, ∞).</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π/2)∪(π/2, π].
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Single.NaN" />, or <paramref name="d" /> in range: (-1, 1).
    ///     This method returns π/2 if <paramref name="d" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Asec(float d)
        => Asec<float>(d);

    /// <summary>
    ///     Arc cotangent is inverse of the <see cref="Coth(float)" />> function.
    /// </summary>
    /// <param name="d">Any real number.</param>
    /// <returns>
    ///     Angle in radians is limited to the range (0, π).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="d" /> equals <see cref="F:System.Single.NaN" />,
    ///     π if <paramref name="d" /> equals <see cref="F:System.Single.NegativeInfinity" />,
    ///     0 if <paramref name="d" /> equals <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acot(float d)
        => Acot<float>(d);

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine is defined as Sinh(x) = (e^x − e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />,
    ///     <see cref="F:System.Single.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NegativeInfinity" />,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Sinh(float x)
        => Sinh<float>(x);

    /// <summary>
    ///     Hyperbolic cosine is defined as Cosh(x) = (e^x + e^−x)/2.
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: [1, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NegativeInfinity" />,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Cosh(float x)
        => Cosh<float>(x);

    /// <summary>
    ///     Hyperbolic tangent is defined as Tanh(x) = (e^x − e^−x)/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (-1, 1).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />,
    ///     -1 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Tanh(float x)
        => Tanh<float>(x);

    /// <summary>
    ///     Hyperbolic cosecant is defined as Csch(x) = 2/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Csch(float x)
        => Csch<float>(x);

    /// <summary>
    ///     Hyperbolic secant is defined as Sech(x) = 2/(e^x + e^−x).
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value in range: (0, 1].
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Sech(float x)
        => Sech<float>(x);

    /// <summary>
    ///     Hyperbolic cotangent is defined as Coth(x) = (e^x + e^−x)/(e^x − e^−x).
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -1)∪(1, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" /> or 0.
    ///     This method returns -1 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />,
    ///     1 if <paramref name="x" /> equals <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Coth(float x)
        => Coth<float>(x);

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh(float)" /> function is defined as Arsinh(x) = ln[x + √(x^2 +
    ///     1)].
    /// </summary>
    /// <param name="x">Any real number.</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />,
    ///     <see cref="F:System.Single.NegativeInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NegativeInfinity" />,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Asinh(float x)
        => Asinh<float>(x);

    /// <summary>
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh(float)" /> function is defined as Arcosh(x) = ln[x + √(x^2
    ///     - 1)].
    /// </summary>
    /// <param name="x">Value in range: [1, +∞).</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" />,
    ///     <see cref="F:System.Single.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NegativeInfinity" />,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acosh(float x)
        => Acosh<float>(x);

    /// <summary>
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh(float)" /> function
    ///     is defined as Artanh(x) = ln[(1 + x)/(1 − x)]/2.
    /// </summary>
    /// <param name="x">Value in range: (-1, 1).</param>
    /// <returns>
    ///     Value (any real number).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    ///     This method returns <see cref="F:System.Single.NegativeInfinity" /> if <paramref name="x" /> equals -1,
    ///     <see cref="F:System.Single.PositiveInfinity" /> if <paramref name="x" /> equals 1.
    /// </returns>
    public static float Atanh(float x)
        => Atanh<float>(x);

    /// <summary>
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Cosh(float)" /> function
    ///     is defined as Arcsch(x) = ln[1/x + √(1/(x^2) + 1)].
    /// </summary>
    /// <param name="x">Value in range: (−∞, 0)∪(0, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, -0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" />
    ///     if <paramref name="x" /> equals <see cref="F:System.Single.NaN" /> or 0.
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acsch(float x)
        => Acsch<float>(x);

    /// <summary>
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech(float)" /> function
    ///     is defined as Arsech(x) = ln([1 + √(1 − x^2)]/x).
    /// </summary>
    /// <param name="x">Value in range: (0, 1].</param>
    /// <returns>
    ///     Value in range: [0, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NaN" />, <see cref="F:System.Single.NegativeInfinity" />,
    ///     <see cref="F:System.Single.PositiveInfinity" />, or 0.
    /// </returns>
    public static float Asech(float x)
        => Asech<float>(x);

    /// <summary>
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth(float)" /> function
    ///     is defined as Arcoth(x) = ln[(1 + x)/(x − 1)]/2.
    /// </summary>
    /// <param name="x">Value in range: (−∞, -1)∪(1, +∞).</param>
    /// <returns>
    ///     Value in range: (−∞, 0)∪(0, +∞).
    ///     This method returns <see cref="F:System.Single.NaN" /> if <paramref name="x" /> equals
    ///     <see cref="F:System.Single.NaN" />, or <paramref name="x" /> in range: [-1, 1].
    ///     This method returns 0 if <paramref name="x" /> equals <see cref="F:System.Single.NegativeInfinity" />
    ///     or <see cref="F:System.Single.PositiveInfinity" />.
    /// </returns>
    public static float Acoth(float x)
        => Acoth<float>(x);

    #endregion

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static float DegreesToRadians(float degrees)
        => degrees * MathF.PI / 180.0f;

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static float RadiansToDegrees(float radians)
        => radians * 180.0f / MathF.PI;
}

#endif