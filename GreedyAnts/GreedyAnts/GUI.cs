using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GreedyAnts
{
    public partial class GUI : Form
    {
        private bool isfullscreen;
        private FormState formState = new FormState();

        //Konstanten
        public const string ANTDENSITY = "Ant Density Algorithm";
        public const string ANTQUANTITY = "Ant Quantity Algorithm";
        public const string ANTCYCLE = "Ant Cycle Algorithm";

        public const string SPREADTOWNSRANDOM = "Zufällig";
        public const string SPREADTOWNSCUSTOM = "Benutzerdefiniert";
        public const string SPREADTOWNSUNDEFINED = "Unbestimmt";

        public const string SPREADANTSEVEN = "Gleichverteilt";
        public const string SPREADANTSRANDOM = "Zufällig";
        public const string SPREADANTSCUSTOM = "Benutzerdefiniert";

        //Visualisierungs-Konstanten
        public const int BORDERMINIMAL = 50;
        private const double MINIMALVISIBLETRAIL = 0.5;
        public const int ROADSTEPS = 500;
        private const int OFFSETX_TOWN = 13;
        private const int OFFSETY_TOWN = 24;
        private const int OFFSETX_ANT = 13;
        private const int OFFSETY_ANT = 18;

        public int borderOffsetWidth;
        public int borderOffsetHeight;
        public int screenSize;
        public double scaleFactor;

        private double currentStep = 0;
        private List<AnimatedAnt> aniAnts;
        private Bitmap defaultSprite;

        //Parameter-Variablen
        //Auslagerung der 11 aktuell ausgewählten Parameterwerte des Parameterpanels "pnlParameter"
        private Parameter parameter;

        //Kontroll-Variablen von "pnlControl"
        public double selectedSpeed;
        private bool isLocked;
        private bool showTrail;
        private bool showSolution;
        private bool showPheromone;
        private bool showDistance;
        private bool showCoordinates;
        private bool showAnts;
        private bool showTowns;
        private bool showNames;

        //Informations-Variablen von "spcInformation"
        public int selectedAnt;
        public string selectedName;

        //Visualisierungs-Variablen von "pnlVisualiszation"
        private bool isMouseDown;
        private bool isMoving;
        bool isLoaded;
        private Town touchedTown;
        private double touchedTownOldX;
        private double touchedTownOldY;
        private bool isWalking;
        private bool isNewWalk;

        private int currentTime;
        private int currentCycle;

        //Code-Referenz
        private Main main;
        private bool isParameterViewSync;

        //Konstruktor
        public GUI()
        {
            InitializeComponent();
            KeyPreview = true;

            cbxArt.Items.Add(ANTDENSITY);
            cbxArt.Items.Add(ANTQUANTITY);
            cbxArt.Items.Add(ANTCYCLE);
            cbxSpreadTowns.Items.Add(SPREADTOWNSRANDOM);
            cbxSpreadTowns.Items.Add(SPREADTOWNSCUSTOM);
            //cbxSpreadTowns.Items.Add(SPREADTOWNSUNDEFINED);
            cbxSpreadAnts.Items.Add(SPREADANTSRANDOM);
            cbxSpreadAnts.Items.Add(SPREADANTSCUSTOM);
            cbxSpreadAnts.Items.Add(SPREADANTSEVEN);

            //Parameter-Panel-Initialisierung "pnlParameter"
            parameter = new Parameter();
            chbExample.Checked = true;

            //Kontroll-Panel-Initialisierung "pnlControl"
            tbxSpeed.Text = 1.ToString();
            isLocked = true;
            showTrail = true;
            showSolution = true;
            showPheromone = false;
            showDistance = false;
            showCoordinates = false;
            showAnts = true;
            showTowns = true;
            showNames = true;

            //Informations-SplitContainer-Initialisierung "spcInformation"
            selectedAnt = -1;
            selectedName = "";

            //Visualisierungs-Panel-Initialisierung "pnlVisualization"
            isMouseDown = false;
            isMoving = false;
            touchedTown = null;
            touchedTownOldX = 0;
            touchedTownOldY = 0;
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                pnlVisualization,
                new object[] { true }); // Double-Buffering

            main = new Main(this);
            main.syncWithNewP();
            currentTime = -1;
            currentCycle = -1;
            this.isParameterViewSync = true;

            isLoaded = true;
            isWalking = false;
            isNewWalk = true;
            aniAnts = new List<AnimatedAnt>();


            Bitmap collection = new Bitmap(GreedyAnts.Properties.Resources.AntSpriteCollection);
            defaultSprite = AnimatedAnt.getDefaultSprite(collection);

            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnNextIt.Enabled = false;
            btnNextRound.Enabled = false;
            btnToTheEnd.Enabled = false;
            btnPrevRound.Enabled = false;
            btnPrevIt.Enabled = false;


            if (this.pnlVisualization.Height < this.pnlVisualization.Width)
            {
                screenSize = this.pnlVisualization.Height - (BORDERMINIMAL * 2);
                borderOffsetHeight = BORDERMINIMAL;
                borderOffsetWidth = (int)((this.pnlVisualization.Width - screenSize) / 2.0);
                scaleFactor = screenSize / 100;
            }
            else
            {
                screenSize = this.pnlVisualization.Width - (BORDERMINIMAL * 2);
                borderOffsetHeight = (int)((this.pnlVisualization.Height - screenSize) / 2.0);
                borderOffsetWidth = BORDERMINIMAL;
                scaleFactor = screenSize / 100;
            }
            isfullscreen = false;

            updateInformationPanel();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI I - PARAMETER Anfang
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chbExample_CheckedChanged(object sender, EventArgs e)
        {
            if (chbExample.Checked)
            {
                //grundlegendes Beispiel
                parameter.setIsSelectedExample(true);

                //Auswahl der Art des im grundlegenden Beispiel verwendeten Ameisenalgorithmus
                cbxArt.SelectedIndex = cbxArt.Items.IndexOf(ANTDENSITY);
                cbxArt.Enabled = false;
                //cbxArt_SelectedIndexChanged(null, null); --> wird ausgelöst

                //Auswahl der Anzahl an Städten im grundlegenden Beispiel
                tbxAmountTowns.Text = 5.ToString();
                tbxAmountTowns.Enabled = false;

                trbAmountTowns.Enabled = false;
                trbAmountTowns_ValueChanged(null, null);

                cbxSpreadTowns.SelectedIndex = cbxSpreadTowns.Items.IndexOf(SPREADTOWNSCUSTOM);
                cbxSpreadTowns.Enabled = false;

                //Auswahl der Anzahl an Ameisen im grundlegenden Beipsiel
                tbxAmountAnts.Text = 3.ToString();
                tbxAmountAnts.Enabled = false;

                trbAmountAnts.Enabled = false;
                trbAmountAnts_ValueChanged(null, null);

                cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSCUSTOM);
                cbxSpreadAnts.Enabled = false;

                //Pheromone
                tbxStrength.Text = 1.ToString();
                tbxStrength.Enabled = false;

                trbStrength.Enabled = false;
                trbStrength_ValueChanged(null, null);

                tbxStartPheromone.Text = 1.ToString();
                tbxStartPheromone.Enabled = false;

                trbStartPheromone.Enabled = false;
                trbStartPheromone_ValueChanged(null, null);

                tbxEvaporation.Text = 0.9.ToString();
                tbxEvaporation.Enabled = false;

                trbEvaporation.Enabled = false;
                trbEvaporation_ValueChanged(null, null);

                //Gewichtung / Relative Bedeutung
                //Alpha
                tbxWeightPheromone.Text = 1.ToString();
                tbxWeightPheromone.Enabled = false;

                trbWeightPheromone.Enabled = false;
                trbWeightPheromone_ValueChanged(null, null);

                //Beta
                tbxWeightDistance.Text = 1.ToString();
                tbxWeightDistance.Enabled = false;

                trbWeightDistance.Enabled = false;
                trbWeightDistance_ValueChanged(null, null);

                //Zyklen
                tbxCycles.Text = 2.ToString();
                tbxCycles.Enabled = false;

                trbCycles.Enabled = false;
                trbCycles_ValueChanged(null, null);
            }
            else
            {
                //grundlegendes Beispiel
                parameter.setIsSelectedExample(false);

                //Auswahl der Art des im grundlegenden Beispiel verwendeten Ameisenalgorithmus
                cbxArt.Enabled = true;

                //Auswahl der Anzahl an Städten im grundlegenden Beispiel
                tbxAmountTowns.Enabled = true;
                trbAmountTowns.Enabled = true;
                cbxSpreadTowns.Enabled = true;

                //Auswahl der Anzahl an Ameisen im grundlegenden Beipsiel
                tbxAmountAnts.Enabled = true;
                trbAmountAnts.Enabled = true;
                cbxSpreadAnts.Enabled = true;
                cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSEVEN);

                //Pheromone
                tbxStrength.Enabled = true;
                trbStrength.Enabled = true;
                tbxStartPheromone.Enabled = true;
                trbStartPheromone.Enabled = true;
                tbxEvaporation.Enabled = true;
                trbEvaporation.Enabled = true;

                //Gewichtung / Relative Bedeutung
                //Alpha
                tbxWeightPheromone.Enabled = true;
                trbWeightPheromone.Enabled = true;
                //Beta
                tbxWeightDistance.Enabled = true;
                trbWeightDistance.Enabled = true;

                //Zyklen
                tbxCycles.Enabled = true;
                trbCycles.Enabled = true;
            }
        }
        private void cbxArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxArt.Text == ANTDENSITY)
            {
                parameter.setSelectedAlgorithm(Parameter.typeOfAlgorithm.Density);
            }
            else if (cbxArt.Text == ANTQUANTITY)
            {
                parameter.setSelectedAlgorithm(Parameter.typeOfAlgorithm.Quantity);
            }
            else if (cbxArt.Text == ANTCYCLE)
            {
                parameter.setSelectedAlgorithm(Parameter.typeOfAlgorithm.Cycle);
            }
            else
            {
                MessageBox.Show("Unbekannter Algorithmus!");
            }

            this.isParameterViewSync = false;
        }
        private void tbxAmountTowns_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxAmountTowns, trbAmountTowns, "Anzahl an Städten", true);
            if (tbxAmountTowns.Text == "")
            {
                tbxAmountTowns.Text = 5.ToString();
            }
        }
        private void trbAmountTowns_ValueChanged(object sender, EventArgs e)
        {
            tbxAmountTowns.Text = Convert.ToString(trbAmountTowns.Value);
            parameter.setSelectedAmountOfTowns(trbAmountTowns.Value);
            cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSEVEN);
            this.isParameterViewSync = false;
        }
        private void cbxSpreadTowns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSpreadTowns.Text == SPREADTOWNSRANDOM)
            {
                parameter.setSelectedSpreadTowns(Parameter.typeOfSpreadTowns.Random);
            }
            else if (cbxSpreadTowns.Text == SPREADTOWNSCUSTOM)
            {
                parameter.setSelectedSpreadTowns(Parameter.typeOfSpreadTowns.Custom);
            }
            else if (cbxSpreadTowns.Text == SPREADTOWNSUNDEFINED)
            {
                parameter.setSelectedSpreadTowns(Parameter.typeOfSpreadTowns.Undefined);
            }
            else
            {
                MessageBox.Show("Unbekannte Verteilung!");
            }
        }
        private void tbxAmountAnts_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxAmountAnts, trbAmountAnts, "Anzahl an Ameisen", true);
            if (tbxAmountAnts.Text == "")
            {
                tbxAmountAnts.Text = 3.ToString();
            }
        }
        private void trbAmountAnts_ValueChanged(object sender, EventArgs e)
        {
            tbxAmountAnts.Text = Convert.ToString(trbAmountAnts.Value);
            parameter.setSelectedAmountOfAnts(trbAmountAnts.Value);
            cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSEVEN);
            this.isParameterViewSync = false;
        }
        private void cbxSpreadAnts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSpreadAnts.Text == SPREADANTSRANDOM)
            {
                parameter.setSelectedSpreadAnts(Parameter.typeOfSpreadAnts.Random);
            }
            else if (cbxSpreadAnts.Text == SPREADANTSCUSTOM)
            {
                parameter.setSelectedSpreadAnts(Parameter.typeOfSpreadAnts.Custom);
            }
            else if (cbxSpreadAnts.Text == SPREADANTSEVEN)
            {
                parameter.setSelectedSpreadAnts(Parameter.typeOfSpreadAnts.Even);
            }
            else
            {
                MessageBox.Show("Unbekannte Verteilung!");
            }
            this.isParameterViewSync = false;
        }
        private void tbxStrength_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxStrength, trbStrength, "Stärke der Pheromone", false);
            if (tbxStrength.Text == "")
            {
                tbxStrength.Text = 1.ToString();
            }
        }
        private void trbStrength_ValueChanged(object sender, EventArgs e)
        {
            double strengthValue = trbStrength.Value / 100.00;
            tbxStrength.Text = Convert.ToString(strengthValue);
            parameter.setSelectedStrength(strengthValue);
            this.isParameterViewSync = false;
        }
        private void tbxStartPheromone_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxStartPheromone, trbStartPheromone, "Startwert der Pheromone", false);
            if (tbxStartPheromone.Text == "")
            {
                tbxStartPheromone.Text = 1.ToString();
            }
        }
        private void trbStartPheromone_ValueChanged(object sender, EventArgs e)
        {
            double startPheromonValue = trbStartPheromone.Value / 100.00;
            tbxStartPheromone.Text = Convert.ToString(startPheromonValue);
            parameter.setSelectedStartPheromone(startPheromonValue);
            this.isParameterViewSync = false;
        }
        private void tbxEvaporation_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxEvaporation, trbEvaporation, "Evaporationskoeffizient der Pheromone", false);
            if (tbxEvaporation.Text == "")
            {
                tbxEvaporation.Text = 0.9.ToString();
            }
        }
        private void trbEvaporation_ValueChanged(object sender, EventArgs e)
        {
            double evaporationValue = trbEvaporation.Value / 100.00;
            tbxEvaporation.Text = Convert.ToString(evaporationValue);
            parameter.setSelectedEvaporation(evaporationValue);
            this.isParameterViewSync = false;
        }
        private void tbxWeightPheromone_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxWeightPheromone, trbWeightPheromone, "Gewichtung der Pheromone", false);
            if (tbxWeightPheromone.Text == "")
            {
                tbxWeightPheromone.Text = 1.ToString();
            }
        }
        private void trbWeightPheromone_ValueChanged(object sender, EventArgs e)
        {
            double weightPheromoneValue = trbWeightPheromone.Value / 100.00;
            tbxWeightPheromone.Text = Convert.ToString(weightPheromoneValue);
            parameter.setSelectedWeightPheromone(weightPheromoneValue);
            this.isParameterViewSync = false;
        }
        private void tbxWeightDistance_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxWeightDistance, trbWeightDistance, "Gewichtung der Distanz", false);
            if (tbxWeightDistance.Text == "")
            {
                tbxWeightDistance.Text = 1.ToString();
            }
        }
        private void trbWeightDistance_ValueChanged(object sender, EventArgs e)
        {
            double weightDistanceValue = trbWeightDistance.Value / 100.00;
            tbxWeightDistance.Text = Convert.ToString(weightDistanceValue);
            parameter.setSelectedWeightDistance(weightDistanceValue);
            this.isParameterViewSync = false;
        }
        private void tbxCycles_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxCycles, trbCycles, "Anzahl an Zyklen", true);
            if (tbxCycles.Text == "")
            {
                tbxCycles.Text = 2.ToString();
            }
        }
        private void trbCycles_ValueChanged(object sender, EventArgs e)
        {
            tbxCycles.Text = Convert.ToString(trbCycles.Value);
            parameter.setSelectedAmountOfCycles(trbCycles.Value);
            this.isParameterViewSync = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI I - PARAMETER ENDE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI II - TRANSFER ANFANG
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRunWithOldP_Click(object sender, EventArgs e)
        {
            main.syncWithOldP();
            currentTime = -1;
            currentCycle = -1;
            this.isParameterViewSync = true;
            pnlVisualization.Invalidate();
            lbxAnts.SelectedItem = 0;
            updateInformationPanel();
        }
        private void btnRunWithNewP_Click(object sender, EventArgs e)
        {
            main.syncWithNewP();
            currentTime = -1;
            currentCycle = -1;
            this.isParameterViewSync = true;
            pnlVisualization.Invalidate();
            lbxAnts.SelectedItem = 0;
            updateInformationPanel();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI II - TRANSFER ENDE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI III - CONTROL ANFANG
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tbxSpeed_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxSpeed, trbSpeed, "Geschwindigkeit", false);
            if (tbxSpeed.Text == "")
            {
                tbxSpeed.Text = 1.ToString();
            }
        }
        private void trbSpeed_ValueChanged(object sender, EventArgs e)
        {
            double speedValue = trbSpeed.Value / 100.00;
            tbxSpeed.Text = Convert.ToString(speedValue);
            selectedSpeed = speedValue;
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
            aniAnts = new List<AnimatedAnt>();
            if (currentTime != -1 && currentTime < maxT)
            {
                int[][] tempTownAnts = main.getResults().Last().getStadtAmeisenVonT().ElementAt(currentTime);
                //lade animierte Ameisen
                for (int i = 0; i < tempTownAnts.Length; i++)
                {
                    for(int j = 0; j < tempTownAnts[0].Length; j++)
                    {
                        if (tempTownAnts[i][j] == 0)
                        {
                            j = tempTownAnts[0].Length;
                        }
                        else
                        {
                            double x = main.getResults().Last().getStadtkoordinaten()[i][0];
                            double y = main.getResults().Last().getStadtkoordinaten()[i][1];
                            aniAnts.Add(new AnimatedAnt(x, y, tempTownAnts[i][j]));
                        }
                    }
                }

                int[][] tempTownAnts2 = main.getResults().Last().getStadtAmeisenVonT().ElementAt(currentTime+1);
                //lade Ziel
                for(int h = 0; h < aniAnts.Count; h++)
                {
                    for (int i = 0; i < tempTownAnts2.Length; i++)
                    {
                        for (int j = 0; j < tempTownAnts2[0].Length; j++)
                        {
                            if (tempTownAnts2[i][j] == 0)
                            {
                                j = tempTownAnts2[0].Length;
                            }
                            else if (tempTownAnts2[i][j] == aniAnts.ElementAt(h).getNumber())
                            {
                                aniAnts.ElementAt(h).setXD(main.getResults().Last().getStadtkoordinaten()[i][0]);
                                aniAnts.ElementAt(h).setYD(main.getResults().Last().getStadtkoordinaten()[i][1]);

                                j = tempTownAnts[0].Length;
                                i = tempTownAnts.Length;
                            }
                        }
                    }
                }

                isWalking = true;
                isNewWalk = true;
                timer.Start();
            }
            this.pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            stopAnimation();
            this.pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnNextIt_Click(object sender, EventArgs e)
        {
            int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;

            //nächste Iteration
            if (currentTime == -1)
            {
                currentTime = -1;
                currentCycle = -1;
            }
            else if (currentTime == maxT)
            {
                currentTime = -1;
                currentCycle = -1;
            }
            else
            {
                currentTime++;
                currentCycle = (currentTime / main.getResults().Last().getStadtkoordinaten().Length)+1;
            }
            pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnNextCycle_Click(object sender, EventArgs e)
        {
            int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
            //erste Iteration der nächsten Runde
            if (currentCycle == -1)
            {
                currentTime = -1;
                currentCycle = -1;
            }
            else if (currentCycle == (maxT / main.getResults().Last().getStadtkoordinaten().Length) +1)
            {

                currentTime = -1;
                currentCycle = -1;
            }
            else
            {
                currentCycle++;
                currentTime = (currentCycle-1) * main.getResults().Last().getStadtkoordinaten().Length;
            }
            pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnToTheEnd_Click(object sender, EventArgs e)
        {
            //letzte Iteration
            currentTime = -1;
            currentCycle = -1;
            pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnPrevIt_Click(object sender, EventArgs e)
        {
            int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
            //vorherige Iteration
            if (currentTime == -1)
            {
                currentTime = maxT;
                currentCycle = (currentTime / main.getResults().Last().getStadtkoordinaten().Length)+1;
            }
            else if (currentTime == 0)
            {
                currentTime = 0;
                currentCycle = 1;
            }
            else
            {
                currentTime--;
                currentCycle = (currentTime / main.getResults().Last().getStadtkoordinaten().Length)+1;
            }
            pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnPrevCycle_Click(object sender, EventArgs e)
        {
            //erste Iteration der aktuellen Runde, wenn momentane Iteration nicht erste Iteration der Runde
            //erste Iteration der vorherigen Runde, wenn momentane Iteration erste Iteration der Runde
            int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
            if (currentCycle == -1)
            {
                currentTime = maxT;
                int tempN = main.getResults().Last().getStadtkoordinaten().Length;
                currentCycle =( currentTime / tempN) + 1;
                currentTime = (currentCycle-1) * tempN;
            }
            else if (currentCycle == 1)
            {
                currentTime = 0;
                currentCycle = 1;
            }
            else
            {
                currentCycle--;
                currentTime = (currentCycle-1) * main.getResults().Last().getStadtkoordinaten().Length;
            }
            pnlVisualization.Invalidate();
            updateInformationPanel();
        }
        private void btnToTheStart_Click(object sender, EventArgs e)
        {
            //erste Iteration
            currentTime = 0;
            currentCycle = 1;
            pnlVisualization.Invalidate();
            updateInformationPanel();
            btnPlay.Enabled = true;
            btnPause.Enabled = true;
            btnNextIt.Enabled = true;
            btnNextRound.Enabled = true;
            btnToTheEnd.Enabled = true;
            btnPrevRound.Enabled = true;
            btnPrevIt.Enabled = true;
        }
        private void chbLock_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbLock.Checked && chbExample.Checked && this.isParameterViewSync)
            {
                DialogResult dialogResult = MessageBox.Show("Sperre für das Grundlegende Beispiel aufheben?", "Sperre aufheben", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    chbExample.Checked = false;
                    main.setIsExample(false);
                }
                else if (dialogResult == DialogResult.No)
                {
                    chbLock.Checked = true;
                }
            }
            if (chbExample.Checked == true)
            {
                isLocked = true;
            }
            else
            {
                isLocked = false;
            }
            updateInformationPanel();
        }
        private void chbTrail_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTrail.Checked == true)
            {
                showTrail = true;
            }
            else
            {
                showTrail = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbSolution_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSolution.Checked)
            {
                showSolution = true;
            }
            else
            {
                showSolution = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbPheromone_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPheromone.Checked)
            {
                showPheromone = true;
            }
            else
            {
                showPheromone = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDistance.Checked)
            {
                showDistance = true;
            }
            else
            {
                showDistance = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbCoordinates_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCoordinates.Checked)
            {
                showCoordinates = true;
            }
            else
            {
                showCoordinates = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbAnts_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAnts.Checked)
            {
                showAnts = true;
            }
            else
            {
                showAnts = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbTowns_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTowns.Checked)
            {
                showTowns = true;
            }
            else
            {
                showTowns = false;
            }
            pnlVisualization.Invalidate();
        }
        private void chbNames_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNames.Checked)
            {
                showNames = true;
            }
            else
            {
                showNames = false;
            }
            pnlVisualization.Invalidate();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI III - CONTROL ENDE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI IV - INFO ANFANG
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lbxAnts_Click(object sender, EventArgs e)
        {
            if (lbxAnts.SelectedIndex == selectedAnt)
            {
                selectedAnt = 0;
                //clearSelectedAnt();
            }
            updateInformationPanel();
        }
        private void lbxAnts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                lbxAnts_Click(null, null);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI IV - INFO ENDE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI V - VIEW ANFANG
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pnlVisualization_MouseDown(object sender, MouseEventArgs e)
        {
            double xCorrected = (e.X - borderOffsetWidth) / scaleFactor * 1.0;
            double yCorrected = (this.pnlVisualization.Height - borderOffsetHeight - e.Y) / scaleFactor * 1.0;
            isMouseDown = true;
            isMoving = false;
            if (!isLocked)
            {
                //prüfen ob Erzeugung neuer Stadt möglich
                if (isInBorder(xCorrected, yCorrected))
                {
                    if (!townSpaceDetection(xCorrected, yCorrected,null))
                    {
                        main.increaseAmountOfTowns();
                        main.addTown((e.X-borderOffsetWidth)/scaleFactor*1.0, (this.pnlVisualization.Height- borderOffsetHeight - e.Y)/scaleFactor*1.0,0);
                        main.syncWithOldP();
                        currentTime = -1;
                        this.isParameterViewSync = true;
                        return;
                    }
                }
                touchedTown = townIconDetection(xCorrected, yCorrected, null);
                if (touchedTown != null)
                {
                    touchedTownOldX = touchedTown.getX();
                    touchedTownOldY = touchedTown.getY();
                }
            }
            Invalidate();
        }
        private void pnlVisualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (touchedTown != null)
                {
                    main.setIsExample(false);
                    main.updateTown(touchedTown, (e.X - borderOffsetWidth) / scaleFactor * 1.0, (this.pnlVisualization.Height - borderOffsetHeight - e.Y) / scaleFactor * 1.0);
                    pnlVisualization.Invalidate();
                    isMoving = true;
                }
            }
        }
        private void pnlVisualization_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (touchedTown != null)
            {
                if (townSpaceDetection(touchedTown.getX(), touchedTown.getY(), touchedTown))
                {
                    main.updateTown(touchedTown, touchedTownOldX, touchedTownOldY);
                }

                if (!isInBorder(touchedTown.getX(), touchedTown.getY()))
                {
                    main.updateTown(touchedTown, touchedTownOldX, touchedTownOldY);
                }
                if (isMoving)
                {
                    main.syncWithOldP();
                    currentTime = -1;
                    this.isParameterViewSync = true;
                    isMoving = false;
                }
            }
            touchedTown = null;
            pnlVisualization.Invalidate();
        }
        private void pnlVisualization_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isLocked)
            {
                Town tempTown = townIconDetection((e.X - borderOffsetWidth) / scaleFactor * 1.0, (this.pnlVisualization.Height - borderOffsetHeight - e.Y) / scaleFactor * 1.0, null);
                if (tempTown != null)
                {
                    main.decreaseAmountOfTowns();
                    main.deleteTown(tempTown);
                    main.syncWithOldP();
                    currentTime = -1;
                    this.isParameterViewSync = true;
                    pnlVisualization.Invalidate();
                }
            }
        }
        private void render(object sender, PaintEventArgs e)
        {
            Pen Pen;
            Font font = new Font("Arial", 10, FontStyle.Bold);

            //Male Spuren
            if (showTrail)
            {
                if (currentTime == -1)
                {
                    Point p1, p2;
                    double[][] tempTau = main.getResults().Last().getFinalTau();
                    double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                    int startColumn = 1;
                    for (int i = 0; i < tempTau.Length; i++)
                    {
                        for (int j = startColumn; j < tempTau[0].Length; j++)
                        {
                            if (tempTau[i][j] >= MINIMALVISIBLETRAIL)
                            {
                                p1 = new Point();
                                p1.X = borderOffsetWidth + (int)(tempCoords[i][0] * scaleFactor);
                                p1.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[i][1] * scaleFactor);
                                p2 = new Point();
                                p2.X = borderOffsetWidth + (int)(tempCoords[j][0] * scaleFactor);
                                p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[j][1] * scaleFactor);

                                float size;

                                if (tempTau[i][j] > 6)
                                {
                                    size = 6;
                                }
                                else
                                {
                                    size = (float)(tempTau[i][j]);
                                }
                                Pen = new Pen(Color.LightBlue, size);
                                e.Graphics.DrawLine(Pen, p1, p2);
                            }
                        }
                        startColumn++;
                    }
                }
                else
                {
                    Point p1, p2;
                    double[][] tempTau = main.getResults().Last().getTauVonT().ElementAt(currentTime);
                    double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                    int startColumn = 1;
                    for (int i = 0; i < tempTau.Length; i++)
                    {
                        for (int j = startColumn; j < tempTau[0].Length; j++)
                        {
                            if (tempTau[i][j] >= MINIMALVISIBLETRAIL)
                            {
                                p1 = new Point();
                                p1.X = borderOffsetWidth + (int)(tempCoords[i][0] * scaleFactor);
                                p1.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[i][1] * scaleFactor);
                                p2 = new Point();
                                p2.X = borderOffsetWidth + (int)(tempCoords[j][0] * scaleFactor);
                                p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[j][1] * scaleFactor);

                                float size;

                                if (tempTau[i][j] > 6)
                                {
                                    size = 6;
                                }
                                else
                                {
                                    size = (float)(tempTau[i][j]);
                                }
                                Pen = new Pen(Color.LightBlue, size);
                                e.Graphics.DrawLine(Pen, p1, p2);
                            }
                        }
                        startColumn++;
                    }

                }
            }

            //Male Lösung
            if (showSolution)
            {
                Pen = new Pen(Color.LightGreen, 6); //6 statt Stärke wie Pheromonspur:
                if (currentTime == -1)
                {
                    byte[] tempTowns = main.getResults().Last().getStaedteKuerzesterTourOfAll();
                    double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                    Point p1, p2;
                    for (int k = 0; k < tempTowns.Length-1; k++)
                    {
                        p1 = new Point();
                        p1.X = borderOffsetWidth+(int)(tempCoords[(int)(tempTowns[k]-1)][0]*scaleFactor);
                        p1.Y = this.pnlVisualization.Height- borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[k] - 1)][1] * scaleFactor);
                        p2 = new Point();
                        p2.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[k+1] - 1)][0] * scaleFactor);
                        p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[k+1] - 1)][1] * scaleFactor);
                        e.Graphics.DrawLine(Pen, p1, p2);
                    }
                    p1 = new Point();
                    p1.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[tempTowns.Length-1] - 1)][0] * scaleFactor);
                    p1.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[tempTowns.Length-1] - 1)][1] * scaleFactor);
                    p2 = new Point();
                    p2.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[0] - 1)][0] * scaleFactor);
                    p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[0] - 1)][1] * scaleFactor);
                    e.Graphics.DrawLine(Pen, p1, p2);
                }
                else
                {

                    byte[] tempTowns = null;
                    tempTowns = main.getResults().Last().getStaedteKuerzesterTourVonRunde().ElementAt(currentCycle-1);
                    double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                    Point p1, p2;
                    for (int k = 0; k < tempTowns.Length - 1; k++)
                    {
                        p1 = new Point();
                        p1.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[k] - 1)][0] * scaleFactor);
                        p1.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[k] - 1)][1] * scaleFactor);
                        p2 = new Point();
                        p2.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[k + 1] - 1)][0] * scaleFactor);
                        p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[k + 1] - 1)][1] * scaleFactor);
                        e.Graphics.DrawLine(Pen, p1, p2);
                    }
                    p1 = new Point();
                    p1.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[tempTowns.Length - 1] - 1)][0] * scaleFactor);
                    p1.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[tempTowns.Length - 1] - 1)][1] * scaleFactor);
                    p2 = new Point();
                    p2.X = borderOffsetWidth + (int)(tempCoords[(int)(tempTowns[0] - 1)][0] * scaleFactor);
                    p2.Y = this.pnlVisualization.Height - borderOffsetHeight - (int)(tempCoords[(int)(tempTowns[0] - 1)][1] * scaleFactor);
                    e.Graphics.DrawLine(Pen, p1, p2);
                }
            }

            //Male Pheromonwerte
            if (showPheromone)
            {
                int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
                double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                double[][] tempTau = null;
                if (currentTime != -1 && currentTime <= maxT)
                {
                    tempTau = main.getResults().Last().getTauVonT().ElementAt(currentTime);
                }
                else
                {
                    tempTau = main.getResults().Last().getFinalTau();
                }
                int startColumn = 1;
                for (int i = 0; i < tempCoords.Length; i++)
                {
                    for (int j = startColumn; j < tempCoords.Length; j++)
                    {
                        double midX = (((tempCoords[i][0] * scaleFactor + borderOffsetWidth) + (tempCoords[j][0] * scaleFactor + borderOffsetWidth)) / 2);
                        double midY = (((this.pnlVisualization.Height - borderOffsetHeight - (tempCoords[i][1] * scaleFactor)) + (this.pnlVisualization.Height - borderOffsetHeight - (tempCoords[j][1]*scaleFactor))) / 2);
                        e.Graphics.DrawString(Math.Round(tempTau[i][j],0).ToString(), font, new SolidBrush(Color.Blue), new PointF((float)midX, (float)(midY +12)));

                    }
                    startColumn++;
                }
            }

            //Male Distanzwerte
            if (showDistance)
            {
                double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                double[][] tempD = main.getResults().Last().getD();
                int startColumn = 1;
                for (int i = 0; i < tempCoords.Length; i++)
                {
                    for (int j = startColumn; j < tempCoords.Length; j++)
                    {
                        double midX = (((tempCoords[i][0] * scaleFactor + borderOffsetWidth) + (tempCoords[j][0] * scaleFactor + borderOffsetWidth)) / 2);
                        double midY = (((this.pnlVisualization.Height - borderOffsetHeight - (tempCoords[i][1] * scaleFactor)) + (this.pnlVisualization.Height - borderOffsetHeight - (tempCoords[j][1] * scaleFactor))) / 2);
                        e.Graphics.DrawString(Math.Round(tempD[i][j], 0).ToString(), font, new SolidBrush(Color.Black), new PointF((float)midX, (float)(midY)));
                    }
                    startColumn++;
                }
            }

            //Male Städte
            //Punkte
            double[][] tempCoords2 = main.getResults().Last().getStadtkoordinaten();
            for (int i = 0; i < tempCoords2.Length; i++)
            {
                double x = tempCoords2[i][0] * scaleFactor + borderOffsetWidth;
                double y = this.pnlVisualization.Height - borderOffsetHeight - (tempCoords2[i][1] * scaleFactor);
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkOrange), new Rectangle((int)(x - 5), (int)(y - 5), 9, 9));
            }
            //Icons
            if (showTowns)
            {
                for (int i = 0; i < main.towns.Count; i++)
                {
                    Town tempTown = main.towns.ElementAt(i);
                    double x = tempTown.getX() * scaleFactor + borderOffsetWidth;
                    double y = this.pnlVisualization.Height - borderOffsetHeight - (tempTown.getY() * scaleFactor);
                    e.Graphics.DrawImage(tempTown.getLook(), (float)(x - OFFSETX_TOWN), (float)(y - OFFSETY_TOWN));
                }
            }

            //Male Ameisen
            //Punkte
            for (int i = 0; i < main.towns.Count; i++)
            {
                Town tempTown = main.towns.ElementAt(i);
                int count = 0;
                for (int j = 0; j < tempTown.getAntList().Count; j++)
                {
                    //e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(tempTown.getPosition().X - 3 - (count * 3), tempTown.getPosition().Y - 3 + (count * 3), 5, 5));
                    count++;
                }
            }
            //Icons
            if (showAnts)
            {
                if (isWalking)
                {
                    for (int i = 0; i < aniAnts.Count; i++)
                    {
                        Bitmap rotatedSprite = AnimatedAnt.rotateImage(aniAnts.ElementAt(i).getCurrentSprite(), aniAnts.ElementAt(i).getAngle());
                        e.Graphics.DrawImage(rotatedSprite, (float)(aniAnts.ElementAt(i).getX() * scaleFactor + borderOffsetWidth) - OFFSETX_ANT, (float)(this.pnlVisualization.Height - borderOffsetHeight - aniAnts.ElementAt(i).getY() * scaleFactor) - OFFSETY_ANT);
                    }
                }
                else
                {
                    int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
                    int[][] tempTownAnts = null;
                    if (currentTime != -1 && currentTime <= maxT)
                    {
                        tempTownAnts = main.getResults().Last().getStadtAmeisenVonT().ElementAt(currentTime);
                    }
                    else
                    {
                        tempTownAnts = main.getResults().Last().getStadtAmeisenVonT().ElementAt(0);
                    }
                    for (int i = 0; i < tempTownAnts.Length; i++)
                    {
                        for (int j = 0; j < tempTownAnts[0].Length; j++)
                        {
                            if (tempTownAnts[i][j] == 0)
                            {
                                j = tempTownAnts[0].Length;
                            }
                            else
                            {
                                double x = main.getResults().Last().getStadtkoordinaten()[i][0];
                                double y = main.getResults().Last().getStadtkoordinaten()[i][1];
                                e.Graphics.DrawImage(defaultSprite, (float)((x * scaleFactor + borderOffsetWidth) - OFFSETX_ANT), (float)((this.pnlVisualization.Height - borderOffsetHeight - y * scaleFactor) - OFFSETY_ANT));
                            }
                        }
                    }
                }
            }

            //Male Koordinaten
            if (showCoordinates)
            {
                double[][] tempCoords = main.getResults().Last().getStadtkoordinaten();
                double[][] tempD = main.getResults().Last().getD();
                int startColumn = 1;
                for (int i = 0; i < tempCoords.Length; i++)
                {
                    double x = tempCoords[i][0] * scaleFactor + borderOffsetWidth + OFFSETX_TOWN;
                    double y = this.pnlVisualization.Height - borderOffsetHeight - (tempCoords[i][1] * scaleFactor) - OFFSETY_TOWN / 2;
                    string coordinates = "(" + Math.Round(tempCoords[i][0], 1) + ";" + Math.Round(tempCoords[i][1], 1) + ")";
                    e.Graphics.DrawString(coordinates, font, new SolidBrush(Color.Green), new PointF((float)x, (float)(y)));
                    startColumn++;
                }
            }

            //Male Namen
            if (showNames)
            {
                for (int i = 0; i < tempCoords2.Length; i++)
                {
                    //Städtenamen
                    Town tempTown = main.towns.ElementAt(i);
                    double x = tempCoords2[i][0] * scaleFactor + borderOffsetWidth;
                    double y = this.pnlVisualization.Height - borderOffsetHeight - (tempCoords2[i][1] * scaleFactor);
                    e.Graphics.DrawString("" + tempTown.getName(), font, new SolidBrush(Color.DarkOrange), new PointF((float)x + OFFSETX_TOWN, (float)y - (OFFSETY_TOWN-2)));

                    /*
                    for (int j = 0; j < tempTown.getAntList().Count; j++)
                    {
                        //Ameisennamen
                        Ant tempAnt = tempTown.getAntList().ElementAt(j);
                        e.Graphics.DrawString("" + tempAnt.getDisplayName(), font, new SolidBrush(Color.Black), new PointF((float)x + OFFSETX_ANT + j * 24, (float)y + 2));
                    }
                    */
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////GUI V - VIEW ENDE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkValue(TextBox tbx, TrackBar trb, string title, bool isInt)
        {
            double amount = 0;
            int trackbarTranslation = 1;
            if (!isInt)
            {
                trackbarTranslation = 100;
            }

            try
            {
                if (tbx.Text != "")
                {
                    amount = Convert.ToDouble(tbx.Text);

                    if (amount < trb.Minimum / trackbarTranslation)
                    {
                        MessageBox.Show("Der eingegebene Wert ist zu klein!",
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        tbx.Text = Convert.ToString(trb.Minimum / trackbarTranslation);
                        trb.Value = trb.Minimum;
                    }
                    else if (amount <= trb.Maximum)
                    {
                        trb.Value = Convert.ToInt32(amount * trackbarTranslation);
                    }
                    else
                    {
                        MessageBox.Show("Der eingegebene Wert ist zu groß!",
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tbx.Text = Convert.ToString(trb.Maximum / trackbarTranslation);
                        trb.Value = trb.Maximum;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ungültige Eingabe!",
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tbx.Text = "";
            }
        }
        public bool isInBorder(double x, double y)
        {
            if (x >= 0 && x <= 100 && y >= 0 && y <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool townSpaceDetection(double x, double y, Town t)
        {
            for (int i = 0; i < main.towns.Count; i++)
            {
                if (x > main.towns.ElementAt(i).getX() - OFFSETX_TOWN/scaleFactor && x < main.towns.ElementAt(i).getX() + OFFSETX_TOWN / scaleFactor)
                {
                    if (y > main.towns.ElementAt(i).getY() - OFFSETY_TOWN / scaleFactor && y < main.towns.ElementAt(i).getY() + OFFSETY_TOWN / scaleFactor)
                    {
                        if (!main.towns.ElementAt(i).Equals(t))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private Town townIconDetection(double x, double y, Town t)
        {
            for (int i = 0; i < main.towns.Count; i++)
            {
                if (x > main.towns.ElementAt(i).getX() - OFFSETX_TOWN / scaleFactor/2 && x < main.towns.ElementAt(i).getX() + OFFSETX_TOWN / scaleFactor/2)
                {
                    if (y > main.towns.ElementAt(i).getY() - OFFSETY_TOWN / scaleFactor/2 && y < main.towns.ElementAt(i).getY() + OFFSETY_TOWN / scaleFactor/2)
                    {
                        if (!main.towns.ElementAt(i).Equals(t))
                        {
                            return main.towns.ElementAt(i);
                        }
                    }
                }
            }
            return null;
        }
        public void updateInformationPanel()
        {
            //1. pnlShowTime
            if (currentTime == -1)
            {
                lblShowTime.Text = "Zeitpunkt: Index von t: " + main.getResults().Last().getTimeEnd();
            }
            else
            {
                lblShowTime.Text = "Zeitpunkt: Index von t: " + currentTime;
            }

            //2. pnlRound
            if (currentTime == -1)
            {
                int round = main.getResults().Last().getTimeEnd() / main.getResults().Last().getStadtkoordinaten().Length;
                lblRound.Text = "Zyklus: " +( (round + 1)+ " ("+round+" abgeschlossen)");
            }
            else
            {
                lblRound.Text = "Zyklus: " + currentCycle;
            }

            //3. pnlIterationInRound
            int rest = 0;
            if (currentTime == -1)
            {
                lblIterationInRound.Text = "Iteration des Zyklus: " + 0;
            }
            else
            {
                rest = currentTime % main.getResults().Last().getStadtkoordinaten().Length;
                lblIterationInRound.Text = "Iteration des Zyklus: " + (rest+1);
            }
            if (lbxAnts.SelectedIndex == 0)
            {
                lbxAnts.SelectedItem = 0;
                lblAntName.Visible = false;
                lblCurrentPlace.Visible = false;
                lblCoordinates.Visible = false;
                lblDestination.Visible = false;
                lblCurrentPathLength.Visible = false;
                lblPossibilities.Visible = false;
                lblCoordinatesDestiny.Visible = false;
                lblTabu.Visible = false;
                pnlShortestPath.Controls.Clear();
                pnlAntPossibilities.Controls.Clear();
                pnlAntTabuList.Controls.Clear();

            }
            else if (lbxAnts.SelectedIndex == 1)
            {
                lblAntName.Visible = false;
                lblCurrentPlace.Visible = false;
                lblCoordinates.Visible = false;
                lblDestination.Visible = false;
                lblCurrentPathLength.Visible = false;
                lblPossibilities.Visible = false;
                lblCoordinatesDestiny.Visible = false;
                lblTabu.Visible = false;
                //4. pnlShortestPath
                pnlShortestPath.Controls.Clear();
                pnlAntPossibilities.Controls.Clear();
                pnlAntTabuList.Controls.Clear();
                Label labelshortestPath = new Label();
                byte[] shortestPath = null;
                if (currentTime == -1)
                {
                    shortestPath = main.getResults().Last().getStaedteKuerzesterTourOfAll();
                }
                else
                {
                    shortestPath = main.getResults().Last().getStaedteKuerzesterTourVonRunde().ElementAt(currentCycle - 1);
                }
                int count = 0;
                string path = "";
                LinkedList<string> pathList = new LinkedList<string>();

                for (int k = 0; k < shortestPath.Length; k++)
                {
                    if (k == shortestPath.Length - 1)
                    {
                        path += "S" + shortestPath[k];

                    }
                    else
                    {
                        path += "S" + shortestPath[k] + " - ";
                    }
                    count++;
                    if (count == 5)
                    {
                        pathList.AddLast(path);
                        path = "";
                        count = 0;
                    }
                }

                if (count != 5)
                {
                    pathList.AddLast(path);
                    path = "";
                    count = 0;
                }
                for (int i = pathList.Count - 1; i >= 0; i--)
                {
                    labelshortestPath = new Label();
                    labelshortestPath.Text = pathList.ElementAt(i);
                    //labelshortestPath.BringToFront();
                    labelshortestPath.Dock = DockStyle.Top;
                    pnlShortestPath.Controls.Add(labelshortestPath);
                }
                labelshortestPath = new Label();
                //if (main.getShortestPathLength() < 0)
                //{
                //    labelshortestPath.Text = "kürzester Pfad: -";
                //}
                //else
                //{
                //    labelshortestPath.Text = "kürzester Pfad: " + Math.Round((main.getShortestPathLength()), 2).ToString();
                //}
                if (currentTime == -1)
                {
                    labelshortestPath.Text = "kürzester Pfad: " + Math.Round(main.getResults().Last().getKuerzesteTourOfAll(), 2).ToString();
                }
                else
                {
                    labelshortestPath.Text = "kürzester Pfad: " + Math.Round(main.getResults().Last().getKuerzesteTourVonRunde()[currentCycle - 1], 2).ToString();
                }
                labelshortestPath.BringToFront();
                labelshortestPath.Dock = DockStyle.Top;
                pnlShortestPath.Controls.Add(labelshortestPath);

                Label newLabel = new Label();
                newLabel.Text = "-------------------------------------------------------------------";
                newLabel.BringToFront();
                newLabel.Dock = DockStyle.Top;
                pnlShortestPath.Controls.Add(newLabel);

            }
            else
            {
                pnlAntTabuList.Controls.Clear();
                pnlAntPossibilities.Controls.Clear();
                pnlShortestPath.Controls.Clear();
                lblTabu.Visible = true;
                this.lblPossibilities.Visible = true;
                lblCurrentPathLength.Visible = true;
                lblCoordinatesDestiny.Visible = true;
                lblDestination.Visible = true;
                lblCoordinates.Visible = true;
                lblCurrentPlace.Visible = true;
                lblAntName.Visible = true;
                //suche aktuell ausgewählte Ameise in Städten
                Ant tempAnt = null;
                for (int i = 0; i < main.towns.Count; i++)
                {
                    for (int j = 0; j < main.towns.ElementAt(i).getAntList().Count; j++)
                    {
                        if (main.towns.ElementAt(i).getAntList().ElementAt(j).displayName == lbxAnts.SelectedItem.ToString())
                        {
                            tempAnt = main.towns.ElementAt(i).getAntList().ElementAt(j);
                        }
                    }
                }

                //1. Name
                lblAntName.Text = "ausgewählte Ameise: " + lbxAnts.SelectedItem.ToString();
                //2. Platz
                int antNumber = lbxAnts.SelectedIndex - 1;
                int town = 0;
                int[][] tempTownAnts = null;
                if (currentTime == -1)
                {
                    tempTownAnts = main.getResults().Last().getStadtAmeisenVonT()[0];
                }
                else
                {
                    tempTownAnts = main.getResults().Last().getStadtAmeisenVonT()[currentTime];
                }
                for (int i = 0; i < tempTownAnts.Length; i++)
                {
                    for (int j = 0; j < tempTownAnts[0].Length; j++)
                    {
                        if (tempTownAnts[i][j] == 0)
                        {
                            j = tempTownAnts[0].Length;
                        }
                        else if (tempTownAnts[i][j] == antNumber)
                        {
                            town = i + 1;
                            i = tempTownAnts.Length;
                            j = tempTownAnts[0].Length;
                        }
                    }
                }
                lblCurrentPlace.Text = "Aktueller Ort: S" + town;
                //3. Koordinaten
                double x = main.getResults().Last().getStadtkoordinaten()[town - 1][0];
                double y = main.getResults().Last().getStadtkoordinaten()[town - 1][1];
                lblCoordinates.Text = "Koordinaten: x = " + Math.Round(x, 1).ToString() + "; y = " + Math.Round(y, 1).ToString();
                //4. Ziel
                tempTownAnts = null;
                int nextTown = 0;
                int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
                if (currentTime == -1)
                {
                    lblDestination.Text = "Ziel: Suche abgeschlossen";
                    //Koordinaten
                    lblCoordinatesDestiny.Text = "Koordinaten: x = - ; y = - ";
                }
                else if (currentTime == maxT)
                {
                    lblDestination.Text = "Ziel: nicht gespeichert";
                    //Koordinaten
                    lblCoordinatesDestiny.Text = "Koordinaten: x = - ; y = - ";
                }
                else
                {
                    tempTownAnts = main.getResults().Last().getStadtAmeisenVonT()[currentTime + 1];
                    for (int i = 0; i < tempTownAnts.Length; i++)
                    {
                        for (int j = 0; j < tempTownAnts[0].Length; j++)
                        {
                            if (tempTownAnts[i][j] == 0)
                            {
                                j = tempTownAnts[0].Length;
                            }
                            else if (tempTownAnts[i][j] == antNumber)
                            {
                                nextTown = i + 1;
                                i = tempTownAnts.Length;
                                j = tempTownAnts[0].Length;
                            }
                        }
                    }
                    lblDestination.Text = "Ziel: S" + nextTown;
                    //Koordinaten
                    x = main.getResults().Last().getStadtkoordinaten()[nextTown - 1][0];
                    y = main.getResults().Last().getStadtkoordinaten()[nextTown - 1][1];
                    lblCoordinatesDestiny.Text = "Koordinaten: x = " + Math.Round(x, 1).ToString() + "; y = " + Math.Round(y, 1).ToString();
                }
                //5. Pfadlänge
                double aktuellerPfad = 0;
                double[][] tempD = main.getResults().Last().getD();
                byte[] aktuelleTabuliste = null;
                if (currentTime == -1)
                {
                    aktuelleTabuliste = main.getResults().Last().getFinalTabu()[antNumber - 1];
                }
                else
                {
                    aktuelleTabuliste = main.getResults().Last().getAmeisenTabulistenVonT()[currentTime][antNumber - 1];
                }
                for (byte i = 0; i < (aktuelleTabuliste.Length - 1); i++)
                {
                    if (aktuelleTabuliste[i] != 0 && aktuelleTabuliste[i + 1] != 0)
                    {
                        aktuellerPfad += tempD[aktuelleTabuliste[i] - 1][aktuelleTabuliste[i + 1] - 1];
                    }
                    if (i == aktuelleTabuliste.Length - 2)
                    {
                        if (aktuelleTabuliste[aktuelleTabuliste.Length - 1] != 0)
                        {
                            aktuellerPfad += tempD[aktuelleTabuliste[aktuelleTabuliste.Length - 1] - 1][aktuelleTabuliste[0] - 1];
                        }
                    }
                }


                lblCurrentPathLength.Text = "Aktuelle Tourlänge: " + Math.Round(aktuellerPfad, 2).ToString();
                //6. pnlAntPossibilities
                //leere label als abstandshalter
                pnlAntPossibilities.Controls.Clear();
                Label newLabel = new Label();
                newLabel.Text = "-------------------------------------------------------------------";
                newLabel.BringToFront();
                newLabel.Dock = DockStyle.Top;
                pnlAntPossibilities.Controls.Add(newLabel);


                int countTabu = 0;
                for (int i = 0; i < aktuelleTabuliste.Length; i++)
                {
                    if (aktuelleTabuliste[i] != 0)
                    {
                        countTabu++;
                    }
                }
                double[][] tau = null;
                if (currentTime == -1)
                {
                    tau = main.getResults().Last().getFinalTau();
                }
                else
                {
                    tau = main.getResults().Last().getTauVonT().ElementAt(currentTime);
                }
                double[][] eta = main.getResults().Last().getEta();
                double alpha = main.getResults().Last().getAlpha();
                double beta = main.getResults().Last().getBeta();
                byte[] bereisbareStaedte = new byte[aktuelleTabuliste.Length - countTabu];
                double[] Wahrscheinlichkeiten = new double[aktuelleTabuliste.Length - countTabu];
                double SummeAllerWahrscheinlichkeiten = 0;
                int freieStelle = 0;
                //Teil-Wahrscheinlichkeiten und ihre Summe sammeln
                for (byte u = 1; u <= main.getResults().Last().getStadtkoordinaten().Length; u++)
                {
                    bool moeglich = true;
                    for (int w = 0; w < aktuelleTabuliste.Length; w++)
                    {
                        if (aktuelleTabuliste[w] == u)
                        {
                            moeglich = false;
                        }
                    }
                    if (moeglich)
                    {
                        bereisbareStaedte[freieStelle] = u;
                        Wahrscheinlichkeiten[freieStelle] = (Math.Pow(tau[town - 1][u - 1], alpha) * Math.Pow(eta[town - 1][u - 1], beta));
                        // Untere Grenze für Wahrscheinlichkeiten auf 1 Milliardstel
                        if (Wahrscheinlichkeiten[freieStelle] < 0.000_000_001)
                        {
                            Wahrscheinlichkeiten[freieStelle] = 0.000_000_001;
                        }
                        SummeAllerWahrscheinlichkeiten += Wahrscheinlichkeiten[freieStelle];
                        freieStelle++;
                    }
                }
                //Summe aller Wahrscheinlichkeiten verrechnen
                for (byte u = 0; u < Wahrscheinlichkeiten.Length; u++)
                {
                    Wahrscheinlichkeiten[u] /= SummeAllerWahrscheinlichkeiten;

                }

                //Label newLabel = new Label();
                /*
                LinkedList<Town> possibleTowns = main.getTowns();
                if (rest == 0)
                {
                    newLabel = new Label();
                    newLabel.Text = "-";
                    newLabel.BringToFront();
                    newLabel.Dock = DockStyle.Top;
                    pnlAntPossibilities.Controls.Add(newLabel);
                }
                else
                {
                */
                //4. pnlShortestPath
                Label lblPossibilities = new Label();
                int count = 0;
                string path = "";
                LinkedList<string> pathList = new LinkedList<string>();

                for (int i = 0; i < Wahrscheinlichkeiten.Length; i++)
                {
                    if (i == Wahrscheinlichkeiten.Length - 1)
                    {
                        path += "S" + (i + 1)
                        + "= " + Math.Round(Wahrscheinlichkeiten.ElementAt(i) * 100.0, 0).ToString() + "%";

                    }
                    else
                    {
                        path += "S" + (i + 1)
                        + "= " + Math.Round(Wahrscheinlichkeiten.ElementAt(i) * 100.0, 0).ToString() + "%, ";
                    }
                    count++;
                    if (count == 3)
                    {
                        pathList.AddLast(path);
                        path = "";
                        count = 0;
                    }
                }

                if (count != 3)
                {
                    pathList.AddLast(path);
                    path = "";
                    count = 0;
                }
                for (int i = pathList.Count - 1; i >= 0; i--)
                {
                    lblPossibilities = new Label();
                    lblPossibilities.Text = pathList.ElementAt(i);
                    //labelshortestPath.BringToFront();
                    lblPossibilities.Dock = DockStyle.Top;
                    pnlAntPossibilities.Controls.Add(lblPossibilities);
                }

                if (Wahrscheinlichkeiten.Length == 0)
                {
                    newLabel = new Label();
                    newLabel.Text = "-";
                    newLabel.BringToFront();
                    newLabel.Dock = DockStyle.Top;
                    pnlAntPossibilities.Controls.Add(newLabel);
                }



                newLabel = new Label();
                newLabel.Text = "Wahrscheinlichkeiten";
                newLabel.BringToFront();
                newLabel.Dock = DockStyle.Top;
                pnlAntPossibilities.Controls.Add(newLabel);
                newLabel = new Label();
                newLabel.Text = "-------------------------------------------------------------------";
                newLabel.BringToFront();
                newLabel.Dock = DockStyle.Top;
                pnlAntPossibilities.Controls.Add(newLabel);

                //7. pnlAntTabuList
                pnlAntTabuList.Controls.Clear();
                Label labelshortestPath = new Label();
                count = 0;
                path = "";
                pathList = new LinkedList<string>();

                for (int k = 0; k < aktuelleTabuliste.Length; k++)
                {
                    if (aktuelleTabuliste[k] != 0)
                    {
                        if(k< aktuelleTabuliste.Length - 1)
                        {
                            if (aktuelleTabuliste[k + 1] == 0)
                            {
                                path += "S" + aktuelleTabuliste[k];

                            }
                            else
                            {
                                path += "S" + aktuelleTabuliste[k] + ", ";
                            }
                        }
                        if(k== aktuelleTabuliste.Length - 1)
                        {
                            path += "S" + aktuelleTabuliste[k];
                        }
                    }

                    count++;
                    if (count == 5)
                    {
                        pathList.AddLast(path);
                        path = "";
                        count = 0;
                    }
                }

                if (count != 5)
                {
                    pathList.AddLast(path);
                    path = "";
                    count = 0;
                }
                for (int i = pathList.Count - 1; i >= 0; i--)
                {
                    Label lblTabuList = new Label();
                    lblTabuList.Text = pathList.ElementAt(i);
                    //labelshortestPath.BringToFront();
                    lblTabuList.Dock = DockStyle.Top;
                    pnlAntTabuList.Controls.Add(lblTabuList);
                }
                newLabel = new Label();
                newLabel.Text = "Tabuliste";
                newLabel.BringToFront();
                newLabel.Dock = DockStyle.Top;
                pnlAntTabuList.Controls.Add(newLabel);
            }
        }

        private void pnlVisualization_SizeChanged(object sender, EventArgs e)
        {
            if (this.pnlVisualization.Height < this.pnlVisualization.Width)
            {
                screenSize = this.pnlVisualization.Height - (BORDERMINIMAL * 2);
                borderOffsetHeight = BORDERMINIMAL;
                borderOffsetWidth = (int)((this.pnlVisualization.Width - screenSize) / 2.0);
                scaleFactor = screenSize / 100;
            }
            else
            {
                screenSize = this.pnlVisualization.Width - (BORDERMINIMAL * 2);
                borderOffsetHeight = (int)((this.pnlVisualization.Height - screenSize) / 2.0);
                borderOffsetWidth = BORDERMINIMAL;
                scaleFactor = screenSize / 100;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                formState.Maximize(this);
                isfullscreen = true;
            }
            this.pnlVisualization.Invalidate();
            if (isfullscreen)
            {
                MessageBox.Show("Esc drücken zum Verlassen des Fullscreen.");
            }
        }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isfullscreen)
            {
                formState.Restore(this);
                isfullscreen = false;
            }
        }
        private void update(object sender, EventArgs e)
        {
            double tempSpeed = Convert.ToDouble(tbxSpeed.Text) * 10;
            //Ameisenschrittweite berechnen
            if (isNewWalk)
            {
                double angle = 0;
                for (int i = 0; i < aniAnts.Count; i++)
                {
                    double xDiff = (aniAnts.ElementAt(i).getXD() - aniAnts.ElementAt(i).getX());
                    double yDiff = (aniAnts.ElementAt(i).getYD() - aniAnts.ElementAt(i).getY());
                    double steigung = yDiff / xDiff;
                    double atan = (Math.Atan2(xDiff, yDiff) * 180.0 / Math.PI);
                    aniAnts.ElementAt(i).setXStep(xDiff * 1.0 / ROADSTEPS * 1.0);
                    aniAnts.ElementAt(i).setYStep(yDiff * 1.0 / ROADSTEPS * 1.0);

                    if (xDiff == 0)
                    {
                        if (aniAnts.ElementAt(i).getYD() < aniAnts.ElementAt(i).getY())
                        {
                            //gerade nach unten
                            angle = 180.0;
                        }
                        else
                        {
                            //gerade nach oben
                            angle = 0.0;
                        }
                    }
                    else if (yDiff == 0)
                    {
                        if (aniAnts.ElementAt(i).getXD() < aniAnts.ElementAt(i).getX())
                        {
                            //gerade nach links
                            angle = -90.0;
                        }
                        else
                        {
                            //Fall1
                            angle = 90.0;
                        }
                    }
                    else if (aniAnts.ElementAt(i).getYD() > aniAnts.ElementAt(i).getY())
                    {
                        if (aniAnts.ElementAt(i).getXD() > aniAnts.ElementAt(i).getX())
                        {
                            //1. Quadrant
                            if (steigung > 1)
                            {
                                //Fall3
                                //N-NO
                                angle = atan;
                            }
                            else
                            {
                                //Fall 8
                                //O-NO
                                angle = atan;
                            }
                        }
                        else
                        {
                            //xD<x
                            //x=0 hier
                            //2. Quadrant
                            if (steigung < -1)
                            {
                                //Fall9
                                //N-NW
                                angle = atan;
                            }
                            else
                            {
                                //Fall6
                                //W-NW
                                angle = atan;

                            }
                        }
                    }
                    else
                    {
                        //yD<y
                        //y=0 hier
                        if (aniAnts.ElementAt(i).getXD() < aniAnts.ElementAt(i).getX())
                        {
                            //3. Quadrant
                            if (steigung > 1)
                            {
                                //Fall 2:
                                //s-sw
                                angle = atan;
                            }
                            else
                            {
                                //Fall 7:
                                //W-SW
                                angle = atan;
                            }
                        }
                        else
                        {
                            //xD>x
                            //x=0 hier
                            //4. Quadrant
                            if (steigung < -1)
                            {
                                //Fall4:
                                //S-SO
                                angle = atan;
                            }
                            else
                            {
                                //Fall5:
                                //O-SO
                                angle = atan;

                            }
                        }
                    }
                    aniAnts.ElementAt(i).setAngle((float)(angle));
                }
                isNewWalk = false;
            }
            //eine Iteration weiter nach Erreichen des Ziels
            if (currentStep >= ROADSTEPS)
            {
                currentStep = 0;
                for (int i = 0; i < aniAnts.Count; i++)
                {
                    aniAnts.ElementAt(i).setX(aniAnts.ElementAt(i).getXD());
                    aniAnts.ElementAt(i).setY(aniAnts.ElementAt(i).getYD());
                }
                //nächste Iteration
                int maxT = main.getResults().Last().getStadtAmeisenVonT().Count - 1;
                if (currentTime == maxT-1)
                {
                    currentTime = -1;
                    currentCycle = -1;
                    isWalking = false;
                    isNewWalk = true;
                    timer.Stop();
                }
                else
                {
                    currentTime++;
                    currentCycle = (currentTime / main.getResults().Last().getStadtkoordinaten().Length)+1;
                    int[][] tempTownAnts = main.getResults().Last().getStadtAmeisenVonT().ElementAt(currentTime+1);
                    //lade Ziele
                    for (int h = 0; h < aniAnts.Count; h++)
                    {
                        for (int i = 0; i < tempTownAnts.Length; i++)
                        {
                            for (int j = 0; j < tempTownAnts[0].Length; j++)
                            {
                                if (tempTownAnts[i][j] == 0)
                                {
                                    j = tempTownAnts[0].Length;
                                }
                                else if (tempTownAnts[i][j] == aniAnts.ElementAt(h).getNumber())
                                {
                                    aniAnts.ElementAt(h).setXD(main.getResults().Last().getStadtkoordinaten()[i][0]);
                                    aniAnts.ElementAt(h).setYD(main.getResults().Last().getStadtkoordinaten()[i][1]);

                                    j = tempTownAnts[0].Length;
                                    i = tempTownAnts.Length;
                                }
                            }
                        }
                    }
                }
                isNewWalk = true;
                updateInformationPanel();
            }
            int newLook = aniAnts.ElementAt(0).getCurrentLook() + (int)(tempSpeed*1.5);
            for (int i = 0; i < aniAnts.Count; i++)
            {
                aniAnts.ElementAt(i).setX(aniAnts.ElementAt(i).getX() + (aniAnts.ElementAt(i).getXStep() * 1.0 * tempSpeed));
                aniAnts.ElementAt(i).setY(aniAnts.ElementAt(i).getY() + (aniAnts.ElementAt(i).getYStep() * 1.0 * tempSpeed));

                if (newLook >= 62)
                {
                    aniAnts.ElementAt(i).setCurrentLook(0);
                }
                else
                {
                    aniAnts.ElementAt(i).setCurrentLook(newLook);

                }
            }
            currentStep += tempSpeed;
            this.pnlVisualization.Invalidate();
        }
        public void stopAnimation()
        {
            timer.Stop();
            isNewWalk = true;
            isWalking = false;
            currentStep = 0;
        }
        //Getter
        public Panel getPanelVisualisation()
        {
            return this.pnlVisualization;
        }
        public ListBox getListBoxAnts()
        {
            return this.lbxAnts;
        }
        public Panel getPanelShortestPath()
        {
            return this.pnlShortestPath;
        }
        public ComboBox getComboBoxSpreadTowns()
        {
            return this.cbxSpreadTowns;
        }
        public ComboBox getComboBoxSpreadAnts()
        {
            return this.cbxSpreadAnts;
        }
        public bool getIsWalking()
        {
            return this.isWalking;
        }
        public Parameter getParameter()
        {
            return this.parameter;
        }
        //Setter
        public void setCheckBoxExample(bool isExample)
        {
            this.chbExample.Checked = isExample;
        }
        public void setComboBoxArt(Parameter.typeOfAlgorithm type)
        {
            if (type == Parameter.typeOfAlgorithm.Density)
            {
                this.cbxArt.SelectedIndex = cbxArt.Items.IndexOf(ANTDENSITY);
            }
            else if (type == Parameter.typeOfAlgorithm.Quantity)
            {
                this.cbxArt.SelectedIndex = cbxArt.Items.IndexOf(ANTQUANTITY);
            }
            else if (type == Parameter.typeOfAlgorithm.Cycle)
            {
                this.cbxArt.SelectedIndex = cbxArt.Items.IndexOf(ANTCYCLE);
            }
            else
            {
                MessageBox.Show("Unbekannter Algorithmus!");
            }
        }
        public void setTextBoxAmountTowns(int amount)
        {
            this.tbxAmountTowns.Text = amount.ToString();
        }
        public void setComboBoxSpreadTowns(Parameter.typeOfSpreadTowns type)
        {
            if (type == Parameter.typeOfSpreadTowns.Random)
            {
                this.cbxSpreadTowns.SelectedIndex = cbxSpreadTowns.Items.IndexOf(SPREADTOWNSRANDOM);
            }
            else if (type == Parameter.typeOfSpreadTowns.Custom)
            {
                this.cbxSpreadTowns.SelectedIndex = cbxSpreadTowns.Items.IndexOf(SPREADTOWNSCUSTOM);
            }
            else if (type == Parameter.typeOfSpreadTowns.Undefined)
            {
                this.cbxSpreadTowns.SelectedIndex = cbxSpreadTowns.Items.IndexOf(SPREADTOWNSUNDEFINED);
            }
            else
            {
                MessageBox.Show("Unbekannte Verteilung!");
            }
        }
        public void setTextBoxAmountAnts(int amount)
        {
            this.tbxAmountAnts.Text = amount.ToString();
        }
        public void setComboBoxSpreadAnts(Parameter.typeOfSpreadAnts type)
        {
            if (type == Parameter.typeOfSpreadAnts.Random)
            {
                this.cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSRANDOM);
            }
            else if (type == Parameter.typeOfSpreadAnts.Custom)
            {
                this.cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSCUSTOM);
            }
            else if (type == Parameter.typeOfSpreadAnts.Even)
            {
                this.cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(SPREADANTSEVEN);
            }
            else
            {
                MessageBox.Show("Unbekannte Verteilung!");
            }
        }
        public void setTextBoxStrength(double amount)
        {
            this.tbxStrength.Text = amount.ToString();
        }
        public void setTextBoxStartPheromone(double amount)
        {
            this.tbxStartPheromone.Text = amount.ToString();
        }
        public void setTextBoxEvaporation(double amount)
        {
            this.tbxEvaporation.Text = amount.ToString();
        }
        public void setTextBoxWeightPheromone(double amount)
        {
            this.tbxWeightPheromone.Text = amount.ToString();
        }
        public void setTextBoxWeightDistance(double amount)
        {
            this.tbxWeightDistance.Text = amount.ToString();
        }
        public void setTextBoxCycles(int amount)
        {
            this.tbxCycles.Text = amount.ToString();
        }
        public void setShowSolution(bool show)
        {
            showSolution = show;
            chbSolution.Checked = show;
        }
        public void setIsWalking(bool isWalking)
        {
            this.isWalking = isWalking;
        }
        public void setBtnPlay(bool btnPlay)
        {
            this.btnPlay.Enabled = btnPlay;

        }
        public void setBtnPause(bool btnPause)
        {
            this.btnPause.Enabled = btnPause;

        }
        public void setBtnNextIt(bool btnNextIt)
        {
            this.btnNextIt.Enabled = btnNextIt;

        }
        public void setBtnNextRound(bool btnNextRound)
        {

            this.btnNextRound.Enabled = btnNextRound;
        }
        public void setBtnToTheEnd(bool btnToTheEnd)
        {
            this.btnToTheEnd.Enabled = btnToTheEnd;

        }
        public void setBtnPrevRound(bool btnPrevRound)
        {

            this.btnPrevRound.Enabled = btnPrevRound;
        }
        public void setBtnPrevIt(bool btnPrevIt)
        {

            this.btnPrevIt.Enabled = btnPrevIt;
        }

    }
    /// <span class="code-SummaryComment"><summary></span>
    /// Selected Win API Function Calls
    /// <span class="code-SummaryComment"></summary></span>

    public class WinApi
    {
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0×0040

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }
    }

    /// <span class="code-SummaryComment"><summary></span>
    /// Class used to preserve / restore / maximize state of the form
    /// <span class="code-SummaryComment"></summary></span>
    public class FormState
    {
        private FormWindowState winState;
        private FormBorderStyle brdStyle;
        private bool topMost;
        private Rectangle bounds;

        private bool IsMaximized = false;

        public void Maximize(Form targetForm)
        {
            if (!IsMaximized)
            {
                IsMaximized = true;
                Save(targetForm);
                targetForm.WindowState = FormWindowState.Maximized;
                targetForm.FormBorderStyle = FormBorderStyle.None;
                targetForm.TopMost = true;
                WinApi.SetWinFullScreen(targetForm.Handle);
            }
        }

        public void Save(Form targetForm)
        {
            winState = targetForm.WindowState;
            brdStyle = targetForm.FormBorderStyle;
            topMost = targetForm.TopMost;
            bounds = targetForm.Bounds;
        }

        public void Restore(Form targetForm)
        {
            targetForm.WindowState = winState;
            targetForm.FormBorderStyle = brdStyle;
            targetForm.TopMost = topMost;
            targetForm.Bounds = bounds;
            IsMaximized = false;
        }
    }
}
