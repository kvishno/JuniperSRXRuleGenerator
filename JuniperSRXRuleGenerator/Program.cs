using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniperSRXRuleGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rules> rules = ProcessData.ReadCSV(@"rules.csv");

            foreach (var item in rules)
            {
                string baseLine = String.Format("set security policies from-zone {0} to-zone {1} policy {2} ", item.FromZone, item.ToZone, item.RuleName);

                ProcessData.PrintForeach(baseLine, item.Source, "match source-address ");
                ProcessData.PrintForeach(baseLine, item.Destination, "match destination-address ");
                ProcessData.PrintForeach(baseLine, item.Application, "match application ");
                Console.WriteLine(baseLine + "then permit");
                Console.WriteLine(baseLine + "then log session-init session-close");
            }
        }
    }
}
