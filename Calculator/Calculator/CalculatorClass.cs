using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorClass
    {
        public int ActionIndex(string operation)
        {
            if (operation.Contains('+'))
                return 1;

            if (operation.Contains('-'))
                return 2;

            if (operation.Contains('*'))
                return 3;

            if (operation.Contains('/'))
                return 4;

            return 0;
        }

        public int MakeOperation(string operation, int action)
        {
            int op1 = 0, op2 = 0;

            switch (action)
            {
                case(1):
                    try
                    {
                        op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('+')));
                        op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('+'), operation.Length - operation.IndexOf('+')));
                    } catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR:");
                        Console.ResetColor();
                        Console.Write(e + "\n");
                    }
                    
                    return op1 + op2;
                    break;

                case (2):
                    try
                    {
                        op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('-')));
                        op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('-') + 1, operation.Length - operation.IndexOf('-') - 1));
                    } catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR:");
                        Console.ResetColor();
                        Console.Write(e + "\n");
                    }
                    
                    return op1 - op2;
                    break;

                case (3):
                    try
                    {
                        op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('*')));
                        op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('*') + 1, operation.Length - operation.IndexOf('*') - 1));
                    } catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR:");
                        Console.ResetColor();
                        Console.Write(e + "\n");
                    }
                    
                    return op1 * op2;
                    break;

                case (4):
                    try
                    {
                        op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('/')));
                        op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('/') + 1, operation.Length - operation.IndexOf('/') - 1));
                    } catch(FormatException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR:");
                        Console.ResetColor();
                        Console.Write(e + "\n");
                    }
                    
                    try
                    {
                        return op1 / op2;
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
            }

            return 0;
        }
    }
}
