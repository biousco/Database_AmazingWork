using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRecord
    {
        DataTable getUserRecord(Model.Viewer viewer, string sql);
        DataTable getAllRecord();
    }
}
