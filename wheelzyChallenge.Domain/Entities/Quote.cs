using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class Quote : Entity
    {
        public int BuyerId { get; set; }
        public int ZipCodeId { get; set; }
        public double Amount { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public Buyer Buyer { get; set; } = null!;
        [JsonIgnore]
        public ZipCode ZipCode { get; set; } = null!;
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
  

    }
}