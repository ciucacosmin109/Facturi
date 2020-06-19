namespace Facturi {
    partial class ContNou {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.info_banca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.info_iban = new System.Windows.Forms.TextBox();
            this.info_moneda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.info_sold = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.info_costFix = new System.Windows.Forms.NumericUpDown();
            this.info_costProcentual = new System.Windows.Forms.NumericUpDown();
            this.info_isFix = new System.Windows.Forms.CheckBox();
            this.info_isPercent = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_sold)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_costFix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_costProcentual)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.info_banca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.info_iban);
            this.groupBox1.Controls.Add(this.info_moneda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.info_sold);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 102);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informatii cont";
            // 
            // info_banca
            // 
            this.info_banca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_banca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.info_banca.FormattingEnabled = true;
            this.info_banca.Location = new System.Drawing.Point(44, 19);
            this.info_banca.Name = "info_banca";
            this.info_banca.Size = new System.Drawing.Size(267, 21);
            this.info_banca.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Banca";
            // 
            // info_iban
            // 
            this.info_iban.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_iban.Location = new System.Drawing.Point(44, 46);
            this.info_iban.MaxLength = 24;
            this.info_iban.Name = "info_iban";
            this.info_iban.Size = new System.Drawing.Size(267, 20);
            this.info_iban.TabIndex = 12;
            // 
            // info_moneda
            // 
            this.info_moneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.info_moneda.FormattingEnabled = true;
            this.info_moneda.Location = new System.Drawing.Point(242, 71);
            this.info_moneda.Name = "info_moneda";
            this.info_moneda.Size = new System.Drawing.Size(69, 21);
            this.info_moneda.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Moneda";
            // 
            // info_sold
            // 
            this.info_sold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_sold.DecimalPlaces = 2;
            this.info_sold.Increment = new decimal(new int[] {
            1005,
            0,
            0,
            65536});
            this.info_sold.Location = new System.Drawing.Point(44, 72);
            this.info_sold.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.info_sold.Name = "info_sold";
            this.info_sold.Size = new System.Drawing.Size(140, 20);
            this.info_sold.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IBAN";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(12, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anulare";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(254, 199);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Adaugare";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 225);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(341, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(176, 17);
            this.statusLabel.Text = "Introduceti informatiile contului";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.info_costFix);
            this.groupBox2.Controls.Add(this.info_costProcentual);
            this.groupBox2.Controls.Add(this.info_isFix);
            this.groupBox2.Controls.Add(this.info_isPercent);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 72);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Costuri - plata facturi";
            // 
            // info_costFix
            // 
            this.info_costFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_costFix.DecimalPlaces = 2;
            this.info_costFix.Increment = new decimal(new int[] {
            105,
            0,
            0,
            65536});
            this.info_costFix.Location = new System.Drawing.Point(72, 44);
            this.info_costFix.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.info_costFix.Name = "info_costFix";
            this.info_costFix.Size = new System.Drawing.Size(239, 20);
            this.info_costFix.TabIndex = 7;
            // 
            // info_costProcentual
            // 
            this.info_costProcentual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_costProcentual.DecimalPlaces = 2;
            this.info_costProcentual.Location = new System.Drawing.Point(135, 18);
            this.info_costProcentual.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.info_costProcentual.Name = "info_costProcentual";
            this.info_costProcentual.Size = new System.Drawing.Size(176, 20);
            this.info_costProcentual.TabIndex = 6;
            // 
            // info_isFix
            // 
            this.info_isFix.AutoSize = true;
            this.info_isFix.Location = new System.Drawing.Point(6, 45);
            this.info_isFix.Name = "info_isFix";
            this.info_isFix.Size = new System.Drawing.Size(60, 17);
            this.info_isFix.TabIndex = 1;
            this.info_isFix.Text = "Cost fix";
            this.info_isFix.UseVisualStyleBackColor = true;
            // 
            // info_isPercent
            // 
            this.info_isPercent.AutoSize = true;
            this.info_isPercent.Location = new System.Drawing.Point(6, 19);
            this.info_isPercent.Name = "info_isPercent";
            this.info_isPercent.Size = new System.Drawing.Size(123, 17);
            this.info_isPercent.TabIndex = 0;
            this.info_isPercent.Text = "Cost procentual ( % )";
            this.info_isPercent.UseVisualStyleBackColor = true;
            // 
            // ContNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 247);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.MinimumSize = new System.Drawing.Size(349, 278);
            this.Name = "ContNou";
            this.Text = "Cont Nou";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_sold)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_costFix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_costProcentual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox info_banca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox info_iban;
        private System.Windows.Forms.ComboBox info_moneda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown info_sold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown info_costFix;
        private System.Windows.Forms.NumericUpDown info_costProcentual;
        private System.Windows.Forms.CheckBox info_isFix;
        private System.Windows.Forms.CheckBox info_isPercent;
    }
}