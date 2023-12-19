using System;
using System.Collections.Generic;

namespace MprojectLastVersion.DataDB
{
    public partial class MailAddressGroup
    {
        public int Id { get; set; }
        public int MailAddressId { get; set; }
        public int GroupId { get; set; }
        public bool? SubscriptionStatus { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
