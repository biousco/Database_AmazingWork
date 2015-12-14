using System;
using System.Collections;
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
        Hashtable Borrow(Model.Book book, Model.Viewer viewer, Model.Manager manager);
        bool ReturnBook(Model.Viewer viewer, Model.Book book, Model.Manager manager);
    };
}
