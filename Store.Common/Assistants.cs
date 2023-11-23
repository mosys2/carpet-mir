using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public static class Assistants
    {
        //Convert long text to minify text + ...
        public static string TruncateText(string? text,int count)
        {
            if(!string.IsNullOrEmpty(text))
            if(text.Length<count)
            {
                return text;
            }
            string outText=text?.Substring(0,count)+"...";
            return outText;
        }

        //Convert Date
        public static string ConvertToShamsi(string date)
        {
            if (string.IsNullOrEmpty(date)) { return "0000/00/00"; }
            DateTime d = DateTime.Parse(date);
            PersianCalendar pc = new PersianCalendar();
            string shamsi= string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
            return shamsi;  
        }
        //Convert DateTo Morning And Evening
        public static string ConvertToMorningAndEvening(DateTime? date)
        {
            if (date==null) { return "0000/00/00"; }
            return date.Value.ToString("HH:mm") + " " + ((int)(date.Value.Hour) >= 12 ? "عصر" : "صبح").ToString();
        }
    }
}
