using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkListTests
{
    [TestClass]
    public class SetLifoTest
    {
        L2.LinkList<L2.Worker> TestList = new L2.LinkList<L2.Worker>();
        
        /// <summary>
        /// Checks if the list keeps object type
        /// </summary>
        [TestMethod]
        public void SetLifo_KeepsType()
        {
            L2.Worker worker = new L2.Worker(DateTime.Parse("2000-01-05"),
                                 "Surname", "Name", "X1", 4);
            Type expected = worker.GetType();
            TestList.SetLifo(worker);
            Type actual = TestList.ReturnHead().Data.GetType();
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Checks the equality of objects in a list
        /// </summary>
        [TestMethod]
        public void Same_Person_In_List()
        {
            L2.Worker worker1 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                            "Surname", "Name", "X1", 4);
            L2.Worker worker2 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                "Surname", "Name", "X1", 4);
            TestList.SetLifo(worker1);
            TestList.SetLifo(worker2);

            Assert.AreEqual(TestList.ReturnHead().Data.Surname, 
                            TestList.ReturnHead().Link.Data.Surname);
            Assert.AreEqual(TestList.ReturnHead().Data.Name,
                            TestList.ReturnHead().Link.Data.Name);
        }

        /// <summary>
        /// Checks the inequality of date
        /// </summary>
        [TestMethod]
        public void Different_Date()
        {
            L2.Worker worker1 = new L2.Worker(DateTime.Parse("2000-01-04"),
                                            "Surname", "Name", "X1", 4);
            L2.Worker worker2 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                "Surname", "Name", "X1", 4);
            TestList.SetLifo(worker1);
            TestList.SetLifo(worker2);

            Assert.AreNotEqual(TestList.ReturnHead().Data.Date,
                               TestList.ReturnHead().Link.Data.Date);
        }
    }
}
