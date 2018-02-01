using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlank.Models.Requests
{
    public class ErrorLogAddRequest
    {

        public string Title { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int ErrorSourceTypeId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}