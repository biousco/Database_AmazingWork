using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    class ValidateHelper
    {
        public static bool validateBook(Model.Book Book)
        {
            LMSBLL.Book book_bll = new LMSBLL.Book();
            string bookname = book_bll.GetSingleBook(Book.Id).Id;
            if (bookname == null)
            {
                return false;
            }
            return true;
        }

        public static bool validateViewer(Model.Viewer Viewer)
        {
            LMSBLL.Viewer viewer_bll = new LMSBLL.Viewer();
            string viewername = viewer_bll.GetViewerName(Viewer.Id);
            if (viewername == null)
            {
                return false;
            }
            return true;
        }
    }
}
