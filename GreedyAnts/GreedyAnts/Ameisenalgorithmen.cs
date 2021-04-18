using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedyAnts
{
    /// <summary>
    /// Vorgängerversion der AntSystem-Klasse aus ImperativeAntSystem
    /// </summary>
    class Ameisenalgorithmen
    {
        private const int TIMEOUT = 15;

        //Variablen des Algorithmus
        private int time; // Zeit
        private int n; // Anzahl Städte
        private double[][] townCoords; // Koordinaten der Städte
        private double[][] d; // Distanzmatrix
        private double[][] eta; // Sichtbarkeitsmatrix
        private int m; // Anzahl Ameisen
        private byte[] antHomes; //NEU Übergabeparameter
        private int[][] townAnts; // Verteilung der Ameisen auf die Städte
        private byte[][] tabus; // Tabulisten der Ameisen
        private byte s; // AKtuelle Iteration des aktuellen Zyklus
        private double q; // Pheromonstärke der Ameisen
        private double qStart; // Startwert aller Strecken
        private double[][] tau; // Pheromonmatrix
        private double[][] deltaTau; // neu gelegte Pheromonspuren durch Ameisen
        private double rho; // Koeffizient der Evaporation
        private double alpha; // Relative Bedeutung der Pheromone
        private double beta; // Relative Bedeutung der Sichtbarkeiten
        private int nc; // Anzahl an Zyklen 
        private byte art; //0=Ant density, 1=Ant Quantity, 2=Ant Cycle;

        Stopwatch sw;
        bool Overtime;
        Output output;

        public Ameisenalgorithmen()
        {
        }
        /// <summary>
        /// Die Ant-System-Methode, die den Ant-Density-Algorithmus, den Ant-Quantity-Algorithmus und den Ant-Cycle-Algorithmus in sich vereint
        /// </summary>
        /// <param name="townCoords"></param>
        /// <param name="antHomes"></param>
        /// <param name="q"></param>
        /// <param name="qStart"></param>
        /// <param name="rho"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="nc"></param>
        /// <param name="art"></param>
        /// <returns></returns>
        public Output algorithmieren(double[][] townCoords, byte[] antHomes, double q, double qStart, double rho, double alpha, double beta, int nc, byte art)
        {
            //Input-Parameter
            this.townCoords = townCoords;
            this.antHomes = antHomes;
            this.q = q;
            this.qStart = qStart;
            this.rho = rho;
            this.alpha = alpha;
            this.beta = beta;
            this.nc = nc;
            this.art = art;


            this.sw = new Stopwatch();
            this.sw.Start();
            this.Overtime = false;

            //Zeit
            this.time = 0;


            //modifizierte Variablen
            this.n = this.townCoords.Length;

            //Output-Parameter
            this.output = new Output();
            this.output.setStadtkoordinaten(this.townCoords);
            this.output.setAlpha(this.alpha);
            this.output.setBeta(this.beta);


            //1.Pheromone: tau(t)
            this.tau = new double[this.n][];
            double[][] tauOut = new double[this.n][];
            if (this.time < 1000)
            {
                this.output.getTauVonT().Add(new double[this.n][]);
                tauOut = this.output.getTauVonT().ElementAt(this.time);
            }
            for (byte i = 0; i < this.n; i++)
            {
                this.tau[i] = new double[this.n];
                tauOut[i] = new double[this.n];
                for (byte j = 0; j < this.n; j++)
                {
                    tauOut[i][j] = this.qStart;
                    this.tau[i][j] = this.qStart;
                }
                tauOut[i][i] = 0;
                this.tau[i][i] = 0;
            }
            this.deltaTau = new double[this.n][];
            for (byte i = 0; i < this.n; i++)
            {
                this.deltaTau[i] = new double[this.n];
                for (byte j = 0; j < this.n; j++)
                {
                    this.deltaTau[i][j] = 0;
                }
            }

            this.m = this.antHomes.Length;
            //Verteilung der Ameisen
            this.townAnts = new int[this.n][];
            int[][] townAntsOut = new int[this.n][];
            if (this.time < 1000)
            {
                this.output.getStadtAmeisenVonT().Add(new int[this.n][]);
                townAntsOut = this.output.getStadtAmeisenVonT().ElementAt(this.time);
            }
            for (byte i = 0; i < this.n; i++)
            {
                this.townAnts[i] = new int[this.m];
                townAntsOut[i] = new int[this.m];
            }
            for (byte i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    if (this.townAnts[this.antHomes[i] - 1][j] == 0)
                    {
                        this.townAnts[this.antHomes[i] - 1][j] = i + 1;
                        townAntsOut[this.antHomes[i] - 1][j] = i + 1;
                        j = this.m;
                    }
                }
            }
            //Tabulisten
            this.tabus = new byte[this.m][];
            byte[][] tabusOut = new byte[this.m][];
            if (this.time < 1000)
            {
                this.output.getAmeisenTabulistenVonT().Add(new byte[this.m][]);
                tabusOut = this.output.getAmeisenTabulistenVonT().ElementAt(this.time);
            }
            for (byte i = 0; i < this.m; i++)
            {
                this.tabus[i] = new byte[this.n];
                tabusOut[i] = new byte[this.n];
                this.tabus[i][0] = this.antHomes[i];
                tabusOut[i][0] = this.antHomes[i];
            }


            //gleichbleibende Variablen
            // Abstand
            this.d = new double[this.n][];
            double deltaX, deltaY;
            for (byte i = 0; i < this.n; i++)
            {
                this.d[i] = new double[this.n];
                for (byte j = 0; j < this.n; j++)
                {
                    deltaX = (townCoords[i][0] - townCoords[j][0]);
                    deltaY = (townCoords[i][1] - townCoords[j][1]);
                    this.d[i][j] = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                }
            }
            this.output.setD(this.d);
            // Sichtbarkeit
            this.eta = new double[this.n][];
            for (byte i = 0; i < this.n; i++)
            {
                this.eta[i] = new double[this.n];
                for (byte j = 0; j < this.n; j++)
                {
                    this.eta[i][j] = 1.0 / this.d[i][j];
                }
                this.eta[i][i] = -1;
            }
            this.output.setEta(this.eta);


            //----------------------------------------------------------------------
            // wichtige Variablen
            //----------------------------------------------------------------------

            byte[] shortestPathTowns; // Pfad der kürzesten Tour
            double shortestPathLength; // Länge der kürzesten Tour
            int tempNC; // Aktueller Zyklus

            bool ersteTour; // Prüfwert der allersten gefundenen Tour

            Random r; // Instanz zur Generierung von (Pseudo-)Zufallszahlen

            //Algorithmus

            //----------------------------------------------------------------------
            //Initialisierung
            //----------------------------------------------------------------------

            tempNC = 0;

            // Initialisierung der übrigen Variablen
            this.s = 1;
            shortestPathTowns = new byte[this.n];
            shortestPathLength = 0;
            ersteTour = true;
            r = new Random();

            //----------------------------------------------------------------------
            // Berechnung
            //----------------------------------------------------------------------

            bool nichtDieGleicheTour = true;
            //temporärer Zwischenspeicher zum Umsetzen der Ameisen
            int[][] newTownAnts;
            int[][] newTownAntsOut;
            do
            {
                tempNC++;
                do
                {
                    //neuer Iterationsschritt
                    this.s++;

                    //(Re-)Initialisierung temporärer Zwischenspeicher zum Umsetzen der Ameisen
                    newTownAnts = new int[this.n][];
                    newTownAntsOut = new int[this.n][];
                    if (this.time < 1000)
                    {
                        this.output.getStadtAmeisenVonT().Add(new int[this.n][]);
                        newTownAntsOut = this.output.getStadtAmeisenVonT().ElementAt(this.time + 1);
                    }
                    for (byte i = 0; i < this.n; i++)
                    {
                        newTownAnts[i] = new int[this.m];
                        newTownAntsOut[i] = new int[this.m];
                    }

                    //Ermittlung der Streckenwahrscheinlichkeiten, die Streckenwahl, 
                    //das Umsetzen der Ameisen und die Ergänzung der Tabulisten in einer Doppelschleife
                    for (byte tempTown = 1; tempTown <= this.n; tempTown++)
                    {
                        for (int tempEntry = 0; tempEntry < this.m; tempEntry++)
                        {
                            if (this.townAnts[tempTown - 1][tempEntry] == 0)
                            {
                                // keine Ameise in aktueller Spalte vorhanden
                                // und Suche in aktueller Stadt beenden
                                tempEntry = this.m;
                            }
                            else
                            {
                                byte[] freeTowns = new byte[this.n - this.s + 1];
                                double[] possibilities = new double[this.n - this.s + 1];
                                double sumOfPossibilities = 0;
                                int freeEntry = 0;
                                //Teil-Wahrscheinlichkeiten und ihre Summe sammeln
                                for (byte u = 1; u <= this.townAnts.Length; u++)
                                {
                                    byte[] TabulisteZumAbgleich = this.tabus[this.townAnts[tempTown - 1][tempEntry] - 1];
                                    bool possible = true;
                                    for (int w = 0; w < TabulisteZumAbgleich.Length; w++)
                                    {
                                        if (TabulisteZumAbgleich[w] == u)
                                        {
                                            possible = false;
                                        }
                                    }
                                    if (possible)
                                    {
                                        freeTowns[freeEntry] = u;
                                        double tempTau = Math.Pow(this.tau[tempTown - 1][u - 1], this.alpha);
                                        double tempEta = Math.Pow(this.eta[tempTown - 1][u - 1], this.beta);
                                        possibilities[freeEntry] = (tempTau * tempEta);
                                        // Untere Grenze für Wahrscheinlichkeiten auf 1 Milliardstel
                                        if (possibilities[freeEntry] < 0.000_000_001)
                                        {
                                            possibilities[freeEntry] = 0.000_000_001;
                                        }
                                        sumOfPossibilities += possibilities[freeEntry];
                                        freeEntry++;
                                    }
                                }
                                //Summe aller Wahrscheinlichkeiten verrechnen
                                for (byte u = 0; u < possibilities.Length; u++)
                                {
                                    possibilities[u] /= sumOfPossibilities;

                                }

                                //Sortieren der ermittelten Wahrscheinlichkeiten per Insertion Sort
                                for (byte u = 0; u < possibilities.Length - 1; u++)
                                {
                                    for (int w = (u + 1); w > 0; w--)
                                    {
                                        if (possibilities[w - 1] > possibilities[w])
                                        {
                                            double oldPossibility = possibilities[w - 1];
                                            possibilities[w - 1] = possibilities[w];
                                            possibilities[w] = oldPossibility;

                                            byte oldTown = freeTowns[w - 1];
                                            freeTowns[w - 1] = freeTowns[w];
                                            freeTowns[w] = oldTown;
                                        }
                                    }
                                }

                                //Strecke wählen
                                double WuerfelWurfErgebnis = r.NextDouble();
                                double sumUp = 0;
                                byte chosenTown = 0;
                                //Sicherstellung, dass Summe aller Wahrscheinlichkeiten >= 1
                                possibilities[possibilities.Length - 1] += 0.03;
                                for (int counter = 0; counter < possibilities.Length; counter++)
                                {
                                    sumUp += possibilities[counter];
                                    if (WuerfelWurfErgebnis < sumUp)
                                    {
                                        chosenTown = freeTowns[counter];
                                        counter = possibilities.Length;
                                    }
                                }


                                //int StadtAmeisen[aktuelleStadt - 1][aktuelleSpalte]
                                //byte[] bereisbareStaedte[w]
                                //double[] Wahrscheinlichkeiten[w]

                                //Ameisen setzen
                                for (int freeSpace = 0; freeSpace < newTownAnts[tempTown - 1].Length; freeSpace++)
                                {
                                    if (newTownAnts[chosenTown - 1][freeSpace] == 0)
                                    {
                                        newTownAnts[chosenTown - 1][freeSpace] = this.townAnts[tempTown - 1][tempEntry];
                                        newTownAntsOut[chosenTown - 1][freeSpace] = this.townAnts[tempTown - 1][tempEntry];
                                        freeSpace = newTownAnts[tempTown - 1].Length;
                                    }
                                }

                                //Tabulisten ergänzen
                                int tempAnt = this.townAnts[tempTown - 1][tempEntry];
                                this.tabus[tempAnt - 1][this.s - 1] = chosenTown;

                                //neue Spuren zwischenspeichern
                                if (this.art == 0)
                                {
                                    this.deltaTau[tempTown - 1][chosenTown - 1] += this.q;
                                    this.deltaTau[chosenTown - 1][tempTown - 1] += this.q;
                                }
                                else if (this.art == 1)
                                {
                                    this.deltaTau[tempTown - 1][chosenTown - 1] += this.q / this.d[tempTown - 1][chosenTown - 1];
                                    this.deltaTau[chosenTown - 1][tempTown - 1] += this.q / this.d[chosenTown - 1][tempTown - 1];
                                }
                            }
                        }
                    }
                    this.townAnts = newTownAnts;

                    //Tabulisten speichern
                    tabusOut = new byte[m][];
                    if (this.time < 1000)
                    {
                        output.getAmeisenTabulistenVonT().Add(new byte[m][]);
                        tabusOut = output.getAmeisenTabulistenVonT().ElementAt(this.time + 1);
                    }
                    for (byte i = 0; i < m; i++)
                    {
                        tabusOut[i] = new byte[n];
                        for (byte k = 0; k < n; k++)
                        {
                            tabusOut[i][k] = tabus[i][k];
                        }
                    }
                    output.setFinalTabu(tabusOut);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //
                    //
                    //
                    //      Zeitsprung
                    //
                    //
                    //
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Zeit inkrementieren
                    this.time++;

                    //Pheromone aktualisieren
                    if (this.art == 0 || this.art == 1)
                    {
                        tauOut = new double[n][];
                        if (this.time < 1000)
                        {
                            output.getTauVonT().Add(new double[n][]);
                            tauOut = output.getTauVonT().ElementAt(this.time);
                        }
                        for (byte i = 0; i < n; i++)
                        {
                            tauOut[i] = new double[n];
                            for (byte j = 0; j < n; j++)
                            {
                                tauOut[i][j] = this.tau[i][j] * this.rho;
                                tauOut[i][j] += this.deltaTau[i][j];
                                this.tau[i][j] *= this.rho;
                                this.tau[i][j] += this.deltaTau[i][j];
                            }
                        }
                        this.deltaTau = new double[n][];
                        for (byte i = 0; i < n; i++)
                        {
                            this.deltaTau[i] = new double[n];
                            for (byte j = 0; j < n; j++)
                            {
                                this.deltaTau[i][j] = 0;
                            }
                        }
                    }
                    else
                    {
                        if (this.time < 1000)
                        {
                            output.getTauVonT().Add(output.getTauVonT().ElementAt(this.time - 1));
                        }
                    }
                }
                while (this.s < n);

                //Touren vollenden und kürzeste Tour speichern
                bool[][] chosenRoads = new bool[n][];
                byte lastEntry = 1;
                for (byte i = 0; i < n; i++)
                {
                    chosenRoads[i] = new bool[lastEntry];
                    lastEntry++;
                }


                for (byte a = 0; a < tabus.Length; a++)
                {
                    double tempPathLength = 0;
                    byte[] tempPathTowns = new byte[n];
                    byte[] tempTabu = tabus[a];



                    for (byte i = 0; i < (n - 1); i++)
                    {
                        tempPathLength += d[tempTabu[i] - 1][tempTabu[i + 1] - 1];
                        tempPathTowns[i] = tempTabu[i];
                        if (tempTabu[i + 1] < tempTabu[i])
                        {
                            chosenRoads[tempTabu[i] - 1][tempTabu[i + 1] - 1] = true;
                        }
                        else
                        {
                            chosenRoads[tempTabu[i + 1] - 1][tempTabu[i] - 1] = true;
                        }
                    }



                    tempPathLength += d[tempTabu[this.s - 1] - 1][tempTabu[0] - 1];
                    tempPathTowns[this.s - 1] = tempTabu[this.s - 1];
                    if (tempTabu[this.s - 1] < tempTabu[0])
                    {
                        chosenRoads[tempTabu[0] - 1][tempTabu[this.s - 1] - 1] = true;
                    }
                    else
                    {
                        chosenRoads[tempTabu[this.s - 1] - 1][tempTabu[0] - 1] = true;
                    }



                    //Check Tour kürzer
                    if (tempPathLength < shortestPathLength || ersteTour)
                    {
                        shortestPathLength = tempPathLength;
                        output.setKuerzesteTourOfAll(tempPathLength);
                        shortestPathTowns = tempPathTowns;
                        output.setStaedteKuerzesterTourOfAll(tempPathTowns);
                        ersteTour = false;
                    }



                    //neue Spuren zwischenspeichern
                    if (this.art == 0)
                    {
                        this.deltaTau[tempTabu[this.s - 1] - 1][tempTabu[0] - 1] += this.q;
                        this.deltaTau[tempTabu[0] - 1][tempTabu[this.s - 1] - 1] += this.q;
                    }
                    else if (this.art == 1)
                    {
                        this.deltaTau[tempTabu[this.s - 1] - 1][tempTabu[0] - 1] += this.q * 1.0 / d[tempTabu[this.s - 1] - 1][tempTabu[0] - 1];
                        this.deltaTau[tempTabu[0] - 1][tempTabu[this.s - 1] - 1] += this.q * 1.0 / d[tempTabu[0] - 1][tempTabu[this.s - 1] - 1];
                    }
                    else if (this.art == 2)
                    {
                        for (byte i = 0; i < (n - 1); i++)
                        {
                            this.deltaTau[tempTabu[i] - 1][tempTabu[i + 1] - 1] += q * 1.0 / tempPathLength;
                            this.deltaTau[tempTabu[i + 1] - 1][tempTabu[i] - 1] += q * 1.0 / tempPathLength;
                        }
                        this.deltaTau[tempTabu[this.s - 1] - 1][tempTabu[0] - 1] += q * 1.0 / tempPathLength;
                        this.deltaTau[tempTabu[0] - 1][tempTabu[this.s - 1] - 1] += q * 1.0 / tempPathLength;
                    }
                }

                byte[] aktuellePfadStaedteOut = new byte[n];
                if (this.time < 1000)
                {
                    output.getKuerzesteTourVonRunde().Add(shortestPathLength);
                    output.getStaedteKuerzesterTourVonRunde().Add(new byte[n]);
                    aktuellePfadStaedteOut = output.getStaedteKuerzesterTourVonRunde().Last();
                }
                for (int i = 0; i < n; i++)
                {
                    aktuellePfadStaedteOut[i] = shortestPathTowns[i];
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                //
                //
                //      Zeitsprung
                //
                //
                //
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Zeit inkrementieren
                this.time++;


                tauOut = new double[n][];
                if (this.time < 1000)
                {
                    output.getTauVonT().Add(new double[n][]);
                    tauOut = output.getTauVonT().ElementAt(this.time);
                }
                for (byte i = 0; i < n; i++)
                {
                    tauOut[i] = new double[n];
                    for (byte j = 0; j < n; j++)
                    {
                        tauOut[i][j] = this.tau[i][j] * this.rho;
                        tauOut[i][j] += this.deltaTau[i][j];
                        this.tau[i][j] *= this.rho;
                        this.tau[i][j] += this.deltaTau[i][j];
                    }
                }

                this.deltaTau = new double[n][];
                for (byte i = 0; i < n; i++)
                {
                    this.deltaTau[i] = new double[n];
                    for (byte j = 0; j < n; j++)
                    {
                        this.deltaTau[i][j] = 0;
                    }
                }

                //Verteilung der Ameisen
                townAnts = new int[n][];
                townAntsOut = new int[n][];
                if (this.time < 1000)
                {
                    output.getStadtAmeisenVonT().Add(new int[n][]);
                    townAntsOut = output.getStadtAmeisenVonT().ElementAt(this.time);
                }
                for (byte i = 0; i < n; i++)
                {
                    townAnts[i] = new int[m];
                    townAntsOut[i] = new int[m];
                }
                for (byte i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (townAnts[this.antHomes[i] - 1][j] == 0)
                        {
                            townAnts[this.antHomes[i] - 1][j] = i + 1;
                            townAntsOut[this.antHomes[i] - 1][j] = i + 1;
                            j = m;
                        }
                    }
                }

                nichtDieGleicheTour = false;
                byte count = 0;
                lastEntry = 1;
                for (byte i = 0; i < n; i++)
                {
                    for (byte u = 0; u < lastEntry; u++)
                    {
                        if (chosenRoads[i][u])
                        {
                            count++;
                        }
                    }
                    lastEntry++;
                }
                if (count == n)
                {
                    nichtDieGleicheTour = true;
                }
                if (sw.Elapsed.TotalSeconds > TIMEOUT)
                {
                    MessageBox.Show("Abbruch nach " + tempNC + " Durchläufen in " + Math.Round(sw.Elapsed.TotalSeconds) + " Sekunden");
                    Overtime = true;
                }

                //Abbruchkriterien beschränkt auf Zyklen und Timeout nach 15 Sekunden
                if (tempNC < this.nc && !Overtime)//(NCAktuell < this.NC && nichtDieGleicheTour) && !Overtime)
                {
                    //Tabulisten leeren
                    tabus = new byte[m][];
                    tabusOut = new byte[m][];
                    if (this.time < 1000)
                    {
                        output.getAmeisenTabulistenVonT().Add(new byte[m][]);
                        tabusOut = output.getAmeisenTabulistenVonT().ElementAt(this.time);
                    }
                    for (byte i = 0; i < m; i++)
                    {
                        tabus[i] = new byte[n];
                        tabusOut[i] = new byte[n];
                        tabus[i][0] = this.antHomes[i];
                        tabusOut[i][0] = this.antHomes[i];
                    }

                    this.s = 1;

                    this.deltaTau = new double[n][];
                    for (byte i = 0; i < n; i++)
                    {
                        this.deltaTau[i] = new double[n];
                        for (byte j = 0; j < n; j++)
                        {
                            this.deltaTau[i][j] = 0;
                        }
                    }
                }
                else
                {
                    output.setFinalTau(this.tau);
                    output.setTimeEnd(this.time);
                    /*
                    string outputstring = "kürzester Pfad: ";
                    for (byte i = 0; i < n; i++)
                    {
                        outputstring += shortestPathTowns[i].ToString();
                        if (i < n - 1)
                        {
                            outputstring += " - ";
                        }
                    }
                    outputstring += "\n Länge: " + shortestPathLength.ToString();
                    Console.WriteLine(outputstring);
                    */
                }
            }
            //Abbruchkriterien beschränkt auf Zyklen und Timeout nach 15 Sekunden
            while (tempNC < this.nc && !Overtime);//(NCAktuell < this.NC && nichtDieGleicheTour)&& !Overtime);
            byte[] fillUp = output.getStaedteKuerzesterTourVonRunde().Last();
            output.getStaedteKuerzesterTourVonRunde().Add(fillUp);
                    output.getKuerzesteTourVonRunde().Add(shortestPathLength);
            sw.Stop();
            return output;
        }
    }
}
