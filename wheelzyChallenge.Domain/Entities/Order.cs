using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class Order : Entity
    {
        public int QuoteId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Quote Quote { get; set; } = null!;
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
