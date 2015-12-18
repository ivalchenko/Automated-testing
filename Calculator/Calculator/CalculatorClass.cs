using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class CalculatorClass
    {
        public static int Calculate(string operation)
        {
            int operand1 = 0, operand2 = 0;

            if (operation.Contains('+'))
            {
                SetValueToOperands(operation, '+', ref operand1, ref operand2);
                return operand1 + operand2;
            }

            if (operation.Contains('-'))
            {
                SetValueToOperands(operation, '-', ref operand1, ref operand2);
                return operand1 - operand2;
            }

            if (operation.Contains('*'))
            {
                SetValueToOperands(operation, '*', ref operand1, ref operand2);
                return operand1 * operand2;
            }

            if (operation.Contains('/'))
            {
                SetValueToOperands(operation, '/', ref operand1, ref operand2);
                return operand1 / operand2;
            }


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Invalid operation!");
            Console.ResetColor();
            return 0;
        }

        private static void SetValueToOperands(string operation, char operationSymbol, ref int operand1, ref int operand2)
        {
            try
            {
                operand1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf(operationSymbol)));
                operand2 = Convert.ToInt32(operation.Substring(operation.IndexOf(operationSymbol) + 1, operation.Length - operation.IndexOf(operationSymbol) - 1));
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR:");
                Console.ResetColor();
                Console.Write(e + "\n");
            }
        }
    }
}
