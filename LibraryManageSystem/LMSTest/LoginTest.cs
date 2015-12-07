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

        
        [TestMethod]
        public void Viewer()
        {
            IViewer target = DataAccessFactory.CreateViewer();

            string userName = "s001";    //用例
            string userPassword = "111111";
            bool expected = true;    //期望值
            bool actual;
            actual = target.Login(userName, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
    }
}
