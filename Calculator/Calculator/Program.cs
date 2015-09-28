using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = "";
            Calculator calculator = new Calculator();

            Console.WriteLine("SIMPLE CSHARP CALCULATOR CREATED BY IVALCHENKO:");

            while (!operation.Equals("stop"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nInput: ");
                Console.ResetColor();

                try
                {
                    operation = Convert.ToString(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSYSTEM FORMAT EXCEPTION: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(e.StackTrace);
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\nTap to continue...");
                    Console.ReadKey(true);
                }

                if (calculator.MakeOperation(operation, calculator.ActionIndex(operation)) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine("Invalid operation! Plaese, try again.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Answer: ");
                    Console.ResetColor();
                    Console.WriteLine(calculator.MakeOperation(operation, calculator.ActionIndex(operation)));
                }  
            }

            Console.ReadKey(true);
        }
    }
}
