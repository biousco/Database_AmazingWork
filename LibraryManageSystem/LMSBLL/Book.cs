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

        /// <summary>
        /// 书籍列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            return book.GetList(strWhere);
        }

        /// <summary>
        /// 单条书籍记录
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public Model.Book GetSingleBook(string book_id)
        {
            return book.GetSingleBook(book_id);
        }

        /// <summary>
        /// 借阅书籍
        /// </summary>
        /// <param name="b_book"></param>
        /// <param name="viewer"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        public Hashtable Borrow(Model.Book b_book, Model.Viewer viewer, Model.Manager manager)
        {
            return book.Borrow(b_book, viewer, manager);
        }

        /// <summary>
        /// 归还书籍
        /// </summary>
        /// <param name="viewer"></param>
        /// <param name="b_book"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        public bool ReturnBook(Model.Viewer viewer, Model.Book b_book, Model.Manager manager)
        {
            return book.ReturnBook(viewer, b_book, manager);
        }

        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="b_book"></param>
        /// <returns></returns>
        public bool AddBook(Model.Book b_book)
        {
            return book.AddBook(b_book);
        }

        /// <summary>
        /// 更新书籍
        /// </summary>
        /// <param name="b_book"></param>
        /// <returns></returns>
        public bool UpdateBook(Model.Book b_book)
        {
            return book.UpdateBook(b_book);
        }

        public bool DeleteBook(Model.Book b_book)
        {
            return book.DeleteBook(b_book);
        }
    }
}
