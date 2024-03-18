using System;
using static System.Console;

namespace CalculatorConsole01
{
    internal class Program
    {
        static string theOperator = "";

        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Clear();
                decimal num1 = InputANumber();
                decimal num2 = InputANumber();

                string sel = MakeASelection();
                decimal answer = CallCorrectFunction(num1, num2, sel);
                DisplayOutput(num1, num2, sel, answer);
                keepGoing = RunProgramAgain();
            }
        }

        static private decimal InputANumber()
        {
            bool result;
            string theNumberStr = "";
            decimal theNumber   = 0;

            Write("\nPlease input a number:\t");
            theNumberStr = ReadLine();
            result = decimal.TryParse(theNumberStr, out theNumber);

            if (!result)
            {
                WriteLine("\nYou Must Enter A Number. Please Try Again.");
                ReadLine();
                Clear();
                InputANumber();
            }

            return theNumber;
        }

        static private string MakeASelection()
        {
            string outputStr = "";
            string selection = "";

            outputStr += "\n\nEnter a 1 To Add n1 + n2\n";
            outputStr += "Enter a 2 To Subtract n1 - n2\n";
            outputStr += "Enter a 3 To Mutilply n1 * n2\n";
            outputStr += "Enter a 4 To Divide n1 / n2\n";
            outputStr += "Enter a 5 To Module n1 % n2\n";
            outputStr += "\nPlease enter a 1, 2, 3, 4 or 5 now:\t";
            Write(outputStr);
            selection = ReadLine();

            //  Validate
            if (selection != "1" &&  selection != "2" &&
                selection != "3" && selection != "4" &&
                selection != "5")
            {
                Write ("\nPlease enter a 1, 2, 3, 4 or 5 now:\t");
                ReadLine();
                Clear();
                MakeASelection();
            }

            return selection;
        }

        static private decimal CallCorrectFunction(decimal n1, decimal n2, 
                                                   string s)
        {
            decimal result = 0; ;

            switch(s)
            {
                case "1":
                    result = CalculateSum(n1, n2);
                    theOperator = " + ";
                    break;

                case "2":
                    result = CalculateDifference(n1, n2);
                    theOperator = " - ";
                    break;

                case "3":
                    result = CalculateProduct(n1, n2);
                    theOperator = " * ";
                    break;

                case "4":
                    result = CalculateQuotient(n1, n2);
                    theOperator = " / ";
                    break;

                case "5":
                    result = CalculateModulo(n1, n2);
                    theOperator = " % ";
                    break;

                default:
                    break;
            }

            return result;
        }

        static private decimal CalculateSum(decimal n1, decimal n2)
        {
            return n1 + n2;
        }

        static private decimal CalculateDifference(decimal n1, decimal n2)
        {
            return n1 - n2;
        }

        static private decimal CalculateProduct(decimal n1, decimal n2)
        {
            return n1 * n2;
        }

        static private decimal CalculateQuotient(decimal n1, decimal n2)
        {
            if (n2 == 0)
            {
                throw new DivideByZeroException("Illegal Attempt To Divide By 0");
            }

            return n1 / n2;
        }

        static private decimal CalculateModulo(decimal n1, decimal n2)
        {
            if (n2 == 0)
            {
                throw new DivideByZeroException("Illegal Attempt To Divide By 0");
            }

            return n1 % n2;
        }

        static void DisplayOutput(decimal num1, decimal num2, 
                                  string sel,   decimal answer)
        {
            WriteLine($"{num1} {theOperator} {num2} = {answer:n2}");
        }

        static bool RunProgramAgain()
        {
            bool retVal = true;
            string again = "";
            Write("\nRun Program Again?!? (Y / N):\t");
            again = ReadLine();

            if (again == "")
            {
                return false;
            }

            again = again.ToUpper();
      
            if (again[0] != 'Y')
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
