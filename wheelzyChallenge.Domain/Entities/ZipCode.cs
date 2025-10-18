using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class ZipCode : Entity
    {
        public int zipCode { get; set; }
        public string AreaName { get; set; } = null!;
        public bool IsActive { get; set; }

        [JsonIgnore]
        public List<Car> Cars { get; set; } = new List<Car>();
        [JsonIgnore]
        public List<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
