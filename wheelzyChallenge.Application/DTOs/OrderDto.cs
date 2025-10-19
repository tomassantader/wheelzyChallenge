using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheelzyChallenge.Application.DTOs
{
    public class OrderDto
    {
        public int ZipCode { get; set; }          
        public string BuyerFullName { get; set; }   
        public double Amount { get; set; }          
        public string StatusDescription { get; set; } 
        public DateTime CreatedDate { get; set; }
        public List<CarDto>? Cars { get; set; } = new List<CarDto>();
    }
}
