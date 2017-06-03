using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AdminManager
{
    public partial class CreateStaticPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BLL.BookListBLL bll = new BLL.BookListBLL();
                List<Model.BookList> booklist = bll.GetBookList();
                foreach (Model.BookList book in booklist)
                {
                    bll.CreateHtmlPage(book.Id);
                }
            }
        }
    }
}