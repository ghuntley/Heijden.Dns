using System;
using System.Collections.Generic;
using Heijden.DNS;

namespace DnsTestConsoleApp
{
    public class DnsTest
    {
        private readonly Resolver _resolver;

        public DnsTest()
        {
            _resolver = new Resolver();
            _resolver.Recursion = true;
            _resolver.UseCache = true;
            _resolver.DnsServer = "8.8.8.8"; // Google Public DNS

            _resolver.TimeOut = 1000;
            _resolver.Retries = 3;
            _resolver.TransportType = TransportType.Tcp;
        }

        public IList<string> CertRecords(string name)
        {
            IList<string> records = new List<string>();
            const QType qType = QType.CERT;
            const QClass qClass = QClass.IN;

            Response response = _resolver.Query(name, qType, qClass);
            
            foreach (RecordCERT record in response.RecordsCERT)
            {
                records.Add(record.ToString());
                
            }

            return records;
        }

        public IList<string> GetQTypes()
        {
            IList<string> items = new List<string>();
            Array types = Enum.GetValues(typeof(QType));

            for (int index = 0; index < types.Length; index++)
            {
                items.Add(types.GetValue(index).ToString());
            }

            return items;
        }

        public IList<string> GetQClasses()
        {
            IList<string> items = new List<string>();
            Array types = Enum.GetValues(typeof(QClass));

            for (int index = 0; index < types.Length; index++)
            {
                items.Add(types.GetValue(index).ToString());
            }

            return items;
        }
    }
}
