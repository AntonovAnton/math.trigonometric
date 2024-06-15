using System;

namespace MathTrigonometric;

/// <summary>
///     This class provides implementations of all trigonometric functions, including basic trigonometric functions (sin,
///     cos, tan, asin, acos, atan), their hyperbolic counterparts (sinh, cosh, tanh, asinh, acosh, atanh), and are missing
///     in .NET: cot, sec, csc, acot, asec, acsc, coth, sech, csch, acoth, asech, acsch.
/// </summary>
public static class MathTrig
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
    {
        return Math.Sin(a);
    }

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
    {
        return Math.Cos(a);
    }

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
        if (Math.Abs(cos) < double.Epsilon)
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
        if (Math.Abs(sin) < double.Epsilon)
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
        if (Math.Abs(cos) < double.Epsilon)
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
        if (Math.Abs(sin) < double.Epsilon)
            return double.NaN;

        return Math.Cos(a) / sin;
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine is inverse of the <see cref="Sin" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Asin(double d)
    {
        return Math.Asin(d);
    }

    /// <summary>
    ///     Arc cosine is inverse of the <see cref="Cos" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acos(double d)
    {
        return Math.Acos(d);
    }

    /// <summary>
    ///     Arc tangent is inverse of the <see cref="Tan" /> function.
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
    {
        return Math.Atan(d);
    }

    /// <summary>
    ///     Arc cosecant is inverse of the <see cref="Csc" /> function.
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
        return Math.Abs(d) < double.Epsilon ? double.NaN : Math.Asin(1.0 / d);
    }

    /// <summary>
    ///     Arc secant is inverse of the <see cref="Sec" /> function.
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
        return Math.Abs(d) < double.Epsilon ? double.NaN : Math.Acos(1.0 / d);
    }

    /// <summary>
    ///     Arc cotangent is inverse of the <see cref="Cot" />> function.
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
        if (Math.Abs(d) < double.Epsilon)
            return Math.PI / 2;

        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return Math.PI - Math.Atan(1 / -d);

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
    {
        return Math.Sinh(x);
    }

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
    {
        return Math.Cosh(x);
    }

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
    {
        return Math.Tanh(x);
    }

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
        var sin = Math.Sinh(x);
        if (Math.Abs(sin) < double.Epsilon)
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
        var cos = Math.Cosh(x);
        if (Math.Abs(cos) < double.Epsilon)
            return double.NaN;

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
        if (Math.Abs(x) < double.Epsilon)
            return double.NaN;

        return 1 / Math.Tanh(x);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh" /> function is defined as Arsinh(x) = ln[x + √(x^2 + 1)].
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
    {
        if (double.IsNegativeInfinity(x))
            return double.NegativeInfinity;

        //the Trigonometric Symmetry is applied: arsinh(−x)=−arsinh(x)
        if (IsNegative(x))
            return -Math.Log(-x + Math.Sqrt(Math.Pow(x, 2) + 1.0));

        return Math.Log(x + Math.Sqrt(Math.Pow(x, 2) + 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh" /> function is defined as Arcosh(x) = ln[x + √(x^2 - 1)].
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
        if (x < 1.0)
            return double.NaN;

        return Math.Log(x + Math.Sqrt(Math.Pow(x, 2) - 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh" /> function
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
        if (Math.Abs(x + 1.0) < double.Epsilon)
            return double.NegativeInfinity;

        if (Math.Abs(x - 1.0) < double.Epsilon)
            return double.PositiveInfinity;

        if (Math.Abs(x) > 1.0)
            return double.NaN;

        return Math.Log((1.0 + x) / (1.0 - x)) / 2;
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Cosh" /> function
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
        if (Math.Abs(x) < double.Epsilon)
            return double.NaN;

        //the Trigonometric Symmetry is applied: arcsch(−x)=−arcsch(x)
        if (IsNegative(x))
            return -Math.Log(1.0 / -x + Math.Sqrt(1.0 / Math.Pow(x, 2.0) + 1.0));

        return Math.Log(1.0 / x + Math.Sqrt(1.0 / Math.Pow(x, 2.0) + 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech" /> function
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
        if (Math.Abs(x) < double.Epsilon)
            return double.NaN;

        if (x is < 0.0 or > 1.0)
            return double.NaN;

        return Math.Log(1.0 / x + Math.Sqrt(1.0 / Math.Pow(x, 2.0) - 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth" /> function
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
        if (double.IsInfinity(x))
            return 0.0;

        if (Math.Abs(x) <= 1.0)
            return double.NaN;

        return Math.Log((x + 1.0) / (x - 1.0)) / 2;
    }

    #endregion

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static double RadiansToDegrees(double radians)
    {
        return radians * 180.0 / Math.PI;
    }

    private static bool IsNegative(double d)
    {
        return BitConverter.DoubleToInt64Bits(d) < 0;
    }
}