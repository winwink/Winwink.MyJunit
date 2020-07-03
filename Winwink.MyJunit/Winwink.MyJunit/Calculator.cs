using System;
using System.Collections.Generic;
using System.Text;

namespace Winwink.MyJunit
{
    public class Calculator
    {
        private int result = 0;

        public void add(int value)
        {
            result += value;
        }

        public void subtract(int value)
        {
            result -= value;
        }

        public int getResult()
        {
            return result;
        }
    }

}
