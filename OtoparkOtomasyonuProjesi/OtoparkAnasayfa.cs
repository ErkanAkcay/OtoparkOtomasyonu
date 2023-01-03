using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkOtomasyonuProjesi
{
    public partial class OtoparkAnasayfa : Form
    {
        public OtoparkAnasayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AraçOtoparkKaydı kayıt = new AraçOtoparkKaydı();
            kayıt.ShowDialog(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AraçOtoparkYerleri yer = new AraçOtoparkYerleri();
            yer.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AraçOtoparkÇıkışı çıkış = new AraçOtoparkÇıkışı();
            çıkış.ShowDialog(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Satış satis = new Satış();
            satis.ShowDialog();

        }
    }
}
