using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class StatsPersonnages
    {
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
		public bool EstMort()
		{
			return this.PtsVie == 0;
		}

        public override string ToString()
        {
			string toString = $"PtsVieMax: {this.PtsVieMax} PtsAttaque: {this.PtsAttaque} PtsDefense: {this.PtsDefense}";
			return toString;
        }
    }
}
