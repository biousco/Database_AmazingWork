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

    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void BorrowTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "00125415152";
            viewer.Id = "s005";
            manager.Id = "m003";

            bool expected = false;    //期望值
            bool actual;

            SQLDAL.Book Program = new SQLDAL.Book();

            actual = Program.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual);

        }
    }
}
