using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkListTests
{
    [TestClass]
    public class LinkListCtrTest
    {
        L2.LinkList<L2.Worker> TestList = new L2.LinkList<L2.Worker>();

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        [TestMethod]       
        public void LinkList_IfEmpty_HeadIsNull()
        {
            Assert.IsNull(TestList.ReturnHead());
        }

        /// <summary>
        /// Checks if the list is not empty
        /// </summary>
        [TestMethod]
        public void LinkList_AddNode_HeadIsChanged()
        {
            string expected = "Surname";
            L2.Worker worker = new L2.Worker(DateTime.Parse("2000-01-05"),
                                             "Surname", "Name", "X1", 4);
            TestList.SetLifo(worker);
            string actual = TestList.ReturnHead().Data.Surname;
            Assert.AreEqual(expected, actual);
        }

    }
}
