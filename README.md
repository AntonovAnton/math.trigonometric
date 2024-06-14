# Math Trigonometric Functions in .NET
## Overview
This C# library provides implementations of all standard trigonometric functions, including basic functions like sine, cosine, and tangent, as well as their hyperbolic counterparts, inverse functions, and more. This library is designed to offer a comprehensive set of tools for mathematical, engineering, and scientific applications requiring trigonometric calculations.
## Missing Trigonometric Functions in .NET
The .NET includes basic trigonometric functions (sin, cos, tan, asin, acos, atan) and their hyperbolic counterparts (sinh, cosh, tanh, asinh, acosh, atanh) in the [Math](https://learn.microsoft.com/en-us/dotnet/api/system.math) class. However, the following trigonometric functions are missed in the .NET and are implemented in this library:
1. **Cot (Cotangent)**
2. **Sec (Secant)**
3. **Csc (Cosecant)**
4. **Acot (Inverse Cotangent)**
5. **Asec (Inverse Secant)**
6. **Acsc (Inverse Cosecant)**
7. **Coth (Hyperbolic Cotangent)**
8. **Sech (Hyperbolic Secant)**
9. **Csch (Hyperbolic Cosecant)**
10. **Acoth (Inverse Hyperbolic Cotangent)**
11. **Asech (Inverse Hyperbolic Secant)**
12. **Acsch (Inverse Hyperbolic Cosecant)**
## Installation
You can install this library via NuGet Package Manager. To do this, follow these steps:
1. Open your project in Visual Studio.
2. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
3. Search for MathTrigonometric.
4. Select the package and click Install.
Alternatively, you can install the package using the NuGet Package Manager Console:

        Install-Package MathTrigonometric

## Functions Included
### Basic Trigonometric Functions
1. **Sin**

    Sine of the angle is ratio of the opposite leg to hypotenuse.

       double Sin(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The sine of the input angle in range: [-1, 1].
2. **Cos**

     Cosine of the angle is ratio of the adjacent leg to hypotenuse.

        double Cos(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The cosine of the input angle in range: [-1, 1].
3. **Tan**

    Tangent of the angle is ratio of the opposite leg to adjacent one.

        double Tan(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The tangent of the input angle (any real number).
4. **Cot**

    Cotangent of the angle is ratio of the adjacent leg to opposite one.

        double Cot(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The cotangent of the input angle (any real number).
5. **Sec**

    Secant of the angle is ratio of the hypotenuse to adjacent leg.

        double Sec(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The secant of the input angle in range: (-∞, -1] ∪ [1, ∞).
6. **Csc**

    Cosecant of the angle is ratio of the hypotenuse to opposite leg.

        double Csc(double a);

    - **Input:** Angle in radians (any real number).
    - **Output:** The cosecant of the input angle in range: (-∞, -1] ∪ [1, ∞).
### Inverse Trigonometric Functions
7. **Asin**

    Arc sine is inverse of the Sine function.

        double Asin(double d);

    - **Input:** Value in range: [-1, 1].
    - **Output:** Angle in radians is limited to the range [−π/2, π/2].
8. **Acos**

    Arc cosine is inverse of the Cosine function.

        double Acos(double d);

    - **Input:** Value in range: [-1, 1].
    - **Output:** Angle in radians is limited to the range [0, π].
9. **Atan**

    Arc tangent is inverse of the Tangent function.

        double Atan(double d);

    - **Input:** Any real number.
    - **Output:** Angle in radians is limited to the range (−π/2, π/2).
10. **Acot**

    Arc cotangent is inverse of the Cotangent function.

        double Acot(double d);

    - **Input:** Any real number.
    - **Output:** Angle in radians is limited to the range (0, π).
11. **Asec**

    Arc secant is inverse of the Secant function.

        double Asec(double d);

    - **Input:** Value in range: (-∞, -1] ∪ [1, ∞).
    - **Output:** Angle in radians is limited to the range [0, π/2)∪(π/2, π].
12. **Acsc**

    Arc cosecant is inverse of the Cosecant function.

        double Acsc(double d);

    - **Input:** Value in range: (-∞, -1] ∪ [1, ∞).
    - **Output:** Angle in radians is limited to the range [−π/2, 0)∪(0, π/2].
### Hyperbolic Trigonometric Functions
13. **Sinh**

    Hyperbolic sine is defined as Sinh(x) = (e\^x − e\^−x)/2.

        double Sinh(double x);

    - **Input:** Any real number.
    - **Output:** Value (any real number).
14. **Cosh**

    Hyperbolic cosine is defined as Cosh(x) = (e\^x + e\^−x)/2.

        double Cosh(double x);

    - **Input:** Any real number.
    - **Output:** Value in range: [1, +∞).
15. **Tanh**

    Hyperbolic tangent is defined as Tanh(x) = (e\^x − e\^−x)/(e\^x + e\^−x).

        double Tanh(double x);

    - **Input:** Any real number.
    - **Output:** Value in range: (-1, 1).
16. **Coth**

    Hyperbolic cotangent is defined as Coth(x) = (e\^x + e\^−x)/(e\^x − e\^−x).

        double Coth(double x);

    - **Input:** Value in range: (−∞, 0)∪(0, +∞).
    - **Output:** Value in range: (−∞, -1)∪(1, +∞).
17. **Sech**

    Hyperbolic secant is defined as Sech(x) = 2/(e\^x + e\^−x).

        double Sech(double x);

    - **Input:** Any real number.
    - **Output:** Value in range: (0, 1].
18. **Csch**

    Hyperbolic cosecant is defined as Csch(x) = 2/(e\^x − e\^−x).

        double Csch(double x);

    - **Input:** Value in range: (−∞, 0)∪(0, +∞).
    - **Output:** Value in range: (−∞, 0)∪(0, +∞).
### Inverse Hyperbolic Trigonometric Functions
19. **Asinh**

    Arc-hyperbolic sine is inverse of the Hyperbolic sine function is defined as Arsinh(x) = ln[x + √(x\^2 + 1)].

        double Asinh(double x);

    - **Input:** Any real number.
    - **Output:** Value (any real number).
20. **Acosh**

    Arc-hyperbolic cosine is inverse of the Hyperbolic cosine function is defined as Arcosh(x) = ln[x + √(x\^2 - 1)].

        double Acosh(double x);

    - **Input:** Value in range: [1, +∞).
    - **Output:** Value in range: [0, +∞).
21. **Atanh**

    Arc-hyperbolic tangent is inverse of the Hyperbolic tangent function is defined as Artanh(x) = ln[(1 + x)/(1 − x)]/2.

        double Atanh(double x);

    - **Input:** Value in range: (-1, 1).
    - **Output:** Value (any real number).
22. **Acoth**

    Arc-hyperbolic cotangent is inverse of the Hyperbolic cotangent function is defined as Arcoth(x) = ln[(1 + x)/(x − 1)]/2.

        double Acoth(double x);

    - **Input:** Value in range: (−∞, -1)∪(1, +∞).
    - **Output:** Value in range: (−∞, 0)∪(0, +∞).
23. **Asech**

    Arc-hyperbolic secant is inverse of the Hyperbolic secant function is defined as Arsech(x) = ln([1 + √(1 − x\^2)]/x).

        double Asech(double x);

    - **Input:** Value in range: (0, 1].
    - **Output:** Value in range: [0, +∞).
24. **Acsch**

    Arc-hyperbolic cosecant is inverse of the Hyperbolic cosecant function is defined as Arcsch(x) = ln[1/x + √(1/(x\^2) + 1)].

        double Acsch(double x);

    - **Input:** Value in range: (−∞, 0)∪(0, +∞).
    - **Output:** Value in range: (−∞, -0)∪(0, +∞).
### Extra functions
25. **DegreesToRadians**

    Converts degrees to radians.

        double DegreesToRadians(double degrees);

    - **Input:** Angle in degrees (any real number).
    - **Output:** Angle in radians (any real number).
26. **RadiansToDegrees**

    Converts radians to degrees.

        double RadiansToDegrees(double radians);

    - **Input:** Angle in radians (any real number).
    - **Output:** Angle in degrees (any real number).
## How to use trigonometry in C#
Here are some examples of how to use the trigonometric functions in this library:
### Basic Trigonometric Functions
    using MathTrigonometric;

    class Program
    {
        static void Main()
        {
            double angle = Math.PI / 4; // 45 degrees in radians

            double sine = MathTrig.Sin(angle);
            double cosine = MathTrig.Cos(angle);
            double tangent = MathTrig.Tan(angle);
            double cotangent = MathTrig.Cot(angle);
            double secant = MathTrig.Sec(angle);
            double cosecant = MathTrig.Csc(angle);

            Console.WriteLine($"Sin({angle}) = {sine}");
            Console.WriteLine($"Cos({angle}) = {cosine}");
            Console.WriteLine($"Tan({angle}) = {tangent}");
            Console.WriteLine($"Cot({angle}) = {cotangent}");
            Console.WriteLine($"Sec({angle}) = {secant}");
            Console.WriteLine($"Csc({angle}) = {cosecant}");
        }
    }
### Inverse Trigonometric Functions
    using MathTrigonometric;
    
    class Program
    {
        static void Main()
        {
            double value = 0.5;
    
            double angleAsin = MathTrig.Asin(value);
            double angleAcos = MathTrig.Acos(value);
            double angleAtan = MathTrig.Atan(value);
            double angleAcot = MathTrig.Acot(value);
            double angleAsec = MathTrig.Asec(2); // sec(π/3) = 2
            double angleAcsc = MathTrig.Acsc(2); // csc(π/6) = 2
    
            Console.WriteLine($"Asin({value}) = {angleAsin}");
            Console.WriteLine($"Acos({value}) = {angleAcos}");
            Console.WriteLine($"Atan({value}) = {angleAtan}");
            Console.WriteLine($"Acot({value}) = {angleAcot}");
            Console.WriteLine($"Asec(2) = {angleAsec}");
            Console.WriteLine($"Acsc(2) = {angleAcsc}");
        }
    }
### Hyperbolic Trigonometric Functions
    using MathTrigonometric;

    class Program
    {
        static void Main()
        {
            double value = 1.0;

            double sinh = MathTrig.Sinh(value);
            double cosh = MathTrig.Cosh(value);
            double tanh = MathTrig.Tanh(value);
            double coth = MathTrig.Coth(value);
            double sech = MathTrig.Sech(value);
            double csch = MathTrig.Csch(value);

            Console.WriteLine($"Sinh({value}) = {sinh}");
            Console.WriteLine($"Cosh({value}) = {cosh}");
            Console.WriteLine($"Tanh({value}) = {tanh}");
            Console.WriteLine($"Coth({value}) = {coth}");
            Console.WriteLine($"Sech({value}) = {sech}");
            Console.WriteLine($"Csch({value}) = {csch}");
        }
    }
### Inverse Hyperbolic Trigonometric Functions
    using MathTrigonometric;

    class Program
    {
        static void Main()
        {
            double value = 0.5;

            double asinh = MathTrig.Asinh(value);
            double acosh = MathTrig.Acosh(1.5);
            double atanh = MathTrig.Atanh(value);
            double acoth = MathTrig.Acoth(2);
            double asech = MathTrig.Asech(value);
            double acsch = MathTrig.Acsch(2);

            Console.WriteLine($"Asinh({value}) = {asinh}");
            Console.WriteLine($"Acosh(1.5) = {acosh}");
            Console.WriteLine($"Atanh({value}) = {atanh}");
            Console.WriteLine($"Acoth(2) = {acoth}");
            Console.WriteLine($"Asech({value}) = {asech}");
            Console.WriteLine($"Acsch(2) = {acsch}");
        }
    }
## Contributing
Contributions are welcome! Please fork the repository and submit pull requests for any enhancements or bug fixes.
If you enjoy my work and find it valuable, please consider becoming my sponsor on GitHub. Your support will enable me to share more open-source code. Together, we can make a positive impact in the developer community!
## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/AntonovAnton/math.trigonometric?tab=MIT-1-ov-file) file for details.
## Contact
If you have any questions or suggestions, feel free to open an issue or contact me directly.