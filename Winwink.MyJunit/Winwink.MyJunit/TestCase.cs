using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Winwink.MyJunit
{
    public abstract class TestCase
    {
        public abstract void setUp();

        public abstract void tearDown();

        public static bool IsTestMethod(MethodInfo method) => method.Name.StartsWith("test");

        public static MethodInfo GetSetUpMethod(Type type) => type.GetMethod("setUp");

        public static MethodInfo GetTearDownMethod(Type type) => type.GetMethod("tearDown");
    }
}
