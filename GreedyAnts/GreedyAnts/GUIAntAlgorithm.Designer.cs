
using System.Windows.Forms;

namespace GreedyAnts
{
    partial class GUIAntAlgorithm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSpace = new System.Windows.Forms.Label();
            this.cbxRaum = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.cbxZeit = new System.Windows.Forms.ComboBox();
            this.lblTowns = new System.Windows.Forms.Label();
            this.trbAmountTowns = new System.Windows.Forms.TrackBar();
            this.lblAmountTowns = new System.Windows.Forms.Label();
            this.lblSpreadTowns = new System.Windows.Forms.Label();
            this.cbxSpreadTowns = new System.Windows.Forms.ComboBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.cbxDistance = new System.Windows.Forms.ComboBox();
            this.lblVisibility = new System.Windows.Forms.Label();
            this.cbxVisibility = new System.Windows.Forms.ComboBox();
            this.cbxTabulist = new System.Windows.Forms.ComboBox();
            this.lblTabulist = new System.Windows.Forms.Label();
            this.cbxSpreadAnts = new System.Windows.Forms.ComboBox();
            this.lblSpreadAnts = new System.Windows.Forms.Label();
            this.lblAmountAnts = new System.Windows.Forms.Label();
            this.trbAmountAnts = new System.Windows.Forms.TrackBar();
            this.lblAnts = new System.Windows.Forms.Label();
            this.lblPheromone = new System.Windows.Forms.Label();
            this.lblStartPheromone = new System.Windows.Forms.Label();
            this.trbStartPheromone = new System.Windows.Forms.TrackBar();
            this.lblStrength = new System.Windows.Forms.Label();
            this.trbStrength = new System.Windows.Forms.TrackBar();
            this.lblEvaporation = new System.Windows.Forms.Label();
            this.trbEvaporation = new System.Windows.Forms.TrackBar();
            this.lblWeightDistance = new System.Windows.Forms.Label();
            this.trbWeightDistance = new System.Windows.Forms.TrackBar();
            this.lblWeightPheromone = new System.Windows.Forms.Label();
            this.trbWeightPheromone = new System.Windows.Forms.TrackBar();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblCycles = new System.Windows.Forms.Label();
            this.trbCycles = new System.Windows.Forms.TrackBar();
            this.tbxAmountTowns = new System.Windows.Forms.TextBox();
            this.tbxAmountAnts = new System.Windows.Forms.TextBox();
            this.tbxStrength = new System.Windows.Forms.TextBox();
            this.tbxStartPheromone = new System.Windows.Forms.TextBox();
            this.tbxEvaporation = new System.Windows.Forms.TextBox();
            this.tbxWeightDistance = new System.Windows.Forms.TextBox();
            this.tbxWeightPheromone = new System.Windows.Forms.TextBox();
            this.tbxCycles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxArt = new System.Windows.Forms.ComboBox();
            this.lblArt = new System.Windows.Forms.Label();
            this.checkExample = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountTowns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountAnts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStartPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEvaporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCycles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.Location = new System.Drawing.Point(10, 82);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(39, 13);
            this.lblSpace.TabIndex = 0;
            this.lblSpace.Text = "Raum";
            // 
            // cbxRaum
            // 
            this.cbxRaum.FormattingEnabled = true;
            this.cbxRaum.Location = new System.Drawing.Point(51, 79);
            this.cbxRaum.Name = "cbxRaum";
            this.cbxRaum.Size = new System.Drawing.Size(236, 21);
            this.cbxRaum.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(10, 116);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Zeit";
            // 
            // cbxZeit
            // 
            this.cbxZeit.FormattingEnabled = true;
            this.cbxZeit.Location = new System.Drawing.Point(51, 113);
            this.cbxZeit.Name = "cbxZeit";
            this.cbxZeit.Size = new System.Drawing.Size(236, 21);
            this.cbxZeit.TabIndex = 3;
            // 
            // lblTowns
            // 
            this.lblTowns.AutoSize = true;
            this.lblTowns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTowns.Location = new System.Drawing.Point(10, 149);
            this.lblTowns.Name = "lblTowns";
            this.lblTowns.Size = new System.Drawing.Size(44, 13);
            this.lblTowns.TabIndex = 4;
            this.lblTowns.Text = "Städte";
            // 
            // trbAmountTowns
            // 
            this.trbAmountTowns.LargeChange = 1;
            this.trbAmountTowns.Location = new System.Drawing.Point(104, 170);
            this.trbAmountTowns.Maximum = 100;
            this.trbAmountTowns.Name = "trbAmountTowns";
            this.trbAmountTowns.Size = new System.Drawing.Size(183, 45);
            this.trbAmountTowns.TabIndex = 5;
            this.trbAmountTowns.ValueChanged += new System.EventHandler(this.trbAmountTowns_ValueChanged);
            // 
            // lblAmountTowns
            // 
            this.lblAmountTowns.AutoSize = true;
            this.lblAmountTowns.Location = new System.Drawing.Point(22, 180);
            this.lblAmountTowns.Name = "lblAmountTowns";
            this.lblAmountTowns.Size = new System.Drawing.Size(39, 13);
            this.lblAmountTowns.TabIndex = 6;
            this.lblAmountTowns.Text = "Anzahl";
            // 
            // lblSpreadTowns
            // 
            this.lblSpreadTowns.AutoSize = true;
            this.lblSpreadTowns.Location = new System.Drawing.Point(22, 211);
            this.lblSpreadTowns.Name = "lblSpreadTowns";
            this.lblSpreadTowns.Size = new System.Drawing.Size(54, 13);
            this.lblSpreadTowns.TabIndex = 8;
            this.lblSpreadTowns.Text = "Verteilung";
            // 
            // cbxSpreadTowns
            // 
            this.cbxSpreadTowns.FormattingEnabled = true;
            this.cbxSpreadTowns.Location = new System.Drawing.Point(86, 208);
            this.cbxSpreadTowns.Name = "cbxSpreadTowns";
            this.cbxSpreadTowns.Size = new System.Drawing.Size(201, 21);
            this.cbxSpreadTowns.TabIndex = 9;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(22, 244);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(46, 13);
            this.lblDistance.TabIndex = 10;
            this.lblDistance.Text = "Abstand";
            // 
            // cbxDistance
            // 
            this.cbxDistance.FormattingEnabled = true;
            this.cbxDistance.Location = new System.Drawing.Point(86, 241);
            this.cbxDistance.Name = "cbxDistance";
            this.cbxDistance.Size = new System.Drawing.Size(201, 21);
            this.cbxDistance.TabIndex = 11;
            // 
            // lblVisibility
            // 
            this.lblVisibility.AutoSize = true;
            this.lblVisibility.Location = new System.Drawing.Point(22, 275);
            this.lblVisibility.Name = "lblVisibility";
            this.lblVisibility.Size = new System.Drawing.Size(63, 13);
            this.lblVisibility.TabIndex = 12;
            this.lblVisibility.Text = "Sichtbarkeit";
            // 
            // cbxVisibility
            // 
            this.cbxVisibility.FormattingEnabled = true;
            this.cbxVisibility.Location = new System.Drawing.Point(86, 275);
            this.cbxVisibility.Name = "cbxVisibility";
            this.cbxVisibility.Size = new System.Drawing.Size(201, 21);
            this.cbxVisibility.TabIndex = 13;
            // 
            // cbxTabulist
            // 
            this.cbxTabulist.FormattingEnabled = true;
            this.cbxTabulist.Location = new System.Drawing.Point(86, 400);
            this.cbxTabulist.Name = "cbxTabulist";
            this.cbxTabulist.Size = new System.Drawing.Size(201, 21);
            this.cbxTabulist.TabIndex = 21;
            // 
            // lblTabulist
            // 
            this.lblTabulist.AutoSize = true;
            this.lblTabulist.Location = new System.Drawing.Point(22, 403);
            this.lblTabulist.Name = "lblTabulist";
            this.lblTabulist.Size = new System.Drawing.Size(56, 13);
            this.lblTabulist.TabIndex = 20;
            this.lblTabulist.Text = "Tabulisten";
            // 
            // cbxSpreadAnts
            // 
            this.cbxSpreadAnts.FormattingEnabled = true;
            this.cbxSpreadAnts.Location = new System.Drawing.Point(86, 367);
            this.cbxSpreadAnts.Name = "cbxSpreadAnts";
            this.cbxSpreadAnts.Size = new System.Drawing.Size(201, 21);
            this.cbxSpreadAnts.TabIndex = 19;
            // 
            // lblSpreadAnts
            // 
            this.lblSpreadAnts.AutoSize = true;
            this.lblSpreadAnts.Location = new System.Drawing.Point(22, 370);
            this.lblSpreadAnts.Name = "lblSpreadAnts";
            this.lblSpreadAnts.Size = new System.Drawing.Size(54, 13);
            this.lblSpreadAnts.TabIndex = 18;
            this.lblSpreadAnts.Text = "Verteilung";
            // 
            // lblAmountAnts
            // 
            this.lblAmountAnts.AutoSize = true;
            this.lblAmountAnts.Location = new System.Drawing.Point(22, 339);
            this.lblAmountAnts.Name = "lblAmountAnts";
            this.lblAmountAnts.Size = new System.Drawing.Size(39, 13);
            this.lblAmountAnts.TabIndex = 16;
            this.lblAmountAnts.Text = "Anzahl";
            // 
            // trbAmountAnts
            // 
            this.trbAmountAnts.LargeChange = 1;
            this.trbAmountAnts.Location = new System.Drawing.Point(104, 329);
            this.trbAmountAnts.Maximum = 128;
            this.trbAmountAnts.Minimum = 1;
            this.trbAmountAnts.Name = "trbAmountAnts";
            this.trbAmountAnts.Size = new System.Drawing.Size(183, 45);
            this.trbAmountAnts.TabIndex = 15;
            this.trbAmountAnts.Value = 1;
            this.trbAmountAnts.ValueChanged += new System.EventHandler(this.trbAmountAnts_ValueChanged);
            // 
            // lblAnts
            // 
            this.lblAnts.AutoSize = true;
            this.lblAnts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnts.Location = new System.Drawing.Point(10, 308);
            this.lblAnts.Name = "lblAnts";
            this.lblAnts.Size = new System.Drawing.Size(54, 13);
            this.lblAnts.TabIndex = 14;
            this.lblAnts.Text = "Ameisen";
            // 
            // lblPheromone
            // 
            this.lblPheromone.AutoSize = true;
            this.lblPheromone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPheromone.Location = new System.Drawing.Point(7, 436);
            this.lblPheromone.Name = "lblPheromone";
            this.lblPheromone.Size = new System.Drawing.Size(70, 13);
            this.lblPheromone.TabIndex = 24;
            this.lblPheromone.Text = "Pheromone";
            // 
            // lblStartPheromone
            // 
            this.lblStartPheromone.AutoSize = true;
            this.lblStartPheromone.Location = new System.Drawing.Point(21, 507);
            this.lblStartPheromone.Name = "lblStartPheromone";
            this.lblStartPheromone.Size = new System.Drawing.Size(49, 13);
            this.lblStartPheromone.TabIndex = 26;
            this.lblStartPheromone.Text = "Startwert";
            // 
            // trbStartPheromone
            // 
            this.trbStartPheromone.LargeChange = 1;
            this.trbStartPheromone.Location = new System.Drawing.Point(126, 492);
            this.trbStartPheromone.Maximum = 200;
            this.trbStartPheromone.Minimum = 1;
            this.trbStartPheromone.Name = "trbStartPheromone";
            this.trbStartPheromone.Size = new System.Drawing.Size(161, 45);
            this.trbStartPheromone.TabIndex = 25;
            this.trbStartPheromone.Value = 1;
            this.trbStartPheromone.ValueChanged += new System.EventHandler(this.trbStartPheromone_ValueChanged);
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(22, 466);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(38, 13);
            this.lblStrength.TabIndex = 29;
            this.lblStrength.Text = "Stärke";
            // 
            // trbStrength
            // 
            this.trbStrength.LargeChange = 1;
            this.trbStrength.Location = new System.Drawing.Point(126, 450);
            this.trbStrength.Maximum = 200;
            this.trbStrength.Minimum = 1;
            this.trbStrength.Name = "trbStrength";
            this.trbStrength.Size = new System.Drawing.Size(161, 45);
            this.trbStrength.TabIndex = 28;
            this.trbStrength.Value = 1;
            this.trbStrength.ValueChanged += new System.EventHandler(this.trbStrength_ValueChanged);
            // 
            // lblEvaporation
            // 
            this.lblEvaporation.AutoSize = true;
            this.lblEvaporation.Location = new System.Drawing.Point(22, 548);
            this.lblEvaporation.Name = "lblEvaporation";
            this.lblEvaporation.Size = new System.Drawing.Size(64, 13);
            this.lblEvaporation.TabIndex = 32;
            this.lblEvaporation.Text = "Evaporation";
            // 
            // trbEvaporation
            // 
            this.trbEvaporation.LargeChange = 1;
            this.trbEvaporation.Location = new System.Drawing.Point(126, 543);
            this.trbEvaporation.Maximum = 99;
            this.trbEvaporation.Minimum = 1;
            this.trbEvaporation.Name = "trbEvaporation";
            this.trbEvaporation.Size = new System.Drawing.Size(161, 45);
            this.trbEvaporation.TabIndex = 31;
            this.trbEvaporation.Value = 1;
            this.trbEvaporation.ValueChanged += new System.EventHandler(this.trbEvaporation_ValueChanged);
            // 
            // lblWeightDistance
            // 
            this.lblWeightDistance.AutoSize = true;
            this.lblWeightDistance.Location = new System.Drawing.Point(21, 604);
            this.lblWeightDistance.Name = "lblWeightDistance";
            this.lblWeightDistance.Size = new System.Drawing.Size(42, 13);
            this.lblWeightDistance.TabIndex = 39;
            this.lblWeightDistance.Text = "Distanz";
            // 
            // trbWeightDistance
            // 
            this.trbWeightDistance.LargeChange = 1;
            this.trbWeightDistance.Location = new System.Drawing.Point(126, 591);
            this.trbWeightDistance.Maximum = 200;
            this.trbWeightDistance.Minimum = 1;
            this.trbWeightDistance.Name = "trbWeightDistance";
            this.trbWeightDistance.Size = new System.Drawing.Size(161, 45);
            this.trbWeightDistance.TabIndex = 38;
            this.trbWeightDistance.Value = 1;
            this.trbWeightDistance.ValueChanged += new System.EventHandler(this.trbWeightDistance_ValueChanged);
            // 
            // lblWeightPheromone
            // 
            this.lblWeightPheromone.AutoSize = true;
            this.lblWeightPheromone.Location = new System.Drawing.Point(21, 642);
            this.lblWeightPheromone.Name = "lblWeightPheromone";
            this.lblWeightPheromone.Size = new System.Drawing.Size(61, 13);
            this.lblWeightPheromone.TabIndex = 36;
            this.lblWeightPheromone.Text = "Pheromone";
            // 
            // trbWeightPheromone
            // 
            this.trbWeightPheromone.LargeChange = 1;
            this.trbWeightPheromone.Location = new System.Drawing.Point(126, 636);
            this.trbWeightPheromone.Maximum = 200;
            this.trbWeightPheromone.Minimum = 1;
            this.trbWeightPheromone.Name = "trbWeightPheromone";
            this.trbWeightPheromone.Size = new System.Drawing.Size(161, 45);
            this.trbWeightPheromone.TabIndex = 35;
            this.trbWeightPheromone.Value = 1;
            this.trbWeightPheromone.ValueChanged += new System.EventHandler(this.trbWeightPheromone_ValueChanged);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(6, 580);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(74, 13);
            this.lblWeight.TabIndex = 34;
            this.lblWeight.Text = "Gewichtung";
            // 
            // lblCycles
            // 
            this.lblCycles.AutoSize = true;
            this.lblCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycles.Location = new System.Drawing.Point(6, 680);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(45, 13);
            this.lblCycles.TabIndex = 42;
            this.lblCycles.Text = "Zyklen";
            // 
            // trbCycles
            // 
            this.trbCycles.LargeChange = 1;
            this.trbCycles.Location = new System.Drawing.Point(86, 677);
            this.trbCycles.Maximum = 1000;
            this.trbCycles.Minimum = 1;
            this.trbCycles.Name = "trbCycles";
            this.trbCycles.Size = new System.Drawing.Size(201, 45);
            this.trbCycles.TabIndex = 41;
            this.trbCycles.Value = 1;
            this.trbCycles.ValueChanged += new System.EventHandler(this.trbCycles_ValueChanged);
            // 
            // tbxAmountTowns
            // 
            this.tbxAmountTowns.Location = new System.Drawing.Point(67, 177);
            this.tbxAmountTowns.Name = "tbxAmountTowns";
            this.tbxAmountTowns.Size = new System.Drawing.Size(31, 20);
            this.tbxAmountTowns.TabIndex = 44;
            this.tbxAmountTowns.Text = "5";
            this.tbxAmountTowns.TextChanged += new System.EventHandler(this.tbxAmountTowns_TextChanged);
            // 
            // tbxAmountAnts
            // 
            this.tbxAmountAnts.Location = new System.Drawing.Point(67, 336);
            this.tbxAmountAnts.Name = "tbxAmountAnts";
            this.tbxAmountAnts.Size = new System.Drawing.Size(31, 20);
            this.tbxAmountAnts.TabIndex = 45;
            this.tbxAmountAnts.Text = "3";
            this.tbxAmountAnts.TextChanged += new System.EventHandler(this.tbxAmountAnts_TextChanged);
            // 
            // tbxStrength
            // 
            this.tbxStrength.Location = new System.Drawing.Point(86, 459);
            this.tbxStrength.Name = "tbxStrength";
            this.tbxStrength.Size = new System.Drawing.Size(34, 20);
            this.tbxStrength.TabIndex = 46;
            this.tbxStrength.Text = "1,00";
            this.tbxStrength.TextChanged += new System.EventHandler(this.tbxStrength_TextChanged);
            // 
            // tbxStartPheromone
            // 
            this.tbxStartPheromone.Location = new System.Drawing.Point(86, 500);
            this.tbxStartPheromone.Name = "tbxStartPheromone";
            this.tbxStartPheromone.Size = new System.Drawing.Size(34, 20);
            this.tbxStartPheromone.TabIndex = 47;
            this.tbxStartPheromone.Text = "1,00";
            this.tbxStartPheromone.TextChanged += new System.EventHandler(this.tbxStartPheromone_TextChanged);
            // 
            // tbxEvaporation
            // 
            this.tbxEvaporation.Location = new System.Drawing.Point(86, 545);
            this.tbxEvaporation.Name = "tbxEvaporation";
            this.tbxEvaporation.Size = new System.Drawing.Size(34, 20);
            this.tbxEvaporation.TabIndex = 48;
            this.tbxEvaporation.Text = "0,90";
            this.tbxEvaporation.TextChanged += new System.EventHandler(this.tbxEvaporation_TextChanged);
            // 
            // tbxWeightDistance
            // 
            this.tbxWeightDistance.Location = new System.Drawing.Point(88, 597);
            this.tbxWeightDistance.Name = "tbxWeightDistance";
            this.tbxWeightDistance.Size = new System.Drawing.Size(32, 20);
            this.tbxWeightDistance.TabIndex = 49;
            this.tbxWeightDistance.Text = "1,00";
            this.tbxWeightDistance.TextChanged += new System.EventHandler(this.tbxWeightDistance_TextChanged);
            // 
            // tbxWeightPheromone
            // 
            this.tbxWeightPheromone.Location = new System.Drawing.Point(88, 639);
            this.tbxWeightPheromone.Name = "tbxWeightPheromone";
            this.tbxWeightPheromone.Size = new System.Drawing.Size(32, 20);
            this.tbxWeightPheromone.TabIndex = 50;
            this.tbxWeightPheromone.Text = "1,00";
            this.tbxWeightPheromone.TextChanged += new System.EventHandler(this.tbxWeightPheromone_TextChanged);
            // 
            // tbxCycles
            // 
            this.tbxCycles.Location = new System.Drawing.Point(56, 677);
            this.tbxCycles.Name = "tbxCycles";
            this.tbxCycles.Size = new System.Drawing.Size(34, 20);
            this.tbxCycles.TabIndex = 51;
            this.tbxCycles.Text = "2";
            this.tbxCycles.TextChanged += new System.EventHandler(this.tbxCycles_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Input-Parameter";
            // 
            // cbxArt
            // 
            this.cbxArt.FormattingEnabled = true;
            this.cbxArt.Location = new System.Drawing.Point(51, 43);
            this.cbxArt.Name = "cbxArt";
            this.cbxArt.Size = new System.Drawing.Size(236, 21);
            this.cbxArt.TabIndex = 54;
            // 
            // lblArt
            // 
            this.lblArt.AutoSize = true;
            this.lblArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArt.Location = new System.Drawing.Point(10, 46);
            this.lblArt.Name = "lblArt";
            this.lblArt.Size = new System.Drawing.Size(23, 13);
            this.lblArt.TabIndex = 53;
            this.lblArt.Text = "Art";
            // 
            // checkExample
            // 
            this.checkExample.AutoSize = true;
            this.checkExample.Location = new System.Drawing.Point(156, 16);
            this.checkExample.Name = "checkExample";
            this.checkExample.Size = new System.Drawing.Size(135, 17);
            this.checkExample.TabIndex = 55;
            this.checkExample.Text = "grundlegendes Beispiel";
            this.checkExample.UseVisualStyleBackColor = true;
            this.checkExample.CheckedChanged += new System.EventHandler(this.checkExample_CheckedChanged);
            // 
            // GUIAntAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 729);
            this.Controls.Add(this.checkExample);
            this.Controls.Add(this.cbxArt);
            this.Controls.Add(this.lblArt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCycles);
            this.Controls.Add(this.tbxWeightPheromone);
            this.Controls.Add(this.tbxWeightDistance);
            this.Controls.Add(this.tbxEvaporation);
            this.Controls.Add(this.tbxStartPheromone);
            this.Controls.Add(this.tbxStrength);
            this.Controls.Add(this.tbxAmountAnts);
            this.Controls.Add(this.tbxAmountTowns);
            this.Controls.Add(this.lblCycles);
            this.Controls.Add(this.trbCycles);
            this.Controls.Add(this.lblWeightDistance);
            this.Controls.Add(this.trbWeightDistance);
            this.Controls.Add(this.lblWeightPheromone);
            this.Controls.Add(this.trbWeightPheromone);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblEvaporation);
            this.Controls.Add(this.trbEvaporation);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.trbStrength);
            this.Controls.Add(this.lblStartPheromone);
            this.Controls.Add(this.trbStartPheromone);
            this.Controls.Add(this.lblPheromone);
            this.Controls.Add(this.cbxTabulist);
            this.Controls.Add(this.lblTabulist);
            this.Controls.Add(this.cbxSpreadAnts);
            this.Controls.Add(this.lblSpreadAnts);
            this.Controls.Add(this.lblAmountAnts);
            this.Controls.Add(this.trbAmountAnts);
            this.Controls.Add(this.lblAnts);
            this.Controls.Add(this.cbxVisibility);
            this.Controls.Add(this.lblVisibility);
            this.Controls.Add(this.cbxDistance);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.cbxSpreadTowns);
            this.Controls.Add(this.lblSpreadTowns);
            this.Controls.Add(this.lblAmountTowns);
            this.Controls.Add(this.trbAmountTowns);
            this.Controls.Add(this.lblTowns);
            this.Controls.Add(this.cbxZeit);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.cbxRaum);
            this.Controls.Add(this.lblSpace);
            this.Name = "GUIAntAlgorithm";
            this.Text = "Initialisierung";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountTowns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountAnts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStartPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEvaporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCycles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.ComboBox cbxRaum;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cbxZeit;
        private System.Windows.Forms.Label lblTowns;
        private System.Windows.Forms.TrackBar trbAmountTowns;
        private System.Windows.Forms.Label lblAmountTowns;
        private System.Windows.Forms.Label lblSpreadTowns;
        private System.Windows.Forms.ComboBox cbxSpreadTowns;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.ComboBox cbxDistance;
        private System.Windows.Forms.Label lblVisibility;
        private System.Windows.Forms.ComboBox cbxVisibility;
        private System.Windows.Forms.ComboBox cbxTabulist;
        private System.Windows.Forms.Label lblTabulist;
        private System.Windows.Forms.ComboBox cbxSpreadAnts;
        private System.Windows.Forms.Label lblSpreadAnts;
        private System.Windows.Forms.Label lblAmountAnts;
        private System.Windows.Forms.TrackBar trbAmountAnts;
        private System.Windows.Forms.Label lblAnts;
        private System.Windows.Forms.Label lblPheromone;
        private System.Windows.Forms.Label lblStartPheromone;
        private System.Windows.Forms.TrackBar trbStartPheromone;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.TrackBar trbStrength;
        private System.Windows.Forms.Label lblEvaporation;
        private System.Windows.Forms.TrackBar trbEvaporation;
        private System.Windows.Forms.Label lblWeightDistance;
        private System.Windows.Forms.TrackBar trbWeightDistance;
        private System.Windows.Forms.Label lblWeightPheromone;
        private System.Windows.Forms.TrackBar trbWeightPheromone;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.TrackBar trbCycles;
        private System.Windows.Forms.TextBox tbxAmountTowns;
        private System.Windows.Forms.TextBox tbxAmountAnts;
        private System.Windows.Forms.TextBox tbxStrength;
        private System.Windows.Forms.TextBox tbxStartPheromone;
        private System.Windows.Forms.TextBox tbxEvaporation;
        private System.Windows.Forms.TextBox tbxWeightDistance;
        private System.Windows.Forms.TextBox tbxWeightPheromone;
        private System.Windows.Forms.TextBox tbxCycles;
        private Label label1;
        private ComboBox cbxArt;
        private Label lblArt;
        private CheckBox checkExample;
    }
}