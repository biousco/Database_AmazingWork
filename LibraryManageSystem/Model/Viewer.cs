using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Viewer
    {
        public Viewer() { }

        #region Model

        private string _r_id;
        private string _r_name;
        private string _r_pwd;
        private string _position;
        private string _class;

        public string Id
        {
            set { _r_id = value; }
            get { return _r_id; }
        }

        public string Name
        {
            set { _r_name = value; }
            get { return _r_name; }
        }

        public string Password
        {
            set { _r_pwd = value; }
            get { return _r_pwd; }
        }

        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public string Class
        {
            set { _class = value; }
            get { return _class; }
        }

        #endregion Model

    }
}
