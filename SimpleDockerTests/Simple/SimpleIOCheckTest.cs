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
        private static Func<Results> FuncTestResultCheck { get; set; }
        private string[] files;
        public SimpleIOCheckTest() : base("SimpleIOCheck", TimeSpan.FromMinutes(5), 2)
        {
            base.TestFlow = Flow;
            Guid = new Guid("6C8588B1-10EE-40D6-9B94-063451097327");
        }

        public void Flow()

        {
            var directoryToCheck = Directory.GetCurrentDirectory();
            files = Directory.GetFiles(directoryToCheck);
            Console.WriteLine($"Files from directory ({directoryToCheck}");
            Thread.Sleep(3000);
            Console.WriteLine(files);
            if (files.Length <= 0)
                throw new Exception("Didn't find any files");
        }
    }
}
