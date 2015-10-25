using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utilites
{
    // this is the test class to my acquaintance with the NUnit
    // just sample
    public class Account : IAccount
    {
        private int id;

        public Account(int id)
        {
            this.id = id;
        }

        public int GetAccountId()
        {
            return id;
        }
    }
}
