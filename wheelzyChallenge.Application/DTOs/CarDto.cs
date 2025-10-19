using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Application.DTOs
{
    public class CarDto
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? SubModel { get; set; }
        public DateTime? Year { get; set; }
        public List<OrderHistoryDto>? OrderHistory { get; set; } = new List<OrderHistoryDto>();

    }
}
