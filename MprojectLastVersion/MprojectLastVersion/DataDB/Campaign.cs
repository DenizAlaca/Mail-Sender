using System;
using System.Collections.Generic;

namespace MprojectLastVersion.DataDB
{
    public partial class Campaign
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? FromName { get; set; }
        public string? FromEmailAddress { get; set; }
        public string? Content { get; set; }
        public string? MailSendAddress { get; set; }
        public int GroupId { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
       
    }
}
