using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class StatsPersonnages
    {
		private const int INDEX_PDV_MIN = 0;
        private const int INDEX_PDV_MAX = 1;
        private const int INDEX_ATQ_MIN = 2;
        private const int INDEX_ATQ_MAX = 3;
        private const int INDEX_DEF_MIN = 4;
        private const int INDEX_DEF_MAX = 5;

		#region PorteeDesStatistiques
        private static Dictionary<Classe, int[]> porteeDesStatistiques;

		public static Dictionary<Classe, int[]> PorteeDesStatistiques
		{
			get { return porteeDesStatistiques; }
			set
			{
				if (value is null)
					throw new ArgumentNullException();
				porteeDesStatistiques = value;
			}
		}
        static StatsPersonnages()
        {
			PorteeDesStatistiques = new Dictionary<Classe, int[]>();
            PorteeDesStatistiques[Classe.Archer] = new int[6];
            PorteeDesStatistiques[Classe.Archer][INDEX_PDV_MIN] = Config.ARCHER_MIN_PDV;
            PorteeDesStatistiques[Classe.Archer][INDEX_PDV_MAX] = Config.ARCHER_MAX_PDV;
            PorteeDesStatistiques[Classe.Archer][INDEX_ATQ_MIN] = Config.ARCHER_MIN_ATQ;
            PorteeDesStatistiques[Classe.Archer][INDEX_ATQ_MAX] = Config.ARCHER_MAX_ATQ;
            PorteeDesStatistiques[Classe.Archer][INDEX_DEF_MIN] = Config.ARCHER_MIN_DEF;
            PorteeDesStatistiques[Classe.Archer][INDEX_DEF_MAX] = Config.ARCHER_MAX_DEF;

            PorteeDesStatistiques[Classe.Mage] = new int[6];
            PorteeDesStatistiques[Classe.Mage][INDEX_PDV_MIN] = Config.MAGE_MIN_PDV;
            PorteeDesStatistiques[Classe.Mage][INDEX_PDV_MAX] = Config.MAGE_MAX_PDV;
            PorteeDesStatistiques[Classe.Mage][INDEX_ATQ_MIN] = Config.MAGE_MIN_ATQ;
            PorteeDesStatistiques[Classe.Mage][INDEX_ATQ_MAX] = Config.MAGE_MAX_ATQ;
            PorteeDesStatistiques[Classe.Mage][INDEX_DEF_MIN] = Config.MAGE_MIN_DEF;
            PorteeDesStatistiques[Classe.Mage][INDEX_DEF_MAX] = Config.MAGE_MAX_DEF;

            PorteeDesStatistiques[Classe.Guerrier] = new int[6];
            PorteeDesStatistiques[Classe.Guerrier][INDEX_PDV_MIN] = Config.GUERRIER_MIN_PDV;
            PorteeDesStatistiques[Classe.Guerrier][INDEX_PDV_MAX] = Config.GUERRIER_MAX_PDV;
            PorteeDesStatistiques[Classe.Guerrier][INDEX_ATQ_MIN] = Config.GUERRIER_MIN_ATQ;
            PorteeDesStatistiques[Classe.Guerrier][INDEX_ATQ_MAX] = Config.GUERRIER_MAX_ATQ;
            PorteeDesStatistiques[Classe.Guerrier][INDEX_DEF_MIN] = Config.GUERRIER_MIN_DEF;
            PorteeDesStatistiques[Classe.Guerrier][INDEX_DEF_MAX] = Config.GUERRIER_MAX_DEF;

            PorteeDesStatistiques[Classe.Assassin] = new int[6];
            PorteeDesStatistiques[Classe.Assassin][INDEX_PDV_MIN] = Config.ASSASSIN_MIN_PDV;
            PorteeDesStatistiques[Classe.Assassin][INDEX_PDV_MAX] = Config.ASSASSIN_MAX_PDV;
            PorteeDesStatistiques[Classe.Assassin][INDEX_ATQ_MIN] = Config.ASSASSIN_MIN_ATQ;
            PorteeDesStatistiques[Classe.Assassin][INDEX_ATQ_MAX] = Config.ASSASSIN_MAX_ATQ;
            PorteeDesStatistiques[Classe.Assassin][INDEX_DEF_MIN] = Config.ASSASSIN_MIN_DEF;
            PorteeDesStatistiques[Classe.Assassin][INDEX_DEF_MAX] = Config.ASSASSIN_MAX_DEF;

            PorteeDesStatistiques[Classe.Moine] = new int[6];
            PorteeDesStatistiques[Classe.Moine][INDEX_PDV_MIN] = Config.MOINE_MIN_PDV;
            PorteeDesStatistiques[Classe.Moine][INDEX_PDV_MAX] = Config.MOINE_MAX_PDV;
            PorteeDesStatistiques[Classe.Moine][INDEX_ATQ_MIN] = Config.MOINE_MIN_ATQ;
            PorteeDesStatistiques[Classe.Moine][INDEX_ATQ_MAX] = Config.MOINE_MAX_ATQ;
            PorteeDesStatistiques[Classe.Moine][INDEX_DEF_MIN] = Config.MOINE_MIN_DEF;
            PorteeDesStatistiques[Classe.Moine][INDEX_DEF_MAX] = Config.MOINE_MAX_DEF;

        }
	#endregion
		#region Propriete
		private int ptsVie;
		private int ptsVieMax;
		private int ptsAttaque;
		private int ptsDefense;
		private int ptsExperience;

		public int PtsExperience
		{
			get { return ptsExperience; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsExperience = value; 
			}
		}
		public int PtsDefense
		{
			get { return ptsDefense; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsDefense = value; 
			}
		}
		public int PtsAttaque
		{
			get { return ptsAttaque; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsAttaque = value; 
			}
		}
		public int PtsVieMax
		{
			get { return ptsVieMax; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsVieMax = value; 
			}
		}

		public int PtsVie
		{
			get { return ptsVie; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsVie = value; 
			}
		}
        #endregion
        #region Constructeurs
        public StatsPersonnages(int ptsVieMax, int ptsAttaque, int ptsDefense)
		{
			this.PtsVieMax = ptsVieMax;
			this.PtsAttaque = ptsAttaque;
			this.PtsDefense = ptsDefense;
			this.PtsVie = this.PtsVieMax;
			this.PtsExperience = 0;
		}
		public StatsPersonnages(Classe classe)
		{
			DeterminerStatistiquesSelonClasse(classe);
            this.PtsVie = this.PtsVieMax;
            this.PtsExperience = 0;
        }
		#endregion
		public bool EstMort()
		{
			return this.PtsVie == 0;
		}
		private void DeterminerStatistiquesSelonClasse(Classe classe)
		{
			this.PtsVieMax = Utility.DemanderNombreEntreMinEtMax(PorteeDesStatistiques[classe][INDEX_PDV_MIN], PorteeDesStatistiques[classe][INDEX_PDV_MAX]);
			this.PtsAttaque = Utility.DemanderNombreEntreMinEtMax(PorteeDesStatistiques[classe][INDEX_ATQ_MIN], PorteeDesStatistiques[classe][INDEX_ATQ_MAX]);
            this.PtsDefense = Utility.DemanderNombreEntreMinEtMax(PorteeDesStatistiques[classe][INDEX_DEF_MIN], PorteeDesStatistiques[classe][INDEX_DEF_MAX]);
        }
        public override string ToString()
        {
			string toString = $"PtsVie: {this.PtsVie}/{this.PtsVieMax} PtsAttaque: {this.PtsAttaque} PtsDefense: {this.PtsDefense}";
			return toString;
        }
    }
}
