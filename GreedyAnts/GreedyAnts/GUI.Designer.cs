
namespace GreedyAnts
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.pnlSelection = new System.Windows.Forms.Panel();
            this.lblWeightPheromone = new System.Windows.Forms.Label();
            this.chbExample = new System.Windows.Forms.CheckBox();
            this.cbxArt = new System.Windows.Forms.ComboBox();
            this.lblArt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCycles = new System.Windows.Forms.TextBox();
            this.tbxWeightPheromone = new System.Windows.Forms.TextBox();
            this.tbxWeightDistance = new System.Windows.Forms.TextBox();
            this.tbxEvaporation = new System.Windows.Forms.TextBox();
            this.tbxStartPheromone = new System.Windows.Forms.TextBox();
            this.tbxStrength = new System.Windows.Forms.TextBox();
            this.tbxAmountAnts = new System.Windows.Forms.TextBox();
            this.tbxAmountTowns = new System.Windows.Forms.TextBox();
            this.lblCycles = new System.Windows.Forms.Label();
            this.trbCycles = new System.Windows.Forms.TrackBar();
            this.lblWeightDistance = new System.Windows.Forms.Label();
            this.trbWeightDistance = new System.Windows.Forms.TrackBar();
            this.trbWeightPheromone = new System.Windows.Forms.TrackBar();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblEvaporation = new System.Windows.Forms.Label();
            this.trbEvaporation = new System.Windows.Forms.TrackBar();
            this.lblStrength = new System.Windows.Forms.Label();
            this.trbStrength = new System.Windows.Forms.TrackBar();
            this.lblStartPheromone = new System.Windows.Forms.Label();
            this.trbStartPheromone = new System.Windows.Forms.TrackBar();
            this.lblPheromone = new System.Windows.Forms.Label();
            this.cbxSpreadAnts = new System.Windows.Forms.ComboBox();
            this.lblSpreadAnts = new System.Windows.Forms.Label();
            this.lblAmountAnts = new System.Windows.Forms.Label();
            this.trbAmountAnts = new System.Windows.Forms.TrackBar();
            this.lblAnts = new System.Windows.Forms.Label();
            this.cbxSpreadTowns = new System.Windows.Forms.ComboBox();
            this.lblSpreadTowns = new System.Windows.Forms.Label();
            this.lblAmountTowns = new System.Windows.Forms.Label();
            this.trbAmountTowns = new System.Windows.Forms.TrackBar();
            this.lblTowns = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.spcInformation = new System.Windows.Forms.SplitContainer();
            this.pnlAntTabuList = new System.Windows.Forms.Panel();
            this.lblTabu = new System.Windows.Forms.Label();
            this.pnlAntPossibilities = new System.Windows.Forms.Panel();
            this.lblPossibilities = new System.Windows.Forms.Label();
            this.pnlAntInfo = new System.Windows.Forms.Panel();
            this.lblCurrentPathLength = new System.Windows.Forms.Label();
            this.lblCoordinatesDestiny = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblCurrentPlace = new System.Windows.Forms.Label();
            this.lblAntName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlShortestPath = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlIteration = new System.Windows.Forms.Panel();
            this.lblIterationInRound = new System.Windows.Forms.Label();
            this.pnlCycle = new System.Windows.Forms.Panel();
            this.lblRound = new System.Windows.Forms.Label();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblShowTime = new System.Windows.Forms.Label();
            this.lbxAnts = new System.Windows.Forms.ListBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlVisualization = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pnlControlIcons = new System.Windows.Forms.Panel();
            this.chbNames = new System.Windows.Forms.CheckBox();
            this.chbAnts = new System.Windows.Forms.CheckBox();
            this.chbTowns = new System.Windows.Forms.CheckBox();
            this.pnlControlValues = new System.Windows.Forms.Panel();
            this.chbCoordinates = new System.Windows.Forms.CheckBox();
            this.chbDistance = new System.Windows.Forms.CheckBox();
            this.chbPheromone = new System.Windows.Forms.CheckBox();
            this.pnlControlLockAndRoads = new System.Windows.Forms.Panel();
            this.chbSolution = new System.Windows.Forms.CheckBox();
            this.chbTrail = new System.Windows.Forms.CheckBox();
            this.chbLock = new System.Windows.Forms.CheckBox();
            this.pnlControlProcedure = new System.Windows.Forms.Panel();
            this.pnlControlLeftDown = new System.Windows.Forms.Panel();
            this.btnToTheStart = new System.Windows.Forms.Button();
            this.btnPrevRound = new System.Windows.Forms.Button();
            this.btnPrevIt = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.pnlControlLeftTop = new System.Windows.Forms.Panel();
            this.btnToTheEnd = new System.Windows.Forms.Button();
            this.btnNextRound = new System.Windows.Forms.Button();
            this.btnNextIt = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pnlControlLeftGap = new System.Windows.Forms.Panel();
            this.tbxSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEvaporation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStartPheromone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountAnts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountTowns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcInformation)).BeginInit();
            this.spcInformation.Panel1.SuspendLayout();
            this.spcInformation.Panel2.SuspendLayout();
            this.spcInformation.SuspendLayout();
            this.pnlAntTabuList.SuspendLayout();
            this.pnlAntPossibilities.SuspendLayout();
            this.pnlAntInfo.SuspendLayout();
            this.pnlShortestPath.SuspendLayout();
            this.pnlIteration.SuspendLayout();
            this.pnlCycle.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlControlIcons.SuspendLayout();
            this.pnlControlValues.SuspendLayout();
            this.pnlControlLockAndRoads.SuspendLayout();
            this.pnlControlProcedure.SuspendLayout();
            this.pnlControlLeftDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            this.pnlControlLeftTop.SuspendLayout();
            this.pnlControlLeftGap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSelection
            // 
            this.pnlSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelection.Controls.Add(this.lblWeightPheromone);
            this.pnlSelection.Controls.Add(this.chbExample);
            this.pnlSelection.Controls.Add(this.cbxArt);
            this.pnlSelection.Controls.Add(this.lblArt);
            this.pnlSelection.Controls.Add(this.label1);
            this.pnlSelection.Controls.Add(this.tbxCycles);
            this.pnlSelection.Controls.Add(this.tbxWeightPheromone);
            this.pnlSelection.Controls.Add(this.tbxWeightDistance);
            this.pnlSelection.Controls.Add(this.tbxEvaporation);
            this.pnlSelection.Controls.Add(this.tbxStartPheromone);
            this.pnlSelection.Controls.Add(this.tbxStrength);
            this.pnlSelection.Controls.Add(this.tbxAmountAnts);
            this.pnlSelection.Controls.Add(this.tbxAmountTowns);
            this.pnlSelection.Controls.Add(this.lblCycles);
            this.pnlSelection.Controls.Add(this.trbCycles);
            this.pnlSelection.Controls.Add(this.lblWeightDistance);
            this.pnlSelection.Controls.Add(this.trbWeightDistance);
            this.pnlSelection.Controls.Add(this.trbWeightPheromone);
            this.pnlSelection.Controls.Add(this.lblWeight);
            this.pnlSelection.Controls.Add(this.lblEvaporation);
            this.pnlSelection.Controls.Add(this.trbEvaporation);
            this.pnlSelection.Controls.Add(this.lblStrength);
            this.pnlSelection.Controls.Add(this.trbStrength);
            this.pnlSelection.Controls.Add(this.lblStartPheromone);
            this.pnlSelection.Controls.Add(this.trbStartPheromone);
            this.pnlSelection.Controls.Add(this.lblPheromone);
            this.pnlSelection.Controls.Add(this.cbxSpreadAnts);
            this.pnlSelection.Controls.Add(this.lblSpreadAnts);
            this.pnlSelection.Controls.Add(this.lblAmountAnts);
            this.pnlSelection.Controls.Add(this.trbAmountAnts);
            this.pnlSelection.Controls.Add(this.lblAnts);
            this.pnlSelection.Controls.Add(this.cbxSpreadTowns);
            this.pnlSelection.Controls.Add(this.lblSpreadTowns);
            this.pnlSelection.Controls.Add(this.lblAmountTowns);
            this.pnlSelection.Controls.Add(this.trbAmountTowns);
            this.pnlSelection.Controls.Add(this.lblTowns);
            this.pnlSelection.Controls.Add(this.btnReset);
            this.pnlSelection.Controls.Add(this.btnConfirm);
            this.pnlSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlSelection.Name = "pnlSelection";
            this.pnlSelection.Size = new System.Drawing.Size(235, 680);
            this.pnlSelection.TabIndex = 0;
            // 
            // lblWeightPheromone
            // 
            this.lblWeightPheromone.AutoSize = true;
            this.lblWeightPheromone.Location = new System.Drawing.Point(15, 454);
            this.lblWeightPheromone.Name = "lblWeightPheromone";
            this.lblWeightPheromone.Size = new System.Drawing.Size(61, 13);
            this.lblWeightPheromone.TabIndex = 75;
            this.lblWeightPheromone.Text = "Pheromone";
            // 
            // chbExample
            // 
            this.chbExample.AutoSize = true;
            this.chbExample.Location = new System.Drawing.Point(98, 13);
            this.chbExample.Name = "chbExample";
            this.chbExample.Size = new System.Drawing.Size(135, 17);
            this.chbExample.TabIndex = 91;
            this.chbExample.Text = "grundlegendes Beispiel";
            this.chbExample.UseVisualStyleBackColor = true;
            this.chbExample.CheckedChanged += new System.EventHandler(this.chbExample_CheckedChanged);
            // 
            // cbxArt
            // 
            this.cbxArt.FormattingEnabled = true;
            this.cbxArt.Location = new System.Drawing.Point(20, 53);
            this.cbxArt.Name = "cbxArt";
            this.cbxArt.Size = new System.Drawing.Size(195, 21);
            this.cbxArt.TabIndex = 90;
            this.cbxArt.SelectedIndexChanged += new System.EventHandler(this.cbxArt_SelectedIndexChanged);
            // 
            // lblArt
            // 
            this.lblArt.AutoSize = true;
            this.lblArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArt.Location = new System.Drawing.Point(10, 35);
            this.lblArt.Name = "lblArt";
            this.lblArt.Size = new System.Drawing.Size(23, 13);
            this.lblArt.TabIndex = 89;
            this.lblArt.Text = "Art";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Parameter";
            // 
            // tbxCycles
            // 
            this.tbxCycles.Location = new System.Drawing.Point(20, 558);
            this.tbxCycles.Name = "tbxCycles";
            this.tbxCycles.Size = new System.Drawing.Size(35, 20);
            this.tbxCycles.TabIndex = 87;
            this.tbxCycles.Text = "2";
            this.tbxCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxCycles.TextChanged += new System.EventHandler(this.tbxCycles_TextChanged);
            // 
            // tbxWeightPheromone
            // 
            this.tbxWeightPheromone.Location = new System.Drawing.Point(20, 472);
            this.tbxWeightPheromone.Name = "tbxWeightPheromone";
            this.tbxWeightPheromone.Size = new System.Drawing.Size(35, 20);
            this.tbxWeightPheromone.TabIndex = 86;
            this.tbxWeightPheromone.Text = "1,00";
            this.tbxWeightPheromone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxWeightPheromone.TextChanged += new System.EventHandler(this.tbxWeightPheromone_TextChanged);
            // 
            // tbxWeightDistance
            // 
            this.tbxWeightDistance.Location = new System.Drawing.Point(20, 515);
            this.tbxWeightDistance.Name = "tbxWeightDistance";
            this.tbxWeightDistance.Size = new System.Drawing.Size(35, 20);
            this.tbxWeightDistance.TabIndex = 85;
            this.tbxWeightDistance.Text = "1,00";
            this.tbxWeightDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxWeightDistance.TextChanged += new System.EventHandler(this.tbxWeightDistance_TextChanged);
            // 
            // tbxEvaporation
            // 
            this.tbxEvaporation.Location = new System.Drawing.Point(20, 411);
            this.tbxEvaporation.Name = "tbxEvaporation";
            this.tbxEvaporation.Size = new System.Drawing.Size(35, 20);
            this.tbxEvaporation.TabIndex = 84;
            this.tbxEvaporation.Text = "0,90";
            this.tbxEvaporation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxEvaporation.TextChanged += new System.EventHandler(this.tbxEvaporation_TextChanged);
            // 
            // tbxStartPheromone
            // 
            this.tbxStartPheromone.Location = new System.Drawing.Point(20, 368);
            this.tbxStartPheromone.Name = "tbxStartPheromone";
            this.tbxStartPheromone.Size = new System.Drawing.Size(35, 20);
            this.tbxStartPheromone.TabIndex = 83;
            this.tbxStartPheromone.Text = "1,00";
            this.tbxStartPheromone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxStartPheromone.TextChanged += new System.EventHandler(this.tbxStartPheromone_TextChanged);
            // 
            // tbxStrength
            // 
            this.tbxStrength.Location = new System.Drawing.Point(20, 325);
            this.tbxStrength.Name = "tbxStrength";
            this.tbxStrength.Size = new System.Drawing.Size(35, 20);
            this.tbxStrength.TabIndex = 82;
            this.tbxStrength.Text = "1,00";
            this.tbxStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxStrength.TextChanged += new System.EventHandler(this.tbxStrength_TextChanged);
            // 
            // tbxAmountAnts
            // 
            this.tbxAmountAnts.Location = new System.Drawing.Point(20, 220);
            this.tbxAmountAnts.Name = "tbxAmountAnts";
            this.tbxAmountAnts.Size = new System.Drawing.Size(35, 20);
            this.tbxAmountAnts.TabIndex = 81;
            this.tbxAmountAnts.Text = "3";
            this.tbxAmountAnts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxAmountAnts.TextChanged += new System.EventHandler(this.tbxAmountAnts_TextChanged);
            // 
            // tbxAmountTowns
            // 
            this.tbxAmountTowns.Location = new System.Drawing.Point(20, 115);
            this.tbxAmountTowns.Name = "tbxAmountTowns";
            this.tbxAmountTowns.Size = new System.Drawing.Size(35, 20);
            this.tbxAmountTowns.TabIndex = 80;
            this.tbxAmountTowns.Text = "5";
            this.tbxAmountTowns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxAmountTowns.TextChanged += new System.EventHandler(this.tbxAmountTowns_TextChanged);
            // 
            // lblCycles
            // 
            this.lblCycles.AutoSize = true;
            this.lblCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycles.Location = new System.Drawing.Point(10, 540);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(45, 13);
            this.lblCycles.TabIndex = 79;
            this.lblCycles.Text = "Zyklen";
            // 
            // trbCycles
            // 
            this.trbCycles.LargeChange = 1;
            this.trbCycles.Location = new System.Drawing.Point(60, 553);
            this.trbCycles.Margin = new System.Windows.Forms.Padding(0);
            this.trbCycles.Maximum = 5000;
            this.trbCycles.Minimum = 1;
            this.trbCycles.Name = "trbCycles";
            this.trbCycles.Size = new System.Drawing.Size(155, 45);
            this.trbCycles.TabIndex = 78;
            this.trbCycles.Value = 2;
            this.trbCycles.ValueChanged += new System.EventHandler(this.trbCycles_ValueChanged);
            // 
            // lblWeightDistance
            // 
            this.lblWeightDistance.AutoSize = true;
            this.lblWeightDistance.Location = new System.Drawing.Point(15, 497);
            this.lblWeightDistance.Name = "lblWeightDistance";
            this.lblWeightDistance.Size = new System.Drawing.Size(109, 13);
            this.lblWeightDistance.TabIndex = 77;
            this.lblWeightDistance.Text = "Distanz / Sichtbarkeit";
            // 
            // trbWeightDistance
            // 
            this.trbWeightDistance.LargeChange = 1;
            this.trbWeightDistance.Location = new System.Drawing.Point(60, 510);
            this.trbWeightDistance.Margin = new System.Windows.Forms.Padding(0);
            this.trbWeightDistance.Maximum = 1000;
            this.trbWeightDistance.Minimum = 1;
            this.trbWeightDistance.Name = "trbWeightDistance";
            this.trbWeightDistance.Size = new System.Drawing.Size(155, 45);
            this.trbWeightDistance.TabIndex = 76;
            this.trbWeightDistance.Value = 100;
            this.trbWeightDistance.ValueChanged += new System.EventHandler(this.trbWeightDistance_ValueChanged);
            // 
            // trbWeightPheromone
            // 
            this.trbWeightPheromone.LargeChange = 1;
            this.trbWeightPheromone.Location = new System.Drawing.Point(60, 467);
            this.trbWeightPheromone.Margin = new System.Windows.Forms.Padding(0);
            this.trbWeightPheromone.Maximum = 1000;
            this.trbWeightPheromone.Minimum = 1;
            this.trbWeightPheromone.Name = "trbWeightPheromone";
            this.trbWeightPheromone.Size = new System.Drawing.Size(155, 45);
            this.trbWeightPheromone.TabIndex = 74;
            this.trbWeightPheromone.Value = 100;
            this.trbWeightPheromone.ValueChanged += new System.EventHandler(this.trbWeightPheromone_ValueChanged);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(10, 436);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(200, 13);
            this.lblWeight.TabIndex = 73;
            this.lblWeight.Text = "Gewichtung / Relative Bedeutung";
            // 
            // lblEvaporation
            // 
            this.lblEvaporation.AutoSize = true;
            this.lblEvaporation.Location = new System.Drawing.Point(15, 393);
            this.lblEvaporation.Name = "lblEvaporation";
            this.lblEvaporation.Size = new System.Drawing.Size(117, 13);
            this.lblEvaporation.TabIndex = 72;
            this.lblEvaporation.Text = "Evaporationskoeffizient";
            // 
            // trbEvaporation
            // 
            this.trbEvaporation.LargeChange = 1;
            this.trbEvaporation.Location = new System.Drawing.Point(60, 406);
            this.trbEvaporation.Margin = new System.Windows.Forms.Padding(0);
            this.trbEvaporation.Maximum = 99;
            this.trbEvaporation.Minimum = 1;
            this.trbEvaporation.Name = "trbEvaporation";
            this.trbEvaporation.Size = new System.Drawing.Size(155, 45);
            this.trbEvaporation.TabIndex = 71;
            this.trbEvaporation.Value = 90;
            this.trbEvaporation.ValueChanged += new System.EventHandler(this.trbEvaporation_ValueChanged);
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(15, 307);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(38, 13);
            this.lblStrength.TabIndex = 70;
            this.lblStrength.Text = "Stärke";
            // 
            // trbStrength
            // 
            this.trbStrength.LargeChange = 1;
            this.trbStrength.Location = new System.Drawing.Point(60, 320);
            this.trbStrength.Margin = new System.Windows.Forms.Padding(0);
            this.trbStrength.Maximum = 10000;
            this.trbStrength.Minimum = 1;
            this.trbStrength.Name = "trbStrength";
            this.trbStrength.Size = new System.Drawing.Size(155, 45);
            this.trbStrength.TabIndex = 69;
            this.trbStrength.Value = 100;
            this.trbStrength.ValueChanged += new System.EventHandler(this.trbStrength_ValueChanged);
            // 
            // lblStartPheromone
            // 
            this.lblStartPheromone.AutoSize = true;
            this.lblStartPheromone.Location = new System.Drawing.Point(15, 350);
            this.lblStartPheromone.Name = "lblStartPheromone";
            this.lblStartPheromone.Size = new System.Drawing.Size(49, 13);
            this.lblStartPheromone.TabIndex = 68;
            this.lblStartPheromone.Text = "Startwert";
            // 
            // trbStartPheromone
            // 
            this.trbStartPheromone.LargeChange = 1;
            this.trbStartPheromone.Location = new System.Drawing.Point(60, 363);
            this.trbStartPheromone.Margin = new System.Windows.Forms.Padding(0);
            this.trbStartPheromone.Maximum = 10000;
            this.trbStartPheromone.Minimum = 1;
            this.trbStartPheromone.Name = "trbStartPheromone";
            this.trbStartPheromone.Size = new System.Drawing.Size(155, 45);
            this.trbStartPheromone.TabIndex = 67;
            this.trbStartPheromone.Value = 100;
            this.trbStartPheromone.ValueChanged += new System.EventHandler(this.trbStartPheromone_ValueChanged);
            // 
            // lblPheromone
            // 
            this.lblPheromone.AutoSize = true;
            this.lblPheromone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPheromone.Location = new System.Drawing.Point(10, 289);
            this.lblPheromone.Name = "lblPheromone";
            this.lblPheromone.Size = new System.Drawing.Size(70, 13);
            this.lblPheromone.TabIndex = 66;
            this.lblPheromone.Text = "Pheromone";
            // 
            // cbxSpreadAnts
            // 
            this.cbxSpreadAnts.FormattingEnabled = true;
            this.cbxSpreadAnts.Location = new System.Drawing.Point(20, 263);
            this.cbxSpreadAnts.Name = "cbxSpreadAnts";
            this.cbxSpreadAnts.Size = new System.Drawing.Size(195, 21);
            this.cbxSpreadAnts.TabIndex = 65;
            this.cbxSpreadAnts.SelectedIndexChanged += new System.EventHandler(this.cbxSpreadAnts_SelectedIndexChanged);
            // 
            // lblSpreadAnts
            // 
            this.lblSpreadAnts.AutoSize = true;
            this.lblSpreadAnts.Location = new System.Drawing.Point(15, 245);
            this.lblSpreadAnts.Name = "lblSpreadAnts";
            this.lblSpreadAnts.Size = new System.Drawing.Size(54, 13);
            this.lblSpreadAnts.TabIndex = 64;
            this.lblSpreadAnts.Text = "Verteilung";
            // 
            // lblAmountAnts
            // 
            this.lblAmountAnts.AutoSize = true;
            this.lblAmountAnts.Location = new System.Drawing.Point(15, 202);
            this.lblAmountAnts.Name = "lblAmountAnts";
            this.lblAmountAnts.Size = new System.Drawing.Size(39, 13);
            this.lblAmountAnts.TabIndex = 63;
            this.lblAmountAnts.Text = "Anzahl";
            // 
            // trbAmountAnts
            // 
            this.trbAmountAnts.LargeChange = 1;
            this.trbAmountAnts.Location = new System.Drawing.Point(60, 215);
            this.trbAmountAnts.Margin = new System.Windows.Forms.Padding(0);
            this.trbAmountAnts.Maximum = 200;
            this.trbAmountAnts.Minimum = 1;
            this.trbAmountAnts.Name = "trbAmountAnts";
            this.trbAmountAnts.Size = new System.Drawing.Size(155, 45);
            this.trbAmountAnts.TabIndex = 62;
            this.trbAmountAnts.Value = 3;
            this.trbAmountAnts.ValueChanged += new System.EventHandler(this.trbAmountAnts_ValueChanged);
            // 
            // lblAnts
            // 
            this.lblAnts.AutoSize = true;
            this.lblAnts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnts.Location = new System.Drawing.Point(10, 184);
            this.lblAnts.Name = "lblAnts";
            this.lblAnts.Size = new System.Drawing.Size(54, 13);
            this.lblAnts.TabIndex = 61;
            this.lblAnts.Text = "Ameisen";
            // 
            // cbxSpreadTowns
            // 
            this.cbxSpreadTowns.FormattingEnabled = true;
            this.cbxSpreadTowns.Location = new System.Drawing.Point(20, 158);
            this.cbxSpreadTowns.Name = "cbxSpreadTowns";
            this.cbxSpreadTowns.Size = new System.Drawing.Size(195, 21);
            this.cbxSpreadTowns.TabIndex = 60;
            this.cbxSpreadTowns.SelectedIndexChanged += new System.EventHandler(this.cbxSpreadTowns_SelectedIndexChanged);
            // 
            // lblSpreadTowns
            // 
            this.lblSpreadTowns.AutoSize = true;
            this.lblSpreadTowns.Location = new System.Drawing.Point(15, 140);
            this.lblSpreadTowns.Name = "lblSpreadTowns";
            this.lblSpreadTowns.Size = new System.Drawing.Size(54, 13);
            this.lblSpreadTowns.TabIndex = 59;
            this.lblSpreadTowns.Text = "Verteilung";
            // 
            // lblAmountTowns
            // 
            this.lblAmountTowns.AutoSize = true;
            this.lblAmountTowns.Location = new System.Drawing.Point(15, 97);
            this.lblAmountTowns.Name = "lblAmountTowns";
            this.lblAmountTowns.Size = new System.Drawing.Size(39, 13);
            this.lblAmountTowns.TabIndex = 58;
            this.lblAmountTowns.Text = "Anzahl";
            // 
            // trbAmountTowns
            // 
            this.trbAmountTowns.LargeChange = 1;
            this.trbAmountTowns.Location = new System.Drawing.Point(60, 110);
            this.trbAmountTowns.Margin = new System.Windows.Forms.Padding(0);
            this.trbAmountTowns.Maximum = 100;
            this.trbAmountTowns.Name = "trbAmountTowns";
            this.trbAmountTowns.Size = new System.Drawing.Size(155, 45);
            this.trbAmountTowns.TabIndex = 57;
            this.trbAmountTowns.Value = 5;
            this.trbAmountTowns.ValueChanged += new System.EventHandler(this.trbAmountTowns_ValueChanged);
            // 
            // lblTowns
            // 
            this.lblTowns.AutoSize = true;
            this.lblTowns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTowns.Location = new System.Drawing.Point(10, 79);
            this.lblTowns.Name = "lblTowns";
            this.lblTowns.Size = new System.Drawing.Size(44, 13);
            this.lblTowns.TabIndex = 56;
            this.lblTowns.Text = "Städte";
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(0, 598);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(233, 40);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Durchlauf\r\nmit bekannten Parametern";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRunWithOldP_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(0, 638);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(233, 40);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Durchlauf\r\nmit neuen Parametern";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnRunWithNewP_Click);
            // 
            // spcInformation
            // 
            this.spcInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcInformation.Dock = System.Windows.Forms.DockStyle.Right;
            this.spcInformation.Location = new System.Drawing.Point(835, 0);
            this.spcInformation.Name = "spcInformation";
            this.spcInformation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcInformation.Panel1
            // 
            this.spcInformation.Panel1.AutoScroll = true;
            this.spcInformation.Panel1.Controls.Add(this.pnlAntTabuList);
            this.spcInformation.Panel1.Controls.Add(this.pnlAntPossibilities);
            this.spcInformation.Panel1.Controls.Add(this.pnlAntInfo);
            this.spcInformation.Panel1.Controls.Add(this.pnlShortestPath);
            this.spcInformation.Panel1.Controls.Add(this.pnlIteration);
            this.spcInformation.Panel1.Controls.Add(this.pnlCycle);
            this.spcInformation.Panel1.Controls.Add(this.pnlTime);
            // 
            // spcInformation.Panel2
            // 
            this.spcInformation.Panel2.Controls.Add(this.lbxAnts);
            this.spcInformation.Size = new System.Drawing.Size(173, 680);
            this.spcInformation.SplitterDistance = 520;
            this.spcInformation.TabIndex = 1;
            // 
            // pnlAntTabuList
            // 
            this.pnlAntTabuList.AutoSize = true;
            this.pnlAntTabuList.Controls.Add(this.lblTabu);
            this.pnlAntTabuList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAntTabuList.Location = new System.Drawing.Point(0, 207);
            this.pnlAntTabuList.Name = "pnlAntTabuList";
            this.pnlAntTabuList.Size = new System.Drawing.Size(171, 13);
            this.pnlAntTabuList.TabIndex = 2;
            // 
            // lblTabu
            // 
            this.lblTabu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTabu.Location = new System.Drawing.Point(0, 0);
            this.lblTabu.Name = "lblTabu";
            this.lblTabu.Size = new System.Drawing.Size(171, 13);
            this.lblTabu.TabIndex = 0;
            this.lblTabu.Tag = "";
            this.lblTabu.Text = "Tabuliste";
            // 
            // pnlAntPossibilities
            // 
            this.pnlAntPossibilities.AutoSize = true;
            this.pnlAntPossibilities.Controls.Add(this.lblPossibilities);
            this.pnlAntPossibilities.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAntPossibilities.Location = new System.Drawing.Point(0, 194);
            this.pnlAntPossibilities.Name = "pnlAntPossibilities";
            this.pnlAntPossibilities.Size = new System.Drawing.Size(171, 13);
            this.pnlAntPossibilities.TabIndex = 1;
            // 
            // lblPossibilities
            // 
            this.lblPossibilities.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPossibilities.Location = new System.Drawing.Point(0, 0);
            this.lblPossibilities.Name = "lblPossibilities";
            this.lblPossibilities.Size = new System.Drawing.Size(171, 13);
            this.lblPossibilities.TabIndex = 0;
            this.lblPossibilities.Text = "Wahrscheinlichkeiten";
            // 
            // pnlAntInfo
            // 
            this.pnlAntInfo.AutoScroll = true;
            this.pnlAntInfo.AutoSize = true;
            this.pnlAntInfo.Controls.Add(this.lblCurrentPathLength);
            this.pnlAntInfo.Controls.Add(this.lblCoordinatesDestiny);
            this.pnlAntInfo.Controls.Add(this.lblDestination);
            this.pnlAntInfo.Controls.Add(this.lblCoordinates);
            this.pnlAntInfo.Controls.Add(this.lblCurrentPlace);
            this.pnlAntInfo.Controls.Add(this.lblAntName);
            this.pnlAntInfo.Controls.Add(this.label2);
            this.pnlAntInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAntInfo.Location = new System.Drawing.Point(0, 103);
            this.pnlAntInfo.Name = "pnlAntInfo";
            this.pnlAntInfo.Size = new System.Drawing.Size(171, 91);
            this.pnlAntInfo.TabIndex = 0;
            // 
            // lblCurrentPathLength
            // 
            this.lblCurrentPathLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentPathLength.Location = new System.Drawing.Point(0, 78);
            this.lblCurrentPathLength.Name = "lblCurrentPathLength";
            this.lblCurrentPathLength.Size = new System.Drawing.Size(171, 13);
            this.lblCurrentPathLength.TabIndex = 4;
            this.lblCurrentPathLength.Text = "Länge bisheriger Tour";
            // 
            // lblCoordinatesDestiny
            // 
            this.lblCoordinatesDestiny.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCoordinatesDestiny.Location = new System.Drawing.Point(0, 65);
            this.lblCoordinatesDestiny.Name = "lblCoordinatesDestiny";
            this.lblCoordinatesDestiny.Size = new System.Drawing.Size(171, 13);
            this.lblCoordinatesDestiny.TabIndex = 6;
            this.lblCoordinatesDestiny.Text = "Koordinaten";
            // 
            // lblDestination
            // 
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDestination.Location = new System.Drawing.Point(0, 52);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(171, 13);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "nächstes Ziel";
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCoordinates.Location = new System.Drawing.Point(0, 39);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(171, 13);
            this.lblCoordinates.TabIndex = 2;
            this.lblCoordinates.Text = "Koordinaten";
            // 
            // lblCurrentPlace
            // 
            this.lblCurrentPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentPlace.Location = new System.Drawing.Point(0, 26);
            this.lblCurrentPlace.Name = "lblCurrentPlace";
            this.lblCurrentPlace.Size = new System.Drawing.Size(171, 13);
            this.lblCurrentPlace.TabIndex = 1;
            this.lblCurrentPlace.Text = "aktuelle Stadt";
            // 
            // lblAntName
            // 
            this.lblAntName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAntName.Location = new System.Drawing.Point(0, 13);
            this.lblAntName.Name = "lblAntName";
            this.lblAntName.Size = new System.Drawing.Size(171, 13);
            this.lblAntName.TabIndex = 0;
            this.lblAntName.Text = "ausgewählte Ameise";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "---------------------------------------------------------";
            // 
            // pnlShortestPath
            // 
            this.pnlShortestPath.AutoSize = true;
            this.pnlShortestPath.Controls.Add(this.label3);
            this.pnlShortestPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlShortestPath.Location = new System.Drawing.Point(0, 90);
            this.pnlShortestPath.Name = "pnlShortestPath";
            this.pnlShortestPath.Size = new System.Drawing.Size(171, 13);
            this.pnlShortestPath.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "---------------------------------------------------------";
            // 
            // pnlIteration
            // 
            this.pnlIteration.Controls.Add(this.lblIterationInRound);
            this.pnlIteration.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIteration.Location = new System.Drawing.Point(0, 65);
            this.pnlIteration.Name = "pnlIteration";
            this.pnlIteration.Size = new System.Drawing.Size(171, 25);
            this.pnlIteration.TabIndex = 6;
            // 
            // lblIterationInRound
            // 
            this.lblIterationInRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIterationInRound.Location = new System.Drawing.Point(0, 0);
            this.lblIterationInRound.Name = "lblIterationInRound";
            this.lblIterationInRound.Size = new System.Drawing.Size(171, 25);
            this.lblIterationInRound.TabIndex = 0;
            this.lblIterationInRound.Text = "IterationInRunde";
            this.lblIterationInRound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlCycle
            // 
            this.pnlCycle.Controls.Add(this.lblRound);
            this.pnlCycle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCycle.Location = new System.Drawing.Point(0, 40);
            this.pnlCycle.Name = "pnlCycle";
            this.pnlCycle.Size = new System.Drawing.Size(171, 25);
            this.pnlCycle.TabIndex = 5;
            // 
            // lblRound
            // 
            this.lblRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRound.Location = new System.Drawing.Point(0, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(171, 25);
            this.lblRound.TabIndex = 0;
            this.lblRound.Text = "Runde";
            this.lblRound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlTime
            // 
            this.pnlTime.Controls.Add(this.lblShowTime);
            this.pnlTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTime.Location = new System.Drawing.Point(0, 0);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(171, 40);
            this.pnlTime.TabIndex = 4;
            // 
            // lblShowTime
            // 
            this.lblShowTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShowTime.Location = new System.Drawing.Point(0, 0);
            this.lblShowTime.Name = "lblShowTime";
            this.lblShowTime.Size = new System.Drawing.Size(171, 40);
            this.lblShowTime.TabIndex = 0;
            this.lblShowTime.Text = "Zeitpunkt";
            this.lblShowTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbxAnts
            // 
            this.lbxAnts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxAnts.FormattingEnabled = true;
            this.lbxAnts.Location = new System.Drawing.Point(0, 0);
            this.lbxAnts.Name = "lbxAnts";
            this.lbxAnts.Size = new System.Drawing.Size(171, 154);
            this.lbxAnts.TabIndex = 0;
            this.lbxAnts.Click += new System.EventHandler(this.lbxAnts_Click);
            this.lbxAnts.SelectedIndexChanged += new System.EventHandler(this.lbxAnts_SelectedIndexChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlVisualization);
            this.pnlMain.Controls.Add(this.pnlControl);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(235, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 680);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlVisualization
            // 
            this.pnlVisualization.BackColor = System.Drawing.Color.White;
            this.pnlVisualization.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVisualization.Location = new System.Drawing.Point(0, 0);
            this.pnlVisualization.Name = "pnlVisualization";
            this.pnlVisualization.Size = new System.Drawing.Size(600, 600);
            this.pnlVisualization.TabIndex = 1;
            this.pnlVisualization.SizeChanged += new System.EventHandler(this.pnlVisualization_SizeChanged);
            this.pnlVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.render);
            this.pnlVisualization.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlVisualization_MouseDoubleClick);
            this.pnlVisualization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlVisualization_MouseDown);
            this.pnlVisualization.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlVisualization_MouseMove);
            this.pnlVisualization.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlVisualization_MouseUp);
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.pnlControlIcons);
            this.pnlControl.Controls.Add(this.pnlControlValues);
            this.pnlControl.Controls.Add(this.pnlControlLockAndRoads);
            this.pnlControl.Controls.Add(this.pnlControlProcedure);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 600);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(600, 80);
            this.pnlControl.TabIndex = 0;
            // 
            // pnlControlIcons
            // 
            this.pnlControlIcons.Controls.Add(this.chbNames);
            this.pnlControlIcons.Controls.Add(this.chbAnts);
            this.pnlControlIcons.Controls.Add(this.chbTowns);
            this.pnlControlIcons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlIcons.Location = new System.Drawing.Point(527, 0);
            this.pnlControlIcons.Name = "pnlControlIcons";
            this.pnlControlIcons.Size = new System.Drawing.Size(78, 78);
            this.pnlControlIcons.TabIndex = 3;
            // 
            // chbNames
            // 
            this.chbNames.Checked = true;
            this.chbNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNames.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbNames.Location = new System.Drawing.Point(0, 52);
            this.chbNames.Name = "chbNames";
            this.chbNames.Size = new System.Drawing.Size(78, 26);
            this.chbNames.TabIndex = 2;
            this.chbNames.Text = "Namen";
            this.chbNames.UseVisualStyleBackColor = true;
            this.chbNames.CheckedChanged += new System.EventHandler(this.chbNames_CheckedChanged);
            // 
            // chbAnts
            // 
            this.chbAnts.Checked = true;
            this.chbAnts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAnts.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbAnts.Location = new System.Drawing.Point(0, 26);
            this.chbAnts.Name = "chbAnts";
            this.chbAnts.Size = new System.Drawing.Size(78, 26);
            this.chbAnts.TabIndex = 1;
            this.chbAnts.Text = "Ameisen";
            this.chbAnts.UseVisualStyleBackColor = true;
            this.chbAnts.CheckedChanged += new System.EventHandler(this.chbAnts_CheckedChanged);
            // 
            // chbTowns
            // 
            this.chbTowns.Checked = true;
            this.chbTowns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTowns.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbTowns.Location = new System.Drawing.Point(0, 0);
            this.chbTowns.Name = "chbTowns";
            this.chbTowns.Size = new System.Drawing.Size(78, 26);
            this.chbTowns.TabIndex = 0;
            this.chbTowns.Text = "Städte";
            this.chbTowns.UseVisualStyleBackColor = true;
            this.chbTowns.CheckedChanged += new System.EventHandler(this.chbTowns_CheckedChanged);
            // 
            // pnlControlValues
            // 
            this.pnlControlValues.Controls.Add(this.chbCoordinates);
            this.pnlControlValues.Controls.Add(this.chbDistance);
            this.pnlControlValues.Controls.Add(this.chbPheromone);
            this.pnlControlValues.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlValues.Location = new System.Drawing.Point(440, 0);
            this.pnlControlValues.Name = "pnlControlValues";
            this.pnlControlValues.Size = new System.Drawing.Size(87, 78);
            this.pnlControlValues.TabIndex = 2;
            // 
            // chbCoordinates
            // 
            this.chbCoordinates.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbCoordinates.Location = new System.Drawing.Point(0, 52);
            this.chbCoordinates.Name = "chbCoordinates";
            this.chbCoordinates.Size = new System.Drawing.Size(87, 26);
            this.chbCoordinates.TabIndex = 9;
            this.chbCoordinates.Text = "Koordinaten";
            this.chbCoordinates.UseVisualStyleBackColor = true;
            this.chbCoordinates.CheckedChanged += new System.EventHandler(this.chbCoordinates_CheckedChanged);
            // 
            // chbDistance
            // 
            this.chbDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbDistance.Location = new System.Drawing.Point(0, 26);
            this.chbDistance.Name = "chbDistance";
            this.chbDistance.Size = new System.Drawing.Size(87, 26);
            this.chbDistance.TabIndex = 7;
            this.chbDistance.Text = "Distanzen";
            this.chbDistance.UseVisualStyleBackColor = true;
            this.chbDistance.CheckedChanged += new System.EventHandler(this.chbDistance_CheckedChanged);
            // 
            // chbPheromone
            // 
            this.chbPheromone.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbPheromone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPheromone.Location = new System.Drawing.Point(0, 0);
            this.chbPheromone.Name = "chbPheromone";
            this.chbPheromone.Size = new System.Drawing.Size(87, 26);
            this.chbPheromone.TabIndex = 8;
            this.chbPheromone.Text = "Pheromone";
            this.chbPheromone.UseVisualStyleBackColor = true;
            this.chbPheromone.CheckedChanged += new System.EventHandler(this.chbPheromone_CheckedChanged);
            // 
            // pnlControlLockAndRoads
            // 
            this.pnlControlLockAndRoads.Controls.Add(this.chbSolution);
            this.pnlControlLockAndRoads.Controls.Add(this.chbTrail);
            this.pnlControlLockAndRoads.Controls.Add(this.chbLock);
            this.pnlControlLockAndRoads.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlLockAndRoads.Location = new System.Drawing.Point(370, 0);
            this.pnlControlLockAndRoads.Name = "pnlControlLockAndRoads";
            this.pnlControlLockAndRoads.Size = new System.Drawing.Size(70, 78);
            this.pnlControlLockAndRoads.TabIndex = 1;
            // 
            // chbSolution
            // 
            this.chbSolution.Checked = true;
            this.chbSolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbSolution.Location = new System.Drawing.Point(0, 52);
            this.chbSolution.Name = "chbSolution";
            this.chbSolution.Size = new System.Drawing.Size(70, 26);
            this.chbSolution.TabIndex = 8;
            this.chbSolution.Text = "Lösung";
            this.chbSolution.UseVisualStyleBackColor = true;
            this.chbSolution.CheckedChanged += new System.EventHandler(this.chbSolution_CheckedChanged);
            // 
            // chbTrail
            // 
            this.chbTrail.Checked = true;
            this.chbTrail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTrail.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbTrail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTrail.Location = new System.Drawing.Point(0, 26);
            this.chbTrail.Name = "chbTrail";
            this.chbTrail.Size = new System.Drawing.Size(70, 26);
            this.chbTrail.TabIndex = 6;
            this.chbTrail.Text = "Spuren";
            this.chbTrail.UseVisualStyleBackColor = true;
            this.chbTrail.CheckedChanged += new System.EventHandler(this.chbTrail_CheckedChanged);
            // 
            // chbLock
            // 
            this.chbLock.Checked = true;
            this.chbLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLock.Location = new System.Drawing.Point(0, 0);
            this.chbLock.Name = "chbLock";
            this.chbLock.Size = new System.Drawing.Size(70, 26);
            this.chbLock.TabIndex = 7;
            this.chbLock.Text = "Sperre";
            this.chbLock.UseVisualStyleBackColor = true;
            this.chbLock.CheckedChanged += new System.EventHandler(this.chbLock_CheckedChanged);
            // 
            // pnlControlProcedure
            // 
            this.pnlControlProcedure.Controls.Add(this.pnlControlLeftDown);
            this.pnlControlProcedure.Controls.Add(this.pnlControlLeftTop);
            this.pnlControlProcedure.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlProcedure.Location = new System.Drawing.Point(0, 0);
            this.pnlControlProcedure.Name = "pnlControlProcedure";
            this.pnlControlProcedure.Size = new System.Drawing.Size(370, 78);
            this.pnlControlProcedure.TabIndex = 0;
            // 
            // pnlControlLeftDown
            // 
            this.pnlControlLeftDown.Controls.Add(this.btnToTheStart);
            this.pnlControlLeftDown.Controls.Add(this.btnPrevRound);
            this.pnlControlLeftDown.Controls.Add(this.btnPrevIt);
            this.pnlControlLeftDown.Controls.Add(this.btnPause);
            this.pnlControlLeftDown.Controls.Add(this.trbSpeed);
            this.pnlControlLeftDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlLeftDown.Location = new System.Drawing.Point(0, 40);
            this.pnlControlLeftDown.Name = "pnlControlLeftDown";
            this.pnlControlLeftDown.Size = new System.Drawing.Size(370, 38);
            this.pnlControlLeftDown.TabIndex = 1;
            // 
            // btnToTheStart
            // 
            this.btnToTheStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToTheStart.Location = new System.Drawing.Point(305, 0);
            this.btnToTheStart.Name = "btnToTheStart";
            this.btnToTheStart.Size = new System.Drawing.Size(55, 38);
            this.btnToTheStart.TabIndex = 5;
            this.btnToTheStart.Text = "zum Anfang";
            this.btnToTheStart.UseVisualStyleBackColor = true;
            this.btnToTheStart.Click += new System.EventHandler(this.btnToTheStart_Click);
            // 
            // btnPrevRound
            // 
            this.btnPrevRound.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrevRound.Location = new System.Drawing.Point(250, 0);
            this.btnPrevRound.Name = "btnPrevRound";
            this.btnPrevRound.Size = new System.Drawing.Size(55, 38);
            this.btnPrevRound.TabIndex = 4;
            this.btnPrevRound.Text = "Zyklus zurück";
            this.btnPrevRound.UseVisualStyleBackColor = true;
            this.btnPrevRound.Click += new System.EventHandler(this.btnPrevCycle_Click);
            // 
            // btnPrevIt
            // 
            this.btnPrevIt.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrevIt.Location = new System.Drawing.Point(195, 0);
            this.btnPrevIt.Name = "btnPrevIt";
            this.btnPrevIt.Size = new System.Drawing.Size(55, 38);
            this.btnPrevIt.TabIndex = 3;
            this.btnPrevIt.Text = "Iteration zurück";
            this.btnPrevIt.UseVisualStyleBackColor = true;
            this.btnPrevIt.Click += new System.EventHandler(this.btnPrevIt_Click);
            // 
            // btnPause
            // 
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPause.Location = new System.Drawing.Point(140, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(55, 38);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Stop";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // trbSpeed
            // 
            this.trbSpeed.Dock = System.Windows.Forms.DockStyle.Left;
            this.trbSpeed.Location = new System.Drawing.Point(0, 0);
            this.trbSpeed.Maximum = 500;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(140, 38);
            this.trbSpeed.TabIndex = 0;
            this.trbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trbSpeed.Value = 100;
            this.trbSpeed.ValueChanged += new System.EventHandler(this.trbSpeed_ValueChanged);
            // 
            // pnlControlLeftTop
            // 
            this.pnlControlLeftTop.Controls.Add(this.btnToTheEnd);
            this.pnlControlLeftTop.Controls.Add(this.btnNextRound);
            this.pnlControlLeftTop.Controls.Add(this.btnNextIt);
            this.pnlControlLeftTop.Controls.Add(this.btnPlay);
            this.pnlControlLeftTop.Controls.Add(this.pnlControlLeftGap);
            this.pnlControlLeftTop.Controls.Add(this.lblSpeed);
            this.pnlControlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlControlLeftTop.Name = "pnlControlLeftTop";
            this.pnlControlLeftTop.Size = new System.Drawing.Size(370, 40);
            this.pnlControlLeftTop.TabIndex = 0;
            // 
            // btnToTheEnd
            // 
            this.btnToTheEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToTheEnd.Location = new System.Drawing.Point(305, 0);
            this.btnToTheEnd.Name = "btnToTheEnd";
            this.btnToTheEnd.Size = new System.Drawing.Size(55, 40);
            this.btnToTheEnd.TabIndex = 6;
            this.btnToTheEnd.Text = "zum Ende";
            this.btnToTheEnd.UseVisualStyleBackColor = true;
            this.btnToTheEnd.Click += new System.EventHandler(this.btnToTheEnd_Click);
            // 
            // btnNextRound
            // 
            this.btnNextRound.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNextRound.Location = new System.Drawing.Point(250, 0);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(55, 40);
            this.btnNextRound.TabIndex = 5;
            this.btnNextRound.Text = "Zyklus vorwärts";
            this.btnNextRound.UseVisualStyleBackColor = true;
            this.btnNextRound.Click += new System.EventHandler(this.btnNextCycle_Click);
            // 
            // btnNextIt
            // 
            this.btnNextIt.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNextIt.Location = new System.Drawing.Point(195, 0);
            this.btnNextIt.Name = "btnNextIt";
            this.btnNextIt.Size = new System.Drawing.Size(55, 40);
            this.btnNextIt.TabIndex = 4;
            this.btnNextIt.Text = "Iteration vorwärts";
            this.btnNextIt.UseVisualStyleBackColor = true;
            this.btnNextIt.Click += new System.EventHandler(this.btnNextIt_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.Location = new System.Drawing.Point(140, 0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(55, 40);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Los";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pnlControlLeftGap
            // 
            this.pnlControlLeftGap.Controls.Add(this.tbxSpeed);
            this.pnlControlLeftGap.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControlLeftGap.Location = new System.Drawing.Point(100, 0);
            this.pnlControlLeftGap.Name = "pnlControlLeftGap";
            this.pnlControlLeftGap.Size = new System.Drawing.Size(40, 40);
            this.pnlControlLeftGap.TabIndex = 93;
            // 
            // tbxSpeed
            // 
            this.tbxSpeed.Location = new System.Drawing.Point(0, 12);
            this.tbxSpeed.Name = "tbxSpeed";
            this.tbxSpeed.Size = new System.Drawing.Size(35, 20);
            this.tbxSpeed.TabIndex = 92;
            this.tbxSpeed.Text = "2,00";
            this.tbxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSpeed.TextChanged += new System.EventHandler(this.tbxSpeed_TextChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(0, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(100, 40);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "Geschwindigkeit:";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer
            // 
            this.timer.Interval = 16;
            this.timer.Tick += new System.EventHandler(this.update);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 680);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.spcInformation);
            this.Controls.Add(this.pnlSelection);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 719);
            this.Name = "GUI";
            this.Text = "GreedyAnts";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GUI_KeyDown);
            this.pnlSelection.ResumeLayout(false);
            this.pnlSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWeightPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbEvaporation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbStartPheromone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountAnts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAmountTowns)).EndInit();
            this.spcInformation.Panel1.ResumeLayout(false);
            this.spcInformation.Panel1.PerformLayout();
            this.spcInformation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcInformation)).EndInit();
            this.spcInformation.ResumeLayout(false);
            this.pnlAntTabuList.ResumeLayout(false);
            this.pnlAntPossibilities.ResumeLayout(false);
            this.pnlAntInfo.ResumeLayout(false);
            this.pnlShortestPath.ResumeLayout(false);
            this.pnlShortestPath.PerformLayout();
            this.pnlIteration.ResumeLayout(false);
            this.pnlCycle.ResumeLayout(false);
            this.pnlTime.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControlIcons.ResumeLayout(false);
            this.pnlControlValues.ResumeLayout(false);
            this.pnlControlLockAndRoads.ResumeLayout(false);
            this.pnlControlProcedure.ResumeLayout(false);
            this.pnlControlLeftDown.ResumeLayout(false);
            this.pnlControlLeftDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            this.pnlControlLeftTop.ResumeLayout(false);
            this.pnlControlLeftGap.ResumeLayout(false);
            this.pnlControlLeftGap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelection;
        private System.Windows.Forms.SplitContainer spcInformation;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlVisualization;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlAntPossibilities;
        private System.Windows.Forms.Panel pnlAntInfo;
        private System.Windows.Forms.Panel pnlAntTabuList;
        private System.Windows.Forms.Label lblPossibilities;
        private System.Windows.Forms.Label lblAntName;
        private System.Windows.Forms.Panel pnlControlLeftDown;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Panel pnlControlLeftTop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnToTheStart;
        private System.Windows.Forms.Button btnPrevRound;
        private System.Windows.Forms.Button btnPrevIt;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnToTheEnd;
        private System.Windows.Forms.Button btnNextRound;
        private System.Windows.Forms.Button btnNextIt;
        private System.Windows.Forms.CheckBox chbDistance;
        private System.Windows.Forms.CheckBox chbTrail;
        private System.Windows.Forms.CheckBox chbPheromone;
        private System.Windows.Forms.CheckBox chbLock;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnlControlValues;
        private System.Windows.Forms.CheckBox chbCoordinates;
        private System.Windows.Forms.Panel pnlControlLockAndRoads;
        private System.Windows.Forms.CheckBox chbSolution;
        private System.Windows.Forms.Panel pnlControlProcedure;
        private System.Windows.Forms.CheckBox chbExample;
        private System.Windows.Forms.ComboBox cbxArt;
        private System.Windows.Forms.Label lblArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCycles;
        private System.Windows.Forms.TextBox tbxWeightPheromone;
        private System.Windows.Forms.TextBox tbxWeightDistance;
        private System.Windows.Forms.TextBox tbxEvaporation;
        private System.Windows.Forms.TextBox tbxStartPheromone;
        private System.Windows.Forms.TextBox tbxStrength;
        private System.Windows.Forms.TextBox tbxAmountAnts;
        private System.Windows.Forms.TextBox tbxAmountTowns;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.TrackBar trbCycles;
        private System.Windows.Forms.Label lblWeightDistance;
        private System.Windows.Forms.TrackBar trbWeightDistance;
        private System.Windows.Forms.Label lblWeightPheromone;
        private System.Windows.Forms.TrackBar trbWeightPheromone;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblEvaporation;
        private System.Windows.Forms.TrackBar trbEvaporation;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.TrackBar trbStrength;
        private System.Windows.Forms.Label lblStartPheromone;
        private System.Windows.Forms.TrackBar trbStartPheromone;
        private System.Windows.Forms.Label lblPheromone;
        private System.Windows.Forms.ComboBox cbxSpreadAnts;
        private System.Windows.Forms.Label lblSpreadAnts;
        private System.Windows.Forms.Label lblAmountAnts;
        private System.Windows.Forms.TrackBar trbAmountAnts;
        private System.Windows.Forms.Label lblAnts;
        private System.Windows.Forms.ComboBox cbxSpreadTowns;
        private System.Windows.Forms.Label lblSpreadTowns;
        private System.Windows.Forms.Label lblAmountTowns;
        private System.Windows.Forms.TrackBar trbAmountTowns;
        private System.Windows.Forms.Label lblTowns;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlControlLeftGap;
        private System.Windows.Forms.TextBox tbxSpeed;
        public System.Windows.Forms.ListBox lbxAnts;
        private System.Windows.Forms.Panel pnlShortestPath;
        private System.Windows.Forms.Panel pnlControlIcons;
        private System.Windows.Forms.CheckBox chbNames;
        private System.Windows.Forms.CheckBox chbAnts;
        private System.Windows.Forms.CheckBox chbTowns;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Label lblShowTime;
        private System.Windows.Forms.Panel pnlIteration;
        private System.Windows.Forms.Label lblIterationInRound;
        private System.Windows.Forms.Panel pnlCycle;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblCurrentPlace;
        private System.Windows.Forms.Label lblCurrentPathLength;
        private System.Windows.Forms.Label lblTabu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCoordinatesDestiny;
    }
}

