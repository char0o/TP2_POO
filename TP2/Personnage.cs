using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Personnage
    {

        #region Properties
        private string nom;
        private Classe classe;
        private StatsPersonnages stats;
        private Arme arme;
        private int nbPotions;
        private List<Sort> sorts;
        private List<int> degatsDernierCombat;
        private static List<Classe> classesPermises = new List<Classe>();
        private static Dictionary<Classe, List<Arme>> armesPermises = new Dictionary<Classe, List<Arme>>();
        private static Dictionary<Arme, int> armesPtsArmure;
        private static Dictionary<Arme, int> armesPtsDommage;

        public static Dictionary<Arme, int> ArmesPtsDommage
        {
            get { return armesPtsDommage; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                armesPtsDommage = value;
            }
        }
        public static Dictionary<Arme, int> ArmesPtsArmure
        {
            get { return armesPtsArmure; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                armesPtsArmure = value;
            }
        }


        public static Dictionary<Classe, List<Arme>> ArmesPermises
        {
            get { return armesPermises; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                armesPermises = value;
            }
        }
        public static List<Classe> ClassesPermises
        {
            get { return classesPermises; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                classesPermises = value;
            }
        }

        public List<int> DegatsDernierCombat
        {
            get { return degatsDernierCombat; }
            set
            {
                if (value is null)
                    throw new ArgumentNullException();
                degatsDernierCombat = value;
            }
        }
        public List<Sort> Sorts
        {
            get { return sorts; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                sorts = value;
            }
        }
        public int NbPotions
        {
            get { return nbPotions; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                nbPotions = value;
            }
        }
        public Arme Arme
        {
            get { return arme; }
            set
            {
                if (!ArmesPermises.ContainsKey(this.Classe))
                    throw new InvalidOperationException("Classe non comptatible");
                if (!ArmesPermises[this.Classe].Contains(value))
                    throw new InvalidOperationException("Arme non valide pour la classe");
                if (!ArmesPtsDommage.ContainsKey(value) || !ArmesPtsArmure.ContainsKey(value))
                    throw new ArgumentOutOfRangeException("L'arme manque les statistiques dommages ou armure");
                arme = value;
            }
        }
        public StatsPersonnages Stats
        {
            get { return stats; }
            private set
            {
                if (value is null)
                    throw new ArgumentNullException();
                stats = value;
            }
        }
        public Classe Classe
        {
            get { return classe; }
            private set { classe = value; }
        }
        static Personnage()
        {
            armesPermises[Classe.Mage] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            armesPermises[Classe.Archer] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            armesPermises[Classe.Guerrier] = new List<Arme>() { Arme.MainsNues, Arme.EpeeBouclier, Arme.EpeeDeuxMains };
            armesPermises[Classe.Assassin] = new List<Arme>() { Arme.MainsNues, Arme.Arc, Arme.EpeeDeuxMains };
            armesPermises[Classe.Moine] = new List<Arme>() { Arme.MainsNues };
            armesPermises[Classe.Troll] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            armesPermises[Classe.Goblin] = new List<Arme>() { Arme.MainsNues, Arme.EpeeBouclier, Arme.EpeeDeuxMains };
            armesPermises[Classe.Squelette] = new List<Arme>() { Arme.MainsNues, Arme.Arc, Arme.EpeeDeuxMains };
            armesPermises[Classe.Faermoore] = new List<Arme>() { Arme.MainsNues };

            ArmesPtsArmure = new Dictionary<Arme, int>();
            ArmesPtsArmure[Arme.MainsNues] = 0;
            ArmesPtsArmure[Arme.EpeeBouclier] = 5;
            ArmesPtsArmure[Arme.EpeeDeuxMains] = 2;
            ArmesPtsArmure[Arme.Arc] = 1;

            ArmesPtsDommage = new Dictionary<Arme, int>();
            ArmesPtsDommage[Arme.MainsNues] = 1;
            ArmesPtsDommage[Arme.EpeeBouclier] = 3;
            ArmesPtsDommage[Arme.EpeeDeuxMains] = 5;
            ArmesPtsDommage[Arme.Arc] = 3;

            classesPermises.Add(Classe.Archer);
            classesPermises.Add(Classe.Mage);
            classesPermises.Add(Classe.Guerrier);
            classesPermises.Add(Classe.Assassin);
            classesPermises.Add(Classe.Moine);
        }
        public string Nom
        {
            get { return nom; }
            private set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                    throw new ArgumentNullException();
                nom = value;
            }
        }
        #endregion

        public Personnage(string nom, Classe classe, List<Sort> sorts, Arme arme)
        {
            this.Nom = nom;
            this.Classe = classe;
            this.Sorts = sorts;
            this.Arme = arme;
            this.NbPotions = 0;
            this.DegatsDernierCombat = new List<int>();
            this.Stats = new StatsPersonnages(classe);
            this.Stats.PtsDefense += ArmesPtsArmure[this.Arme];
        }
        public Personnage(string nom, Classe classe, List<Sort> sorts, Arme arme, StatsPersonnages statsPersonnages)
        {
            this.Nom = nom;
            this.Classe = classe;
            this.Sorts = sorts;
            this.Arme = arme;
            this.NbPotions = 0;
            this.DegatsDernierCombat = new List<int>();
            this.Stats = statsPersonnages;
            this.Stats.PtsDefense += ArmesPtsArmure[this.Arme];
        }
        public void AjoutSort(Sort sort)
        {
            if (this.Sorts.Contains(sort))
                throw new InvalidOperationException();
            this.Sorts.Add(sort);
        }
        public bool EstMort()
        {
            return this.Stats.EstMort();
        }
        public void Attaquer(Personnage ennemi)
        {
            if (ennemi is null)
                throw new ArgumentNullException();
            if (this == ennemi)
                throw new InvalidOperationException();

            int chanceAttaque = Utility.DemanderNombreEntreMinEtMax(1, 6);
            int degats = this.Stats.PtsAttaque + ArmesPtsDommage[this.Arme] - ennemi.Stats.PtsDefense;

            if (chanceAttaque <= 2 || degats < 0)
                return;

            ennemi.InfligerDegat(degats);
            this.DegatsDernierCombat.Add(degats);
        }
        public void InfligerDegat(int degats)
        {
            if (this.Stats.PtsVie - degats <= 0)
            {
                this.Stats.PtsVie = 0;
            }
            else
            {
                this.Stats.PtsVie -= degats;
            }
            int neg = -degats;
            this.DegatsDernierCombat.Add(neg);
        }
        public void BoirePotion()
        {
            if (this.NbPotions == 0)
                throw new InvalidOperationException();
            if (this.Stats.PtsVie + Config.POTION_PDV > this.Stats.PtsVieMax)
            {
                this.Stats.PtsVie = this.Stats.PtsVieMax;
            }
            else
            {
                this.Stats.PtsVie += Config.POTION_PDV;
            }
            this.NbPotions -= 1;
        }
        public override string ToString()
        {
            string toString = $"Nom: {this.Nom} Classe: {this.Classe} Arme: {this.Arme} NbPotions: {this.NbPotions}\n";
            foreach (Sort sort in this.Sorts)
            {
                toString += sort.ToString();
                toString += "\n";
            }
            toString += this.Stats.ToString();
            toString += "\n";
            return toString;
        }
    }
}
