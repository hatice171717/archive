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
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }
        public void temizle()
        {
            maskedTC.Clear();
            txtRegisterName.Clear();
            txtRegisterAge.Clear();
            maskedPhone.Clear();
            txtRegisterPassword.Clear();
            txtRegisterPasswordAgain.Clear();


        }
        private void lblHesap_Click(object sender, EventArgs e)
        {
            GirişSayfasi girişSayfasi = new GirişSayfasi();
            girişSayfasi.Show();
            this.Hide();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
      
            if (txtRegisterPassword.Text == txtRegisterPasswordAgain.Text)
            {
                txtRegisterPassword = txtRegisterPasswordAgain;

                ArsivOdasi bag = new ArsivOdasi();
                string kayit = "insert into Kisiler " +
                    "(K_TC,K_AdSoyad,K_Yas,K_Tel,K_Sifre,K_SifreTekrar) values" +
                    "(@tc,@ad,@yas,@tel,@pass,@passAgain)";
                SqlCommand komut = new SqlCommand(kayit, bag.baglanti());
                komut.Parameters.AddWithValue("@tc", maskedTC.Text);
                komut.Parameters.AddWithValue("@ad", txtRegisterName.Text);
                komut.Parameters.AddWithValue("@yas", txtRegisterAge.Text);
                komut.Parameters.AddWithValue("@tel", maskedPhone.Text);
                komut.Parameters.AddWithValue("@pass", txtRegisterPassword.Text);
                komut.Parameters.AddWithValue("@passAgain", txtRegisterPasswordAgain.Text);
                komut.ExecuteNonQuery();
                
                MessageBox.Show("Başarılı bir şekilde kaydınız gerçekleşti.");
                temizle();
            }


            else if (txtRegisterPassword.Text != txtRegisterPasswordAgain.Text)
            {
                temizle();
                MessageBox.Show("Hatalı şifre");
                
            }


        }

    }
}
