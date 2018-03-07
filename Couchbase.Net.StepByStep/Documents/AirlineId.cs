using System;
using Couchbase.Linq.Filters;

namespace Couchbase.Net.StepByStep.Documents
{
    [DocumentTypeFilter(TypeString)]
    public class AirlineId
    {
        public const string TypeString = "airlineId";

        public int Id { get; set; }

        public string Type => TypeString;

        public static string GetKey()
        {
            return TypeString;
        }
    }
}
