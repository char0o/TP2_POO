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
        private const int XP_POUR_AUGMENTER = 100;
        #region Properties
        private string nom;
        private Classe classe;
        private StatsPersonnages stats;
        private Arme arme;
        private int nbPotions;
        private List<Sort> sorts;
        private List<int> degatsDernierCombat;
        private static List<Classe> classesPermises;
        private static Dictionary<Classe, List<Arme>> armesPermises;
        private static Dictionary<Arme, int> armesPtsArmure;
        private static Dictionary<Arme, int> armesPtsDommage;
        private static List<Sort> sortsDisponible;

        public static List<Sort> SortsDisponible
        {
            get { return sortsDisponible; }
            private set {
                if ( value is null )
                    throw new ArgumentNullException();
                sortsDisponible = value; 
            }
        }
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
                    throw new ArgumentException("Armes pour la classe pas définies");
                if (!ArmesPermises[this.Classe].Contains(value))
                    throw new ArgumentException("Arme non valide pour la classe");
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
        #region Constructeur
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
        static Personnage()
        {
            Personnage.ArmesPermises = new Dictionary<Classe, List<Arme>>();
            Personnage.ArmesPermises[Classe.Mage] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            Personnage.ArmesPermises[Classe.Archer] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            Personnage.ArmesPermises[Classe.Guerrier] = new List<Arme>() { Arme.MainsNues, Arme.EpeeBouclier, Arme.EpeeDeuxMains };
            Personnage.ArmesPermises[Classe.Assassin] = new List<Arme>() { Arme.MainsNues, Arme.Arc, Arme.EpeeDeuxMains };
            Personnage.ArmesPermises[Classe.Moine] = new List<Arme>() { Arme.MainsNues };
            Personnage.ArmesPermises[Classe.Troll] = new List<Arme>() { Arme.MainsNues, Arme.Arc };
            Personnage.ArmesPermises[Classe.Goblin] = new List<Arme>() { Arme.MainsNues, Arme.EpeeBouclier, Arme.EpeeDeuxMains };
            Personnage.ArmesPermises[Classe.Squelette] = new List<Arme>() { Arme.MainsNues, Arme.Arc, Arme.EpeeDeuxMains };
            Personnage.ArmesPermises[Classe.Dragon] = new List<Arme>() { Arme.MainsNues };

            Personnage.ArmesPtsArmure = new Dictionary<Arme, int>();
            Personnage.ArmesPtsArmure[Arme.MainsNues] = 0;
            Personnage.ArmesPtsArmure[Arme.EpeeBouclier] = 5;
            Personnage.ArmesPtsArmure[Arme.EpeeDeuxMains] = 2;
            Personnage.ArmesPtsArmure[Arme.Arc] = 1;

            Personnage.ArmesPtsDommage = new Dictionary<Arme, int>();
            Personnage.ArmesPtsDommage[Arme.MainsNues] = 1;
            Personnage.ArmesPtsDommage[Arme.EpeeBouclier] = 3;
            Personnage.ArmesPtsDommage[Arme.EpeeDeuxMains] = 5;
            Personnage.ArmesPtsDommage[Arme.Arc] = 3;

            Personnage.ClassesPermises = new List<Classe>();
            Personnage.ClassesPermises.Add(Classe.Archer);
            Personnage.ClassesPermises.Add(Classe.Mage);
            Personnage.ClassesPermises.Add(Classe.Guerrier);
            Personnage.ClassesPermises.Add(Classe.Assassin);
            Personnage.ClassesPermises.Add(Classe.Moine);

            Personnage.CreerSorts();
        }
        #endregion
        public void AjoutSort(Sort sort)
        {
            if (sort is null)
                throw new ArgumentNullException();
            if (this.Sorts.Contains(sort))
                throw new ArgumentException();
            
            this.Sorts.Add(sort);
        }
        public static void CreerSorts()
        {
            Personnage.SortsDisponible = new List<Sort>();

            Sort bouleDeFeu = new Sort("Boule de feu");
            bouleDeFeu.PtsDegatMin = Config.BOULE_DE_FEU_MIN_DMG;
            bouleDeFeu.PtsDegatMax = Config.BOULE_DE_FEU_MAX_DMG;
            Personnage.SortsDisponible.Add(bouleDeFeu);

            Sort missileMagique = new Sort("Missile Magique");
            missileMagique.PtsDegatMin = Config.MISSILE_MAGIQUE_MIN_DMG;
            missileMagique.PtsDegatMax = Config.MISSILE_MAGIQUE_MAX_DMG;
            Personnage.SortsDisponible.Add(missileMagique);

            Sort foudre = new Sort("Foudre");
            foudre.PtsDegatMin = Config.FOUDRE_MIN_DMG;
            foudre.PtsDegatMax = Config.FOUDRE_MAX_DMG;
            Personnage.SortsDisponible.Add(foudre);
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
                throw new ArgumentException();

            int chanceAttaque = Utility.DemanderNombreEntreMinEtMax(1, 6);
            int degats = 0;
            if (this.Classe == Classe.Mage)
            {
                int degatsSort = Utility.DemanderNombreEntreMinEtMax(this.Sorts[0].PtsDegatMin, this.Sorts[0].PtsDegatMax);
                degats = this.Stats.PtsAttaque + degatsSort - ennemi.Stats.PtsDefense;
            }
            else
            {
                degats = this.Stats.PtsAttaque + ArmesPtsDommage[this.Arme] - ennemi.Stats.PtsDefense;
            }
            if (chanceAttaque <= 2 || degats < 0)
            {
                degats = 0;
            }
            ennemi.InfligerDegat(degats);
            this.DegatsDernierCombat.Add(degats);
        }
        public void InfligerDegat(int degats)
        {
            if (degats < 0)
                throw new ArgumentOutOfRangeException();
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
        public void DonnerExperience(int xp)
        {
            if (xp < 0)
                throw new ArgumentOutOfRangeException();
            this.Stats.PtsExperience += xp;
            if (this.Stats.PtsExperience % XP_POUR_AUGMENTER == 0)
            {
                this.Stats.PtsAttaque++;
            }
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
