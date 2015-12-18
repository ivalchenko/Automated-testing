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
            Console.WriteLine("SIMPLE CSHARP CALCULATOR CREATED BY ILIA VALCHENKO:");
            Console.WriteLine("Enter 'stop' if you want to terminate the process.");

            while (true)
            {
                string operation;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n\nInput: ");
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

                    continue;
                }

                if (operation == "stop")
                    break;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Result: ");
                Console.ResetColor();
                Console.Write(CalculatorClass.Calculate(operation));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
