using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //请求管道中第一个事件触发以后调用的方法，完成URL重写。
            string url = Request.AppRelativeCurrentExecutionFilePath;//~/BookDetail_4976.aspx
            Match match = Regex.Match(url, @"~/BookDetail_(\d+).aspx");
            if (match.Success)
            {
                Context.RewritePath("/BookDetail.aspx?id=" + match.Groups[1].Value);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}