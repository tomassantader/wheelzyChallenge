using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Common;

namespace wheelzyChallenge.Domain.Entities
{
    public class OrderHistory : Entity
    {
        public int OrderDetailId { get; set; }    
        public int StatusId { get; set; }
        public DateTime? UpdateDate { get; set; }
        
        public OrderDetail? OrderDetail { get; set; } = null!;
        public Status? Status { get; set; }
    }
}
