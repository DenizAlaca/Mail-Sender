using System;
using System.Collections.Generic;

namespace MprojectLastVersion.DataDB
{
    public partial class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
