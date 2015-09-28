using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
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
            int op1, op2;

            switch (action)
            {
                case(1):
                    op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('+')));
                    op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('+'), operation.Length - operation.IndexOf('+')));
                    return op1 + op2;
                    break;

                case (2):
                    op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('-')));
                    op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('-') + 1, operation.Length - operation.IndexOf('-') - 1));
                    return op1 - op2;
                    break;

                case (3):
                    op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('*')));
                    op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('*') + 1, operation.Length - operation.IndexOf('*') - 1));
                    return op1 * op2;
                    break;

                case (4):
                    op1 = Convert.ToInt32(operation.Substring(0, operation.IndexOf('/')));
                    op2 = Convert.ToInt32(operation.Substring(operation.IndexOf('/') + 1, operation.Length - operation.IndexOf('/') - 1));
                    return op1 / op2;
                    break;
            }

            return 0;
        }
    }
}
