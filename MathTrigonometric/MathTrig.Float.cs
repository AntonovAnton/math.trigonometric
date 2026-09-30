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
        => MathF.Sin(a);

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
        => MathF.Cos(a);

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
    {
        var cos = MathF.Cos(a);
        if (cos == 0.0f)
            return float.NaN;

        return MathF.Sin(a) / cos;
    }

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
    {
        var sin = MathF.Sin(a);
        if (sin == 0.0f)
            return float.NaN;

        return 1.0f / sin;
    }

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
    {
        var cos = MathF.Cos(a);
        if (cos == 0.0f)
            return float.NaN;

        return 1.0f / cos;
    }

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
    {
        var sin = MathF.Sin(a);
        if (sin == 0.0f)
            return float.NaN;

        return MathF.Cos(a) / sin;
    }

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
        => MathF.Asin(d);

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
        => MathF.Acos(d);

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
        => MathF.Atan(d);

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
        => MathF.Asin(1.0f / d);

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
        => MathF.Acos(1.0f / d);

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
    {
        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return MathF.PI - MathF.Atan(1.0f / -d);

        return MathF.Atan(1.0f / d);
    }

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
        => MathF.Sinh(x);

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
        => MathF.Cosh(x);

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
        => MathF.Tanh(x);

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
    {
        var sin = MathF.Sinh(x);
        if (sin == 0.0f)
            return float.NaN;

        return 1.0f / sin;
    }

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
    {
        var cos = MathF.Cosh(x);
        return 1.0f / cos;
    }

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
    {
        if (x == 0.0f)
            return float.NaN;

        return 1.0f / MathF.Tanh(x);
    }

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
    {
        if (float.IsInfinity(x))
            return x;

        //the Trigonometric Symmetry is applied: arsinh(−x)=−arsinh(x)
        if (IsNegative(x))
            return -MathF.Log(-x + MathF.Sqrt(x * x + 1.0f));

        return MathF.Log(x + MathF.Sqrt(x * x + 1.0f));
    }

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
    {
        if (x < 1.0f)
            return float.NaN;

        return MathF.Log(x + MathF.Sqrt(x * x - 1.0f));
    }

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
    {
        if (MathF.Abs(x + 1.0f) < float.Epsilon)
            return float.NegativeInfinity;

        if (MathF.Abs(x - 1.0f) < float.Epsilon)
            return float.PositiveInfinity;

        if (MathF.Abs(x) > 1.0f)
            return float.NaN;

        return MathF.Log((1.0f + x) / (1.0f - x)) / 2.0f;
    }

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
    {
        if (x == 0.0f)
            return float.NaN;

        //the Trigonometric Symmetry is applied: arcsch(−x)=−arcsch(x)
        if (IsNegative(x))
            return -MathF.Log(1.0f / -x + MathF.Sqrt(1.0f / (x * x) + 1.0f));

        return MathF.Log(1.0f / x + MathF.Sqrt(1.0f / (x * x) + 1.0f));
    }

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
    {
        if (x is <= 0.0f or > 1.0f)
            return float.NaN;

        return MathF.Log(1.0f / x + MathF.Sqrt(1.0f / (x * x) - 1.0f));
    }

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
    {
        if (float.IsInfinity(x))
            return 0.0f;

        if (MathF.Abs(x) <= 1.0f)
            return float.NaN;

        return MathF.Log((x + 1.0f) / (x - 1.0f)) / 2.0f;
    }

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

    private static bool IsNegative(float d)
        => BitConverter.SingleToInt32Bits(d) < 0;
}

#endif