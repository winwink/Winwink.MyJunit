using System;
using System.Collections.Generic;
using System.Text;

namespace Winwink.MyJunit
{
    public class CalculatorTest : TestCase
    {
        Calculator calculator = null;

        public override  void  setUp()
        {
            calculator = new Calculator();
        }

        public override void tearDown()
        {

        }

        public void testAdd()
        {
            calculator.add(5);
            Assert.assertEquals(5, calculator.getResult());
        }

        public void testSubtract()
        {
            calculator.add(10);
            calculator.subtract(5);
            Assert.assertEquals(5, calculator.getResult());
        }
    }
}
