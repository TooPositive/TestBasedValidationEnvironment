using System;
using System.Linq;
using System.Reflection;
using Tests.Core.Simple;

namespace DockerTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting test.....");
            args = new string[] { "-test Tests.Core.Simple.SimpleIOCheckTest, Tests.Core, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null" };
            //var testNameSpace = GetTestName(args);
            Type type = Type.GetType(GetTestName(args));
            object classInstance = Activator.CreateInstance(type, null);
            MethodInfo method = type.GetMethod("RunTest", BindingFlags.Public | BindingFlags.Instance);
            method.Invoke(classInstance, null);
            System.Threading.Thread.Sleep((int)TimeSpan.FromMinutes(1).TotalMilliseconds);
            Console.WriteLine("TEST END!");
        }
        private static string GetTestName(string[] args)
        {
            return args.FirstOrDefault(x => x.Contains("-test")).Replace("-test", "").Trim();
        }
    }
}
