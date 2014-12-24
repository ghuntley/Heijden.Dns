using System;
using System.Collections.Generic;

namespace DnsTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DnsTest dnsTest = new DnsTest();

            Console.WriteLine("CERT Records for: direct.sitenv.org");
            WriteList(dnsTest.CertRecords("direct.sitenv.org"));

            //Console.WriteLine("Available QTypes");
            //WriteList(dnsTest.GetQTypes());

            //Console.WriteLine("Available QClasses");
            //WriteList(dnsTest.GetQClasses());

            Console.ReadKey();
        }

        private static void WriteList(IEnumerable<string> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
