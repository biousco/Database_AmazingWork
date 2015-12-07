using DALFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBLL
{
    public class Manager
    {
        IDAL.IManager manager = DataAccessFactory.CreateManager();
        //登录
        public bool Login(string user_id, string user_pwd)
        {
            return manager.Login(user_id, user_pwd);
        }

        //得到用户名
        public string GetViewerName(string user_id)
        {
            Model.Manager model = manager.GetManagerName(user_id);
            return model.Name;
        }
    }
}
