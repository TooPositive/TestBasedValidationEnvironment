using System;
using System.Linq;
using System.Reflection;

namespace SimpleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "-test Tests.Simple.SimpleIOCheckTest" };
            Type type = Type.GetType(GetTestName(args));
            object classInstance = Activator.CreateInstance(type, null);
            MethodInfo method = type.GetMethod("RunTest", BindingFlags.Public | BindingFlags.Instance);
            method.Invoke(classInstance, null);
            Console.WriteLine("TEST END!");
        }
        private static string GetTestName(string[] args)
        {
            return args.FirstOrDefault(x => x.Contains("-test")).Replace("-test","").Trim();
        }
    }
}
