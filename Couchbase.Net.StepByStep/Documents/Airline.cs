using System;
using Couchbase.Linq.Filters;
using Newtonsoft.Json;

namespace Couchbase.Net.StepByStep.Documents
{
    [DocumentTypeFilter(TypeString)]
    public class Airline
    {
        public const string TypeString = "airline";

        public string Callsign { get; set; }
        public string Country { get; set; }
        [JsonProperty("iata")]
        public string IATA { get; set; }
        [JsonProperty("icao")]
        public string ICAO { get; set; }
        public int Id { get; set; }
        public string  Name { get; set; }

        public string Type => TypeString;

        public static string GetKey(int id)
        {
            return $"{TypeString}_{id}";
        }
    }
}
