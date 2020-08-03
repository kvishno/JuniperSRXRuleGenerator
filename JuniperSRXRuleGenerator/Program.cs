using System;
using System.Collections.Generic;
using System.IO;

namespace JuniperSRXRuleGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length == 0)
            {
                path = "rules.csv";
            }
            else
            {
                path = args[0];
            }

            List<Rules> rules = ProcessData.ReadCSV(path);

            //https://social.msdn.microsoft.com/Forums/en-US/8210c6d6-3379-4692-8d4e-a66a025ecae8/how-to-save-consolewriteline-outputs-in-this-program-to-text-file-using-c?forum=vssmartdevicesvbcs
            TextWriter myText = Console.Out;
            FileStream myFileStream = new FileStream("Output.txt", FileMode.Create);
            StreamWriter myStream = new StreamWriter(myFileStream);
            myFileStream.Flush();
            Console.SetOut(myStream);

            foreach (var item in rules)
            {
                string baseLine = String.Format("set security policies from-zone {0} to-zone {1} policy {2} ", item.FromZone, item.ToZone, item.RuleName);

                ProcessData.PrintForeach(baseLine, item.Source, "match source-address ");
                ProcessData.PrintForeach(baseLine, item.Destination, "match destination-address ");
                ProcessData.PrintForeach(baseLine, item.Application, "match application ");
                Console.WriteLine(baseLine + "then permit");
                Console.WriteLine(baseLine + "then log session-init session-close");
            }

            Console.SetOut(myText);
            myStream.Close();
            myFileStream.Close();
            Console.WriteLine("\nDone");
        }
    }
}
