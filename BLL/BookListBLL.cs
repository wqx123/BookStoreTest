using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class BookListBLL
    {
        BookListDAL dal = new BookListDAL();

        public void CreateHtmlPage(int id)
        {
            BookList booklist = dal.GetBookInfo(id);
            //获取模板文件
            string template = HttpContext.Current.Request.MapPath("/Template/BookTemplate.html");
            string fileContent = File.ReadAllText(template);
            fileContent = fileContent.Replace("$title", booklist.Title).Replace("$author", booklist.Author).Replace("$unitprice", booklist.UnitPrice.ToString("0.00")).Replace("$isbn", booklist.ISBN).Replace("$content", booklist.ContentDescription).Replace("$bookId", booklist.Id.ToString());
            string dir = "/HtmlPage/" + booklist.PublishDate.Year + "/" + booklist.PublishDate.Month + "/" + booklist.PublishDate.Day + "/";
            Directory.CreateDirectory(Path.GetDirectoryName(HttpContext.Current.Request.MapPath(dir)));
            string fullDir = dir + booklist.Id + ".html";
            File.WriteAllText(HttpContext.Current.Request.MapPath(fullDir), fileContent, Encoding.UTF8);
        }

        public BookList GetBookInfo(int id)
        {
            return dal.GetBookInfo(id);
        }

        public int GetPageCount(int pageSize)//获取总的页面数量
        {
            int count = dal.GetCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)count / pageSize));
            return pageCount;
        }

        public List<BookList> GetPageList(int pageIndex, int pageSize)//获取指定页的信息
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return dal.GetPageList(start, end);
        }

        public List<BookList> GetBookList()//获取图书信息
        {
            return dal.GetBookList();
        }
    }
}
