using System;
using static System.Console;
using CalculatorLibrary;

namespace CalculatorConsole02
{
    internal class Program
    {
        //  Declare and initialize program constants
        const int MINSELECT = 1;
        const int MAXSELECT = 5;

        //  Declare and initialize class variabes
        static string num1Str = "";
        static string num2Str = "";
        static string selStr  = "";
        static double n1      = 0.0;
        static double n2      = 0.0;
        static int sel        = 0;
        static double result  = 0.0;
        static string theOperator = "";

        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Clear();

                //  Read in first number
                Write("Enter First Number:\t");
                num1Str = ReadLine();

                //  Read in second number
                Write("Enter Second Number:\t");
                num2Str = ReadLine();

                //  Create a menu
                WriteLine("\n\nEnter a 1 To Add n1 + n2\n");
                WriteLine("Enter a 2 To Subtract n1 - n2\n");
                WriteLine("Enter a 3 To Mutilply n1 * n2\n");
                WriteLine("Enter a 4 To Divide n1 / n2\n");
                WriteLine("Enter a 5 To Module n1 % n2\n");
                Write("\nPlease enter a 1, 2, 3, 4 or 5 now:\t");
                selStr = ReadLine();

                try
                {
                    if (IsValidData())
                    {
                        n1 = Convert.ToDouble(num1Str);
                        n2 = Convert.ToDouble(num2Str);
                        sel = Convert.ToInt32(selStr);

                        //CallCorrectFunction();
                        //DisplayOutput();
                        //keepGoing = RunProgramAgain();
                    }
                }
                catch(Exception ex)
                {
                    WriteLine(ex.Message + "\n\n" +
                              ex.GetType().ToString() + "\n" +
                              ex.StackTrace, "EXCEPTION");
                }
            }
        }

        private static bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            //  Validate first number
            errorMessage += Validator.IsPresent(num1Str, "Number1");
            errorMessage += Validator.IsDouble(num1Str, "Number1");

            //  Validate second number
            errorMessage += Validator.IsPresent(num2Str, "Number2");
            errorMessage += Validator.IsDouble(num2Str, "Number2");

            //  Validate selection
            errorMessage += Validator.IsPresent(selStr, "Selection");
            errorMessage += Validator.IsInt32(selStr, "Selection");
            errorMessage += Validator.IsWithinRange(selStr, "Selection",
                                                    MINSELECT, MAXSELECT);

            if (errorMessage != "")
            {
                success = false;
                WriteLine(errorMessage);
                ReadLine();
            }

            return success;
        }

        static private double CallCorrectFunction()
        {

            //  Instantiate a new Calculator object
            StandardCalculator sc = new StandardCalculator();

            switch (sel)
            {
                case 1:
                    result = sc.Add(n1, n2);
                    theOperator = " + ";
                    break;

                case 2:
                    result = sc.Subtract(n1, n2);
                    theOperator = " - ";
                    break;

                case 3:
                    result = sc.Multiply(n1, n2);
                    theOperator = " * ";
                    break;

                case 4:
                    result = sc.Divide(n1, n2);
                    theOperator = " / ";
                    break;

                case 5:
                    result = sc.Modulo(n1, n2);
                    theOperator = " % ";
                    break;

                default:
                    break;
            }

            return result;
        }
        static void DisplayOutput()
        {
            WriteLine($"{n1} {theOperator} {n2} = {result:n2}");
        }

        static bool RunProgramAgain()
        {
            bool retVal = true;
            string again = "";
            Write("\nRun Program Again?!? (Y / N):\t");
            again = ReadLine();

            again = again.ToUpper();
            if (again[0] != 'Y')
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
