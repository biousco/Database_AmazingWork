using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDAL;
using DALFactory;
using LMSBLL;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Xml;
using System.Collections;

namespace LMSTest
{
    [TestClass]
    public class ViewerTests
    {
        [TestMethod]
        public void VLoginPwdErrTest()
        {
            SQLDAL.Viewer target = new SQLDAL.Viewer();
            string userId = "st";    
            string userPassword = "1111";//密码错误
            bool expected = false;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VLoginIdErrTest()
        {
            SQLDAL.Viewer target = new SQLDAL.Viewer();
            string userId = "s000001";    //学号错误
            string userPassword = "111111";
            bool expected = false;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VLoginTest()
        {
            SQLDAL.Viewer target = new SQLDAL.Viewer();
            string userId = "s001";
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
            string userId = "manager";    
            string userPassword = "123456";
            bool expected = true;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MLoginIdErrTest()
        {
            SQLDAL.Manager target = new SQLDAL.Manager();
            string userId = "m";    //账号错误
            string userPassword = "123456";
            bool expected = false;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MLoginPwdErrTest()
        {
            SQLDAL.Manager target = new SQLDAL.Manager();
            string userId = "manager";
            string userPassword = "123";
            bool expected = false;    //期望值
            bool actual;
            actual = target.Login(userId, userPassword); //实际值
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetManagerNameTest()
        {
            SQLDAL.Manager target = new SQLDAL.Manager();
            string r_id = "manager";    
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

          //  bool expected = false;    //期望值//因为数据库中已经存在这一项数据 所以为false
            //bool actual;

            int expected = 0;    //期望值//因为数据库中已经存在这一项数据 所以为false
            Hashtable actual;


            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual["result"]);
           
        }
        [TestMethod()]
        public void BorrowVIdErrTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "book";
            viewer.Id = "s000001";//学号错误
            manager.Id = "manager";

            //bool expected = false;    //期望值
            //bool actual;
            int expected = 0;    //期望值
            Hashtable actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual["result"]);

        }
        [TestMethod()]
        public void BorrowMIdErrTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "book";
            viewer.Id = "s000001";
            manager.Id = "m";//帐号错误

           // bool expected = false;    //期望值
            // bool actual;
            int expected = 0;    //期望值
            Hashtable actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual["result"]);

        }
        [TestMethod()]
        public void MulBorrowTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "9787513318525";
            viewer.Id = "st";
            manager.Id = "manager";

           // bool expected = false;    //期望值
            //bool actual;
            int expected = 0;    //期望值
            Hashtable actual;

            SQLDAL.Book target = new SQLDAL.Book();
            target.Borrow(book, viewer, manager);//第一次借
            actual = target.Borrow(book, viewer, manager); //实际值//第二次借
            Assert.AreEqual(expected, actual["result"]);
            //由于系统限制每个人只能借同一本书一次 所以测试时只有第一次是能成功
        }
        [TestMethod()]
        public void ReturnTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "9787569902921";
            viewer.Id = "s001";
            manager.Id = "manager";

            bool expected = false;    //期望值//因为数据库中已经存在这一项数据 所以为false
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.ReturnBook(viewer, book, manager); //实际值
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void MulReturnTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "9787513318525";
            viewer.Id = "st";
            manager.Id = "manager";

            bool expected = false;    //期望值
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            target.ReturnBook(viewer, book, manager); //第一次还
            actual = target.ReturnBook(viewer, book, manager); //实际值//第二次还
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void ReturnVIdErrTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "book";
            viewer.Id = "s00001";//学号错误
            manager.Id = "manager";

            bool expected = false;    //期望值
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.ReturnBook(viewer, book, manager); //实际值
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void ReturnBIdErrTest()
        {
            string b_id = "9787550264";
            string r_id = "s001";
            Model.Viewer v = new Model.Viewer();
            v.Id = r_id;
            Model.Book b = new Model.Book();
            b.Id = b_id;
            Model.Manager m = new Model.Manager();
            //m.Id = m_id;
            //Model.Book book = new Model.Book();
            //Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            //book.Id = "boo";//书号错误
            //viewer.Id = "st";
            manager.Id = "manager";

            bool expected = false;    //期望值
            bool actual;

            SQLDAL.Book target = new SQLDAL.Book();
            actual = target.ReturnBook(v, b, manager); //实际值
            Assert.AreEqual(expected, actual);
        } 
        [TestMethod()]
        public void ReturnMIdErrTest()
        {
            Model.Book book = new Model.Book();
            Model.Viewer viewer = new Model.Viewer();
            Model.Manager manager = new Model.Manager();
            book.Id = "book";
            viewer.Id = "st";
            manager.Id = "m";//账号错误

            bool expected = false;    //期望值
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
        [TestMethod()]
        public void AddBook()
        {
            Model.Book book = new Model.Book();
            book = TestHelper.initBook();

            SQLDAL.Book target = new SQLDAL.Book();
            bool actual = target.AddBook(book);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

    }

    [TestClass()]
    public class RecordTest
    {
        [TestMethod()]
        public void getRecordBorrowTime()
        {
            string b_id = "9787550264601";
            string r_id = "s001";
            Model.Viewer v = new Model.Viewer();
            v.Id = r_id;
            Model.Book b = new Model.Book();
            b.Id = b_id;

            DateTime expected = new DateTime();    //期望值
            expected = Convert.ToDateTime("2015-12-15");
            DateTime actual;

            SQLDAL.Record target = new SQLDAL.Record();
            actual = target.getRecordBorrowTime(b, v); //实际值
            Assert.AreEqual(expected, actual);
        }
    }
    


}
