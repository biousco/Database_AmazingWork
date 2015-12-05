using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDAL;
using DALFactory;
using LMSBLL;
using System.Configuration;
using System.Reflection;

namespace LMSTest
{
    [TestClass]
    public class LoginTest
    {
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["DAL"];
        
        [TestMethod]
        public void TestMethod1()
        {
            //string className = AssemblyName + ".Viewer";

           // if (AssemblyName== null) throw new ArgumentNullException();
            //if (className == null) throw new ArgumentNullException();

            try
            {

                //IDAL.IViewer target = (IViewer)Assembly.Load("SQLDAL").CreateInstance("SQLDAL.Viewer");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);

            }
            IDAL.IViewer target = DataAccessFactory.CreateViewer();

            string userName = "s001";    //用例
            string userPassword = "111111";
            bool expected = true;    //期望值
            bool actual;
            actual = target.Login(userName, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
    }
}
