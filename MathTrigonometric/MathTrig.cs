using System;
using System.Numerics;

// ReSharper disable InconsistentNaming

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
        => Math.Sin(a);

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
        => Math.Cos(a);

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
        if (cos == 0.0)
            return double.NaN;

        return Math.Sin(a) / cos;
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
        if (sin == 0.0)
            return double.NaN;

        return 1.0 / sin;
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
        if (cos == 0.0)
            return double.NaN;

        return 1.0 / cos;
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
        if (sin == 0.0)
            return double.NaN;

        return Math.Cos(a) / sin;
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
    ///     Arc sine is inverse of the <see cref="Sin(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [−π/2, π/2].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Asin(double d)
        => Math.Asin(d);

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
    ///     Arc cosine is inverse of the <see cref="Cos(double)" /> function.
    /// </summary>
    /// <param name="d">Value in range: [-1, 1].</param>
    /// <returns>
    ///     Angle in radians is limited to the range [0, π].
    ///     This method returns <see cref="F:System.Double.NaN" /> if <paramref name="d" /> equals
    ///     <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.NegativeInfinity" />,
    ///     or <see cref="F:System.Double.PositiveInfinity" />.
    /// </returns>
    public static double Acos(double d)
        => Math.Acos(d);

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
    ///     Arc tangent is inverse of the <see cref="Tan(double)" /> function.
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
        => Math.Atan(d);

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
    ///     Arc cosecant is inverse of the <see cref="Csc(double)" /> function.
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
        => Math.Asin(1.0 / d);

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
    ///     Arc secant is inverse of the <see cref="Sec(double)" /> function.
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
        => Math.Acos(1.0 / d);

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
    ///     Arc cotangent is inverse of the <see cref="Coth(double)" />> function.
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
        //the Trigonometric Symmetry is applied: arccot(−x) = π − arccot(x)
        if (IsNegative(d))
            return Math.PI - Math.Atan(1.0 / -d);

        return Math.Atan(1.0 / d);
    }

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
        => Math.Sinh(x);

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
        => Math.Cosh(x);

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
        => Math.Tanh(x);

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
        if (sin == 0.0)
            return double.NaN;

        return 1.0 / sin;
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
        return 1.0 / cos;
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
        if (x == 0.0)
            return double.NaN;

        return 1.0 / Math.Tanh(x);
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
    ///     Arc-hyperbolic sine is inverse of the <see cref="Sinh(double)" /> function is defined as Arsinh(x) = ln[x + √(x^2 +
    ///     1)].
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
        if (double.IsInfinity(x))
            return x;

        //the Trigonometric Symmetry is applied: arsinh(−x)=−arsinh(x)
        if (IsNegative(x))
            return -Math.Log(-x + Math.Sqrt(x * x + 1.0));

        return Math.Log(x + Math.Sqrt(x * x + 1.0));
    }

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
    ///     Arc-hyperbolic cosine is inverse of the <see cref="Cosh(double)" /> function is defined as Arcosh(x) = ln[x + √(x^2
    ///     - 1)].
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

        return Math.Log(x + Math.Sqrt(x * x - 1.0));
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
    ///     Arc-hyperbolic tangent is inverse of the <see cref="Tanh(double)" /> function
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

        return Math.Log((1.0 + x) / (1.0 - x)) / 2.0;
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
    ///     Arc-hyperbolic cosecant is inverse of the <see cref="Cosh(double)" /> function
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
        if (x == 0.0)
            return double.NaN;

        //the Trigonometric Symmetry is applied: arcsch(−x)=−arcsch(x)
        if (IsNegative(x))
            return -Math.Log(1.0 / -x + Math.Sqrt(1.0 / (x * x) + 1.0));

        return Math.Log(1.0 / x + Math.Sqrt(1.0 / (x * x) + 1.0));
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
    ///     Arc-hyperbolic secant is inverse of the <see cref="Sech(double)" /> function
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
        if (x is <= 0.0 or > 1.0)
            return double.NaN;

        return Math.Log(1.0 / x + Math.Sqrt(1.0 / (x * x) - 1.0));
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
    ///     Arc-hyperbolic cotangent is inverse of the <see cref="Coth(double)" /> function
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

        return Math.Log((x + 1.0) / (x - 1.0)) / 2.0;
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

    /// <summary>
    ///     Converts degrees to radians.
    /// </summary>
    /// <param name="degrees">Angle in degrees (any real number).</param>
    /// <returns>Angle in radians (any real number).</returns>
    public static double DegreesToRadians(double degrees)
        => degrees * Math.PI / 180.0;

    /// <summary>
    ///     Converts radians to degrees.
    /// </summary>
    /// <param name="radians">Angle in radians (any real number).</param>
    /// <returns>Angle in degrees (any real number).</returns>
    public static double RadiansToDegrees(double radians)
        => radians * 180.0 / Math.PI;

    private static bool IsNegative(double d)
        => BitConverter.DoubleToInt64Bits(d) < 0;

    private static bool IsNegativeInfinity(Complex value)
        => value.Imaginary == 0.0 && double.IsNegativeInfinity(value.Real);

    private static bool IsPositiveInfinity(Complex value)
        => value.Imaginary == 0.0 && double.IsPositiveInfinity(value.Real);

    private static bool IsInfinity(Complex value)
        => double.IsInfinity(value.Real) || double.IsInfinity(value.Imaginary);
}