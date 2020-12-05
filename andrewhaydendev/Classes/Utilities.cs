using andrewhaydendev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace andrewhaydendev.Classes
{
    public static class Utilities
    {
        public static DateTime ToDateTime(this string input)
        {
            DateTime buff = DateTime.MinValue;
            DateTime.TryParse(input, out buff);
            
            return buff;
        }

        public static bool ToBoolean(this string input)
        {
            if (input.ToInt() == 0)
                return false;
            else
                return true;
        }

        public static int ToInt(this string input)
        {
            int buff = 0;
            int.TryParse(input, out buff);

            return buff;
        }
    }
}
