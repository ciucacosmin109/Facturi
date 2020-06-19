namespace Facturi
{
    partial class MeniuPrincipal
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
            this.conturiLV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.facturiLV = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filtrareBanca = new System.Windows.Forms.Button();
            this.resetFiltreConturiButton = new System.Windows.Forms.Button();
            this.filtrareMonedaC = new System.Windows.Forms.Button();
            this.filtrareSold = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filtrareSumaDePlata = new System.Windows.Forms.Button();
            this.resetFiltreFacturiButton = new System.Windows.Forms.Button();
            this.filtrareMonedaF = new System.Windows.Forms.Button();
            this.filtrareDataS = new System.Windows.Forms.Button();
            this.filtrareDataE = new System.Windows.Forms.Button();
            this.filtrareSumaTotala = new System.Windows.Forms.Button();
            this.filtrarePrioritate = new System.Windows.Forms.Button();
            this.filtrareFurnizor = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.ordonareFacturiCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.conturiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importaSolduricsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaContToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bancaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizeazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaFacturiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.furnizoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizeazaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.conturiSplitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonTranz = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conturiSplitContainer)).BeginInit();
            this.conturiSplitContainer.Panel1.SuspendLayout();
            this.conturiSplitContainer.Panel2.SuspendLayout();
            this.conturiSplitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conturiLV
            // 
            this.conturiLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conturiLV.CheckBoxes = true;
            this.conturiLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader11,
            this.columnHeader3,
            this.columnHeader4});
            this.conturiLV.FullRowSelect = true;
            this.conturiLV.GridLines = true;
            this.conturiLV.HideSelection = false;
            this.conturiLV.Location = new System.Drawing.Point(3, 45);
            this.conturiLV.Name = "conturiLV";
            this.conturiLV.Size = new System.Drawing.Size(606, 106);
            this.conturiLV.TabIndex = 0;
            this.conturiLV.UseCompatibleStateImageBehavior = false;
            this.conturiLV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IBAN";
            this.columnHeader1.Width = 144;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sold";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "La data";
            this.columnHeader11.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Moneda";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nume Banca";
            this.columnHeader4.Width = 110;
            // 
            // facturiLV
            // 
            this.facturiLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.facturiLV.CheckBoxes = true;
            this.facturiLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.facturiLV.FullRowSelect = true;
            this.facturiLV.GridLines = true;
            this.facturiLV.HideSelection = false;
            this.facturiLV.Location = new System.Drawing.Point(3, 48);
            this.facturiLV.Name = "facturiLV";
            this.facturiLV.Size = new System.Drawing.Size(779, 109);
            this.facturiLV.TabIndex = 1;
            this.facturiLV.UseCompatibleStateImageBehavior = false;
            this.facturiLV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nume furnizor";
            this.columnHeader5.Width = 192;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Prioritate";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 56;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Suma totala";
            this.columnHeader12.Width = 79;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Suma de plata";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 86;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Moneda";
            this.columnHeader7.Width = 51;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Data emitere";
            this.columnHeader8.Width = 79;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Data scadenta";
            this.columnHeader9.Width = 83;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filtrareBanca);
            this.groupBox1.Controls.Add(this.resetFiltreConturiButton);
            this.groupBox1.Controls.Add(this.filtrareMonedaC);
            this.groupBox1.Controls.Add(this.filtrareSold);
            this.groupBox1.Controls.Add(this.conturiLV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 166);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conturi";
            // 
            // filtrareBanca
            // 
            this.filtrareBanca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareBanca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareBanca.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareBanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareBanca.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareBanca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareBanca.Location = new System.Drawing.Point(174, 16);
            this.filtrareBanca.Name = "filtrareBanca";
            this.filtrareBanca.Size = new System.Drawing.Size(80, 23);
            this.filtrareBanca.TabIndex = 5;
            this.filtrareBanca.Text = "Banca";
            this.filtrareBanca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareBanca.UseVisualStyleBackColor = true;
            this.filtrareBanca.Click += new System.EventHandler(this.filtrareBanca_Click);
            // 
            // resetFiltreConturiButton
            // 
            this.resetFiltreConturiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.resetFiltreConturiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetFiltreConturiButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.resetFiltreConturiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetFiltreConturiButton.ForeColor = System.Drawing.Color.Red;
            this.resetFiltreConturiButton.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.resetFiltreConturiButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetFiltreConturiButton.Location = new System.Drawing.Point(284, 16);
            this.resetFiltreConturiButton.Name = "resetFiltreConturiButton";
            this.resetFiltreConturiButton.Size = new System.Drawing.Size(48, 23);
            this.resetFiltreConturiButton.TabIndex = 6;
            this.resetFiltreConturiButton.Text = "X";
            this.resetFiltreConturiButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.resetFiltreConturiButton.UseVisualStyleBackColor = true;
            this.resetFiltreConturiButton.Click += new System.EventHandler(this.resetFiltreConturiButton_Click);
            // 
            // filtrareMonedaC
            // 
            this.filtrareMonedaC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareMonedaC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareMonedaC.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareMonedaC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareMonedaC.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareMonedaC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareMonedaC.Location = new System.Drawing.Point(84, 16);
            this.filtrareMonedaC.Name = "filtrareMonedaC";
            this.filtrareMonedaC.Size = new System.Drawing.Size(84, 23);
            this.filtrareMonedaC.TabIndex = 4;
            this.filtrareMonedaC.Text = "Moneda";
            this.filtrareMonedaC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareMonedaC.UseVisualStyleBackColor = true;
            this.filtrareMonedaC.Click += new System.EventHandler(this.filtrareMonedaC_Click);
            // 
            // filtrareSold
            // 
            this.filtrareSold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareSold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareSold.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareSold.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareSold.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareSold.Location = new System.Drawing.Point(3, 16);
            this.filtrareSold.Name = "filtrareSold";
            this.filtrareSold.Size = new System.Drawing.Size(75, 23);
            this.filtrareSold.TabIndex = 3;
            this.filtrareSold.Text = "Sold";
            this.filtrareSold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareSold.UseVisualStyleBackColor = true;
            this.filtrareSold.Click += new System.EventHandler(this.filtrareSold_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filtrareSumaDePlata);
            this.groupBox2.Controls.Add(this.resetFiltreFacturiButton);
            this.groupBox2.Controls.Add(this.filtrareMonedaF);
            this.groupBox2.Controls.Add(this.filtrareDataS);
            this.groupBox2.Controls.Add(this.filtrareDataE);
            this.groupBox2.Controls.Add(this.filtrareSumaTotala);
            this.groupBox2.Controls.Add(this.filtrarePrioritate);
            this.groupBox2.Controls.Add(this.filtrareFurnizor);
            this.groupBox2.Controls.Add(this.facturiLV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 173);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Facturi";
            // 
            // filtrareSumaDePlata
            // 
            this.filtrareSumaDePlata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareSumaDePlata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareSumaDePlata.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareSumaDePlata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareSumaDePlata.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareSumaDePlata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareSumaDePlata.Location = new System.Drawing.Point(284, 19);
            this.filtrareSumaDePlata.Name = "filtrareSumaDePlata";
            this.filtrareSumaDePlata.Size = new System.Drawing.Size(113, 23);
            this.filtrareSumaDePlata.TabIndex = 14;
            this.filtrareSumaDePlata.Text = "Suma de plata";
            this.filtrareSumaDePlata.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareSumaDePlata.UseVisualStyleBackColor = true;
            this.filtrareSumaDePlata.Click += new System.EventHandler(this.filtrareSumaDePlata_Click);
            // 
            // resetFiltreFacturiButton
            // 
            this.resetFiltreFacturiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.resetFiltreFacturiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetFiltreFacturiButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.resetFiltreFacturiButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetFiltreFacturiButton.ForeColor = System.Drawing.Color.Red;
            this.resetFiltreFacturiButton.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.resetFiltreFacturiButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetFiltreFacturiButton.Location = new System.Drawing.Point(733, 19);
            this.resetFiltreFacturiButton.Name = "resetFiltreFacturiButton";
            this.resetFiltreFacturiButton.Size = new System.Drawing.Size(48, 23);
            this.resetFiltreFacturiButton.TabIndex = 13;
            this.resetFiltreFacturiButton.Text = "X";
            this.resetFiltreFacturiButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.resetFiltreFacturiButton.UseVisualStyleBackColor = true;
            this.resetFiltreFacturiButton.Click += new System.EventHandler(this.resetFiltreFacturiButton_Click);
            // 
            // filtrareMonedaF
            // 
            this.filtrareMonedaF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareMonedaF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareMonedaF.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareMonedaF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareMonedaF.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareMonedaF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareMonedaF.Location = new System.Drawing.Point(403, 19);
            this.filtrareMonedaF.Name = "filtrareMonedaF";
            this.filtrareMonedaF.Size = new System.Drawing.Size(81, 23);
            this.filtrareMonedaF.TabIndex = 6;
            this.filtrareMonedaF.Text = "Moneda";
            this.filtrareMonedaF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareMonedaF.UseVisualStyleBackColor = true;
            this.filtrareMonedaF.Click += new System.EventHandler(this.filtrareMonedaF_Click);
            // 
            // filtrareDataS
            // 
            this.filtrareDataS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareDataS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareDataS.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareDataS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareDataS.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareDataS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareDataS.Location = new System.Drawing.Point(597, 19);
            this.filtrareDataS.Name = "filtrareDataS";
            this.filtrareDataS.Size = new System.Drawing.Size(107, 23);
            this.filtrareDataS.TabIndex = 6;
            this.filtrareDataS.Text = "Data scadeta";
            this.filtrareDataS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareDataS.UseVisualStyleBackColor = true;
            this.filtrareDataS.Click += new System.EventHandler(this.filtrareDataS_Click);
            // 
            // filtrareDataE
            // 
            this.filtrareDataE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareDataE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareDataE.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareDataE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareDataE.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareDataE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareDataE.Location = new System.Drawing.Point(490, 19);
            this.filtrareDataE.Name = "filtrareDataE";
            this.filtrareDataE.Size = new System.Drawing.Size(101, 23);
            this.filtrareDataE.TabIndex = 5;
            this.filtrareDataE.Text = "Data emitere";
            this.filtrareDataE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareDataE.UseVisualStyleBackColor = true;
            this.filtrareDataE.Click += new System.EventHandler(this.filtrareDataE_Click);
            // 
            // filtrareSumaTotala
            // 
            this.filtrareSumaTotala.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareSumaTotala.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareSumaTotala.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareSumaTotala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareSumaTotala.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareSumaTotala.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareSumaTotala.Location = new System.Drawing.Point(183, 19);
            this.filtrareSumaTotala.Name = "filtrareSumaTotala";
            this.filtrareSumaTotala.Size = new System.Drawing.Size(95, 23);
            this.filtrareSumaTotala.TabIndex = 4;
            this.filtrareSumaTotala.Text = "Suma totala";
            this.filtrareSumaTotala.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareSumaTotala.UseVisualStyleBackColor = true;
            this.filtrareSumaTotala.Click += new System.EventHandler(this.filtrareSumaTotala_Click);
            // 
            // filtrarePrioritate
            // 
            this.filtrarePrioritate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrarePrioritate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrarePrioritate.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrarePrioritate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrarePrioritate.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrarePrioritate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrarePrioritate.Location = new System.Drawing.Point(94, 19);
            this.filtrarePrioritate.Name = "filtrarePrioritate";
            this.filtrarePrioritate.Size = new System.Drawing.Size(83, 23);
            this.filtrarePrioritate.TabIndex = 3;
            this.filtrarePrioritate.Text = "Prioritate";
            this.filtrarePrioritate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrarePrioritate.UseVisualStyleBackColor = true;
            this.filtrarePrioritate.Click += new System.EventHandler(this.filtrarePrioritate_Click);
            // 
            // filtrareFurnizor
            // 
            this.filtrareFurnizor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filtrareFurnizor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filtrareFurnizor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.filtrareFurnizor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrareFurnizor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filtrareFurnizor.Image = global::Facturi.Properties.Resources.Filter_Icon_26x25;
            this.filtrareFurnizor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filtrareFurnizor.Location = new System.Drawing.Point(3, 19);
            this.filtrareFurnizor.Name = "filtrareFurnizor";
            this.filtrareFurnizor.Size = new System.Drawing.Size(85, 23);
            this.filtrareFurnizor.TabIndex = 2;
            this.filtrareFurnizor.Text = "Furnizor";
            this.filtrareFurnizor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filtrareFurnizor.UseVisualStyleBackColor = true;
            this.filtrareFurnizor.Click += new System.EventHandler(this.filtrareFurnizor_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(13, 59);
            this.nextButton.MinimumSize = new System.Drawing.Size(146, 23);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(148, 23);
            this.nextButton.TabIndex = 10;
            this.nextButton.Text = "Next >";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // ordonareFacturiCB
            // 
            this.ordonareFacturiCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordonareFacturiCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ordonareFacturiCB.FormattingEnabled = true;
            this.ordonareFacturiCB.Items.AddRange(new object[] {
            "Prioritate",
            "Data scadenta",
            "Valoare"});
            this.ordonareFacturiCB.Location = new System.Drawing.Point(13, 32);
            this.ordonareFacturiCB.MinimumSize = new System.Drawing.Size(146, 0);
            this.ordonareFacturiCB.Name = "ordonareFacturiCB";
            this.ordonareFacturiCB.Size = new System.Drawing.Size(148, 21);
            this.ordonareFacturiCB.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Criteriu de analizare a facturilor";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.conturiToolStripMenuItem1,
            this.facturiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // conturiToolStripMenuItem1
            // 
            this.conturiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importaSolduricsvToolStripMenuItem,
            this.adaugaContToolStripMenuItem,
            this.toolStripMenuItem2,
            this.bancaToolStripMenuItem});
            this.conturiToolStripMenuItem1.Name = "conturiToolStripMenuItem1";
            this.conturiToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.conturiToolStripMenuItem1.Text = "&Conturi";
            // 
            // importaSolduricsvToolStripMenuItem
            // 
            this.importaSolduricsvToolStripMenuItem.Name = "importaSolduricsvToolStripMenuItem";
            this.importaSolduricsvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importaSolduricsvToolStripMenuItem.Text = "Importa solduri";
            this.importaSolduricsvToolStripMenuItem.Click += new System.EventHandler(this.importaSolduricsvToolStripMenuItem_Click);
            // 
            // adaugaContToolStripMenuItem
            // 
            this.adaugaContToolStripMenuItem.Name = "adaugaContToolStripMenuItem";
            this.adaugaContToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adaugaContToolStripMenuItem.Text = "Adauga cont";
            this.adaugaContToolStripMenuItem.Click += new System.EventHandler(this.adaugaContToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // bancaToolStripMenuItem
            // 
            this.bancaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaToolStripMenuItem,
            this.vizualizeazaToolStripMenuItem});
            this.bancaToolStripMenuItem.Enabled = false;
            this.bancaToolStripMenuItem.Name = "bancaToolStripMenuItem";
            this.bancaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bancaToolStripMenuItem.Text = "Banca";
            // 
            // adaugaToolStripMenuItem
            // 
            this.adaugaToolStripMenuItem.Name = "adaugaToolStripMenuItem";
            this.adaugaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.adaugaToolStripMenuItem.Text = "Adauga";
            // 
            // vizualizeazaToolStripMenuItem
            // 
            this.vizualizeazaToolStripMenuItem.Name = "vizualizeazaToolStripMenuItem";
            this.vizualizeazaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.vizualizeazaToolStripMenuItem.Text = "Vizualizeaza";
            // 
            // facturiToolStripMenuItem
            // 
            this.facturiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importaFacturiToolStripMenuItem,
            this.adaugaFacturaToolStripMenuItem,
            this.toolStripMenuItem3,
            this.furnizoriToolStripMenuItem});
            this.facturiToolStripMenuItem.Name = "facturiToolStripMenuItem";
            this.facturiToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.facturiToolStripMenuItem.Text = "&Facturi";
            // 
            // importaFacturiToolStripMenuItem
            // 
            this.importaFacturiToolStripMenuItem.Name = "importaFacturiToolStripMenuItem";
            this.importaFacturiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importaFacturiToolStripMenuItem.Text = "Importa facturi";
            this.importaFacturiToolStripMenuItem.Click += new System.EventHandler(this.importaFacturiToolStripMenuItem_Click);
            // 
            // adaugaFacturaToolStripMenuItem
            // 
            this.adaugaFacturaToolStripMenuItem.Name = "adaugaFacturaToolStripMenuItem";
            this.adaugaFacturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adaugaFacturaToolStripMenuItem.Text = "Adauga factura";
            this.adaugaFacturaToolStripMenuItem.Click += new System.EventHandler(this.adaugaFacturaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // furnizoriToolStripMenuItem
            // 
            this.furnizoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaToolStripMenuItem2,
            this.vizualizeazaToolStripMenuItem2});
            this.furnizoriToolStripMenuItem.Name = "furnizoriToolStripMenuItem";
            this.furnizoriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.furnizoriToolStripMenuItem.Text = "Furnizori";
            // 
            // adaugaToolStripMenuItem2
            // 
            this.adaugaToolStripMenuItem2.Name = "adaugaToolStripMenuItem2";
            this.adaugaToolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.adaugaToolStripMenuItem2.Text = "Adauga";
            this.adaugaToolStripMenuItem2.Click += new System.EventHandler(this.adaugaToolStripMenuItem2_Click);
            // 
            // vizualizeazaToolStripMenuItem2
            // 
            this.vizualizeazaToolStripMenuItem2.Name = "vizualizeazaToolStripMenuItem2";
            this.vizualizeazaToolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.vizualizeazaToolStripMenuItem2.Text = "Vizualizeaza";
            this.vizualizeazaToolStripMenuItem2.Click += new System.EventHandler(this.vizualizeazaToolStripMenuItem2_Click);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.conturiSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.groupBox2);
            this.MainSplitContainer.Size = new System.Drawing.Size(788, 343);
            this.MainSplitContainer.SplitterDistance = 166;
            this.MainSplitContainer.TabIndex = 14;
            // 
            // conturiSplitContainer
            // 
            this.conturiSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conturiSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.conturiSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.conturiSplitContainer.Name = "conturiSplitContainer";
            // 
            // conturiSplitContainer.Panel1
            // 
            this.conturiSplitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // conturiSplitContainer.Panel2
            // 
            this.conturiSplitContainer.Panel2.Controls.Add(this.buttonTranz);
            this.conturiSplitContainer.Panel2.Controls.Add(this.label1);
            this.conturiSplitContainer.Panel2.Controls.Add(this.nextButton);
            this.conturiSplitContainer.Panel2.Controls.Add(this.ordonareFacturiCB);
            this.conturiSplitContainer.Size = new System.Drawing.Size(788, 166);
            this.conturiSplitContainer.SplitterDistance = 612;
            this.conturiSplitContainer.TabIndex = 0;
            // 
            // buttonTranz
            // 
            this.buttonTranz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTranz.Location = new System.Drawing.Point(13, 101);
            this.buttonTranz.Name = "buttonTranz";
            this.buttonTranz.Size = new System.Drawing.Size(147, 23);
            this.buttonTranz.TabIndex = 14;
            this.buttonTranz.Text = "Vizualizeaza Tranzactii";
            this.buttonTranz.UseVisualStyleBackColor = true;
            this.buttonTranz.Click += new System.EventHandler(this.buttonTranz_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 367);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // MeniuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 389);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(684, 315);
            this.Name = "MeniuPrincipal";
            this.Text = "Selectati conturi - facturi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.conturiSplitContainer.Panel1.ResumeLayout(false);
            this.conturiSplitContainer.Panel2.ResumeLayout(false);
            this.conturiSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conturiSplitContainer)).EndInit();
            this.conturiSplitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView conturiLV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView facturiLV;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox ordonareFacturiCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conturiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importaSolduricsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaContToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturiToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bancaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualizeazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaFacturiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem furnizoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vizualizeazaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer conturiSplitContainer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button filtrareFurnizor;
        private System.Windows.Forms.Button filtrareDataS;
        private System.Windows.Forms.Button filtrareDataE;
        private System.Windows.Forms.Button filtrareSumaTotala;
        private System.Windows.Forms.Button filtrarePrioritate;
        private System.Windows.Forms.Button filtrareBanca;
        private System.Windows.Forms.Button filtrareMonedaC;
        private System.Windows.Forms.Button filtrareSold;
        private System.Windows.Forms.Button filtrareMonedaF;
        private System.Windows.Forms.Button resetFiltreConturiButton;
        private System.Windows.Forms.Button resetFiltreFacturiButton;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button filtrareSumaDePlata;
        private System.Windows.Forms.Button buttonTranz;
    }
}

