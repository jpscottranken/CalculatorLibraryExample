using System;

namespace CalculatorLibrary
{
    public class StandardCalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            //  Validate that the second number is NOT zero.
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0");
            }

            return a / b;
        }
        public double Modulo(double a, double b)
        {
            //  Validate that the second number is NOT zero.
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0");
            }

            return a % b;
        }

    }
}
