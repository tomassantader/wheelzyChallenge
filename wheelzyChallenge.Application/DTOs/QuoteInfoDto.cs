using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Application.DTOs
{
    public class QuoteInfoDto
    {
        public List<CarDto>? Cars { get; set; }
        public string? BuyerName { get; set; }
        public double? Amount { get; set; }
        public string? Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
