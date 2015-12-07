using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manager
    {
        private string _m_id;
        private string _m_name;
        private string _m_pwd;

        public string Id
        {
            set { _m_id = value; }
            get { return _m_id; }
        }

        public string Name
        {
            set { _m_name = value; }
            get { return _m_name; }
        }

        public string Password
        {
            set { _m_pwd = value; }
            get { return _m_pwd; }
        }

    }
}
