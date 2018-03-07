using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Couchbase.Net.StepByStep.Dto
{
    public class AirlineDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Callsign { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }

        [JsonProperty("iata")]
        [Required(AllowEmptyStrings = false)]
        public string IATA { get; set; }

        [JsonProperty("icao")]
        [Required(AllowEmptyStrings = false)]
        public string ICAO { get; set; }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string  Name { get; set; }
    }
}
