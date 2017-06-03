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
    public class BookListDAL
    {
        ////Id, Title, Author, PublisherId, PublishDate, ISBN, WordsCount, UnitPrice, ContentDescription, AuthorDescription, EditorComment, TOC, CategoryId, Clicks

        public BookList GetBookInfo(int id)
        {
            string sql = "select * from BookList where Id=@Id";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@Id", id));
            BookList booklist = new BookList();
            if (dt.Rows.Count > 0)
            {
                booklist.Author = dt.Rows[0]["Author"].ToString();
                booklist.AuthorDescription = dt.Rows[0]["AuthorDescription"].ToString();
                booklist.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                booklist.Clicks = Convert.ToInt32(dt.Rows[0]["Clicks"]);
                booklist.ContentDescription = dt.Rows[0]["ContentDescription"].ToString();
                booklist.EditorComment = dt.Rows[0]["EditorComment"].ToString();
                booklist.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                booklist.ISBN = dt.Rows[0]["ISBN"].ToString();
                booklist.PublishDate = Convert.ToDateTime(dt.Rows[0]["PublishDate"]);
                booklist.PublisherId = Convert.ToInt32(dt.Rows[0]["PublisherId"]);
                booklist.Title = dt.Rows[0]["Title"].ToString();
                booklist.TOC = dt.Rows[0]["TOC"].ToString();
                booklist.UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                booklist.WordsCount = Convert.ToInt32(dt.Rows[0]["WordsCount"]);
            }
            return booklist;
        }

        public int GetCount()//获取总的记录数
        {
            string sql = "select count(*) from BookList";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
        }

        public List<BookList> GetPageList(int start, int end)//获取指定页的信息
        {
            string sql = "select * from(select *,row_number()over(order by id) as num from BookList) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] ps =
            {
                new SqlParameter("@start",start),
                new SqlParameter("@end",end)
            };
            DataTable dt = SqlHelper.ExecuteTable(sql, ps);
            List<BookList> list = new List<BookList>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToBookList(dr));
                }
            }
            return list;
        }

        public List<BookList> GetBookList()//获取图书信息
        {
            string sql = "select * from BookList";
            DataTable dt = SqlHelper.ExecuteTable(sql);
            List<BookList> booklist = new List<BookList>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    booklist.Add(RowToBookList(dr));
                }
            }
            return booklist;
        }

        private BookList RowToBookList(DataRow dr)
        {
            BookList booklist = new BookList();
            booklist.Author = dr["Author"].ToString();
            booklist.AuthorDescription = dr["AuthorDescription"].ToString();
            booklist.CategoryId = Convert.ToInt32(dr["CategoryId"]);
            booklist.Clicks = Convert.ToInt32(dr["Clicks"]);
            booklist.ContentDescription = dr["ContentDescription"].ToString();
            booklist.EditorComment = dr["EditorComment"].ToString();
            booklist.Id = Convert.ToInt32(dr["Id"]);
            booklist.ISBN = dr["ISBN"].ToString();
            booklist.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
            booklist.PublisherId = Convert.ToInt32(dr["PublisherId"]);
            booklist.Title = dr["Title"].ToString();
            booklist.TOC = dr["TOC"].ToString();
            booklist.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
            booklist.WordsCount = Convert.ToInt32(dr["WordsCount"]);
            return booklist;
        }
    }
}
