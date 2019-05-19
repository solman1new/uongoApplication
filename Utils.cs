using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uongoClient
{
    class Utils
    {
        public static int[] ConverStrDateToIntArrDate(string date)
        {
            int[] intDate = new int[date.Split(new char[] { ' ', }).Length];
            /*
             * 0 - day
             * 1 - month
             * 2 - year
             */
            intDate[0] = Convert.ToInt32(date.Split(new char[] { ' ' })[0]);
            intDate[1] = ConvertStrMonthToInt(date.Split(new char[] { ' ' })[1]);
            intDate[2] = Convert.ToInt32(date.Split(new char[] { ' ' })[2]);

            return intDate;
        }

        public static int[] GetHourAndMinutes(string str)
        {
            int[] result = new int[2];

            string[] arr = str.Split(new char[] { ':' });

            result[0] = Convert.ToInt32(arr[0]);
            result[1] = Convert.ToInt32(arr[1]);

            return result;
        }
        private static int ConvertStrMonthToInt(string strMonth)
        {
            int intMonth = 0;

            switch(strMonth)
            {
                case "января":
                    intMonth = 1;
                    break;
                case "февраля":
                    intMonth = 2;
                    break;
                case "марта":
                    intMonth = 3;
                    break;
                case "апреля":
                    intMonth = 4;
                    break;
                case "мая":
                    intMonth = 5;
                    break;
                case "июня":
                    intMonth = 6;
                    break;
                case "июля":
                    intMonth = 7;
                    break;
                case "августа":
                    intMonth = 8;
                    break;
                case "сентября":
                    intMonth = 9;
                    break;
                case "октября":
                    intMonth = 10;
                    break;
                case "ноября":
                    intMonth = 11;
                    break;
                case "декабря":
                    intMonth = 12;
                    break;
                default:
                    // ...
                    break;
            }

            return intMonth;
        }
    }
}
