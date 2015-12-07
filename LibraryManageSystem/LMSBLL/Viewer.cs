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
        IDAL.IViewer viewer = DataAccessFactory.CreateViewer();

        //登录
        public bool Login(string user_id, string user_pwd)
        {
            return viewer.Login(user_id, user_pwd);
        }

        //得到用户名
        public string GetViewerName(string user_id)
        {
            Model.Viewer model =  viewer.GetViewerName(user_id);
            return model.Name;
        }
    }
}
