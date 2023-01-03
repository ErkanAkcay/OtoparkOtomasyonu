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
using System.Data.SqlClient;


namespace OtoparkOtomasyonuProjesi
{
    public partial class AraçOtoparkKaydı : Form
    {
        public AraçOtoparkKaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PQ9VQUE;Initial Catalog=araç_otopark;Integrated Security=True");


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
        }

        private void AraçOtoparkKaydı_Load(object sender, EventArgs e)
        {
            BoşAraçlar();
            MarkaMetodu();

        }

        private void MarkaMetodu()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgileri ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combomarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void BoşAraçlar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araçdurumu WHERE durumu='BOŞ'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboparkyeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into araç_otopark_kaydı(ad,soyad,telefon,email,plaka,marka,seri,renk,parkyeri,tarih) values(@ad,@soyad,@telefon,@email,@plaka,@marka,@seri,@renk,@parkyeri,@tarih)", baglanti);
            komut.Parameters.AddWithValue("@ad", txtad.Text);
            komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
            komut.Parameters.AddWithValue("@email", txtemail.Text);
            komut.Parameters.AddWithValue("@plaka", txtplaka.Text);
            komut.Parameters.AddWithValue("@marka", combomarka.Text);
            komut.Parameters.AddWithValue("@seri", comboseri.Text);
            komut.Parameters.AddWithValue("@renk", txtrenk.Text);
            komut.Parameters.AddWithValue("@parkyeri", comboparkyeri.Text);
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            


            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update araçdurumu set durumu='DOLU' where parkyeri='" +comboparkyeri.SelectedItem +"'",baglanti);
            komut2.ExecuteNonQuery();
               
            baglanti.Close();
            MessageBox.Show("Araç kaydı oluşturuldu ...","Kayıt");
            comboparkyeri.Items.Clear();
            BoşAraçlar();
            combomarka.Items.Clear();
            MarkaMetodu();
            comboseri.Items.Clear();    


            foreach (Control item in grupKişi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = ""; 
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            


        }


        private void btnmarka_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.ShowDialog();

        }

        private void btnseri_Click(object sender, EventArgs e)
        {
            Seri seri = new Seri(); 
            seri.ShowDialog();  
        }

        private void combomarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboseri.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select seri from seribilgileri where marka='"+combomarka.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboseri.Items.Add(read["seri"].ToString());
            }
            baglanti.Close();
             
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}