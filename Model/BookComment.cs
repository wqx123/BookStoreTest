using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookComment
    {
        //Id, Msg, CreatDateTime, BookId
        private int _id;
        private string _msg;
        private DateTime _creatDateTime;
        private int _bookId;

        public int Id { get => _id; set => _id = value; }
        public string Msg { get => _msg; set => _msg = value; }
        public DateTime CreatDateTime { get => _creatDateTime; set => _creatDateTime = value; }
        public int BookId { get => _bookId; set => _bookId = value; }
    }
}
