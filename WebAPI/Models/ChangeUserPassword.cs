using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ChangeUserPassword
    {
        public string password { get; set; }
        public string email { get; set; }
    }
}
