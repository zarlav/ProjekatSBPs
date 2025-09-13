namespace ProjekatSBP.Forme
{
    partial class TransakcijeForm
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
            this.cmdObrisiTransakciju = new System.Windows.Forms.Button();
            this.cmdAzurirajTransakciju = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmdPrikaziTransakcije = new System.Windows.Forms.Button();
            this.cmdDodajTransakciju = new System.Windows.Forms.Button();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdObrisiTransakciju
            // 
            this.cmdObrisiTransakciju.BackColor = System.Drawing.Color.Red;
            this.cmdObrisiTransakciju.Location = new System.Drawing.Point(477, 1);
            this.cmdObrisiTransakciju.Name = "cmdObrisiTransakciju";
            this.cmdObrisiTransakciju.Size = new System.Drawing.Size(91, 49);
            this.cmdObrisiTransakciju.TabIndex = 81;
            this.cmdObrisiTransakciju.Text = "Obrisi";
            this.cmdObrisiTransakciju.UseVisualStyleBackColor = false;
            this.cmdObrisiTransakciju.Click += new System.EventHandler(this.cmdObrisiTransakciju_Click);
            // 
            // cmdAzurirajTransakciju
            // 
            this.cmdAzurirajTransakciju.Location = new System.Drawing.Point(380, 1);
            this.cmdAzurirajTransakciju.Name = "cmdAzurirajTransakciju";
            this.cmdAzurirajTransakciju.Size = new System.Drawing.Size(91, 49);
            this.cmdAzurirajTransakciju.TabIndex = 80;
            this.cmdAzurirajTransakciju.Text = "Azuriraj";
            this.cmdAzurirajTransakciju.UseVisualStyleBackColor = true;
            this.cmdAzurirajTransakciju.Click += new System.EventHandler(this.cmdAzurirajTransakciju_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.numericUpDown9);
            this.panel9.Controls.Add(this.label37);
            this.panel9.Controls.Add(this.comboBox6);
            this.panel9.Controls.Add(this.label36);
            this.panel9.Controls.Add(this.label35);
            this.panel9.Controls.Add(this.comboBox5);
            this.panel9.Controls.Add(this.label34);
            this.panel9.Controls.Add(this.comboBox4);
            this.panel9.Controls.Add(this.textBox8);
            this.panel9.Controls.Add(this.dateTimePicker5);
            this.panel9.Controls.Add(this.label33);
            this.panel9.Controls.Add(this.label32);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(1, 1);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(372, 272);
            this.panel9.TabIndex = 78;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Location = new System.Drawing.Point(9, 126);
            this.numericUpDown9.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(159, 22);
            this.numericUpDown9.TabIndex = 79;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(201, 212);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(94, 16);
            this.label37.TabIndex = 78;
            this.label37.Text = "Izaberi uredjaj:";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(201, 230);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(157, 24);
            this.comboBox6.TabIndex = 77;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 212);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(92, 16);
            this.label36.TabIndex = 65;
            this.label36.Text = "Izaberi karticu:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(199, 153);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(109, 16);
            this.label35.TabIndex = 65;
            this.label35.Text = "Vrsta transakcije:";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(9, 230);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(157, 24);
            this.comboBox5.TabIndex = 64;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(9, 154);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(105, 16);
            this.label34.TabIndex = 76;
            this.label34.Text = "Datum izvrsenja:";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Podizanje",
            "Uplata",
            "ProveraStanja",
            "PromenaPina"});
            this.comboBox4.Location = new System.Drawing.Point(201, 171);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(157, 24);
            this.comboBox4.TabIndex = 64;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(201, 122);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(157, 22);
            this.textBox8.TabIndex = 70;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(9, 172);
            this.dateTimePicker5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(157, 22);
            this.dateTimePicker5.TabIndex = 75;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(201, 97);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 69;
            this.label33.Text = "Valuta:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(9, 97);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(109, 16);
            this.label32.TabIndex = 67;
            this.label32.Text = "Iznos transakcije:";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.cmdPrikaziTransakcije);
            this.panel10.Controls.Add(this.cmdDodajTransakciju);
            this.panel10.Location = new System.Drawing.Point(182, 2);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(185, 73);
            this.panel10.TabIndex = 56;
            // 
            // cmdPrikaziTransakcije
            // 
            this.cmdPrikaziTransakcije.Location = new System.Drawing.Point(3, 38);
            this.cmdPrikaziTransakcije.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdPrikaziTransakcije.Name = "cmdPrikaziTransakcije";
            this.cmdPrikaziTransakcije.Size = new System.Drawing.Size(179, 31);
            this.cmdPrikaziTransakcije.TabIndex = 17;
            this.cmdPrikaziTransakcije.Text = "Prikazi detalje";
            this.cmdPrikaziTransakcije.UseVisualStyleBackColor = true;
            this.cmdPrikaziTransakcije.Click += new System.EventHandler(this.cmdPrikaziTransakcije_Click);
            // 
            // cmdDodajTransakciju
            // 
            this.cmdDodajTransakciju.Location = new System.Drawing.Point(3, 2);
            this.cmdDodajTransakciju.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdDodajTransakciju.Name = "cmdDodajTransakciju";
            this.cmdDodajTransakciju.Size = new System.Drawing.Size(179, 31);
            this.cmdDodajTransakciju.TabIndex = 16;
            this.cmdDodajTransakciju.Text = "Dodaj transakciju";
            this.cmdDodajTransakciju.UseVisualStyleBackColor = true;
            this.cmdDodajTransakciju.Click += new System.EventHandler(this.cmdDodajTransakciju_Click);
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(380, 55);
            this.dataGridView7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.RowHeadersWidth = 51;
            this.dataGridView7.RowTemplate.Height = 24;
            this.dataGridView7.Size = new System.Drawing.Size(1195, 227);
            this.dataGridView7.TabIndex = 79;
            // 
            // TransakcijeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.cmdObrisiTransakciju);
            this.Controls.Add(this.cmdAzurirajTransakciju);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.dataGridView7);
            this.Name = "TransakcijeForm";
            this.Text = "Transakcije";
            this.Load += new System.EventHandler(this.TransakcijeForm_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdObrisiTransakciju;
        private System.Windows.Forms.Button cmdAzurirajTransakciju;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button cmdPrikaziTransakcije;
        private System.Windows.Forms.Button cmdDodajTransakciju;
        private System.Windows.Forms.DataGridView dataGridView7;
    }
}