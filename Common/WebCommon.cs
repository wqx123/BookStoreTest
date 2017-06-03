using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class WebCommon
    {
        public static void RedirectPage()
        {
            HttpContext.Current.Response.Redirect("/Member/Login.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
        }

        public static string GetMd5String(string str)//对字符串进行MD5运算
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.Default.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Buffer)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GetTimeSpan(TimeSpan ts)//对时间差进行处理
        {
            if (ts.TotalDays >= 365)
            {
                return Math.Floor(ts.TotalDays / 365) + "年前";
            }
            else if (ts.TotalDays >= 30)
            {
                return Math.Floor(ts.TotalDays / 30) + "月前";
            }
            else if (ts.TotalHours >= 24)
            {
                return Math.Floor(ts.TotalDays) + "天前";
            }
            else if (ts.TotalHours >= 1)
            {
                return Math.Floor(ts.TotalHours) + "小时前";
            }
            else if (ts.TotalMinutes >= 1)
            {
                return Math.Floor(ts.TotalMinutes) + "分钟前";
            }
            else
            {
                return "刚刚";
            }

        }
    }
}
