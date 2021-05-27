using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiraklAPI.Models
{
    //common class
    public class ResponseHeader
    {
        public string RequestStatus { get; set; }

        public string ReturnCode { get; set; }

        public string ReturnMessage { get; set; }

        public string LanguageCode { get; set; }
    }    

    //Put Tracking Number Classes
    public class PutTrackingNumberRequest
    {
        public string carrier_code { get; set; }
        public string carrier_name { get; set; }
        public string carrier_url { get; set; }
        public string tracking_number { get; set; }
    }

    public class PutTrackingNumberResponse
    {
        public ResponseHeader Header { get; set; }
    }


    //Get Product Classes
    public class GetLabelRequest
    {
        public string referenceId { get; set; }
        public string referenceSource { get; set; }

        public string mode { get; set; }

    }
    public class GetLabelResponse
    {
        public ResponseHeader Header { get; set; }
        public GetLabelResponseData Response { get; set; }
    }

    public class GetLabelResponseData
    {
        public labelData data { get; set; }
        public labelstatus status { get; set; }
    }

    public class labelData
    {
        public string label { get; set; }
        public string trackingNumber { get; set; }
        public string referenceId { get; set; }
    }

    public class labelstatus
    {
        public int code { get; set; }
        public string message { get; set; }
        public string detail_message { get; set; }
    }

    public class GetTokenResponse
    {
        public ResponseHeader Header { get; set; }
        public GetTokenResponseData Response { get; set; }
    }

    public class GetTokenResponseData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}