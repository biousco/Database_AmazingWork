using DALFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBLL
{
    public class Record
    {
        

        //得到用户借阅记录
        public DataTable GetUserRecord(Model.Viewer viewer, string sql)
        {
            IDAL.IRecord record_bll = DataAccessFactory.CreateRecord();
            return record_bll.getUserRecord(viewer, sql);
        }
    }
}
