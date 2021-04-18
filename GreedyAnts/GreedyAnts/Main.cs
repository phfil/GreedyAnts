using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static GreedyAnts.Parameter;

namespace GreedyAnts
{
    public class Main
    {
        //Grundlegendes Beispiel
        private bool isExample;
        //Art des Algorithmus
        private byte typeOfAlgorithm; //Parameter 1
        //Städte
        private double[][] townCoords; //Parameter 2
        private int n;
        int indexTownsCreated;
        public LinkedList<Town> towns;
        private typeOfSpreadTowns spreadTowns;
        public LinkedList<LinkedList<double[]>> matrix; //Abstands-, Sichtbarkeits- und Pheromonmatrix
        //Ameisen
        private byte[] antHomes; //Parameter 3
        private int m;
        int indexAntsCreated;
        private typeOfSpreadAnts spreadAnts;
        //Pheromone
        private double q; //Parameter 4
        private double qStart; //Parameter 5
        private double rho; //Parameter 6
        //Gewichtung
        private double alpha; //Parameter 7
        private double beta; //Parameter 8
        //Zyklen
        private int nc; //Parameter 9
        //GUI-Referenz
        private GUI gui;
        private List<Output> results;
        private Ameisenalgorithmen antAlgorithms;
        Random r;

        public Main(GUI gui)
        {
            this.gui = gui;
            antAlgorithms = new Ameisenalgorithmen();
            results = new List<Output>();
            r = new Random();
        }
        public void syncWithOldP()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Grundlegendes Beispiel
            gui.setCheckBoxExample(isExample);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Art des Algorithmus
            if (typeOfAlgorithm == 0)
            {
                gui.setComboBoxArt(Parameter.typeOfAlgorithm.Density);
            }
            else if (typeOfAlgorithm == 1)
            {
                gui.setComboBoxArt(Parameter.typeOfAlgorithm.Quantity);
            }
            else if (typeOfAlgorithm == 2)
            {
                gui.setComboBoxArt(Parameter.typeOfAlgorithm.Cycle);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Städte
            gui.setTextBoxAmountTowns(n);
            spreadTowns = Parameter.typeOfSpreadTowns.Custom;
            gui.setComboBoxSpreadTowns(spreadTowns);
            if (isExample)
            {
                //Initialisierung der Städte und Ameisen des Beispiels
                towns = new LinkedList<Town>();
                matrix = new LinkedList<LinkedList<double[]>>();
                indexTownsCreated = 0;
                this.townCoords = new double[n][];

                //Verteilung der 5 Städte
                addTown(20, 60, 1);
                towns.ElementAt(0).setName("A (S1)");
                this.townCoords[0] = new double[] { 20, 60 };
                addTown(20, 20, 2);
                towns.ElementAt(1).setName("B (S2)");
                this.townCoords[1] = new double[] { 20, 20 };
                addTown(80, 20, 3);
                towns.ElementAt(2).setName("C (S3)");
                this.townCoords[2] = new double[] { 80, 20 };
                addTown(80, 60, 4);
                towns.ElementAt(3).setName("D (S4)");
                this.townCoords[3] = new double[] { 80, 60 };
                addTown(50, 90, 5);
                towns.ElementAt(4).setName("E (S5)");
                this.townCoords[4] = new double[] { 50, 90 };
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Ameisen
            gui.setTextBoxAmountAnts(m);
            //spreadAnts = Parameter.typeOfSpreadAnts.Custom;
            //gui.setComboBoxSpreadAnts(spreadAnts);
            if (isExample)
            {
                //Initialisierung der Ameisen des Beispiels
                indexAntsCreated = 0;
                this.antHomes = new byte[m];

                //Verteilung der 3 Ameisen
                gui.getListBoxAnts().Items.Clear();
                gui.getListBoxAnts().Items.Add("Informationen deaktivieren");
                gui.getListBoxAnts().Items.Add("Kürzesten Pfad zeigen");
                gui.getListBoxAnts().SelectedIndex = 0;
                Town tempTown = towns.ElementAt(2);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[0] = 3;
                tempTown = towns.ElementAt(0);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[1] = 1;
                tempTown = towns.ElementAt(4);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[2] = 5;
                gui.getListBoxAnts().SetSelected(0, true);
            }
            else
            {
                this.antHomes = new byte[m];
                for (int i = 0; i < towns.Count; i++)
                {
                    towns.ElementAt(i).setAntList(new LinkedList<Ant>());
                }
                indexAntsCreated = 0;
                //Verteilung von m Ameisen
                gui.getListBoxAnts().Items.Clear();
                gui.getListBoxAnts().Items.Add("Informationen deaktivieren");
                gui.getListBoxAnts().Items.Add("Kürzesten Pfad zeigen");
                gui.getListBoxAnts().SelectedIndex = 0;
                if (towns.Count > 0)
                {
                    byte countTowns = 1;
                    for (int i = 0; i < m; i++)
                    {
                        indexAntsCreated++;
                        Town tempTown = towns.ElementAt(countTowns-1);
                        tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                        this.antHomes[i] = countTowns;
                        countTowns++;
                        if (countTowns > n)
                        {
                            countTowns = 1;
                        }
                    }
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Pheromone
            gui.setTextBoxStrength(q);
            gui.setTextBoxStartPheromone(qStart);
            gui.setTextBoxEvaporation(rho);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Gewichtung
            gui.setTextBoxWeightPheromone(alpha);
            gui.setTextBoxWeightDistance(beta);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Zyklen
            gui.setTextBoxCycles(nc);
            gui.stopAnimation();
            gui.setBtnPlay(false);
            gui.setBtnPause(false);
            gui.setBtnNextIt(false);
            gui.setBtnNextRound(false);
            gui.setBtnToTheEnd(false);
            gui.setBtnPrevRound(false);
            gui.setBtnPrevIt(false);
            gui.stopAnimation();
            this.results.Add(antAlgorithms.algorithmieren(this.townCoords, this.antHomes, q, qStart, rho, alpha, beta, nc, typeOfAlgorithm));
            if (results.Count > 5)
            {
                this.results.RemoveAt(0);
            }
        }
        public void syncWithNewP()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Grundlegendes Beispiel
            isExample = gui.getParameter().getIsSelectedExample();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Art des Algorithmus
            if(gui.getParameter().getSelectedAlgorithm() == Parameter.typeOfAlgorithm.Density)
            {
                typeOfAlgorithm = 0;
            }
            else if(gui.getParameter().getSelectedAlgorithm() == Parameter.typeOfAlgorithm.Quantity)
            {
                typeOfAlgorithm = 1;
            }
            else if (gui.getParameter().getSelectedAlgorithm() == Parameter.typeOfAlgorithm.Cycle)
            {
                typeOfAlgorithm = 2;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Städte
            bool theSameTowns = false;
            if (n == gui.getParameter().getSelectedAmountOfTowns() && gui.getParameter().getSelectedSpreadTowns() == typeOfSpreadTowns.Custom)
            {
                theSameTowns = true;
            }
            n = gui.getParameter().getSelectedAmountOfTowns();
            spreadTowns = gui.getParameter().getSelectedSpreadTowns();
            //gui.getComboBoxSpreadTowns().SelectedItem = GUI.SPREADTOWNSCUSTOM;
            if (isExample)
            {
                //Initialisierung der Städte und Ameisen des Beispiels
                towns = new LinkedList<Town>();
                matrix = new LinkedList<LinkedList<double[]>>();
                indexTownsCreated = 0;
                this.townCoords = new double[n][];

                //Verteilung der 5 Städte
                addTown(20, 60, 1);
                towns.ElementAt(0).setName("A (S1)");
                this.townCoords[0] = new double[] {20,60 };
                addTown(20, 20, 2);
                towns.ElementAt(1).setName("B (S2)");
                this.townCoords[1] = new double[] {20,20 };
                addTown(80, 20, 3);
                towns.ElementAt(2).setName("C (S3)");
                this.townCoords[2] = new double[] {80,20 };
                addTown(80, 60, 4);
                towns.ElementAt(3).setName("D (S4)");
                this.townCoords[3] = new double[] {80,60 };
                addTown(50, 90, 5);
                towns.ElementAt(4).setName("E (S5)");
                this.townCoords[4] = new double[] {50,90 };
            }
            else
            {
                //Städte aktualisieren
                if (!theSameTowns || spreadTowns == typeOfSpreadTowns.Random)
                {
                    bool deadend = true;
                    while (deadend)
                    {
                        //Initialisierung der Städte und Ameisen der frei gewählten Parameter
                        towns = new LinkedList<Town>();
                        matrix = new LinkedList<LinkedList<double[]>>();
                        indexTownsCreated = 0;
                        this.townCoords = new double[n][];
                        int count0 = 0;
                        //Verteilung von n Städten

                        for (int i = 0; i < n; i++)
                        {
                            bool placeFound = false;
                            //prüfen bis Erzeugung neuer Stadt möglich
                            while (!placeFound)
                            {
                                int x = r.Next(0, 100);
                                int y = r.Next(0, 100);
                                if (gui.isInBorder(x, y))
                                {
                                    if (!gui.townSpaceDetection(x, y, null))
                                    {
                                        addTown(x, y, 0);
                                        this.townCoords[i] = new double[] { x, y };
                                        placeFound = true;
                                    }
                                }
                                count0++;
                                if (count0 > 25000)
                                {
                                    placeFound = true;
                                    i = n;
                                }
                            }
                        }
                        if (indexTownsCreated == n)
                        {
                            deadend = false;
                        }
                    }
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Ameisen
            bool theSameAnts = false;
            if (m == gui.getParameter().getSelectedAmountOfAnts() && gui.getParameter().getSelectedSpreadAnts() == typeOfSpreadAnts.Custom)
            {
                theSameAnts = true;
            }
            m = gui.getParameter().getSelectedAmountOfAnts();
            //MessageBox.Show("m: " + m);
            spreadAnts = gui.getParameter().getSelectedSpreadAnts();
            //gui.getComboBoxSpreadAnts().SelectedItem = GUI.SPREADANTSCUSTOM;
            if (isExample)
            {
                //Initialisierung der Ameisen des Beispiels
                indexAntsCreated = 0;
                this.antHomes = new byte[m];

                //Verteilung der 3 Ameisen
                gui.getListBoxAnts().Items.Clear();
                gui.getListBoxAnts().Items.Add("Informationen deaktivieren");
                gui.getListBoxAnts().Items.Add("Kürzesten Pfad zeigen");
                gui.getListBoxAnts().SelectedIndex = 0;
                Town tempTown = towns.ElementAt(2);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[0] = 3;
                tempTown = towns.ElementAt(0);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[1] = 1;
                tempTown = towns.ElementAt(4);
                indexAntsCreated++;
                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                this.antHomes[2] = 5;
            }
            else
            {
                //Ameisen aktualisieren
                if (!theSameTowns || (theSameTowns && !theSameAnts))
                {
                    this.antHomes = new byte[m];
                    for (int i = 0; i < towns.Count; i++)
                    {
                        towns.ElementAt(i).setAntList(new LinkedList<Ant>());
                    }
                    indexAntsCreated = 0;
                    //Verteilung von m Ameisen
                    gui.getListBoxAnts().Items.Clear();
                    gui.getListBoxAnts().Items.Add("Informationen deaktivieren");
                    gui.getListBoxAnts().Items.Add("Kürzesten Pfad zeigen");
                    gui.getListBoxAnts().SelectedIndex = 0;
                    if (towns.Count > 0)
                    {
                        byte countTowns = 1;
                        if (spreadAnts == typeOfSpreadAnts.Even)
                        {
                            for (int i = 0; i < m; i++)
                            {
                                indexAntsCreated++;
                                Town tempTown = towns.ElementAt(countTowns - 1);
                                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                                this.antHomes[i] = countTowns;
                                countTowns++;
                                if (countTowns > n)
                                {
                                    countTowns = 1;
                                }
                            }
                        } else if (spreadAnts == typeOfSpreadAnts.Random)
                        {
                            for (int i = 0; i < m; i++)
                            {
                                indexAntsCreated++;
                                int nextRandomInt = r.Next(0, n);
                                Town tempTown = towns.ElementAt(r.Next(nextRandomInt));
                                tempTown.getAntList().AddLast(new Ant(tempTown.getX(), tempTown.getY(), tempTown, gui.getListBoxAnts(), indexAntsCreated));
                                this.antHomes[i] = (byte)(nextRandomInt+1);
                                
                            }
                        } 
                    }
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Pheromone
            q = gui.getParameter().getSelectedStrength();
            qStart = gui.getParameter().getSelectedStartPheromone();
            rho = gui.getParameter().getSelectedEvaporation();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Gewichtung
            alpha = gui.getParameter().getSelectedWeightPheromone();
            beta = gui.getParameter().getSelectedWeightDistance();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Zyklen
            nc = gui.getParameter().getSelectedAmountOfCycles();
            string test = "";
            for(int i = 0; i < m;i++)
            {
                test += this.antHomes[i] + " , ";
            }
            gui.setBtnPlay(false);
            gui.setBtnPause(false);
            gui.setBtnNextIt(false);
            gui.setBtnNextRound(false);
            gui.setBtnToTheEnd(false);
            gui.setBtnPrevRound(false);
            gui.setBtnPrevIt(false);
            gui.stopAnimation();
            this.results.Add(antAlgorithms.algorithmieren(this.townCoords, this.antHomes, q,qStart,rho,alpha,beta,nc, typeOfAlgorithm));
            if (results.Count > 5)
            {
                this.results.RemoveAt(0);
            }
        }
        public void addTown(double x, double y, int look)
        {
            indexTownsCreated++;
            Town newTown;
            if (isExample)
            {
                newTown = new Town(x, y, towns.Count, indexTownsCreated, look);
            }
            else
            {
                newTown = new Town(x, y, towns.Count, indexTownsCreated, r);
            }
            towns.AddLast(newTown);

            //Lege neuen Knoten an
            //
            // - - -
            // - - -
            // - - -
            // new new new new
            //
            LinkedList<double[]> newNode = new LinkedList<double[]>();
            for (int i = 0; i <= matrix.Count; i++)
            {
                //distanz newTown - towns.elementAt(i)
                double deltaX = Convert.ToDouble(x - towns.ElementAt(i).getX());
                double deltaY = Convert.ToDouble(y - towns.ElementAt(i).getY());
                double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                double[] newEntry;
                if (i == matrix.Count)
                {
                    newEntry = new double[3] { distance, -1, 0 };
                }
                else
                {
                    newEntry = new double[3] { distance, 1.0 / distance, qStart };
                }
                newNode.AddLast(newEntry);
            }
            //erweitere vorhandene Knoten
            // - - - new
            // - - - new
            // - - - new
            // - - - -
            //
            for (int i = 0; i < matrix.Count; i++)
            {
                //distanz newTown - towns.elementAt(i)
                double deltaX = Convert.ToDouble(newTown.getX() - towns.ElementAt(i).getX());
                double deltaY = Convert.ToDouble(newTown.getY() - towns.ElementAt(i).getY());
                double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                double[] newEntry = new double[3] { distance, 1.0 / distance, qStart };
                matrix.ElementAt(i).AddLast(newEntry);
            }
            matrix.AddLast(newNode);
            updateTownCoordinates();
        }
        private void updateTownCoordinates()
        {

            this.townCoords = new double[n][];
            for (int i = 0; i < towns.Count; i++)
            {
                this.townCoords[i] = new double[] { towns.ElementAt(i).getX(), towns.ElementAt(i).getY() };
            }
        }
        public void deleteTown(Town townToDelete)
        {
            LinkedList<Ant> antsToSave = new LinkedList<Ant>();
            antsToSave = townToDelete.getAntList();
            towns.Remove(townToDelete);

            //Spalten aus Matrix entfernen
            for (int i = 0; i < matrix.Count; i++)
            {
                //MessageBox.Show(i.ToString() + "; " + townToDelete.currentIndex);
                double[] elementToDelete = matrix.ElementAt(i).ElementAt(townToDelete.currentIndex);
                matrix.ElementAt(i).Remove(elementToDelete);
            }

            //Zeilen aus Matrix entfernen
            LinkedList<double[]> nodeToDelete = matrix.ElementAt(townToDelete.currentIndex);
            matrix.Remove(nodeToDelete);

            for (int i = townToDelete.currentIndex; i < matrix.Count; i++)
            {
                towns.ElementAt(i).currentIndex--;
            }

            //stadtlose Ameisen neue verteilen
            if (towns.Count > 0)
            {
                for (int i = 0; i < antsToSave.Count; i++)
                {
                    Town tempTown = towns.ElementAt(r.Next(0, n));
                    antsToSave.ElementAt(i).setPosition(tempTown.getX(), tempTown.getY());
                    tempTown.getAntList().AddLast(antsToSave.ElementAt(i));
                }
            }
            else
            {
                gui.setTextBoxAmountAnts(0);
            }
            updateTownCoordinates();
        }
        public void updateTown(Town townToMove, double x, double y)
        {
            townToMove.update(x, y);

            LinkedList<double[]> newNode = new LinkedList<double[]>();
            for (int i = 0; i < matrix.Count; i++)
            {
                //distanz townToMove - towns.elementAt(i)
                double deltaX = Convert.ToDouble(x - towns.ElementAt(i).getX());
                double deltaY = Convert.ToDouble(y - towns.ElementAt(i).getY());
                double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                matrix.ElementAt(i).ElementAt(townToMove.currentIndex)[0] = distance;
                matrix.ElementAt(townToMove.currentIndex).ElementAt(i)[0] = distance;
            }
            updateTownCoordinates();
        }
        public void increaseAmountOfTowns()
        {
            n++;
            gui.setTextBoxAmountTowns(n);
        }
        public void decreaseAmountOfTowns()
        {
            n--;
            gui.setTextBoxAmountTowns(n);
        }
        //Getter
        public GUI getGUI()
        {
            return this.gui;
        }
        public int getAmountOfTownsN()
        {
            return n;
        }
        public LinkedList<Town> getTowns()
        {
            return this.towns;
        }
        public byte getArt()
        {
            return typeOfAlgorithm;
        }
        //Setter
        public void setIsExample(bool isExample)
        {
            this.isExample = isExample;
        }
        public List<Output> getResults()
        {
            return this.results;
        }
    }
}