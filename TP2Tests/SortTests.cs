using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Tests
{
    [TestClass()]
    public class SortTests
    {
        [TestMethod()]
        public void ConstructeurTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            Assert.AreEqual(nom, sort.Nom);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NomVideTest()
        {
            string nom = " ";
            Sort sort = new Sort(nom);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsDegatsMaxNegatifTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            sort.PtsDegatMax = -5;
        }
        [TestMethod()]
        public void PtsDegatsMaxTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            int expected = 5;
            sort.PtsDegatMax = 5;
            Assert.AreEqual(expected, sort.PtsDegatMax);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsDegatsMinNegatifTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            sort.PtsDegatMin = -5;
        }
        [TestMethod()]
        public void PtsDegatsMinTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            int expected = 5;
            sort.PtsDegatMin = 5;
            Assert.AreEqual(expected, sort.PtsDegatMin);
        }
        [TestMethod()]
        public void EqualsTest()
        {
            string nom = "Sort";
            Sort sort = new Sort(nom);
            bool result = sort.Equals(sort);
            Assert.IsTrue(result);
        }
    }
}