using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsSave
{
    public static class Utils
    {
        public static string getTimestamp(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
