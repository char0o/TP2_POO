﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
	public class Personnage
	{

		private static int[] armePtsArmure = new int[4];

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
			set {
				if (value is null)
					throw new ArgumentNullException();
				degatsDernierCombat = value; 
			}
		}
		public List<Sort> Sorts
		{
			get { return sorts; }
			private set {
				if (value is null)
					throw new ArgumentNullException();
				sorts = value; 
			}
		}
		public int NbPotions
		{
			get { return nbPotions; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				nbPotions = value; 
			}
		}
		public Arme Arme
		{
			get { return arme; }
			set {
				if (!ArmesPermises[this.Classe].Contains(value))
					throw new InvalidOperationException("Not a valid weapon");
				if ((int)value < 0 || (int)value > armePtsArmure.Length)
					throw new ArgumentOutOfRangeException("Weapon has no armor value");
				arme = value; 
			}
		}
		public StatsPersonnages Stats
		{
			get { return stats; }
			private set {
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

            armePtsArmure[(int)Arme.MainsNues] = 0;
            armePtsArmure[(int)Arme.EpeeBouclier] = 5;
            armePtsArmure[(int)Arme.EpeeDeuxMains] = 2;
            armePtsArmure[(int)Arme.Arc] = 1;

            classesPermises.Add(Classe.Archer);
            classesPermises.Add(Classe.Mage);
            classesPermises.Add(Classe.Guerrier);
            classesPermises.Add(Classe.Assassin);
            classesPermises.Add(Classe.Moine);
        }
        public string Nom
		{
			get { return nom; }
			private set {
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
		}
        public Personnage(string nom, Classe classe, List<Sort> sorts)
        {
            this.Nom = nom;
            this.Classe = classe;
            this.Sorts = sorts;
            this.Arme = arme;
            this.NbPotions = 0;
            this.DegatsDernierCombat = new List<int>();
            this.Stats = new StatsPersonnages(classe);
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

		}
		public void BoirePotion()
		{
			if (this.NbPotions == 0)
				return;
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
