using DALFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBLL
{
    public class Book
    {
        IDAL.IBook book = DataAccessFactory.CreateBook();

        //书籍列表
        public DataTable GetList(string strWhere)
        {
            return book.GetList(strWhere);
        }

        //单条书籍记录
        public Model.Book GetSingleBook(string book_id)
        {
            return book.GetSingleBook(book_id);
        }

        //借阅
        public Hashtable Borrow(Model.Book b_book, Model.Viewer viewer, Model.Manager manager)
        {
            return book.Borrow(b_book, viewer, manager);
        }

        public bool ReturnBook(Model.Viewer viewer, Model.Book b_book, Model.Manager manager)
        {
            return book.ReturnBook(viewer, b_book, manager);
        }
    }
}
