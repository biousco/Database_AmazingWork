using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALFactory;
using System.Threading.Tasks;

namespace LMSBLL
{
    public class Viewer
    {
        IDAL.IViewer viewer = DALFactory.DataAccessFactory.CreateViewer();

        //登录
        public bool Login(string user_id, string user_pwd)
        {
            return viewer.Login(user_id, user_pwd);
        }
    }
}
