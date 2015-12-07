using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Book
    {
        public Book() { }

        private string _b_id;
        private string _b_name;
        private string _author;
        private string _publisher;
        private string _amount;

        public string Id
        {
            set { _b_id = value; }
            get { return _b_id; }
        }

        public string Name
        {
            set { _b_name = value; }
            get { return _b_name; }
        }

        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }

        public string Publisher
        {
            set { _publisher = value; }
            get { return _publisher; }
        }

        public string Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
    }
}
