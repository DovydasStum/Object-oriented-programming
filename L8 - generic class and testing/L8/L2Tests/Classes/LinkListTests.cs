using Microsoft.VisualStudio.TestTools.UnitTesting;
using L2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace L2.Tests
{
    [TestClass()]
    public class LinkListTests
    {
        [TestMethod()]
        public void LinkList_EmptyIsSetToZerro()
        {
            LinkedList<Worker> temp = new LinkedList<Worker>();
            Assert.AreEqual(0, temp.Count());
        }

        [TestMethod()]
        public void NullList_NotThrowsException()
        {
            Action act = () => {
                LinkedList<Worker> temp = new LinkedList<Worker>(null);
            };
            act.Should().NotThrow<NullReferenceException>();
        }

        [TestMethod()]
        public void SetLifoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetFifoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BeginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CopyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WorkersCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}