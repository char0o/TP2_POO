using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class StatsPersonnages
    {
		private const int PDV_MIN = 0;
        private const int PDV_MAX = 1;
        private const int ATQ_MIN = 2;
        private const int ATQ_MAX = 3;
        private const int DEF_MIN = 4;
        private const int DEF_MAX = 5;


        #region PorteeDesStatistiques
        private static Dictionary<Classe, int[]> porteeDesStatistiques = new Dictionary<Classe, int[]>();
        static StatsPersonnages()
        {
            porteeDesStatistiques[Classe.Archer] = new int[6];
            porteeDesStatistiques[Classe.Archer][PDV_MIN] = Config.ARCHER_MIN_PDV;
            porteeDesStatistiques[Classe.Archer][PDV_MAX] = Config.ARCHER_MAX_PDV;
            porteeDesStatistiques[Classe.Archer][ATQ_MIN] = Config.ARCHER_MIN_ATQ;
            porteeDesStatistiques[Classe.Archer][ATQ_MAX] = Config.ARCHER_MAX_ATQ;
            porteeDesStatistiques[Classe.Archer][DEF_MIN] = Config.ARCHER_MIN_DEF;
            porteeDesStatistiques[Classe.Archer][DEF_MAX] = Config.ARCHER_MAX_DEF;

            porteeDesStatistiques[Classe.Mage] = new int[6];
            porteeDesStatistiques[Classe.Mage][PDV_MIN] = Config.MAGE_MIN_PDV;
            porteeDesStatistiques[Classe.Mage][PDV_MAX] = Config.MAGE_MAX_PDV;
            porteeDesStatistiques[Classe.Mage][ATQ_MIN] = Config.MAGE_MIN_ATQ;
            porteeDesStatistiques[Classe.Mage][ATQ_MAX] = Config.MAGE_MAX_ATQ;
            porteeDesStatistiques[Classe.Mage][DEF_MIN] = Config.MAGE_MIN_DEF;
            porteeDesStatistiques[Classe.Mage][DEF_MAX] = Config.MAGE_MAX_DEF;

            porteeDesStatistiques[Classe.Guerrier] = new int[6];
            porteeDesStatistiques[Classe.Guerrier][PDV_MIN] = Config.GUERRIER_MIN_PDV;
            porteeDesStatistiques[Classe.Guerrier][PDV_MAX] = Config.GUERRIER_MAX_PDV;
            porteeDesStatistiques[Classe.Guerrier][ATQ_MIN] = Config.GUERRIER_MIN_ATQ;
            porteeDesStatistiques[Classe.Guerrier][ATQ_MAX] = Config.GUERRIER_MAX_ATQ;
            porteeDesStatistiques[Classe.Guerrier][DEF_MIN] = Config.GUERRIER_MIN_DEF;
            porteeDesStatistiques[Classe.Guerrier][DEF_MAX] = Config.GUERRIER_MAX_DEF;

            porteeDesStatistiques[Classe.Assassin] = new int[6];
            porteeDesStatistiques[Classe.Assassin][PDV_MIN] = Config.ASSASSIN_MIN_PDV;
            porteeDesStatistiques[Classe.Assassin][PDV_MAX] = Config.ASSASSIN_MAX_PDV;
            porteeDesStatistiques[Classe.Assassin][ATQ_MIN] = Config.ASSASSIN_MIN_ATQ;
            porteeDesStatistiques[Classe.Assassin][ATQ_MAX] = Config.ASSASSIN_MAX_ATQ;
            porteeDesStatistiques[Classe.Assassin][DEF_MIN] = Config.ASSASSIN_MIN_DEF;
            porteeDesStatistiques[Classe.Assassin][DEF_MAX] = Config.ASSASSIN_MAX_DEF;

            porteeDesStatistiques[Classe.Moine] = new int[6];
            porteeDesStatistiques[Classe.Moine][PDV_MIN] = Config.MOINE_MIN_PDV;
            porteeDesStatistiques[Classe.Moine][PDV_MAX] = Config.MOINE_MAX_PDV;
            porteeDesStatistiques[Classe.Moine][ATQ_MIN] = Config.MOINE_MIN_ATQ;
            porteeDesStatistiques[Classe.Moine][ATQ_MAX] = Config.MOINE_MAX_ATQ;
            porteeDesStatistiques[Classe.Moine][DEF_MIN] = Config.MOINE_MIN_DEF;
            porteeDesStatistiques[Classe.Moine][DEF_MAX] = Config.MOINE_MAX_DEF;

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
		public bool EstMort()
		{
			return this.PtsVie == 0;
		}
		private void DeterminerStatistiquesSelonClasse(Classe classe)
		{
			this.PtsVieMax = Utility.DemanderNombreEntreMinEtMax(porteeDesStatistiques[classe][PDV_MIN], porteeDesStatistiques[classe][PDV_MAX]);
			this.PtsAttaque = Utility.DemanderNombreEntreMinEtMax(porteeDesStatistiques[classe][ATQ_MIN], porteeDesStatistiques[classe][ATQ_MAX]);
            this.PtsDefense = Utility.DemanderNombreEntreMinEtMax(porteeDesStatistiques[classe][DEF_MIN], porteeDesStatistiques[classe][DEF_MAX]);
        }
        public override string ToString()
        {
			string toString = $"PtsVie: {this.PtsVie}/{this.PtsVieMax} PtsAttaque: {this.PtsAttaque} PtsDefense: {this.PtsDefense}";
			return toString;
        }
    }
}
