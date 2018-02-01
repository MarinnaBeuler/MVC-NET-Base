using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlank.Models.Requests
{
    public class ErrorLogUpdateRequest: ErrorLogAddRequest
    {
        public int Id { get; set; }
    }
}