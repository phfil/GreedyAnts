using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GreedyAnts
{
    public partial class GUIAntAlgorithm : Form
    {
        public GUIAntAlgorithm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //check Example
            checkExample.Checked = true;
            // Art
            String antDensity = "Ant density algorithm";
            cbxArt.Items.Add(antDensity);
            String antQuantity = "Ant quantity algorithm";
            cbxArt.Items.Add(antQuantity);
            String antCycle = "Ant cycle algorithm";
            cbxArt.Items.Add(antCycle);
            cbxArt.SelectedIndex = cbxArt.Items.IndexOf(antDensity);

            // Raum
            String dim2euklid = "Zweidimensionaler Euklidischer Raum";
            cbxRaum.Items.Add(dim2euklid);
            cbxRaum.SelectedIndex = cbxRaum.Items.IndexOf(dim2euklid);

            // Zeit
            String timeStep = "Fortlauf nach jeder Iteration";
            cbxZeit.Items.Add(timeStep);
            cbxZeit.SelectedIndex = cbxZeit.Items.IndexOf(timeStep);

            // Städte
            trbAmountTowns.Value = 5;

            String spreadTownsRandom = "Zufällig";
            cbxSpreadTowns.Items.Add(spreadTownsRandom);
            cbxSpreadTowns.SelectedIndex = cbxSpreadTowns.Items.IndexOf(spreadTownsRandom);

            String distanceEuclid = "Euklidisch";
            cbxDistance.Items.Add(distanceEuclid);
            cbxDistance.SelectedIndex = cbxDistance.Items.IndexOf(distanceEuclid);

            String visibilityReciproce = "Kehrwert des Abstandes";
            cbxVisibility.Items.Add(visibilityReciproce);
            cbxVisibility.SelectedIndex = cbxVisibility.Items.IndexOf(visibilityReciproce);

            // Ameisen
            trbAmountAnts.Value = 3;

            //String spreadAntsEqual = "Gleichverteilt";
            //cbxSpreadTowns.Items.Add(spreadAntsEqual);
            String spreadAntsRandom = "Zufällig";
            cbxSpreadAnts.Items.Add(spreadAntsRandom);
            cbxSpreadAnts.SelectedIndex = cbxSpreadAnts.Items.IndexOf(spreadAntsRandom);

            String tabulistStandard = "Eine Tabuliste pro Ameise";
            cbxTabulist.Items.Add(tabulistStandard);
            cbxTabulist.SelectedIndex = cbxTabulist.Items.IndexOf(tabulistStandard);

            // Pheromone
            trbStrength.Value = 100;
            trbStartPheromone.Value = 100;
            trbEvaporation.Value = 90;

            // Gewichtung
            trbWeightDistance.Value = 100;
            trbWeightPheromone.Value = 100;

            // Zyklen
            trbCycles.Value = 2;

            tbxCycles.Select();
        }

        private void trbAmountTowns_ValueChanged(object sender, EventArgs e)
        {
            tbxAmountTowns.Text = Convert.ToString(trbAmountTowns.Value);
        }

        private void trbAmountAnts_ValueChanged(object sender, EventArgs e)
        {
            tbxAmountAnts.Text = Convert.ToString(trbAmountAnts.Value);
        }

        private void trbStrength_ValueChanged(object sender, EventArgs e)
        {
            double strengthValue = trbStrength.Value / 100.00;
            tbxStrength.Text = Convert.ToString(strengthValue);
        }

        private void trbStartPheromone_ValueChanged(object sender, EventArgs e)
        {
            double startPheromonValue = trbStartPheromone.Value / 100.00;
            tbxStartPheromone.Text = Convert.ToString(startPheromonValue);
        }

        private void trbEvaporation_ValueChanged(object sender, EventArgs e)
        {
            double evaporationValue = trbEvaporation.Value / 100.00;
            tbxEvaporation.Text = Convert.ToString(evaporationValue);
        }

        private void trbWeightDistance_ValueChanged(object sender, EventArgs e)
        {
            double weightDistanceValue = trbWeightDistance.Value / 100.00;
            tbxWeightDistance.Text = Convert.ToString(weightDistanceValue);
        }

        private void trbWeightPheromone_ValueChanged(object sender, EventArgs e)
        {
            double weightPheromoneValue = trbWeightPheromone.Value / 100.00;
            tbxWeightPheromone.Text = Convert.ToString(weightPheromoneValue);
        }

        private void trbCycles_ValueChanged(object sender, EventArgs e)
        {
             tbxCycles.Text = Convert.ToString(trbCycles.Value);
        }

        private void checkValue(System.Windows.Forms.TextBox tbx, System.Windows.Forms.TrackBar trb, string title, bool isInt)
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

                    if (amount < trb.Minimum/trackbarTranslation)
                    {
                        MessageBox.Show("Der eingegebene Wert ist zu klein!",
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        
                        tbx.Text = Convert.ToString(trb.Minimum/trackbarTranslation);
                        trb.Value = trb.Minimum;
                    }
                    else if (amount <= trb.Maximum)
                    {
                        trb.Value = Convert.ToInt32(amount*trackbarTranslation);
                    }
                    else
                    {
                        MessageBox.Show("Der eingegebene Wert ist zu groß!",
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tbx.Text = Convert.ToString(trb.Maximum/trackbarTranslation);
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

        private void tbxAmountTowns_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxAmountTowns, trbAmountTowns, "Anzahl an Städten", true);
        }

        private void tbxAmountAnts_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxAmountAnts, trbAmountAnts, "Anzahl an Ameisen", true);
        }

        private void tbxStrength_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxStrength, trbStrength, "Stärke der Pheromone", false);
        }

        private void tbxStartPheromone_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxStartPheromone, trbStartPheromone, "Startwert der Pheromone", false);

        }

        private void tbxEvaporation_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxEvaporation, trbEvaporation, "Evaporationskoeffizient der Pheromone", false);

        }

        private void tbxWeightDistance_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxWeightDistance, trbWeightDistance, "Gewichtung der Distanz", false);

        }

        private void tbxWeightPheromone_TextChanged(object sender, EventArgs e)
        {

            checkValue(tbxWeightPheromone, trbWeightPheromone, "Gewichtung der Pheromone", false);
        }

        private void tbxCycles_TextChanged(object sender, EventArgs e)
        {
            checkValue(tbxCycles, trbCycles, "Anzahl an Zyklen", true);

        }

        private void checkExample_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
