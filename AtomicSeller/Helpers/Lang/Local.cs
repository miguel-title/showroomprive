using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using System.IO;

namespace AtomicSeller
{

    public class Status
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Lang { get; set; }
        public string Active { get; set; }
        public Status(string _Code, string _Label, string _Type, string _Lang, string _Active)
        {
            Code = _Code;
            Label = _Label;
            Type = _Type;
            Lang = _Lang;
            Active = _Active;
        }

    }

    public class CommonValues
    {
        public static List<Status> StatusList = new List<Status> {
             new Status("T", "To be Processed", "ShipmentStatus", "en-US", "Y"),
             new Status("P", "Label ready to print", "ShipmentStatus", "en-US", "Y"),
             new Status("S", "Shipped", "ShipmentStatus", "en-US", "Y"),
             new Status("W", "Waiting", "ShipmentStatus", "en-US", "Y"),
             new Status("C", "Canceled", "ShipmentStatus", "en-US", "Y"),

        };

        public static List<Status> LocalizedStatusList(string StatusType)
        {
            CultureInfo Culture;
            Culture = Thread.CurrentThread.CurrentUICulture;
            string CultureCode = Culture.Name;

            List<Status> LocalStatusList = new List<Status>();

            foreach (Status StatusElement in StatusList)
            {
                if (StatusElement.Active == "Y" && StatusElement.Lang == CultureCode && StatusElement.Type == StatusType)
                    LocalStatusList.Add(StatusElement);
            }

            if (LocalStatusList.Count == 0)
                // If translation not found, default lang
                foreach (Status StatusElement in StatusList)
                {
                    if (StatusElement.Active == "Y" && StatusElement.Lang == "en-US" && StatusElement.Type == StatusType)
                        LocalStatusList.Add(StatusElement);
                }

            return LocalStatusList;
        }

    }

    public class Local
    {
        public static string LabelSheet;

        public class InternationalMessage3
        {
            public string Token { get; set; }
            public string en_US { get; set; }
            public string fr_FR { get; set; }
            public string de_DE { get; set; }
            public string es_ES { get; set; }
            public string it_IT { get; set; }
            public string zh_CHS { get; set; }
            public string nl_NL { get; set; }
            public string zh_TW { get; set; }
            public string el_GR { get; set; }
            public string ja_JP { get; set; }
            public string pt_PT { get; set; }
            public string ru_RU { get; set; }

            public InternationalMessage3(string _Token,
                string _en_US,
                string _fr_FR,
                string _de_DE,
                string _es_ES ,
                string _it_IT ,
                string _zh_CHS ,
                string _nl_NL ,
                string _zh_TW ,
                string _el_GR ,
                string _ja_JP ,
                string _pt_PT ,
                string _ru_RU )
            {
                Token = _Token;
                en_US = _en_US;
                fr_FR = _fr_FR;
                de_DE = _de_DE;
                es_ES = _es_ES;
                it_IT = _it_IT;
                zh_CHS = _zh_CHS;
                nl_NL = _nl_NL;
                zh_TW = _zh_TW;
                el_GR = _el_GR;
                ja_JP = _ja_JP;
                pt_PT = _pt_PT;
                ru_RU = _ru_RU;
            }
        }

        //public static Dictionary<string, Local.InternationalMessage3> D_Lang = new Dictionary<string, Local.InternationalMessage3>(StringComparer.OrdinalIgnoreCase);
        public static Dictionary<string, Local.InternationalMessage3> D_Lang = new Dictionary<string, Local.InternationalMessage3>();

        public static string TranslatedMessage(string MessageCode)
        {
            string Message = "";//GetLocalizedMessage3(MessageCode.ToUpper(), "en-US");
            return Message;
        }



    }
}
