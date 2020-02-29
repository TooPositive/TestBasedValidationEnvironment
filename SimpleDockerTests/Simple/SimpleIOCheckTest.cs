using Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static Tests.Base.Enums;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Tests.Simple
{
    public class SimpleIOCheckTest : BaseTest
    {
        private static Func<TestResult> FuncTestResultCheck { get; set; }
        private string[] files;
        public SimpleIOCheckTest() : base("SimpleIOCheck", TimeSpan.FromMinutes(5), 1)
        {
            base.TestFlow = Flow;
        }

        public async Task Flow()
        {
            var directoryToCheck = Directory.GetCurrentDirectory();
            files = Directory.GetFiles(directoryToCheck);
            Console.WriteLine($"Files from directory ({directoryToCheck}");
            await Task.Delay(3000);
            Console.WriteLine(files);
            if (files.Length <= 0)
                throw new Exception("Didn't find any files");
        }
    }
}
