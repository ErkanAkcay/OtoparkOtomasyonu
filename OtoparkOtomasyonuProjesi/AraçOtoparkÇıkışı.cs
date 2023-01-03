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
    public partial class AraçOtoparkÇıkışı : Form
    {
        public AraçOtoparkÇıkışı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PQ9VQUE;Initial Catalog=araç_otopark;Integrated Security=True");


        private void AraçOtoparkÇıkışı_Load(object sender, EventArgs e)
        {
            Plakalar();
            DoluYerler();
            timer1.Enabled = true;


        }

        private void Plakalar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboplaka.Items.Add(read["plaka"].ToString());

            }
            baglanti.Close();
        }

        private void DoluYerler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araçdurumu where durumu='DOLU'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboparkyeri.Items.Add(read["parkyeri"].ToString());

            }
            baglanti.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı where parkyeri='" + comboparkyeri.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                
                txtad.Text = read["ad"].ToString();
                txtparkyeri2.Text = read["parkyeri"].ToString();
                txtsoyad.Text = read["soyad"].ToString();
                txttelefon.Text = read["telefon"].ToString();
                txtemail.Text = read["email"].ToString();
                txtmarka.Text = read["marka"].ToString();
                txtseri.Text = read["seri"].ToString();
                txtplaka.Text = read["plaka"].ToString();
                txtrenk.Text = read["renk"].ToString();
                lblgiriş.Text = read["tarih"].ToString();




            }
            baglanti.Close();
            DateTime giriş, çıkış;
            giriş = DateTime.Parse(lblgiriş.Text);
            çıkış = DateTime.Parse(lblçıkış.Text);
            TimeSpan fark = (çıkış - giriş);
            lbltoplam.Text = fark.TotalHours.ToString("0.00");
            lbltutar.Text = (double.Parse(lbltoplam.Text) * 12.5).ToString("0.00");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı where plaka='"+comboplaka.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {  
                txtparkyeri.Text = read["parkyeri"].ToString();


            }
            baglanti.Close();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
                
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblçıkış.Text=DateTime.Now.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from araç_otopark_kaydı where plaka='"+txtplaka.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update araçdurumu set durumu='BOŞ' where parkyeri='" +txtparkyeri2.Text + "'", baglanti);
            komut2.ExecuteNonQuery();
            
            SqlCommand komut3 = new SqlCommand("insert into satis(parkyeri,plaka,giriş,çıkış,süre,tutar) values(@parkyeri,@plaka,@giriş,@çıkış,@süre,@tutar)", baglanti);
           
            komut3.Parameters.AddWithValue("@parkyeri", txtparkyeri2.Text);
            komut3.Parameters.AddWithValue("@plaka", txtplaka.Text);
            komut3.Parameters.AddWithValue("@giriş", lblgiriş.Text);
            komut3.Parameters.AddWithValue("@çıkış", lblçıkış.Text);
            komut3.Parameters.AddWithValue("@süre", double.Parse(lbltoplam.Text));
            komut3.Parameters.AddWithValue("@tutar", double.Parse(lbltutar.Text));

            komut3.ExecuteNonQuery();
            baglanti.Close();




            MessageBox.Show("Araç Çıkışı Yapıldı ...");

            foreach (Control item in groupBox2.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                    txtparkyeri.Text = "";
                    comboparkyeri.Text = "";
                    comboplaka.Text = "";

      
                }
            }

            

            comboplaka.Items.Clear();
            comboparkyeri.Items.Clear();
            Plakalar();
            DoluYerler();


        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbltoplam_Click(object sender, EventArgs e)
        {

        }

        private void lblgiriş_Click(object sender, EventArgs e)
        {

        }

        private void lblçıkış_Click(object sender, EventArgs e)
        {

        }
    }
}
