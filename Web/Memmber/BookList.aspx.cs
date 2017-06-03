using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Memmber
{
    public partial class BookList : System.Web.UI.Page
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
        }

        private void BindBookList()
        {
            int pageIndex;
            if (!int.TryParse(Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 10;
            BLL.BookListBLL bll = new BLL.BookListBLL();
            int pageCount = bll.GetPageCount(pageSize);
            PageCount = pageCount;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            this.BookListRepeater.DataSource = bll.GetPageList(pageIndex, pageSize);
            this.BookListRepeater.DataBind();
        }

        public string CutString(string str, int length)//截取字符串
        {
            return str.Length > length ? str.Substring(0, length) + "......" : str;
        }

        public string GetString(object obj)
        {
            DateTime t = Convert.ToDateTime(obj);
            return "/HtmlPage/" + t.Year + "/" + t.Month + "/" + t.Day + "/";
        }
    }
}