using System;

namespace AtomicSeller.Models
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Convertit un string en datetime? pour les dates passées en GET (ex : filtres)
        /// => http://stackoverflow.com/questions/8910482/passing-a-datetime-to-controller-via-url-causing-error-in-asp-net-mvc-3-cultur  
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns>DateTime?</returns>
        public static DateTime? GetDatetimeNullableFromString(string dateString)
        {
            DateTime date;

            return DateTime.TryParse(dateString, out date) ? date : (DateTime?)null;
        }

        /// <summary>
        /// Convertit un string en datetime pour les dates passées en GET (ex : filtres)
        /// => http://stackoverflow.com/questions/8910482/passing-a-datetime-to-controller-via-url-causing-error-in-asp-net-mvc-3-cultur  
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetDatetimeFromString(string dateString)
        {
            DateTime date;

            return DateTime.TryParse(dateString, out date) ? date : DateTime.Now;
        }
    }
}