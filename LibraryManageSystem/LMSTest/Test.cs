using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDAL;
using DALFactory;
using LMSBLL;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Xml;

namespace LMSTest
{
    [TestClass]
    public class ViewerTests
    {
        [TestMethod]
        public void VLoginTest()
        {
            SQLDAL.Viewer target = new SQLDAL.Viewer();
            string userId = "st";    //用例
            string userPassword = "111111";
            bool expected = true;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetViewerNameTest()
        {
            SQLDAL.Viewer target = new SQLDAL.Viewer();
            string r_id = "st";
            string expected = "Test";    //期望值
            string actual;
            actual = target.GetViewerName(r_id).Name.ToString();
            Assert.AreEqual(expected, actual);
        }
       
    }
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void MLoginTest()
        {
            SQLDAL.Manager target = new SQLDAL.Manager();
            string userId = "manager";    //用例
            string userPassword = "123456";
            bool expected = true;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetManagerNameTest()
        {
            SQLDAL.Manager target = new SQLDAL.Manager();
            string r_id = "manager";    //用例
            string expected = "Test";    //期望值
            string actual;
            actual = target.GetManagerName(r_id).Name.ToString(); //实际值
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
            book.Id = "book";
            viewer.Id = "st";
            manager.Id = "manager";

            bool expected = true;    //期望值
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual);
           
        }
        [TestMethod()]
        public void ReturnTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "book";
            viewer.Id = "st";
            manager.Id = "manager";

            bool expected = true;    //期望值
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.ReturnBook(viewer, book, manager); //实际值
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void GetListTest()
        {
            string sql = "b_id ='00125415152'";
            int expected = 1;    //期望值
            int actual;

            SQLDAL.Book target = new SQLDAL.Book();
            DataTable dt = target.GetList(sql);
            actual = dt.Rows.Count; //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetSingleBookTest()
        {
            string b_id = "00125415152";
            string expected = "计算机组成原理";    //期望值
            string actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual =target.GetSingleBook(b_id).Name; //实际值
            Assert.AreEqual(expected, actual);
        }
        
    }
    


}
