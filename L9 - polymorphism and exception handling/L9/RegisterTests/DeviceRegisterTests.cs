using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace RegisterTests
{
    [TestClass]
    public class DeviceRegisterTests
    {
        [TestMethod]
        public void NullList_NotThrowException()
        {
            L4.DeviceRegister New = new L4.DeviceRegister(null, "name", "address", "phone");
            Assert.AreEqual(New.Count(), 1);
        }
    }
}
