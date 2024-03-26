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
		private const int POTION_PDV = 6;
        #region Properties
        private string nom;
		private Classe classe;
		private StatsPersonnages stats;
		private Arme arme;
		private int nbPotions;
		private List<Sort> sorts;
		private List<int> degatsDernierCombat;
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
			set { arme = value; }
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
			if (this.Stats.PtsVie + POTION_PDV > this.Stats.PtsVieMax)
			{
				this.Stats.PtsVie = this.Stats.PtsVieMax;
			}
			else
			{
				this.Stats.PtsVie += 6;
			}
			this.NbPotions -= 1;
		}
        public override string ToString()
        {
			string toString = $"Nom: {this.Nom} Classe: {this.Classe} Arme: {this.Arme} NbPotions: {this.NbPotions}";
			foreach (Sort sort in this.Sorts)
			{
				toString += sort.ToString();
			}
            return toString;
        }
    }
}
