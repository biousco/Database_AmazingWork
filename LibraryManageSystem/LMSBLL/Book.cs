﻿using DALFactory;
using System;
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
    }
}
