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
    public class GestionJeuTests
    {
        [TestMethod()]
        public void ConstructeurTest()
        {
            string nom = "Rodrigue";
            Classe classe = Classe.Archer;
            List<Sort> sorts = new List<Sort>();
            Arme arme = Arme.MainsNues;
            Personnage personnage = new Personnage(nom, classe, sorts, arme);
            GestionJeu jeu = new GestionJeu(personnage);
            Assert.AreEqual(personnage, jeu.Joueur);
        }
    }
}