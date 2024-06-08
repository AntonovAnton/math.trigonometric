using System;

namespace MathTrigonometric;

public static class MathTrig
{
    #region Fundamental Trigonometric Functions

    public static double Sin(double a)
    {
        return Math.Sin(a);
    }

    public static double Cos(double a)
    {
        return Math.Cos(a);
    }

    public static double Tan(double a)
    {
        var cos = Math.Cos(a);
        if (Math.Abs(cos) < double.Epsilon)
            return double.NaN;

        return Math.Sin(a) / cos;
    }

    /// <summary>
    ///     Cosecant
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Csc(double a)
    {
        var sin = Math.Sin(a);
        if (Math.Abs(sin) < double.Epsilon)
            return double.NaN;

        return 1.0 / sin;
    }

    /// <summary>
    ///     Secant
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Sec(double a)
    {
        var cos = Math.Cos(a);
        if (Math.Abs(cos) < double.Epsilon)
            return double.NaN;

        return 1.0 / cos;
    }

    /// <summary>
    ///     Cotangent
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Cot(double a)
    {
        var sin = Math.Sin(a);
        if (Math.Abs(sin) < double.Epsilon)
            return double.NaN;

        return Math.Cos(a) / sin;
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    public static double Sinh(double a)
    {
        return Math.Sinh(a);
    }

    public static double Cosh(double a)
    {
        return Math.Cosh(a);
    }

    public static double Tanh(double a)
    {
        var cos = Math.Cosh(a);
        if (Math.Abs(cos) < double.Epsilon)
            return double.NaN;

        return Math.Sinh(a) / cos;
    }

    /// <summary>
    ///     Cosecant
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Csch(double a)
    {
        var sin = Math.Sinh(a);
        if (Math.Abs(sin) < double.Epsilon)
            return double.NaN;

        return 1.0 / sin;
    }

    /// <summary>
    ///     Secant
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Sech(double a)
    {
        var cos = Math.Cosh(a);
        if (Math.Abs(cos) < double.Epsilon)
            return double.NaN;

        return 1.0 / cos;
    }

    /// <summary>
    ///     Cotangent
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static double Coth(double a)
    {
        var sin = Math.Sinh(a);
        if (Math.Abs(sin) < double.Epsilon)
            return double.NaN;

        return Math.Cosh(a) / sin;
    }

    #endregion

    #region Inverse Trigonometric Functions

    public static double Arcsin(double d)
    {
        return Math.Asin(d);
    }

    public static double Arccos(double d)
    {
        return Math.Acos(d);
    }

    public static double Arctan(double d)
    {
        return Math.Atan(d);
    }

    /// <summary>
    ///     Inverse Cosecant
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double Arccsc(double d)
    {
        return Math.Abs(d) < double.Epsilon ? double.NaN : Math.Asin(1.0 / d);
    }

    /// <summary>
    ///     Inverse Secant
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double Arcsec(double d)
    {
        return Math.Abs(d) < double.Epsilon ? double.NaN : Math.Acos(1.0 / d);
    }

    /// <summary>Returns the angle whose cotangent is the specified number.</summary>
    /// <param name="d">A number representing a cotangent.</param>
    /// <returns>
    ///     An angle, θ, measured in radians, such that 0 ≤ θ ≤ π.
    ///     -or-
    ///     <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals <see cref="F:System.Double.NaN" />, 0 if
    ///     <paramref name="d" /> equals <see cref="F:System.Double.NegativeInfinity" />, or π if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Arccot(double d)
    {
        if (Math.Abs(d) < double.Epsilon)
            return Math.PI / 2;

        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return Math.PI - Math.Atan(1 / -d);

        return Math.Atan(1 / d);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    public static double Arsinh(double d)
    {
        if (double.IsNegativeInfinity(d))
            return double.NegativeInfinity;

        //the Trigonometric Symmetry is applied: arsinh(−x)=−arsinh(x)
        if (IsNegative(d))
            return -Math.Log(-d + Math.Sqrt(Math.Pow(d, 2) + 1.0));

        return Math.Log(d + Math.Sqrt(Math.Pow(d, 2) + 1.0));
    }

    public static double Arcosh(double d)
    {
        if (d < 1.0)
            return double.NaN;

        return Math.Log(d + Math.Sqrt(Math.Pow(d, 2) - 1.0));
    }

    public static double Artanh(double d)
    {
        if (Math.Abs(d + 1.0) < double.Epsilon)
            return double.NegativeInfinity;

        if (Math.Abs(d - 1.0) < double.Epsilon)
            return double.PositiveInfinity;

        if (Math.Abs(d) > 1.0)
            return double.NaN;

        return Math.Log((1.0 + d) / (1.0 - d)) / 2;
    }

    /// <summary>
    ///     Inverse Hyperbolic Cosecant
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double Arcsch(double d)
    {
        if (Math.Abs(d) < double.Epsilon)
            return double.NaN;

        //the Trigonometric Symmetry is applied: arcsch(−x)=−arcsch(x)
        if (IsNegative(d))
            return -Math.Log(1.0 / -d + Math.Sqrt(1.0 / Math.Pow(d, 2.0) + 1.0));

        return Math.Log(1.0 / d + Math.Sqrt(1.0 / Math.Pow(d, 2.0) + 1.0));
    }

    /// <summary>
    ///     Inverse Hyperbolic Secant
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double Arsech(double d)
    {
        if (Math.Abs(d) < double.Epsilon)
            return double.NaN;

        if (d is < 0.0 or > 1.0)
            return double.NaN;

        return Math.Log(1.0 / d + Math.Sqrt(1.0 / Math.Pow(d, 2.0) - 1.0));
    }

    public static double Arcoth(double d)
    {
        if (double.IsInfinity(d))
            return 0.0;

        if (Math.Abs(d) <= 1.0)
            return double.NaN;

        return Math.Log((d + 1.0) / (d - 1.0)) / 2;
    }

    #endregion

    public static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    public static double RadiansToDegrees(double radians)
    {
        return radians * 180.0 / Math.PI;
    }

    private static bool IsNegative(double d)
    {
        return BitConverter.DoubleToInt64Bits(d) < 0;
    }
}