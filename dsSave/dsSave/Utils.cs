using System;

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
