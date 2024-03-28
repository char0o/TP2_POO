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
    public class StatsPersonnagesTests
    {
        [TestMethod()]
        public void ConstructeurStatsTest()
        {
            int pdv = 5;
            int atq = 4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
            Assert.AreEqual(pdv, stats.PtsVie);
            Assert.AreEqual(pdv, stats.PtsVieMax);
            Assert.AreEqual(atq, stats.PtsAttaque);
            Assert.AreEqual(def, stats.PtsDefense);
        }

        [TestMethod()]
        public void EstMortTest()
        {
            int pdv = 5;
            int atq = 4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
            stats.PtsVie = 0;
            Assert.IsTrue(stats.EstMort());
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsExperienceNegatifTest()
        {
            int pdv = 5;
            int atq = 4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
            stats.PtsExperience = -50;
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsVieNegatifTest()
        {
            int pdv = -5;
            int atq = 4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsAtqNegatifTest()
        {
            int pdv = 5;
            int atq = -4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsDefNegatifTest()
        {
            int pdv = 5;
            int atq = 4;
            int def = -10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PtsVieMaxNegatifTest()
        {
            int pdv = 5;
            int atq = 4;
            int def = 10;
            StatsPersonnages stats = new StatsPersonnages(pdv, atq, def);
            stats.PtsVieMax = -50;
        }

    }
}