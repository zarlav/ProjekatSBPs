using ProjekatSBP.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatSBP
{
    public partial class pocetna : Form
    {
        public pocetna()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UredjajiForm uf = new UredjajiForm();
            uf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankaForm bf = new BankaForm();
            bf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FilijaleForm ff = new FilijaleForm();
            ff.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KlijentiForm kf = new KlijentiForm();   
            kf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransakcijeForm tf = new TransakcijeForm();
            tf.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KarticeForm kf = new KarticeForm(); 
            kf.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RacuniForm rf = new RacuniForm();
            rf.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
