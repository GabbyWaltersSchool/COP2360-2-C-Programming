using System;

namespace DivisionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string input1 = Console.ReadLine();
            
            Console.WriteLine("Enter the second number:");
            string input2 = Console.ReadLine();
            
            Divide(input1, input2);
        }

        static void Divide(string num1, string num2)
        {
            try
            {
                int number1 = Convert.ToInt32(num1);
                int number2 = Convert.ToInt32(num2);
                int result = number1 / number2;

                Console.WriteLine($"The result of division is: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: One or both inputs were not in a correct format. Please enter valid integers.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed. Please enter a non-zero divisor.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or both numbers are too large. Please enter smaller integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
