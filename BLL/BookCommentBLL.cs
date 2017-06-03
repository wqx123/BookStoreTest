using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookCommentBLL
    {
        DAL.BookCommentDAL dal = new DAL.BookCommentDAL();

        public List<Model.BookComment> GetModel(int bookId)
        {
            return dal.GetModel(bookId);
        }

        public bool Add(Model.BookComment bookcomment)//添加数据
        {
            return dal.Add(bookcomment);
        }
    }
}
