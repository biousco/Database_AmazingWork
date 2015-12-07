using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBook
    {
        DataTable GetList(string sqlStr);
        Model.Book GetSingleBook(string book_id);
    };
}
