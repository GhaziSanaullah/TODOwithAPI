using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class CompletedTask
    {
        public int CompletedTaskID { get; set; }
        public int TaskID { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}