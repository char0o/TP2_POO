using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Sort
    {
        #region Properties
        private string nom;
		private int ptsDegatMin;
		private int ptsDegatMax;

		public int PtsDegatMax
		{
			get { return ptsDegatMax; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsDegatMax = value; 
			}
		}
		public int PtsDegatMin
		{
			get { return ptsDegatMin; }
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException();
				ptsDegatMin = value; 
			}
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
		public Sort(string nom)
		{
			this.Nom = nom;
		}
		public int GetDegat()
		{
			return Utility.DemanderNombreEntreMinEtMax(this.PtsDegatMin, this.PtsDegatMax);
		}
        public override string ToString()
        {
			string toString = $"Nom: {this.Nom} Min: {this.PtsDegatMin} Max: {this.PtsDegatMax}";
			return toString;
        }
        public override bool Equals(object? obj)
        {
			if (obj is null)
				return false;
			if (this.GetType() != obj.GetType())
				throw new ArgumentException();
			Sort sort = (Sort)obj;
			return this.Nom == sort.Nom;
        }
    }
}
