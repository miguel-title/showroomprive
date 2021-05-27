// Decompiled with JetBrains decompiler
// Type: System.Web.WebPages.TypeHelper
// Assembly: System.Web.WebPages, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 455C0C5C-BC80-4C5A-BC3A-F7275091C0C5
// Assembly location: C:\Workspace\Axinod V3 TMA\Developpement Monaco\AtomicSeller\packages\Microsoft.AspNet.WebPages.3.2.3\lib\net45\System.Web.WebPages.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Routing;

namespace AtomicSeller.Helpers.Security.Routing
{
    internal static class TypeHelper
    {
        public static RouteValueDictionary ObjectToDictionary(object value)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            if (value != null)
            {
                foreach (PropertyHelper property in PropertyHelper.GetProperties(value))
                    routeValueDictionary.Add(property.Name, property.GetValue(value));
            }
            return routeValueDictionary;
        }

        public static RouteValueDictionary ObjectToDictionaryUncached(object value)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
            if (value != null)
            {
                foreach (PropertyHelper property in PropertyHelper.GetProperties(value))
                    routeValueDictionary.Add(property.Name, property.GetValue(value));
            }
            return routeValueDictionary;
        }

        public static void AddAnonymousObjectToDictionary(IDictionary<string, object> dictionary, object value)
        {
            foreach (KeyValuePair<string, object> keyValuePair in TypeHelper.ObjectToDictionary(value))
                dictionary.Add(keyValuePair);
        }

        public static bool IsAnonymousType(Type type)
        {
            if (type == (Type)null)
                throw new ArgumentNullException("type");
            if (!Attribute.IsDefined((MemberInfo)type, typeof(CompilerGeneratedAttribute), false) || !type.IsGenericType || !type.Name.Contains("AnonymousType") || !type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) && !type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase))
                return false;
            int num = (int)type.Attributes;
            return 0 == 0;
        }
    }
}
