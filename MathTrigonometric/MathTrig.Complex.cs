using System;
using System.Numerics;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;

/*
 * Complex functions follow the IEEE 754 / ISO C99 Annex G conventions:
 *  - inverse functions return principal values; points on a branch cut take the value from the side indicated
 *    by the sign of the zero component (e.g. +0 imaginary part means the limit from the upper half-plane);
 *  - infinite arguments return the limit value where one exists;
 *  - a NaN argument returns NaN.
 * All results are computed from real System.Math functions only, so they do not depend on the
 * runtime's System.Numerics.Complex implementation (whose edge-case behavior differs across .NET versions).
 */
public static partial class MathTrig
{
    #region Fundamental Trigonometric Functions

    /// <summary>
    ///     Sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Sin(Complex z)
        => new(MultiplyCosh(Math.Sin(z.Real), z.Imaginary), MultiplySinh(Math.Cos(z.Real), z.Imaginary));

    /// <summary>
    ///     Cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Cos(Complex z)
        => new(MultiplyCosh(Math.Cos(z.Real), z.Imaginary), MultiplySinh(-Math.Sin(z.Real), z.Imaginary));

    /// <summary>
    ///     Tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Tan(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        // tan(x ± i∞) = ±i for any x
        if (double.IsInfinity(y))
            return new Complex(CopySign(0d, Math.Sin(2d * x)), CopySign(1d, y));

        if (double.IsInfinity(x))
            return ComplexNaN;

        if (y == 0d)
            return new Complex(Math.Tan(x), y);

        // tan(iy) = i tanh y
        if (x == 0d)
            return new Complex(x, Math.Tanh(y));

        // tan z = (sin x cos x + i sinh y cosh y) / (cos² x + sinh² y)
        // The denominator equals (cos 2x + cosh 2y) / 2 but is computed without cancellation near the poles.
        // For large |y| sinh y and cosh y overflow even though the ratio does not, so divide through by cosh 2y:
        //   tan z = (sin 2x / cosh 2y + i tanh 2y) / (1 + cos 2x / cosh 2y)
        if (Math.Abs(y) <= 4d)
        {
            var sin = Math.Sin(x);
            var cos = Math.Cos(x);
            var sinh = Math.Sinh(y);
            var d = cos * cos + sinh * sinh;
            return new Complex(sin * cos / d, sinh * Math.Cosh(y) / d);
        }
        else
        {
            var cosh2 = Math.Cosh(2d * y);
            var d = 1d + Math.Cos(2d * x) / cosh2;
            return new Complex(Math.Sin(2d * x) / cosh2 / d, Math.Tanh(2d * y) / d);
        }
    }

    /// <summary>
    ///     Cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     Zero, NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Csc(Complex z)
    {
        // |sin z| → ∞ as |Im z| → ∞, for any real part
        if (double.IsInfinity(z.Imaginary) && !double.IsNaN(z.Real))
            return new Complex(0d, -CopySign(0d, z.Imaginary));

        return Reciprocal(Sin(z));
    }

    /// <summary>
    ///     Secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Sec(Complex z)
    {
        // |cos z| → ∞ as |Im z| → ∞, for any real part
        if (double.IsInfinity(z.Imaginary) && !double.IsNaN(z.Real))
            return Complex.Zero;

        return Reciprocal(Cos(z));
    }

    /// <summary>
    ///     Cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals
    ///     Zero, NaN, NegativeInfinity, or PositiveInfinity.
    /// </returns>
    public static Complex Cot(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        // cot(x ± i∞) = ∓i for any x
        if (double.IsInfinity(y))
            return new Complex(CopySign(0d, Math.Sin(2d * x)), -CopySign(1d, y));

        if (double.IsInfinity(x) || (x == 0d && y == 0d))
            return ComplexNaN;

        if (y == 0d)
            return new Complex(1d / Math.Tan(x), -y);

        // cot(iy) = −i coth y
        if (x == 0d)
            return new Complex(x, -1d / Math.Tanh(y));

        // cot z = (sin x cos x − i sinh y cosh y) / (sin² x + sinh² y)
        // The denominator equals (cosh 2y − cos 2x) / 2 but is computed without cancellation near the poles.
        // For large |y|: cot z = (sin 2x / cosh 2y − i tanh 2y) / (1 − cos 2x / cosh 2y)
        if (Math.Abs(y) <= 4d)
        {
            var sin = Math.Sin(x);
            var cos = Math.Cos(x);
            var sinh = Math.Sinh(y);

            // scale tiny sin and sinh so that their squares do not underflow
            var m = Math.Max(Math.Abs(sin), Math.Abs(sinh));
            var s = m < 1e-150 ? 1d / m : 1d;
            sin *= s;
            sinh *= s;
            var d = sin * sin + sinh * sinh;
            return new Complex(sin * cos / d * s, -sinh * Math.Cosh(y) / d * s);
        }
        else
        {
            var cosh2 = Math.Cosh(2d * y);
            var d = 1d - Math.Cos(2d * x) / cosh2;
            return new Complex(Math.Sin(2d * x) / cosh2 / d, -Math.Tanh(2d * y) / d);
        }
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc sine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Asin(Complex z)
    {
        // asin z = −i asinh(iz)
        var w = Asinh(new Complex(-z.Imaginary, z.Real));
        return new Complex(w.Imaginary, -w.Real);
    }

    /// <summary>
    ///     Arc cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc cosine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acos(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
        {
            double re;
            if (double.IsInfinity(y))
                re = double.IsInfinity(x) ? (x > 0 ? Math.PI / 4 : 3 * Math.PI / 4) : Math.PI / 2;
            else
                re = x > 0 ? 0d : Math.PI;

            return new Complex(re, -CopySign(double.PositiveInfinity, y));
        }

        // acos z = ∓i acosh z ≈ ∓i log(2z) for large |z|
        if (IsLarge(x, y))
            return new Complex(Math.Abs(Math.Atan2(y, x)), -CopySign(Ln2 + LogAbs(x, y), y));

        // Kahan: acos z = 2 atan2(Re √(1−z), Re √(1+z)) + i asinh(Im(conj(√(1+z)) √(1−z)))
        Sqrt(1d - x, -y, out var s1Re, out var s1Im);
        Sqrt(1d + x, y, out var s2Re, out var s2Im);
        return new Complex(2d * Math.Atan2(s1Re, s2Re), RealAsinh(s2Re * s1Im - s2Im * s1Re));
    }

    /// <summary>
    ///     Arc tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc tangent.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Atan(Complex z)
    {
        // atan z = −i atanh(iz)
        var w = Atanh(new Complex(-z.Imaginary, z.Real));
        return new Complex(w.Imaginary, -w.Real);
    }

    /// <summary>
    ///     Arc cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc cosecant, asin(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Acsc(Complex z)
        => Asin(Reciprocal(z));

    /// <summary>
    ///     Arc secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc secant, acos(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Asec(Complex z)
        => Acos(Reciprocal(z));

    /// <summary>
    ///     Arc cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc cotangent of the value, π/2 − atan(z), whose real part lies in [0, π].
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acot(Complex z)
    {
        if (z.Real == 0d && z.Imaginary == 0d)
            return new Complex(Math.PI / 2, -z.Imaginary);

        // π/2 − atan z equals atan(1/z) when Re z ≥ +0 and π + atan(1/z) when Re z ≤ −0;
        // the reciprocal form avoids cancellation for large |z|.
        var w = Atan(Reciprocal(z));
        return IsNegative(z.Real) ? new Complex(Math.PI + w.Real, w.Imaginary) : w;
    }

    #endregion

    #region Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Hyperbolic sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Sinh(Complex z)
    {
        if (double.IsInfinity(z.Real) && z.Imaginary == 0d)
            return z;

        // Use sinh(z) = -i sin(iz) to compute via sin(z).
        var sin = Sin(new Complex(-z.Imaginary, z.Real));
        return new Complex(sin.Imaginary, -sin.Real);
    }

    /// <summary>
    ///     Hyperbolic cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Cosh(Complex z)
    {
        if (double.IsInfinity(z.Real) && z.Imaginary == 0d)
            return new Complex(double.PositiveInfinity, MultiplyExact(z.Imaginary, z.Real));

        // Use cosh(z) = cos(iz) to compute via cos(z).
        return Cos(new Complex(-z.Imaginary, z.Real));
    }

    /// <summary>
    ///     Hyperbolic tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Tanh(Complex z)
    {
        // Use tanh(z) = -i tan(iz) to compute via tan(z).
        var tan = Tan(new Complex(-z.Imaginary, z.Real));
        return new Complex(tan.Imaginary, -tan.Real);
    }

    /// <summary>
    ///     Hyperbolic cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Csch(Complex z)
    {
        // csch z = i csc(iz)
        var csc = Csc(new Complex(-z.Imaginary, z.Real));
        return new Complex(-csc.Imaginary, csc.Real);
    }

    /// <summary>
    ///     Hyperbolic secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Sech(Complex z)
        => Sec(new Complex(-z.Imaginary, z.Real)); // sech z = sec(iz)

    /// <summary>
    ///     Hyperbolic cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The hyperbolic cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Coth(Complex z)
    {
        // coth z = i cot(iz)
        var cot = Cot(new Complex(-z.Imaginary, z.Real));
        return new Complex(-cot.Imaginary, cot.Real);
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic sine.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Asinh(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
        {
            if (!double.IsInfinity(x))
                return new Complex(CopySign(double.PositiveInfinity, x), CopySign(Math.PI / 2, y));

            return new Complex(x, double.IsInfinity(y) ? CopySign(Math.PI / 4, y) : CopySign(0d, y));
        }

        // asinh z ≈ log(2z) for large |z| with Re z ≥ +0, and asinh z = −asinh(−z) otherwise
        if (IsLarge(x, y))
        {
            return IsNegative(x)
                ? new Complex(-(Ln2 + LogAbs(x, y)), -Math.Atan2(-y, -x))
                : new Complex(Ln2 + LogAbs(x, y), Math.Atan2(y, x));
        }

        // Kahan: asin w = atan2(Re w, Re(√(1−w) √(1+w))) + i asinh(Im(conj(√(1−w)) √(1+w))), with asinh z = −i asin(iz)
        // Here w = iz = −y + ix, so 1 − w = (1 + y) − ix and 1 + w = (1 − y) + ix.
        Sqrt(1d + y, -x, out var s1Re, out var s1Im);
        Sqrt(1d - y, x, out var s2Re, out var s2Im);
        var asinRe = Math.Atan2(-y, s1Re * s2Re - s1Im * s2Im);
        var asinIm = RealAsinh(s1Re * s2Im - s1Im * s2Re);
        return new Complex(asinIm, -asinRe);
    }

    /// <summary>
    ///     Arc-hyperbolic cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cosine, whose real part is non-negative.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acosh(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
        {
            double im;
            if (double.IsInfinity(y))
                im = double.IsInfinity(x) ? (x > 0 ? Math.PI / 4 : 3 * Math.PI / 4) : Math.PI / 2;
            else
                im = x > 0 ? 0d : Math.PI;

            return new Complex(double.PositiveInfinity, CopySign(im, y));
        }

        // acosh z ≈ log(2z) for large |z|
        if (IsLarge(x, y))
            return new Complex(Ln2 + LogAbs(x, y), Math.Atan2(y, x));

        // Kahan: acosh z = asinh(Re(conj(√(z−1)) √(z+1))) + i 2 atan2(Im √(z−1), Re √(z+1))
        Sqrt(x - 1d, y, out var s1Re, out var s1Im);
        Sqrt(x + 1d, y, out var s2Re, out var s2Im);
        return new Complex(RealAsinh(s1Re * s2Re + s1Im * s2Im), 2d * Math.Atan2(s1Im, s2Re));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic tangent.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Atanh(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
            return new Complex(CopySign(0d, x), CopySign(Math.PI / 2, y));

        // atanh is odd; evaluating on Re z ≥ 0 keeps 4x / ((1 − x)² + y²) non-negative, so log1p does not amplify its rounding error
        if (IsNegative(x))
        {
            var w = Atanh(new Complex(-x, -y));
            return new Complex(-w.Real, -w.Imaginary);
        }

        var ax = x;
        var ay = Math.Abs(y);

        // for large |z|: atanh z ≈ 1/z ± iπ/2
        if (IsLarge(x, y))
            return new Complex(Reciprocal(z).Real, CopySign(Math.PI / 2, y));

        // Re atanh z = ¼ log1p(4x / ((1 − x)² + y²)),  Im atanh z = ½ atan2(2y, (1 − x)(1 + x) − y²)
        double re;
        if (ax == 1d && y != 0d)
            re = CopySign(Math.Log(Hypot(2d, y) / ay) / 2d, x); // (1 − x)² + y² would underflow for tiny y
        else
            re = Log1p(4d * x / ((1d - x) * (1d - x) + y * y)) / 4d;

        return new Complex(re, Math.Atan2(2d * y, (1d - x) * (1d + x) - y * y) / 2d);
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cosecant, asinh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Acsch(Complex z)
        => Asinh(Reciprocal(z));

    /// <summary>
    ///     Arc-hyperbolic secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic secant, acosh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Asech(Complex z)
        => Acosh(Reciprocal(z));

    /// <summary>
    ///     Arc-hyperbolic cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The principal value of the arc-hyperbolic cotangent, atanh(1/z).
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acoth(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
            return new Complex(CopySign(0d, x), -CopySign(0d, y));

        // acoth is odd; evaluating on Re z ≥ 0 keeps 4x / ((x − 1)² + y²) non-negative
        if (IsNegative(x))
        {
            var w = Acoth(new Complex(-x, -y));
            return new Complex(-w.Real, -w.Imaginary);
        }

        // for large |z|: acoth z ≈ 1/z
        if (IsLarge(x, y))
            return Reciprocal(z);

        // acoth z = ½ log((z + 1) / (z − 1)), evaluated without forming 1/z:
        // Re = ¼ log1p(4x / ((x − 1)² + y²)),  Im = ½ atan2(−2y, (x − 1)(x + 1) + y²)
        double re;
        if (x == 1d && y != 0d)
            re = Math.Log(Hypot(2d, y) / Math.Abs(y)) / 2d; // (x − 1)² + y² would underflow for tiny y
        else
            re = Log1p(4d * x / ((x - 1d) * (x - 1d) + y * y)) / 4d;

        return new Complex(re, Math.Atan2(-2d * y, (x - 1d) * (x + 1d) + y * y) / 2d);
    }

    #endregion

    #region Complex helpers

    private static readonly Complex ComplexNaN = new(double.NaN, double.NaN);

    private const double Ln2 = 0.69314718055994531;

    /// <summary>1/z with signed zeros preserved; 1/0 is NaN, 1/∞ is a signed zero.</summary>
    private static Complex Reciprocal(Complex z)
    {
        double x = z.Real, y = z.Imaginary;
        if (double.IsNaN(x) || double.IsNaN(y) || (x == 0d && y == 0d))
            return ComplexNaN;

        if (double.IsInfinity(x) || double.IsInfinity(y))
            return new Complex(CopySign(0d, x), -CopySign(0d, y));

        // Smith's algorithm
        if (Math.Abs(x) >= Math.Abs(y))
        {
            var r = y / x;
            var d = x + y * r;
            return new Complex(1d / d, -r / d);
        }
        else
        {
            var r = x / y;
            var d = y + x * r;
            return new Complex(r / d, -1d / d);
        }
    }

    /// <summary>Principal square root of x + iy, honoring the sign of a zero imaginary part.</summary>
    private static void Sqrt(double x, double y, out double re, out double im)
    {
        if (x == 0d && y == 0d)
        {
            re = 0d;
            im = y;
            return;
        }

        // halves are taken before adding to avoid overflow
        var t = Math.Sqrt(Math.Abs(x) / 2d + Hypot(x, y) / 2d);
        if (x >= 0d)
        {
            re = t;
            im = y / (2d * t);
        }
        else
        {
            re = Math.Abs(y) / (2d * t);
            im = CopySign(t, y);
        }
    }

    /// <summary>a·cosh y without intermediate overflow when cosh y alone exceeds double.MaxValue.</summary>
    private static double MultiplyCosh(double a, double y)
    {
        var cosh = Math.Cosh(y);
        if (!double.IsInfinity(cosh) || double.IsInfinity(y) || a == 0d)
            return MultiplyExact(a, cosh);

        // cosh y = e^|y| / 2 for |y| > 710; split e^|y| = h·h to keep the product finite when it fits
        var h = Math.Exp(Math.Abs(y) / 2d);
        return a * (0.5 * h) * h;
    }

    /// <summary>a·sinh y without intermediate overflow when sinh y alone exceeds double.MaxValue.</summary>
    private static double MultiplySinh(double a, double y)
    {
        var sinh = Math.Sinh(y);
        if (!double.IsInfinity(sinh) || double.IsInfinity(y) || a == 0d)
            return MultiplyExact(a, sinh);

        var h = Math.Exp(Math.Abs(y) / 2d);
        return CopySign(1d, y) * a * (0.5 * h) * h;
    }

    /// <summary>log|x + iy| without overflow or underflow of the modulus.</summary>
    private static double LogAbs(double x, double y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        if (x < y)
            (x, y) = (y, x);

        var r = y / x;
        return Math.Log(x) + Log1p(r * r) / 2d;
    }

    /// <summary>Threshold above which inverse functions use their asymptotic form log(2z) (relative error below 1e-300).</summary>
    private const double AsymptoticThreshold = 1e150;

    private static bool IsLarge(double x, double y)
        => Math.Abs(x) > AsymptoticThreshold || Math.Abs(y) > AsymptoticThreshold;

    /// <summary>a·b, but an exact zero factor stays a (signed) zero even when b is infinite.</summary>
    private static double MultiplyExact(double a, double b)
        => a == 0d && !double.IsNaN(b) ? (IsNegative(b) ? -a : a) : a * b;

    private static double CopySign(double magnitude, double sign)
        => IsNegative(sign) ? -Math.Abs(magnitude) : Math.Abs(magnitude);

    private static double Hypot(double x, double y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        if (double.IsInfinity(x) || double.IsInfinity(y))
            return double.PositiveInfinity;

        if (x < y)
            (x, y) = (y, x);

        if (x == 0d)
            return 0d;

        var r = y / x;
        return x * Math.Sqrt(1d + r * r);
    }

    /// <summary>log(1 + x), accurate for small x.</summary>
    private static double Log1p(double x)
    {
        if (double.IsPositiveInfinity(x))
            return x;

        var u = 1d + x;
        if (u == 1d)
            return x;

        return Math.Log(u) * x / (u - 1d);
    }

    /// <summary>asinh x, accurate for small and large |x|.</summary>
    private static double RealAsinh(double x)
    {
        var a = Math.Abs(x);
        double r;
        if (a > 1e8)
            r = Math.Log(a) + Ln2;
        else
            r = Log1p(a + a * a / (1d + Math.Sqrt(1d + a * a)));

        return CopySign(r, x);
    }

    #endregion
}