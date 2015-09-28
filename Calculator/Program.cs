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

            System.Console.WriteLine("Hello now you start to use calculator by ivalchenko. Please, enter operation:");
            while (!operation.Equals("stop"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("YOU: ");
                Console.ResetColor();

                try
                {
                    operation = Convert.ToString(Console.ReadLine());
                }
                catch (System.FormatException e)
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

                Console.ForegroundColor = ConsoleColor.Cyan;
                System.Console.Write("Answer: ");
                Console.ResetColor();

                if (calculator.MakeOperation(operation, calculator.ActionIndex(operation)) == 0)
                    System.Console.WriteLine("Invalid operation! Plaese, tyr again.");
                else
                    System.Console.WriteLine(calculator.MakeOperation(operation, calculator.ActionIndex(operation)));
            }

            Console.ReadKey(true);
        }
    }
}
