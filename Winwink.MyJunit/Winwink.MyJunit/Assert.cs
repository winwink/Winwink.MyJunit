using System;
using System.Collections.Generic;
using System.Text;

namespace Winwink.MyJunit
{
    public class Assert
    {
        public static bool MethodError = false;

        public static void MethodInit()
        {
            MethodError = false;
        }

        public static bool IsMethodPass()
        {
            return !MethodError;
        }

        public static void assertEquals(Object obj1, Object obj2)
        {
            if (!obj1.Equals(obj2))
            {
                //throw new Exception("Not Equals");
                Console.WriteLine($"{obj1} not equals {obj2}");
                MethodError = true;
            }
        }
    }
}
