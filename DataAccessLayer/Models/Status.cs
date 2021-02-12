using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Status
    {
        public Status()
        {
            MerchantTransaction = new HashSet<MerchantTransaction>();
            User = new HashSet<User>();
            UserTransaction = new HashSet<UserTransaction>();
        }

        public byte StatusId { get; set; }
        public string StatusValue { get; set; }

        public ICollection<MerchantTransaction> MerchantTransaction { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<UserTransaction> UserTransaction { get; set; }
    }
}
