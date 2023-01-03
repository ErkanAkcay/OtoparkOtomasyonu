using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkOtomasyonuProjesi
{
    public partial class Satış : Form
    {
        public Satış()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PQ9VQUE;Initial Catalog=araç_otopark;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Satış_Load(object sender, EventArgs e)
        {
            SatışListele();
            Hesapla();

        }

        private void Hesapla()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satis", baglanti);
            label1.Text = "Toplam Tutar = " + komut.ExecuteScalar() + " Tl ";
            baglanti.Close();
        }

        private void SatışListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satis", baglanti);
            adtr.Fill(daset, "satis");
            dataGridView1.DataSource = daset.Tables["satis"];
            baglanti.Close();
        }
    }
}
