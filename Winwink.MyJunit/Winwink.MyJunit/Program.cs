using System;
using System.Reflection;

namespace Winwink.MyJunit
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = typeof(Program).Assembly.GetTypes();
            foreach (var type in types)
            {
                var isAssignableFrom = typeof(TestCase).IsAssignableFrom(type);
                if (isAssignableFrom && !type.IsAbstract)
                {
                    var obj = Activator.CreateInstance(type);
                    var setUp = TestCase.GetSetUpMethod(type);
                    if (setUp != null)
                    {
                        try
                        {
                            setUp.Invoke(obj, null);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"setUp Error, Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                        }
                    }
                    var methods = type.GetMethods();
                    foreach (var method in methods)
                    {
                        if (TestCase.IsTestMethod(method))
                        {
                            Assert.MethodInit();
                            try
                            {
                                method.Invoke(obj, null);
                                var passMessage = Assert.IsMethodPass() ? "Pass" : "Not Pass";
                                Console.WriteLine($"type:{type.Name}, method:{method.Name}, test result:{passMessage}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"type:{type.Name}, method:{method.Name}, test result:Error, ErrorMessage:{ex.Message}, Error StackTrace:{ex.StackTrace}");
                            }
                        }
                    }

                    var tearDown = TestCase.GetTearDownMethod(type);
                    if (tearDown != null)
                    {
                        try
                        {
                            tearDown.Invoke(obj, null);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"tearDown Error, Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                        }
                    }
                }
            }
        }
    }
}
