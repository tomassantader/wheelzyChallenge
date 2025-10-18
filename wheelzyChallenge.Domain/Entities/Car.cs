using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class Car : Entity
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Submodel { get; set; } = null!;
        public DateTime Year { get; set; }
        public int ZipCodeId { get; set; }
        public bool IsActive { get; set; }
        public ZipCode ZipCode { get; set; } = null!;

        [JsonIgnore]
        public List<OrderDetail> OrdersDetails { get; set; } = new List<OrderDetail>();

    }
}
