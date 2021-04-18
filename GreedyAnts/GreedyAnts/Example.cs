using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    public class Example
    {
        // Singleton
        static Example unique = null;
        // Singletondaten
        int n;
        LinkedList<Town> towns;
        int m;
        double q;
        double qStart;
        double p;
        double alpha;
        double beta;
        int cycles;

        // verbiete Aufruf des normalen Konstruktors
        private Example()
        {
        }

        public static Example getExample()
        {
            if(unique == null)
            {
                unique = new Example();
                // Initialisierung des Beispiels
                unique.n = 5;

                unique.towns = new LinkedList<Town>();
                unique.towns.AddLast(new Town("A", 2, 6));
                unique.towns.AddLast(new Town("B", 2, 2));
                unique.towns.AddLast(new Town("C", 8, 2));
                unique.towns.AddLast(new Town("D", 8, 6));
                unique.towns.AddLast(new Town("E", 5, 9));

                unique.m = 3;

                unique.towns.ElementAt(2).getAnts().AddLast(new Ant("grün", unique.towns.ElementAt(2)));
                unique.towns.ElementAt(0).getAnts().AddLast(new Ant("blau", unique.towns.ElementAt(0)));
                unique.towns.ElementAt(4).getAnts().AddLast(new Ant("orange", unique.towns.ElementAt(4)));

                unique.q = 1;
                unique.qStart = 1;
                unique.p = 0.9;
                unique.alpha = 1;
                unique.beta = 1;
                unique.cycles = 2;
            }
            return unique;
        }

        public int getN()
        {
            return this.n;
        }

        public LinkedList<Town> getTowns()
        {
            return this.towns;
        }
        public int getM()
        {
            return this.m;
        }

        public double getQ()
        {
            return this.q;
        }

        public double getQStart()
        {
            return this.qStart;
        }

        public double getP()
        {
            return this.p;
        }

        public double getAlpha()
        {
            return this.alpha;
        }

        public double getBeta()
        {
            return this.beta;
        }

        public int getCycles()
        {
            return this.cycles;
        }
    }
}
