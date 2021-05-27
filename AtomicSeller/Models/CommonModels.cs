using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AtomicSeller.ViewModels;

namespace AtomicCommonAPI.Models
{
    public class RequestHeader
    {
        public string Token { get; set; }
        public string Option { get; set; }
    }

    public class ResponseHeader
    {
        public string RequestStatus { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string LanguageCode { get; set; }
    }

    public class CheckDataResponse
    {
        public bool Valid { get; set; }
        public List<string> ErrorMessages { get; set; }
        public string LanguageCode { get; set; }
        public DEALVM DEALVM { get; set; }
    }

}