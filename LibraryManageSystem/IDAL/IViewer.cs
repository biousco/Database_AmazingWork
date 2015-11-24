using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IViewer
    {
        bool Login(string user_id, string user_pwd);

    }
}
