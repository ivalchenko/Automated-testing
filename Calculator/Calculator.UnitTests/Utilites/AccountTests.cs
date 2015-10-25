using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator.Utilites;

namespace Calculator.UnitTests.Utilites
{
    // my first acquaintance with unit tests
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void GetAccountId_WasInitializedWithId_ReturnSameId()
        {
            int initId = 777;
            Account account = new Account(initId);
            Assert.AreEqual(account.GetAccountId(), initId);
        }
    }
}
