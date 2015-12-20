using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CheckSummOperation1()
        {
            string operation = "100+50";
            Assert.AreEqual(Calculator.Calculate(operation), 150);
        }

        [Test]
        public void CheckSummOperation2()
        {
            // error action 
            string operation = "100+*/*50";
            Assert.AreEqual(Calculator.Calculate(operation), 150);
        }

        [Test]
        public void CheckDevideOperation()
        {
            string operation = "100/50";
            Assert.AreEqual(Calculator.Calculate(operation), 2);
        }

        [Test]
        public void DevideByZero()
        {
            string operation = "24/0";
            try
            {
                Calculator.Calculate(operation);
                Assert.Fail("No exception thrown.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is DivideByZeroException);
            }
        }

        [Test]
        public void InvalidInputOperation()
        {
            string operation = "11*/35";
            try
            {
                Calculator.Calculate(operation);
                Assert.Fail("No exception thrown.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is FormatException);
            }
        }
    }
}
