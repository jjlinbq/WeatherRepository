using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeather
{
    public class GetUrlEncoder
    {
        public static string UrlEncode(string str, string encode)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.GetEncoding(encode).GetBytes(str); for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }
    }
}
