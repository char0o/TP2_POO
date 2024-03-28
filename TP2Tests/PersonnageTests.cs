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
    public class PersonnageTests
    {
        [TestMethod()]
        public void ConstructeurTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            Assert.AreEqual(nom, personnage.Nom);
            Assert.AreEqual(classe, personnage.Classe);
            CollectionAssert.AreEqual(sorts, personnage.Sorts);
            Assert.AreEqual(arme, personnage.Arme);
        }
        [TestMethod()]
        public void ConstructeurAvecStatsTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            StatsPersonnages stats = new StatsPersonnages(Classe.Archer);
            Personnage personnage = new Personnage(nom, classe, sorts, arme, stats);
            Assert.AreEqual(nom, personnage.Nom);
            Assert.AreEqual(classe, personnage.Classe);
            CollectionAssert.AreEqual(sorts, personnage.Sorts);
            Assert.AreEqual(arme, personnage.Arme);
            Assert.AreEqual(stats, personnage.Stats);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DegatsDernierCombatNull()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.DegatsDernierCombat = null;
        }

        [TestMethod()]
        public void NbPotionsIncrementTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            int EXPECTED = personnage.NbPotions + 1;
            personnage.NbPotions++;
            Assert.AreEqual(EXPECTED, personnage.NbPotions);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NbPotionsNegativeTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.NbPotions += -1;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ArmesClasseNonCompatibleTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.EpeeBouclier;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
        }
        [TestMethod()]
        public void AjoutSortTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            List<Sort> expected = new List<Sort> { new Sort("Sort") };
            personnage.AjoutSort(new Sort("Sort"));
            CollectionAssert.AreEqual(expected, personnage.Sorts);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AjoutSortNullTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.AjoutSort(null);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AjoutSortDejaPresentTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            Sort sort = new Sort("Sort");
            personnage.AjoutSort(sort);
            personnage.AjoutSort(sort);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AttaquerSoiMemeTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.Attaquer(personnage);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AttaquerPersonnageNullTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.Attaquer(null);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InfligerDegatNegatifTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.InfligerDegat(-1);
        }
        [TestMethod()]
        public void InfligerDegatJusquaZero()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            StatsPersonnages stats = new StatsPersonnages(5, 5, 5);
            Personnage personnage = new Personnage(nom, classe, sorts, arme, stats);
            personnage.InfligerDegat(7);
            int expected = 0;
            Assert.AreEqual(expected, personnage.Stats.PtsVie);
        }
        [TestMethod()]
        public void InfligerDegat()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            StatsPersonnages stats = new StatsPersonnages(5, 5, 5);
            Personnage personnage = new Personnage(nom, classe, sorts, arme, stats);
            personnage.InfligerDegat(2);
            int expected = 3;
            Assert.AreEqual(expected, personnage.Stats.PtsVie);
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BoirePotionPasDePotionTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.BoirePotion();
        }
        [TestMethod()]
        public void BoirePotionTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            StatsPersonnages stats = new StatsPersonnages(10, 5, 5);
            Personnage personnage = new Personnage(nom, classe, sorts, arme, stats);
            personnage.InfligerDegat(7);
            personnage.NbPotions++;
            personnage.BoirePotion();
            int expected = 9;
            Assert.AreEqual(expected, personnage.Stats.PtsVie);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DonnerExperienceNegatifTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            personnage.DonnerExperience(-5);
        }
        [TestMethod()]
        public void DonnerExperienceTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            int expected = 50;
            personnage.DonnerExperience(expected);
            Assert.AreEqual(expected, personnage.Stats.PtsExperience);        
        }
        [TestMethod()]
        public void DonnerExperienceAugmenterAtqTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            StatsPersonnages stats = new StatsPersonnages(10, 5, 5);
            Personnage personnage = new Personnage(nom, classe, sorts, arme, stats);
            int expectedAtq = personnage.Stats.PtsAttaque + 1;
            personnage.DonnerExperience(100);
            Assert.AreEqual(expectedAtq, personnage.Stats.PtsAttaque);
        }
    }
}