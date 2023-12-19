using System;
using System.Collections.Generic;

namespace MprojectLastVersion.DataDB
{
    public partial class MailAddress
    {
        public int Id { get; set; }
        public string? MailAddress1 { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
