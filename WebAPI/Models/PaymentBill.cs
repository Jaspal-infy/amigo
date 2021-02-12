using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PaymentBill
    {
        public string email { get; set; }
        public int payment { get; set; } 
        public string merchantName { get; set; }
    }
}
