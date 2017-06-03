using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {
        BLL.BookCommentBLL bll = new BLL.BookCommentBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (action == "add")
            {
                AddComment(context);//添加评论
            }
            else if (action == "load")
            {
                LoadComment(context);//加载评论
            }
            else
            {
                context.Response.Write("参数错误");
            }
        }

        private void AddComment(HttpContext context)
        {
            Model.BookComment bookcomment = new Model.BookComment();
            bookcomment.BookId = Convert.ToInt32(context.Request["bookId"]);
            bookcomment.Msg = context.Request["msg"];
            bookcomment.CreatDateTime = DateTime.Now;
            if (bll.Add(bookcomment))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
        }

        private void LoadComment(HttpContext context)
        {
            int bookId = Convert.ToInt32(context.Request["bookId"]);
            List<Model.BookComment> list = bll.GetModel(bookId);//获取所在页面书的评论
            List<ViewModel.BookCommentViewModel> newList = new List<ViewModel.BookCommentViewModel>();
            foreach (Model.BookComment bookcomment in list)
            {
                ViewModel.BookCommentViewModel viewModel = new ViewModel.BookCommentViewModel();
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(bookcomment.CreatDateTime);
                viewModel.CreateDateTime = Common.WebCommon.GetTimeSpan(ts);//获取评论时间
                viewModel.Msg = bookcomment.Msg;
                newList.Add(viewModel);
            }
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(newList));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}