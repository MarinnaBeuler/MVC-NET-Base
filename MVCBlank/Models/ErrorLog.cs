using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlank.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}