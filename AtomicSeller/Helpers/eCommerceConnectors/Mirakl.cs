using AtomicSeller.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using AtomicSeller.ViewModels;
using MiraklAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Text;

namespace AtomicSeller.Helpers.eCommerceConnectors
{
    public class Mirakl
    {
        private static String API_KEY = "d4abb80a-340b-4029-9d40-8c681f7c9f78";
        private static String API_TRACKING_BASE_URL = "https://showroomprive2-dev.mirakl.net";

        private static String API_LABEL_BASE_URL = "https://label.prawf.showroomprive.net";
        private static String Token = "a2wyq9uc9ka6n27pfqpsv";
        private static String USERNAME = "SNI";
        private static String Password = "O03o76qrgm";
        private static String Client_ID = "0926096f-c191-41b2-a90b-959aa839db65";

        private string SendGetHttpRequest(String url)
        {
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add("Authorization", API_KEY);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private string SendPostHttpRequest(String url, String jsonParam)
        {
            string strToken = Mirakl_GetToken();
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + strToken);

            using (StreamWriter writer = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                writer.WriteLine(jsonParam);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private string SendPutHttpRequest(String url, String jsonParam)
        {
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            httpWebRequest.Headers.Add("Authorization", API_KEY);
            httpWebRequest.Accept = "application/json";

            using (StreamWriter writer = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                writer.WriteLine(jsonParam);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private string SendPostHttpRequestForToken(string url)
        {
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            string postData = "grant_type=password&client_id=" + Client_ID + "&username=" + USERNAME + "&password=" + Password;
            var data = Encoding.ASCII.GetBytes(postData);
            httpWebRequest.ContentLength = data.Length;
            using (var stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        
        public PutTrackingNumberResponse Mirakl_PutTrackingNumber(string strOrderId, string strCarrierCode, string strCarrierName, string strCarrierUrl, string strTrackingNumber)
        {
            PutTrackingNumberResponse response = new PutTrackingNumberResponse();
            ResponseHeader _ResponseHeader = new ResponseHeader();
            _ResponseHeader.LanguageCode = "En";
            _ResponseHeader.RequestStatus = "Ok";
            _ResponseHeader.ReturnCode = "AS0000";
            _ResponseHeader.ReturnMessage = "";
            response.Header = _ResponseHeader;

            PutTrackingNumberRequest request = new PutTrackingNumberRequest();
            request.carrier_code = strCarrierCode;
            request.carrier_name = strCarrierName;
            request.carrier_url = strCarrierUrl;
            request.tracking_number = strTrackingNumber;

            string jsonParam = string.Empty;
            jsonParam = JsonConvert.SerializeObject(request).ToString();

            string PutTrackingNumber_API_URL = API_TRACKING_BASE_URL + "/api/orders/" + strOrderId + "/tracking";
            try
            {
                new Mirakl().SendPutHttpRequest(PutTrackingNumber_API_URL, jsonParam);
            }
            catch (Exception ex)
            {
                _ResponseHeader.LanguageCode = "En";
                _ResponseHeader.RequestStatus = "Error";
                _ResponseHeader.ReturnCode = "WZ0"; ;
                _ResponseHeader.ReturnMessage = ex.Message;
                response.Header = _ResponseHeader;
            }

            return response;
        }

        public string Mirakl_GetToken()
        {
            string strToken = "";

            string token_url = API_LABEL_BASE_URL + "/" + Token + "/api/label/v1/auth/token";
            try
            {
                string strResult = SendPostHttpRequestForToken(token_url);
                GetTokenResponseData _data = JsonConvert.DeserializeObject<GetTokenResponseData>(strResult);
                strToken = _data.access_token;
            }
            catch (Exception ex)
            {

            }

            return strToken;
        }

        public GetLabelResponse Mirakl_GetLabel(string strOrderId)
        {
            GetLabelResponse response = new GetLabelResponse();
            ResponseHeader _ResponseHeader = new ResponseHeader();
            _ResponseHeader.LanguageCode = "En";
            _ResponseHeader.RequestStatus = "Ok";
            _ResponseHeader.ReturnCode = "AS0000";
            _ResponseHeader.ReturnMessage = "";
            response.Header = _ResponseHeader;

            GetLabelRequest request = new GetLabelRequest();
            request.referenceId = strOrderId;
            request.referenceSource = "Mirakl";
            request.mode = "Shipping";

            string jsonParam = string.Empty;
            jsonParam = JsonConvert.SerializeObject(request).ToString();
            string strResult = string.Empty;
            string GetLabel_API_URL = API_LABEL_BASE_URL + "/" + Token + "/api/label/v1/create";
            try
            {
                strResult = new Mirakl().SendPostHttpRequest(GetLabel_API_URL, jsonParam);
                GetLabelResponseData _data = JsonConvert.DeserializeObject<GetLabelResponseData>(strResult);
                response.Response = _data;
            }
            catch (Exception ex)
            {
                _ResponseHeader.LanguageCode = "En";
                _ResponseHeader.RequestStatus = "Error";
                _ResponseHeader.ReturnCode = "WZ0"; ;
                _ResponseHeader.ReturnMessage = ex.Message;
                response.Header = _ResponseHeader;
            }

            return response;
        }
    }
}