using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    class AntAlgorithm
    {
        // 0. Beispielvorlage
        Example example;
        // 1. Raum
        const int minXY = 0;
        const int maxXY = 9;
        // 2. Zeit
        int t;
        // 3. Städte
        //      Anzahl
        int n;
        //      Verteilung
        LinkedList<Town> towns;
        //      Abstand
        double[,] distance;
        //      Sichtbarkeit
        double[,] visibility;
        // 4. Ameisen
        //      Anzahl
        int m;
        //      Verteilung
        // -
        //      Tabulisten
        // -
        // 5. Pheromone
        //      Stärke
        double q;
        //      Startwert
        double qStart;
        //      Evaporation
        double p;
        // 6. Relative Bedeutung
        double alpha;
        double beta;
        // 7. Zyklen
        int cycles;

        Random rnd;
        public AntAlgorithm()
        {
            // Here we go
            init(true,5,3,1,1,0.9,1,1,2);
        }

        void init(bool isExample, int amountTowns,int amountAnts,double pheroStrength,double pheroStart,double evapo, double pheroImportance, double distImportance, int amountCycles)
        {
            // check grundlegendes Beispiel
            if (isExample)
            {
                example = Example.getExample();
            }

            // 1. Raum(-grenzen)
            // -

            // 2. Zeit
            t = 0;

            // 3. Städte

            //      Anzahl
            if (isExample)
            {
                this.n = example.getN();
            }
            else
            {
                this.n = amountTowns;
            }

            //      Verteilung
            if (isExample)
            {
                towns = example.getTowns();
            }
            else
            {
                towns = new LinkedList<Town>();
                rnd = new Random();
                for (int i = 1; i <= this.n; i++)
                {
                    int rndX = rnd.Next(minXY, maxXY);
                    int rndY = rnd.Next(minXY, maxXY);
                    for (int j = 0; j < towns.Count; j++)
                    {
                        if (rndX == towns.ElementAt(j).getPoint().X &&
                            rndY == towns.ElementAt(j).getPoint().Y)
                        {
                            rndX = rnd.Next(minXY, maxXY);
                            rndY = rnd.Next(minXY, maxXY);
                            j = -1;
                        }
                    }
                    towns.AddLast(new Town(i.ToString(), rndX, rndY));
                }
            }

            //      Abstand
            distance = new double[this.n, this.n];
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    distance[i, j] = Math.Sqrt(
                        Math.Pow((towns.ElementAt(i).getPoint().X - towns.ElementAt(j).getPoint().X), 2) +
                        Math.Pow((towns.ElementAt(i).getPoint().Y - towns.ElementAt(j).getPoint().Y), 2));
                }
            }

            //      Sichtbarkeit
            visibility = new double[this.n, this.n];
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    visibility[i, j] = 1.0 / distance[i, j];
                }
            }

            // 4. Ameisen

            //      Anzahl
            if (isExample)
            {
                this.m = example.getM();
            }
            else
            {
                this.m = amountAnts;
            }

            //      Verteilung und Tabulisten
            if (!isExample)
            {
                rnd = new Random();
                if (towns.Count > 0)
                {
                    for (int i = 1; i <= this.m; i++)
                    {
                        int tempElement = rnd.Next(0, towns.Count - 1);
                        towns.ElementAt(tempElement).getAnts().AddLast(new Ant(i.ToString(), towns.ElementAt(tempElement)));
                    }
                }
            }

            // 5. Pheromone
            //      Stärke
            if (isExample)
            {
                this.q = example.getQ();
            }
            else
            {
                this.q = pheroStrength;
            }

            //      Startwert
            if (isExample)
            {
                this.qStart = example.getQStart();
            }
            else
            {
                this.qStart = pheroStart;
            }

            //      Evaporation
            if (isExample)
            {
                this.p = example.getP();
            }
            else
            {
                this.p = evapo;
            }

            // 6. Relative Bedeutung
            if (isExample)
            {
                this.alpha = example.getAlpha();
                this.beta = example.getBeta();
            }
            else
            {
                this.alpha = pheroImportance;
                this.beta = distImportance;
            }

            // 7. Zyklen
            if (isExample)
            {
                this.cycles = example.getCycles();
            }
            else
            {
                this.cycles = amountCycles;
            }
        }
    }
}
