using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MvcLab2.Models
{
    public static class HelperModel
    {
        public static string latitude { get; set; }
        public static string longitude { get; set; }
        public static string GetUntilOrEmpty(this string text,  bool flagAfter, string stopAt = ",")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    if (flagAfter)
                        return text.Substring(charLocation + 1);
                    else
                        return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
        public static bool check_is_digit(char ch)
        {
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 44)
                return false;
            else
                return true;
        }
    }
}
