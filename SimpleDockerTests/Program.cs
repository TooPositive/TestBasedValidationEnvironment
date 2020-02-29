using System;
using System.Threading.Tasks;
using Tests.Simple;

namespace SimpleTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var simpleTest = new SimpleIOCheckTest();
            await simpleTest.RunTest();

        }
    }
}
