using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Mvc;

namespace AtomicSeller.Helpers
{
    public static class SelectListExtension
    {
        public static SelectList ToSelectList(this DataTable table, string valueField, string textField, object selectedValue)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[textField].ToString(),
                        Value = row[valueField].ToString()
                    });
                }
            }

            return new SelectList(list, "Value", "Text", selectedValue);
        }

        public static Dictionary<string, string> ToDictionary(this DataTable table, string keyField, string valueField)
        {
            var dict = new Dictionary<string, string>();

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (dict.ContainsKey(row[keyField].ToString()))
                    {
                        Debug.WriteLine("Dictionary already contains key " + row[keyField] + ": value " +
                                        row[valueField] + " won't be added");
                        continue;
                    }

                    dict.Add(row[keyField].ToString(), row[valueField].ToString());
                }
            }

            return dict;
        }
    }
}
