using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class GestionJeu
    {
        #region Properties
        private Personnage joueur;
		private Personnage ennemi;
		private int noTableau;

		public int NoTableau
		{
			get { return noTableau; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				noTableau = value; 
			}
		}
		public Personnage Ennemi
		{
			get { return ennemi; }
			set {
				if (value is null)
					throw new ArgumentNullException();
				ennemi = value; 
			}
		}
		public Personnage Joueur
		{
			get { return joueur; }
			set {
				if (value is null)
					throw new ArgumentNullException();
				joueur = value; 
			}
		}
		#endregion
		public GestionJeu(Personnage joueur, Personnage ennemi)
		{
			this.Joueur = joueur;
			this.Ennemi = ennemi;
			this.NoTableau = 0;
		}
		public bool Engager()
		{
			return false;
		}
		public void RecueillirRecompense()
		{
			int rdm = Utility.DemanderNombreEntreMinEtMax(0, 100);
			if (rdm <= 30)
			{
				this.Joueur.NbPotions++;
			}
			else if (rdm <= 60)
			{
				joueur.Stats.PtsVieMax += 5;
			}
		}
	}
}
