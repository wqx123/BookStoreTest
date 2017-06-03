using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookList
    {
        //Id, Title, Author, PublisherId, PublishDate, ISBN, WordsCount, UnitPrice, ContentDescription, AuthorDescription, EditorComment, TOC, CategoryId, Clicks

        private int _id;
        private string _title;
        private string _author;
        private int _publisherId;
        private DateTime _publishDate;
        private string _iSBN;
        private int _wordsCount;
        private Decimal _unitPrice;
        private string _contentDescription;
        private string _authorDescription;
        private string _editorComment;
        private string _tOC;
        private int _categoryId;
        private int _clicks;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public int PublisherId { get => _publisherId; set => _publisherId = value; }
        public DateTime PublishDate { get => _publishDate; set => _publishDate = value; }
        public string ISBN { get => _iSBN; set => _iSBN = value; }
        public int WordsCount { get => _wordsCount; set => _wordsCount = value; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
        public string ContentDescription { get => _contentDescription; set => _contentDescription = value; }
        public string AuthorDescription { get => _authorDescription; set => _authorDescription = value; }
        public string EditorComment { get => _editorComment; set => _editorComment = value; }
        public string TOC { get => _tOC; set => _tOC = value; }
        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public int Clicks { get => _clicks; set => _clicks = value; }
    }
}
