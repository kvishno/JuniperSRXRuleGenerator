using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.Linq;
using System.IO;
using System.Globalization;

namespace JuniperSRXRuleGenerator
{
    class ProcessData
    {
        public static List<Rules> ReadCSV(string FilePath)
        {
            List<Rules> records;
            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.CreateSpecificCulture("en-GB")))
            {
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.Delimiter = ";";
                records = csv.GetRecords<Rules>().ToList();
            }
            return records;
        }

        public static List<string> SplitString(string s)
        {
            return s.Split(' ').ToList();
        }
        public static void PrintForeach(string baseline, string items, string mid)
        {
            var list = SplitString(items);
            foreach (var item in list)
            {
                Console.WriteLine(baseline + mid + item);
            }
        }
    }
}
