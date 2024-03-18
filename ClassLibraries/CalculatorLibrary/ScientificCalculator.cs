using System;

namespace CalculatorLibrary
{
    public class ScientificCalculator : StandardCalculator
    {
        //  Square Root Method
        public double SquareRoot(double num)
        {
            //  Validate number is positive
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Number must be non-negative for sqrt");
            }

            return Math.Sqrt(num);
        }

        //  Exponentiation Method
        public double Exponent(double num, double exponent)
        {
            return Math.Pow(num, exponent);
        }

        //  Logarithm Base 10 Method
        public double Log(double num)
        {
            //  Validate number is positive
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Number must be non-negative for sqrt");
            }

            return Math.Log10(num);
        }

        //  Natural Logarithm Method
        public double Ln(double num)
        {
            //  Validate number is positive
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Number must be non-negative for sqrt");
            }

            return Math.Log(num);
        }

    }
}
