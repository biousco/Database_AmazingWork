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
            //利用反射机制，创建对象，并进行类型转换，把子类转换成父类接口类型；
        }
    }
}
