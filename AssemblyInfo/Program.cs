using Dal.Model;
using GuessNumGameTest.ServicesTest;
using System;

namespace AssemblyInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dalAsseembly = new AssemblyInfo(typeof(BaseModel).Assembly);

            dalAsseembly.PrintAssemblyInfo();

            var testAssembly = new AssemblyInfo(typeof(GameServicesTest).Assembly);

            testAssembly.PrintAssemblyInfo();
        }
    }
}
