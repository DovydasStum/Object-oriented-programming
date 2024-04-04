using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace OvenTests
{
    [TestClass]
    public class Oven_Tests
    {
        L4.Oven oven1 = new L4.Oven("manuf1", "model1", "A", "color1",
                                    10.5, 100.0, 1);
        L4.Oven oven2 = new L4.Oven("manuf1", "model1", "A", "color1",
                                    10.5, 100.0, 1);
        L4.Oven oven3 = new L4.Oven("Amanuf2", "model2", "A+", "color3",
                                    11.1, 200.0, 2);
        L4.Oven oven4 = new L4.Oven("Bmanuf2", "model2", "A+", "color3",
                                    11.1, 200.0, 2);

        /// <summary>
        /// Checks are two ovens equal
        /// </summary>
        [TestMethod]
        public void Equals()
        {
            Assert.AreEqual(oven1.Manufactor, oven2.Manufactor);
            Assert.AreEqual(oven1.Model, oven2.Model);
            Assert.AreEqual(oven1.EnergyClass, oven2.EnergyClass);
            Assert.AreEqual(oven1.Color, oven2.Color);
            Assert.AreEqual(oven1.Price, oven2.Price);
            Assert.AreEqual(oven1.Power, oven2.Power);
            Assert.AreEqual(oven1.Programes, oven2.Programes);
        }

        /// <summary>
        /// Checks are two ovens not equal
        /// </summary>
        [TestMethod]
        public void NotEquals()
        {
            Assert.AreNotEqual(oven1.Manufactor, oven3.Manufactor);
            Assert.AreNotEqual(oven1.Model, oven3.Model);
            Assert.AreNotEqual(oven1.EnergyClass, oven3.EnergyClass);
            Assert.AreNotEqual(oven1.Color, oven3.Color);
            Assert.AreNotEqual(oven1.Price, oven3.Price);
            Assert.AreNotEqual(oven1.Power, oven3.Power);
            Assert.AreNotEqual(oven1.Programes, oven3.Programes);
        }

        /// <summary>
        /// Checks if two ovens have equal power and different manufactors
        /// </summary>
        [TestMethod]
        public void CompareSecondHigher()
        {
            Assert.AreEqual(oven3.Power, oven4.Power);
            StringAssert.StartsWith(oven3.Manufactor.ToLower(), "a");
            StringAssert.StartsWith(oven4.Manufactor.ToLower(), "b");
        }

        /// <summary>
        /// Checks if the length of two strings are equal
        /// </summary>
        [TestMethod]
        public void TwoStringEqualLength()
        {
            Assert.AreEqual(oven1.ToString().Length, oven2.ToString().Length);
        }

        /// <summary>
        /// Checks if the string contains manufactor
        /// </summary>
        [TestMethod]
        public void StringContainsManufactor()
        {
            char[] delimiters = {' ', '|' };
            string[] parts = oven1.ToString().Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(parts[0], "manuf1");
        }

        /// <summary>
        /// Checks if the string contains price
        /// </summary>
        [TestMethod]
        public void StringContainsPrice()
        {
            char[] delimiters = {' ', '|'};
            string[] parts = oven1.ToString().Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(Convert.ToDouble(parts[4]), 10.5);
        }

    }
}
