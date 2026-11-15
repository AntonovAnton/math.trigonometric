#if NET11_0_OR_GREATER
using System.Numerics;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;

/*
 * Generic Complex<T> overloads. They use the same algorithms and conventions as the Complex (double) overloads:
 * principal values, branch-cut sides selected by the sign of zero (IEEE 754 / ISO C99 Annex G),
 * limit values for infinite arguments, and NaN for a NaN argument.
 */
public static partial class MathTrig
{
    #region Fundamental Trigonometric Functions

    /// <summary>
    ///     Sine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">
    ///     The floating-point type of the real and imaginary parts, for example
    ///     <see cref="Decimal32" />, <see cref="Decimal64" />, <see cref="Decimal128" />,
    ///     <see cref="float" />, <see cref="System.Half" />, <see cref="BFloat16" /> or <see cref="double" />.
    /// </typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Sin<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => new(MultiplyCosh(T.Sin(z.Real), z.Imaginary), MultiplySinh(T.Cos(z.Real), z.Imaginary));

    /// <summary>
    ///     Cosine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Cos<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => new(MultiplyCosh(T.Cos(z.Real), z.Imaginary), MultiplySinh(-T.Sin(z.Real), z.Imaginary));

    /// <summary>
    ///     Tangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Tan<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        var two = T.CreateTruncating(2);

        // tan(x ± i∞) = ±i for any x
        if (T.IsInfinity(y))
            return new Complex<T>(T.CopySign(T.Zero, T.Sin(two * x)), T.CopySign(T.One, y));

        if (T.IsInfinity(x))
            return NaN<T>();

        if (T.IsZero(y))
            return new Complex<T>(T.Tan(x), y);

        if (T.IsZero(x))
            return new Complex<T>(x, T.Tanh(y));

        // tan z = (sin x cos x + i sinh y cosh y) / (cos² x + sinh² y); for large |y| divide through by cosh 2y
        if (T.Abs(y) <= T.CreateTruncating(4))
        {
            var sin = T.Sin(x);
            var cos = T.Cos(x);
            var sinh = T.Sinh(y);
            var d = cos * cos + sinh * sinh;
            return new Complex<T>(sin * cos / d, sinh * T.Cosh(y) / d);
        }
        else
        {
            var cosh2 = T.Cosh(two * y);
            var d = T.One + T.Cos(two * x) / cosh2;
            return new Complex<T>(T.Sin(two * x) / cosh2 / d, T.Tanh(two * y) / d);
        }
    }

    /// <summary>
    ///     Cosecant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     Zero, NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Csc<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsInfinity(z.Imaginary) && !T.IsNaN(z.Real))
            return new Complex<T>(T.Zero, -T.CopySign(T.Zero, z.Imaginary));

        return Reciprocal(Sin(z));
    }

    /// <summary>
    ///     Secant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Sec<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsInfinity(z.Imaginary) && !T.IsNaN(z.Real))
            return Complex<T>.Zero;

        return Reciprocal(Cos(z));
    }

    /// <summary>
    ///     Cotangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     Zero, NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex<T> Cot<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        var two = T.CreateTruncating(2);

        // cot(x ± i∞) = ∓i for any x
        if (T.IsInfinity(y))
            return new Complex<T>(T.CopySign(T.Zero, T.Sin(two * x)), -T.CopySign(T.One, y));

        if (T.IsInfinity(x) || (T.IsZero(x) && T.IsZero(y)))
            return NaN<T>();

        if (T.IsZero(y))
            return new Complex<T>(T.One / T.Tan(x), -y);

        if (T.IsZero(x))
            return new Complex<T>(x, -T.One / T.Tanh(y));

        // cot z = (sin x cos x − i sinh y cosh y) / (sin² x + sinh² y); for large |y| divide through by cosh 2y
        if (T.Abs(y) <= T.CreateTruncating(4))
        {
            var sin = T.Sin(x);
            var cos = T.Cos(x);
            var sinh = T.Sinh(y);

            // scale tiny sin and sinh so that their squares do not underflow
            var m = T.Max(T.Abs(sin), T.Abs(sinh));
            var s = m < T.CreateTruncating(4) / T.Sqrt(T.MaxValue) ? T.One / m : T.One;
            sin *= s;
            sinh *= s;
            var d = sin * sin + sinh * sinh;
            return new Complex<T>(sin * cos / d * s, -sinh * T.Cosh(y) / d * s);
        }
        else
        {
            var cosh2 = T.Cosh(two * y);
            var d = T.One - T.Cos(two * x) / cosh2;
            return new Complex<T>(T.Sin(two * x) / cosh2 / d, -T.Tanh(two * y) / d);
        }
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc sine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Asin<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var w = Asinh(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(w.Imaginary, -w.Real);
    }

    /// <summary>
    ///     Arc cosine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc cosine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Acos<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        if (T.IsInfinity(x) || T.IsInfinity(y))
        {
            var quarterPi = T.Pi / T.CreateTruncating(4);
            T re;
            if (T.IsInfinity(y))
                re = T.IsInfinity(x) ? (T.IsPositive(x) ? quarterPi : T.CreateTruncating(3) * quarterPi) : T.Pi / T.CreateTruncating(2);
            else
                re = T.IsPositive(x) ? T.Zero : T.Pi;

            return new Complex<T>(re, -T.CopySign(T.PositiveInfinity, y));
        }

        if (IsLarge(x, y))
            return new Complex<T>(T.Abs(T.Atan2(y, x)), -T.CopySign(LogTwo<T>() + LogAbs(x, y), y));

        Sqrt(T.One - x, -y, out var s1Re, out var s1Im);
        Sqrt(T.One + x, y, out var s2Re, out var s2Im);
        return new Complex<T>(T.CreateTruncating(2) * T.Atan2(s1Re, s2Re), RealAsinh(s2Re * s1Im - s2Im * s1Re));
    }

    /// <summary>
    ///     Arc tangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc tangent.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Atan<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var w = Atanh(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(w.Imaginary, -w.Real);
    }

    /// <summary>
    ///     Arc cosecant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc cosecant, asin(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Acsc<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Asin(Reciprocal(z));

    /// <summary>
    ///     Arc secant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc secant, acos(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Asec<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Acos(Reciprocal(z));

    /// <summary>
    ///     Arc cotangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc cotangent of the value, π/2 − atan(z), whose real part lies in [0, π].
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Acot<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsZero(z.Real) && T.IsZero(z.Imaginary))
            return new Complex<T>(T.Pi / T.CreateTruncating(2), -z.Imaginary);

        var w = Atan(Reciprocal(z));
        return T.IsNegative(z.Real) ? new Complex<T>(T.Pi + w.Real, w.Imaginary) : w;
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Sinh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsInfinity(z.Real) && T.IsZero(z.Imaginary))
            return z;

        var sin = Sin(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(sin.Imaginary, -sin.Real);
    }

    /// <summary>
    ///     Hyperbolic cosine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Cosh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsInfinity(z.Real) && T.IsZero(z.Imaginary))
            return new Complex<T>(T.PositiveInfinity, MultiplyExact(z.Imaginary, z.Real));

        return Cos(new Complex<T>(-z.Imaginary, z.Real));
    }

    /// <summary>
    ///     Hyperbolic tangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Tanh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var tan = Tan(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(tan.Imaginary, -tan.Real);
    }

    /// <summary>
    ///     Hyperbolic cosecant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Csch<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var csc = Csc(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(-csc.Imaginary, csc.Real);
    }

    /// <summary>
    ///     Hyperbolic secant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Sech<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Sec(new Complex<T>(-z.Imaginary, z.Real));

    /// <summary>
    ///     Hyperbolic cotangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Coth<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var cot = Cot(new Complex<T>(-z.Imaginary, z.Real));
        return new Complex<T>(-cot.Imaginary, cot.Real);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic sine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Asinh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        if (T.IsInfinity(x) || T.IsInfinity(y))
        {
            if (!T.IsInfinity(x))
                return new Complex<T>(T.CopySign(T.PositiveInfinity, x), T.CopySign(T.Pi / T.CreateTruncating(2), y));

            return new Complex<T>(x, T.IsInfinity(y) ? T.CopySign(T.Pi / T.CreateTruncating(4), y) : T.CopySign(T.Zero, y));
        }

        if (IsLarge(x, y))
        {
            return T.IsNegative(x)
                ? new Complex<T>(-(LogTwo<T>() + LogAbs(x, y)), -T.Atan2(-y, -x))
                : new Complex<T>(LogTwo<T>() + LogAbs(x, y), T.Atan2(y, x));
        }

        Sqrt(T.One + y, -x, out var s1Re, out var s1Im);
        Sqrt(T.One - y, x, out var s2Re, out var s2Im);
        var asinRe = T.Atan2(-y, s1Re * s2Re - s1Im * s2Im);
        var asinIm = RealAsinh(s1Re * s2Im - s1Im * s2Re);
        return new Complex<T>(asinIm, -asinRe);
    }

    /// <summary>
    ///     Arc-hyperbolic cosine of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cosine, whose real part is non-negative.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Acosh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        if (T.IsInfinity(x) || T.IsInfinity(y))
        {
            var quarterPi = T.Pi / T.CreateTruncating(4);
            T im;
            if (T.IsInfinity(y))
                im = T.IsInfinity(x) ? (T.IsPositive(x) ? quarterPi : T.CreateTruncating(3) * quarterPi) : T.Pi / T.CreateTruncating(2);
            else
                im = T.IsPositive(x) ? T.Zero : T.Pi;

            return new Complex<T>(T.PositiveInfinity, T.CopySign(im, y));
        }

        if (IsLarge(x, y))
            return new Complex<T>(LogTwo<T>() + LogAbs(x, y), T.Atan2(y, x));

        Sqrt(x - T.One, y, out var s1Re, out var s1Im);
        Sqrt(x + T.One, y, out var s2Re, out var s2Im);
        return new Complex<T>(RealAsinh(s1Re * s2Re + s1Im * s2Im), T.CreateTruncating(2) * T.Atan2(s1Im, s2Re));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic tangent.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Atanh<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        var two = T.CreateTruncating(2);
        var halfPi = T.Pi / two;

        if (T.IsInfinity(x) || T.IsInfinity(y))
            return new Complex<T>(T.CopySign(T.Zero, x), T.CopySign(halfPi, y));

        if (T.IsNegative(x))
        {
            var w = Atanh(new Complex<T>(-x, -y));
            return new Complex<T>(-w.Real, -w.Imaginary);
        }

        if (IsLarge(x, y))
            return new Complex<T>(Reciprocal(z).Real, T.CopySign(halfPi, y));

        var four = T.CreateTruncating(4);
        var oneMinusX = T.One - x;
        T re;
        if (x == T.One && !T.IsZero(y))
            re = (T.Log(T.Hypot(two, y)) - T.Log(T.Abs(y))) / two;
        else
            re = Log1p(four * x / (oneMinusX * oneMinusX + y * y)) / four;

        return new Complex<T>(re, T.Atan2(two * y, oneMinusX * (T.One + x) - y * y) / two);
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cosecant, asinh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Acsch<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Asinh(Reciprocal(z));

    /// <summary>
    ///     Arc-hyperbolic secant of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic secant, acosh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex<T> Asech<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => Acosh(Reciprocal(z));

    /// <summary>
    ///     Arc-hyperbolic cotangent of the specific generic complex number.
    /// </summary>
    /// <typeparam name="T">The floating-point type of the real and imaginary parts.</typeparam>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cotangent, atanh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex<T> Acoth<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y))
            return NaN<T>();

        if (T.IsInfinity(x) || T.IsInfinity(y))
            return new Complex<T>(T.CopySign(T.Zero, x), -T.CopySign(T.Zero, y));

        if (T.IsNegative(x))
        {
            var w = Acoth(new Complex<T>(-x, -y));
            return new Complex<T>(-w.Real, -w.Imaginary);
        }

        if (IsLarge(x, y))
            return Reciprocal(z);

        var two = T.CreateTruncating(2);
        var four = T.CreateTruncating(4);
        var xMinusOne = x - T.One;
        T re;
        if (x == T.One && !T.IsZero(y))
            re = (T.Log(T.Hypot(two, y)) - T.Log(T.Abs(y))) / two;
        else
            re = Log1p(four * x / (xMinusOne * xMinusOne + y * y)) / four;

        return new Complex<T>(re, T.Atan2(-two * y, xMinusOne * (x + T.One) + y * y) / two);
    }

    #endregion

    #region Generic complex helpers

    private static Complex<T> NaN<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => new(T.NaN, T.NaN);

    private static T LogTwo<T>()
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.Log(T.CreateTruncating(2));

    /// <summary>Threshold √MaxValue / 4: below it intermediate squares cannot overflow, above it log(2z) is exact to working precision.</summary>
    private static bool IsLarge<T>(T x, T y)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var threshold = T.Sqrt(T.MaxValue) / T.CreateTruncating(4);
        return T.Abs(x) > threshold || T.Abs(y) > threshold;
    }

    private static Complex<T> Reciprocal<T>(Complex<T> z)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        T x = z.Real, y = z.Imaginary;
        if (T.IsNaN(x) || T.IsNaN(y) || (T.IsZero(x) && T.IsZero(y)))
            return NaN<T>();

        if (T.IsInfinity(x) || T.IsInfinity(y))
            return new Complex<T>(T.CopySign(T.Zero, x), -T.CopySign(T.Zero, y));

        if (T.Abs(x) >= T.Abs(y))
        {
            var r = y / x;
            var d = x + y * r;
            return new Complex<T>(T.One / d, -r / d);
        }
        else
        {
            var r = x / y;
            var d = y + x * r;
            return new Complex<T>(r / d, -T.One / d);
        }
    }

    private static void Sqrt<T>(T x, T y, out T re, out T im)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        if (T.IsZero(x) && T.IsZero(y))
        {
            re = T.Zero;
            im = y;
            return;
        }

        var two = T.CreateTruncating(2);
        var t = T.Sqrt(T.Abs(x) / two + T.Hypot(x, y) / two);
        if (!T.IsNegative(x))
        {
            re = t;
            im = y / (two * t);
        }
        else
        {
            re = T.Abs(y) / (two * t);
            im = T.CopySign(t, y);
        }
    }

    private static T MultiplyCosh<T>(T a, T y)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var cosh = T.Cosh(y);
        if (!T.IsInfinity(cosh) || T.IsInfinity(y) || T.IsZero(a))
            return MultiplyExact(a, cosh);

        var h = T.Exp(T.Abs(y) / T.CreateTruncating(2));
        return a * (h / T.CreateTruncating(2)) * h;
    }

    private static T MultiplySinh<T>(T a, T y)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var sinh = T.Sinh(y);
        if (!T.IsInfinity(sinh) || T.IsInfinity(y) || T.IsZero(a))
            return MultiplyExact(a, sinh);

        var h = T.Exp(T.Abs(y) / T.CreateTruncating(2));
        return T.CopySign(T.One, y) * a * (h / T.CreateTruncating(2)) * h;
    }

    private static T MultiplyExact<T>(T a, T b)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
        => T.IsZero(a) && !T.IsNaN(b) ? (T.IsNegative(b) ? -a : a) : a * b;

    private static T LogAbs<T>(T x, T y)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        x = T.Abs(x);
        y = T.Abs(y);
        if (x < y)
            (x, y) = (y, x);

        var r = y / x;
        return T.Log(x) + Log1p(r * r) / T.CreateTruncating(2);
    }

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

    private static T RealAsinh<T>(T x)
        where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
    {
        var a = T.Abs(x);
        T r;
        if (a > T.Sqrt(T.MaxValue) / T.CreateTruncating(4))
            r = T.Log(a) + LogTwo<T>();
        else
            r = Log1p(a + a * a / (T.One + T.Sqrt(T.One + a * a)));

        return T.CopySign(r, x);
    }

    #endregion
}

#endif