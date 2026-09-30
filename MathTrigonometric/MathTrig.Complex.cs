#if NET8_0_OR_GREATER

using System;
using System.Numerics;

// ReSharper disable InconsistentNaming

namespace MathTrigonometric;


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
    {
        var sin = Math.Sin(z.Real);
        var cos = Math.Cos(z.Real);
        return new Complex(sin * Math.Cosh(z.Imaginary), cos * Math.Sinh(z.Imaginary));
    }

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
    {
        var sin = Math.Sin(z.Real);
        var cos = Math.Cos(z.Real);
        return new Complex(cos * Math.Cosh(z.Imaginary), -sin * Math.Sinh(z.Imaginary));
    }

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
        // tan z = sin z / cos z, but to avoid unnecessary repeated trig computations, use
        //   tan z = (sin(2x) + i sinh(2y)) / (cos(2x) + cosh(2y))
        // (see Abramowitz & Stegun 4.3.57 or derive by hand), and compute trig functions here.

        // This approach does not work for |y| > ~355, because sinh(2y) and cosh(2y) overflow,
        // even though their ratio does not. In that case, divide through by cosh to get:
        //   tan z = (sin(2x) / cosh(2y) + i \tanh(2y)) / (1 + cos(2x) / cosh(2y))
        // which correctly computes the (tiny) real part and the (normal-sized) imaginary part.

        var x2 = 2.0 * z.Real;
        var y2 = 2.0 * z.Imaginary;
        var sin = Math.Sin(x2);
        var cos = Math.Cos(x2);
        var cosh = Math.Cosh(y2);
        if (Math.Abs(z.Imaginary) <= 4.0)
        {
            var d = cos + cosh;
            return new Complex(sin / d, Math.Sinh(y2) / d);
        }
        else
        {
            var d = 1.0 + cos / cosh;
            return new Complex(sin / cosh / d, Math.Tanh(y2) / d);
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
        var sin = Sin(z);

        if (IsInfinity(sin))
            return Complex.Zero;

        return Complex.One / sin;
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
        var cos = Cos(z);

        if (IsInfinity(cos))
            return Complex.Zero;

        return Complex.One / cos;
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
        if (double.IsInfinity(z.Real) || double.IsNaN(z.Real))
            return new Complex(double.NaN, double.NaN);

        if (double.IsNegativeInfinity(z.Imaginary))
            return Complex.ImaginaryOne;

        if (double.IsPositiveInfinity(z.Imaginary))
            return new Complex(0d, -1d);

        var sin = Math.Sin(z.Real);
        var cos = Math.Cos(z.Real);
        var coshI = Math.Cosh(z.Imaginary);
        var sinhI = Math.Sinh(z.Imaginary);
        return new Complex(cos * coshI, -sin * sinhI) / new Complex(sin * coshI, cos * sinhI);
    }

    #endregion

    #region Inverse Trigonometric Functions

    /// <summary>
    ///     Arc sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Asin(Complex z)
        => Complex.Asin(z);

    /// <summary>
    ///     Arc cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acos(Complex z)
        => Complex.Acos(z);

    /// <summary>
    ///     Arc tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Atan(Complex z)
    {
        //TODO: create an issue for dotnet/runtime to fix Complex.Atan method
        if ((double.IsInfinity(z.Real) && !double.IsInfinity(z.Imaginary)) ||
            (double.IsInfinity(z.Imaginary) && !double.IsInfinity(z.Real)))
        {
            return IsNegative(z.Real) || IsNegative(z.Imaginary)
                ? new Complex(-Math.PI / 2, 0)
                : new Complex(Math.PI / 2, 0);
        }

        return Complex.Atan(z);
    }

    /// <summary>
    ///     Arc cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Acsc(Complex z)
        => Complex.Asin(Complex.One / z);

    /// <summary>
    ///     Arc secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Asec(Complex z)
        => Complex.Acos(Complex.One / z);

    /// <summary>
    ///     Arc cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acot(Complex z)
    {
        if (z == Complex.Zero)
            return new Complex(Math.PI / 2, 0d);

        var oneOverZ = Complex.One / z;
        if (IsInfinity(oneOverZ))
            return new Complex(Math.PI / 2, 0d);

        //the Trigonometric Symmetry is applied: arccot(−z) = π − arccot(z)
        if (IsNegative(z.Real))
            return Math.PI - Complex.Atan(-oneOverZ);

        return Complex.Atan(oneOverZ);
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
        //TODO: create an issue for dotnet/runtime to fix Complex.Sinh method
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
        //TODO: create an issue for dotnet/runtime to fix Complex.Cosh method
        if (double.IsInfinity(z.Real) && z.Imaginary == 0d)
            return new Complex(double.PositiveInfinity, 0);

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
        var sin = Sinh(z);
        if (double.IsInfinity(sin.Real) && double.IsInfinity(sin.Imaginary))
            return Complex.Zero;

        return Complex.One / sin;
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
    {
        var cos = Cosh(z);
        if (double.IsInfinity(cos.Real) && double.IsInfinity(cos.Imaginary))
            return Complex.Zero;

        return Complex.One / cos;
    }

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
        var tanh = Tanh(z);
        return Complex.One / tanh;
    }

    #endregion

    #region Inverse Hyperbolic Trigonometric Functions

    /// <summary>
    ///     Arc-hyperbolic sine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic sine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Asinh(Complex z)
    {
        if (double.IsPositiveInfinity(z.Real) && !double.IsInfinity(z.Imaginary))
            return new Complex(double.PositiveInfinity, 0d);

        if (double.IsNegativeInfinity(z.Real) && !double.IsInfinity(z.Imaginary))
            return new Complex(double.NegativeInfinity, 0d);

        //the Trigonometric Symmetry is applied: arsinh(−z)=−arsinh(z)
        if (IsNegative(z.Real))
            return -Complex.Log(-z + Complex.Sqrt(z * z + Complex.One));

        return Complex.Log(z + Complex.Sqrt(z * z + Complex.One));
    }

    /// <summary>
    ///     Arc-hyperbolic cosine of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic cosine of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acosh(Complex z)
    {
        if (IsPositiveInfinity(z))
            return new Complex(double.PositiveInfinity, 0d);

        if (IsNegativeInfinity(z))
            return new Complex(double.PositiveInfinity, double.NaN);

        return Complex.Log(z + Complex.Sqrt(z * z - Complex.One));
    }

    /// <summary>
    ///     Arc-hyperbolic tangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic tangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Atanh(Complex z)
    {
        if (z == Complex.One)
            return new Complex(double.PositiveInfinity, 0d);

        if (z == -Complex.One)
            return new Complex(double.NegativeInfinity, 0d);

        if ((double.IsPositiveInfinity(z.Real) && !double.IsInfinity(z.Imaginary)) ||
            (!double.IsInfinity(z.Real) && double.IsNegativeInfinity(z.Imaginary)))
            return new Complex(0d, -Math.PI / 2);

        if ((double.IsNegativeInfinity(z.Real) && !double.IsInfinity(z.Imaginary)) ||
            (!double.IsInfinity(z.Real) && double.IsPositiveInfinity(z.Imaginary)))
            return new Complex(0d, Math.PI / 2);

        //the Trigonometric Symmetry is applied: artanh(−x)=−artanh(x)
        if (IsNegative(z.Real))
            return -Complex.Log((1.0 - z) / (1.0 + z)) / 2.0;

        return Complex.Log((1.0 + z) / (1.0 - z)) / 2.0;
    }

    /// <summary>
    ///     Arc-hyperbolic cosecant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic cosecant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Acsch(Complex z)
    {
        if (z == Complex.Zero)
            return new Complex(double.NaN, double.NaN);

        if (IsInfinity(z))
            return Complex.Zero;

        var zz = z * z;
        if (zz == Complex.Zero)
            return new Complex(IsNegative(z.Real) ? double.NegativeInfinity : double.PositiveInfinity, 0d);

        //the Trigonometric Symmetry is applied: arcsch(−z)=−arcsch(z)
        if (IsNegative(z.Real))
            return -Complex.Log(1.0 / -z + Complex.Sqrt(1.0 / zz + 1.0));

        return Complex.Log(1.0 / z + Complex.Sqrt(1.0 / zz + 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic secant of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic secant of the value.
    ///     This method returns NaN if <paramref name="z" /> equals Zero or NaN.
    /// </returns>
    public static Complex Asech(Complex z)
    {
        if (z == Complex.Zero)
            return new Complex(double.NaN, double.NaN);

        if ((double.IsInfinity(z.Real) && !double.IsInfinity(z.Imaginary)) ||
            (!double.IsInfinity(z.Real) && double.IsNegativeInfinity(z.Imaginary)))
            return new Complex(0d, Math.PI / 2);

        if (!double.IsInfinity(z.Real) && double.IsPositiveInfinity(z.Imaginary))
            return new Complex(0d, -Math.PI / 2);

        var zz = z * z;
        if (zz == Complex.Zero)
            return new Complex(double.PositiveInfinity, IsNegative(z.Real) ? Math.PI : 0d);

        return Complex.Log(1.0 / z + Complex.Sqrt(1.0 / zz - 1.0));
    }

    /// <summary>
    ///     Arc-hyperbolic cotangent of the specific complex number.
    /// </summary>
    /// <param name="z">A complex number.</param>
    /// <returns>
    ///     The arc-hyperbolic cotangent of the value.
    ///     This method returns NaN if <paramref name="z" /> equals NaN.
    /// </returns>
    public static Complex Acoth(Complex z)
    {
        if (z == Complex.One)
            return new Complex(double.PositiveInfinity, 0d);

        if (z == -Complex.One)
            return new Complex(double.NegativeInfinity, 0d);

        if ((double.IsInfinity(z.Real) && !double.IsInfinity(z.Imaginary)) ||
            (!double.IsInfinity(z.Real) && double.IsInfinity(z.Imaginary)))
            return Complex.Zero;

        //the Trigonometric Symmetry is applied: arcoth(−x)=−arcoth(x)
        if (IsNegative(z.Real))
            return -Complex.Log((z - 1.0) / (z + 1.0)) / 2.0;

        return Complex.Log((z + 1.0) / (z - 1.0)) / 2.0;
    }

    #endregion
}

#endif