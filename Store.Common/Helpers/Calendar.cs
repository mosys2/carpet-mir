using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common.Helpers
{
    public static class Calendar
    {
        public static int ToShamsi_Mounth(this DateTime Mdate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                return persianCalendar.GetMonth(Mdate);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
