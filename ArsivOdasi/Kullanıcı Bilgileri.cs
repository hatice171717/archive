using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArsivOdasi
{
    public partial class Kullanıcı_Bilgileri : Form
    {
        ArsivOdasi bag = new ArsivOdasi();
        public Kullanıcı_Bilgileri()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            Register yenikayit = new Register();
            yenikayit.Show();
            this.Hide();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            GirişSayfasi girişSayfasi = new GirişSayfasi();
            girişSayfasi.Show();
            this.Hide();
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void toolStripTextBox12_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar();
            oda.Show();
            this.Hide();
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            Bolumler bolumler = new Bolumler();
            bolumler.Show();
            this.Hide();
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            Raflar raflar = new Raflar();
            raflar.Show();
            this.Hide();
        }

        private void toolStripTextBox7_Click(object sender, EventArgs e)
        {
            Klasorler klasorler = new Klasorler();
            klasorler.Show();
            this.Hide();
        }

        private void toolStripTextBox8_Click(object sender, EventArgs e)
        {
            Dosyalar dosyalar = new Dosyalar();
            dosyalar.Show();
            this.Hide();
        }

        private void toolStripTextBox9_Click(object sender, EventArgs e)
        {
            Evraklar evraklar = new Evraklar();
            evraklar.Show();
            this.Hide();
        }



       

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Kullanıcı_Bilgileri kullanıcı_Bilgileri = new Kullanıcı_Bilgileri();
            kullanıcı_Bilgileri.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Buradan başlıyoruz
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            string sql = "update Kisiler  set K_AdSoyad=@NAME, K_Yas=@Yas, K_Tel=@tel  where  K_TC=@TC";
            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@TC", maskedTextTCGuncelle.Text);
            komut.Parameters.AddWithValue("@NAME", txtAdGuncelle.Text);
            komut.Parameters.AddWithValue("@Yas", txtYasGuncelle.Text);
            komut.Parameters.AddWithValue("@tel", maskedTextTelGuncelle.Text);
            komut.ExecuteNonQuery();
           
            MessageBox.Show($"Güncelleme gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSifreDegistirme_Click(object sender, EventArgs e)
        {
            if (txt_newpass.Text == txt_newpass_again.Text)
            {
                
                string pass = "update Kisiler set K_Sifre=@pass, K_SifreTekrar=@passAgain where K_sifre=@oldpass";
                SqlCommand komut = new SqlCommand(pass, bag.baglanti());
                komut.Parameters.AddWithValue("@pass", txt_newpass.Text);
                komut.Parameters.AddWithValue("@passAgain", txt_newpass_again.Text);
                komut.Parameters.AddWithValue("@oldpass", txt_oldpass.Text);
                komut.ExecuteNonQuery();
               
                txt_newpass.Clear();
                txt_newpass_again.Clear();
                txt_oldpass.Clear();
                MessageBox.Show("Şifreniz değişmiştir.");
            }
            else
            {
                MessageBox.Show("Lütfen uygun şifre giriniz.");
                txt_newpass.Clear();
                txt_newpass_again.Clear();
            }


        }

        private void btnKullaniciSİl_Click(object sender, EventArgs e)
        {
            
            string kullaniciSil = "delete from Kisiler where K_TC=@tcSil and K_AdSoyad=@AdSoyad";
            SqlCommand K_sil = new SqlCommand(kullaniciSil, bag.baglanti());
            K_sil.Parameters.AddWithValue("@tcSil", maskedTextBoxTCSil.Text);
            K_sil.Parameters.AddWithValue("@AdSoyad", txtAdSil.Text);
            K_sil.ExecuteNonQuery();
            

            MessageBox.Show("Kullanıcı silinmiştir");
            maskedTextBoxTCSil.Clear();
            txtAdSil.Clear();

        }
    }
}
