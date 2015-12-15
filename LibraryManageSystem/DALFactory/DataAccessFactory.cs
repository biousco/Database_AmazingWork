using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    sealed public class DataAccessFactory
    {
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["DAL"];

        public static IViewer CreateViewer()
        {
            string className = AssemblyName + ".Viewer";
            return (IViewer)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IBook CreateBook()
        {
            string className = AssemblyName + ".Book";
            return (IBook)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IManager CreateManager()
        {
            string className = AssemblyName + ".Manager";
            return (IManager)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IRecord CreateRecord ()
        {
            string className = AssemblyName + ".Record";
            return (IRecord)Assembly.Load(AssemblyName).CreateInstance(className);
        }


    }
}
