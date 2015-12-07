using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL.Tests
{
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

            bool expected = true;    //期望值
            bool actual;

            SQLDAL.Book Program = new SQLDAL.Book();

            actual = Program.Borrow(book, viewer, manager); //实际值
            Assert.AreEqual(expected, actual);

        }
    }
}