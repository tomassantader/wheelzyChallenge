using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class OrderDetail : Entity
    {
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public DateTime? PickedUpDate { get; set; }

        public Order Order { get; set; } = null!;
        public Car Car { get; set; } = null!;
        public List<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    }
}
