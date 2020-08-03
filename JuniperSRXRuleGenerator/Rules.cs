using CsvHelper.Configuration.Attributes;

namespace JuniperSRXRuleGenerator
{
    class Rules
    {
        [Name("FromZone")]
        public string FromZone { get; set; }
        [Name("ToZone")]
        public string ToZone { get; set; }
        [Name("Source")]
        public string Source { get; set; }
        [Name("Destination")]
        public string Destination { get; set; }
        [Name("RuleName")]
        public string RuleName { get; set; }
        [Name("Application")]
        public string Application { get; set; }
    }
}
