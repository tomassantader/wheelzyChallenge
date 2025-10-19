using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class Order : Entity
    {
        public int QuoteId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Quote Quote { get; set; } = null!;

        [JsonIgnore]
        public Status Status { get; set; } = null!;

        [JsonIgnore]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
