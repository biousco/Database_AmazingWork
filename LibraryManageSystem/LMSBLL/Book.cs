using DALFactory;
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

        //登录
        public DataTable GetList(string strWhere)
        {
            return book.GetList(strWhere);
        }
    }
}
