using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IManager
    {
        bool Login(string user_id, string user_pwd);
        Model.Manager GetManagerName(string r_id);
    };
}
