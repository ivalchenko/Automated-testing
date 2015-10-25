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
            CalculatorClass calc = new CalculatorClass();
            Assert.AreEqual(calc.MakeOperation(operation, calc.ActionIndex(operation)), 150);
        }

        [Test]
        public void CheckSummOperation2()
        {
            // error action 
            string operation = "100+*/*50";
            CalculatorClass calc = new CalculatorClass();
            Assert.AreEqual(calc.MakeOperation(operation, calc.ActionIndex(operation)), 150);
        }

        [Test]
        public void CheckChoosingOperation1()
        {
            string operation = "100+50";
            CalculatorClass calc = new CalculatorClass();
            Assert.AreEqual(calc.ActionIndex(operation), 1);
        }

        [Test]
        public void CheckChoosingOperation2()
        {
            string operation = "100/50";
            CalculatorClass calc = new CalculatorClass();
            Assert.AreEqual(calc.ActionIndex(operation), 4);
        }

        [Test]
        public void CheckDevideOperation()
        {
            string operation = "100/50";
            CalculatorClass calc = new CalculatorClass();
            Assert.AreEqual(calc.MakeOperation(operation, calc.ActionIndex(operation)), 2);
        }

        [Test]
        public void DevideByZero()
        {
            string operation = "24/0";
            CalculatorClass calc = new CalculatorClass();
            //Assert.AreEqual(calc.MakeOperation(operation, calc.ActionIndex(operation)), 2);
            Assert.Fail();
        }
    }
}
