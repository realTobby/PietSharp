using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietSharp
{
    class Program
    {
        private static string buildVersion = "0.0";

        static void Main(string[] args)
        {
            Console.WriteLine("PietSharp v" + buildVersion);
            Console.WriteLine("===============");
            Console.Write("Path to piet code: ");
            string inputPath = Console.ReadLine();
            PietInterpret interpret = new PietInterpret(inputPath);
            interpret.Start();
            Console.ReadKey();
        }
    }
}
