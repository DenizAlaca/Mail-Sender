using System;
using System.Collections.Generic;

namespace MprojectLastVersion.DataDB
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? EmailAddress { get; set; }
    }
}
