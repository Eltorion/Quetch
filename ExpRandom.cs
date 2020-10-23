using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quetch_simulation
{
    public class ExpRandom
    {
        public static double Generate(double lambda, Random rand)
        {
            double r = rand.NextDouble();
            double tau = -1.0 / lambda * Math.Log(r);
            return tau;
        }
    }
}
