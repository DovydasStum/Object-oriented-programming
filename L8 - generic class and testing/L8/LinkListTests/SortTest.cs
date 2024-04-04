using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkListTests
{
    [TestClass]
    public class SortTest
    {
        L2.LinkList<L2.Worker> TestList = new L2.LinkList<L2.Worker>();
        L2.Worker worker1 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                          "ZSurname", "BName", "X1", 4);
        L2.Worker worker2 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                          "Surname", "AName", "X1", 4);
        L2.Worker worker3 = new L2.Worker(DateTime.Parse("2000-01-05"),
                                          "Surname", "BName", "X1", 4);

        /// <summary>
        /// Checks if the list sorts objects by their names and surnames
        /// </summary>
        [TestMethod]
        public void Sort_By_Name_And_Surname()
        {
            TestList.SetLifo(worker1);
            TestList.SetLifo(worker2);
            TestList.SetLifo(worker3);
            TestList.Sort();
            
            Assert.AreEqual(worker2.Name, 
                            TestList.ReturnHead().Data.Name);
            Assert.AreEqual(worker3.Name, 
                            TestList.ReturnHead().Link.Data.Name);
            Assert.AreEqual(worker1.Name, 
                            TestList.ReturnHead().Link.Link.Data.Name);
        }

        /// <summary>
        /// Checks if the names are equal and surnames not equal
        /// </summary>
        [TestMethod]
        public void Different_Surnames_Same_Names()
        {
            Assert.AreEqual(worker1.Name, worker3.Name);
            Assert.AreNotEqual(worker1.Surname, worker3.Surname);
        }
    }
}
