using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
//using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;
using NLog.Targets;
using System.Web.Mvc;
using AtomicSeller.Models;
using System.Net;
using System.Data.Entity.SqlServer;
//using NLog.Extensions.Logging;

namespace AtomicSeller
{
    public class Tools
    {

        public static double StringToDouble(string Value)
        {
            Value = Regex.Replace(Value, ",", ".");
            if (string.IsNullOrEmpty(Value)) return 0;
            decimal DValue = 0;
            try
            {
                DValue = decimal.Parse(Value, new CultureInfo("en-US"));
            }
            catch
            {
                DValue = 0;
            }
            return Convert.ToDouble(DValue);
        }

        public static string RoundStringValue(string Value)
        {
            int IntValue = (int)StringToDouble(Value);
            return IntValue.ToString();
        }




        public static decimal ConvertStringToDecimal(string Value)
        {
            if (string.IsNullOrEmpty(Value)) return 0;
            Value = Regex.Replace(Value, "[^\\d,^\\.,^\\,]*", "");
            Value = Value.Replace(",", ".");
            if (string.IsNullOrEmpty(Value))
                return 0;
            else
                return Convert.ToDecimal(Value, new CultureInfo("en-US"));
        }

        public static string ConvertDateToString(DateTime? InputDate, string DateFormat=null)
        {
            DateTime _InputDate;
            if (InputDate == null)
                _InputDate = new DateTime(1900, 1, 1);
            else
                _InputDate = (DateTime)InputDate;

            if (DateFormat==null)
                return _InputDate.ToString("yyyyMMdd");
            else
                return _InputDate.ToString(DateFormat);
        }

        public static string FixedLength(string input, int length)
        {
            if (string.IsNullOrEmpty(input))
                return new string(' ', length);

            if (input.Length > length)
                return input.Substring(0, length);
            else
                return input.PadRight(length, ' ');
        }

            public static string Truncate(string input, int maxLength)
            {
                if (string.IsNullOrEmpty(input)) return input;
                return input.Length <= maxLength ? input : input.Substring(0, maxLength);
            }


        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }


        public static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly TempDataDictionary tempData; 

        public static void ErrorHandler(string Message, Exception ex, bool DisplayMessage, bool TraceLog, bool DisplayTrace, BaseController controller = null)
        {
        }

        

        public static string Base64Encode(string pdfPath)
        {
            byte[] pdfBytes = null;

            try
            {
                pdfBytes = File.ReadAllBytes(pdfPath);
            }
            catch
            {
                WebClient _Client = new WebClient();
                   pdfBytes = _Client.DownloadData(pdfPath);
            }

            string pdfBase64 = Convert.ToBase64String(pdfBytes);
            //string pdfBase64 = Convert.ToBase64String(pdfBytes);


            //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            //return System.Convert.ToBase64String(plainTextBytes);
            return pdfBase64;
        }



    }
}
