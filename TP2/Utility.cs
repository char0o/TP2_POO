using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public static class Utility
    {
        public static Random random = new Random();
        public static int DemanderNombreEntreMinEtMax(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
