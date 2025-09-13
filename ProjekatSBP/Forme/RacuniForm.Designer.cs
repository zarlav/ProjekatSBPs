namespace ProjekatSBP.Forme
{
    partial class RacuniForm
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
            this.cmdObrisiRacun = new System.Windows.Forms.Button();
            this.cmdAzurirajRacun = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.dateTimePicker8 = new System.Windows.Forms.DateTimePicker();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cmdDodajRacun = new System.Windows.Forms.Button();
            this.cmdPrikaziRacune = new System.Windows.Forms.Button();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdObrisiRacun
            // 
            this.cmdObrisiRacun.BackColor = System.Drawing.Color.Red;
            this.cmdObrisiRacun.Location = new System.Drawing.Point(633, 1);
            this.cmdObrisiRacun.Name = "cmdObrisiRacun";
            this.cmdObrisiRacun.Size = new System.Drawing.Size(91, 49);
            this.cmdObrisiRacun.TabIndex = 86;
            this.cmdObrisiRacun.Text = "Obrisi";
            this.cmdObrisiRacun.UseVisualStyleBackColor = false;
            this.cmdObrisiRacun.Click += new System.EventHandler(this.cmdObrisiRacun_Click);
            // 
            // cmdAzurirajRacun
            // 
            this.cmdAzurirajRacun.Location = new System.Drawing.Point(536, 1);
            this.cmdAzurirajRacun.Name = "cmdAzurirajRacun";
            this.cmdAzurirajRacun.Size = new System.Drawing.Size(91, 49);
            this.cmdAzurirajRacun.TabIndex = 85;
            this.cmdAzurirajRacun.Text = "Azuriraj";
            this.cmdAzurirajRacun.UseVisualStyleBackColor = true;
            this.cmdAzurirajRacun.Click += new System.EventHandler(this.cmdAzurirajRacun_Click);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.comboBox9);
            this.panel11.Controls.Add(this.label47);
            this.panel11.Controls.Add(this.numericUpDown10);
            this.panel11.Controls.Add(this.label46);
            this.panel11.Controls.Add(this.label45);
            this.panel11.Controls.Add(this.dateTimePicker8);
            this.panel11.Controls.Add(this.textBox7);
            this.panel11.Controls.Add(this.label44);
            this.panel11.Controls.Add(this.comboBox8);
            this.panel11.Controls.Add(this.label43);
            this.panel11.Controls.Add(this.comboBox7);
            this.panel11.Controls.Add(this.label42);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(0, 1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(530, 281);
            this.panel11.TabIndex = 84;
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] {
            "aktivan",
            "blokiran",
            "ugovoren"});
            this.comboBox9.Location = new System.Drawing.Point(373, 113);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(157, 24);
            this.comboBox9.TabIndex = 85;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(371, 97);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(47, 16);
            this.label47.TabIndex = 84;
            this.label47.Text = "Status:";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.DecimalPlaces = 2;
            this.numericUpDown10.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numericUpDown10.Location = new System.Drawing.Point(376, 171);
            this.numericUpDown10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(157, 22);
            this.numericUpDown10.TabIndex = 76;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(373, 153);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(46, 16);
            this.label46.TabIndex = 83;
            this.label46.Text = "Saldo:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(205, 153);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(108, 16);
            this.label45.TabIndex = 82;
            this.label45.Text = "Datum otvaranja:";
            // 
            // dateTimePicker8
            // 
            this.dateTimePicker8.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker8.Location = new System.Drawing.Point(208, 173);
            this.dateTimePicker8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker8.Name = "dateTimePicker8";
            this.dateTimePicker8.Size = new System.Drawing.Size(157, 22);
            this.dateTimePicker8.TabIndex = 76;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(208, 115);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(157, 22);
            this.textBox7.TabIndex = 81;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(205, 94);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 16);
            this.label44.TabIndex = 60;
            this.label44.Text = "Valuta:";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(6, 171);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(157, 24);
            this.comboBox8.TabIndex = 59;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(3, 154);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(168, 16);
            this.label43.TabIndex = 58;
            this.label43.Text = "Klijent kome pripada racun:";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(6, 113);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(157, 24);
            this.comboBox7.TabIndex = 57;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 94);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(184, 16);
            this.label42.TabIndex = 56;
            this.label42.Text = "Banka na koju je vezan racun:";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.cmdDodajRacun);
            this.panel12.Controls.Add(this.cmdPrikaziRacune);
            this.panel12.Location = new System.Drawing.Point(343, 2);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(185, 73);
            this.panel12.TabIndex = 55;
            // 
            // cmdDodajRacun
            // 
            this.cmdDodajRacun.Location = new System.Drawing.Point(4, 1);
            this.cmdDodajRacun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodajRacun.Name = "cmdDodajRacun";
            this.cmdDodajRacun.Size = new System.Drawing.Size(179, 31);
            this.cmdDodajRacun.TabIndex = 14;
            this.cmdDodajRacun.Text = "Dodaj racun";
            this.cmdDodajRacun.UseVisualStyleBackColor = true;
            this.cmdDodajRacun.Click += new System.EventHandler(this.cmdDodajRacun_Click);
            // 
            // cmdPrikaziRacune
            // 
            this.cmdPrikaziRacune.Location = new System.Drawing.Point(4, 36);
            this.cmdPrikaziRacune.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikaziRacune.Name = "cmdPrikaziRacune";
            this.cmdPrikaziRacune.Size = new System.Drawing.Size(179, 31);
            this.cmdPrikaziRacune.TabIndex = 15;
            this.cmdPrikaziRacune.Text = "Prikazi racune";
            this.cmdPrikaziRacune.UseVisualStyleBackColor = true;
            this.cmdPrikaziRacune.Click += new System.EventHandler(this.cmdPrikaziRacune_Click);
            // 
            // dataGridView9
            // 
            this.dataGridView9.AllowUserToAddRows = false;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Location = new System.Drawing.Point(536, 55);
            this.dataGridView9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.RowHeadersWidth = 51;
            this.dataGridView9.RowTemplate.Height = 24;
            this.dataGridView9.Size = new System.Drawing.Size(1065, 227);
            this.dataGridView9.TabIndex = 87;
            // 
            // RacuniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dataGridView9);
            this.Controls.Add(this.cmdObrisiRacun);
            this.Controls.Add(this.cmdAzurirajRacun);
            this.Controls.Add(this.panel11);
            this.Name = "RacuniForm";
            this.Text = "Racuni";
            this.Load += new System.EventHandler(this.RacuniForm_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdObrisiRacun;
        private System.Windows.Forms.Button cmdAzurirajRacun;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DateTimePicker dateTimePicker8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button cmdDodajRacun;
        private System.Windows.Forms.Button cmdPrikaziRacune;
        private System.Windows.Forms.DataGridView dataGridView9;
    }
}