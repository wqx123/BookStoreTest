using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookCommentDAL
    {
        //Id, Msg, CreatDateTime, BookId
        public List<Model.BookComment> GetModel(int bookId)
        {
            string sql = "select * from BookComment where BookId=@BookId";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@BookId", bookId));
            List<Model.BookComment> list = new List<Model.BookComment>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToBookComment(dr));
                }
            }
            return list;
        }

        private BookComment RowToBookComment(DataRow dr)
        {
            Model.BookComment bookcomment = new BookComment();
            bookcomment.BookId = Convert.ToInt32(dr["BookId"]);
            bookcomment.CreatDateTime = Convert.ToDateTime(dr["CreatDateTime"]);
            bookcomment.Id = Convert.ToInt32(dr["Id"]);
            bookcomment.Msg = dr["Msg"].ToString();
            return bookcomment;
        }

        public bool Add(Model.BookComment bookcomment)//添加数据
        {
            ////Id, Msg, CreatDateTime, BookId
            string sql = "Insert into BookComment (Msg, CreatDateTime, BookId) values (@Msg,@CreatDateTime,@BookId)";
            SqlParameter[] ps =
            {
                new SqlParameter("@Msg",bookcomment.Msg),
                new SqlParameter("@CreatDateTime",bookcomment.CreatDateTime),
                new SqlParameter("@BookId",bookcomment.BookId)
            };
            return SqlHelper.ExecuteNonQuery(sql, ps) > 0;
        }
    }
}
