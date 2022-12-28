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
    public partial class GirişSayfasi : Form
    {
        public GirişSayfasi()
        {
            InitializeComponent();
        }
        public void temizle()
        {
            txtName.Clear();
            txtPassword.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            ArsivOdasi bag = new ArsivOdasi();
            string sql = "Select * from Kisiler where K_AdSoyad=@adi AND K_Sifre=@sifresi";
            SqlParameter prm1 = new SqlParameter("adi", txtName.Text.Trim());
            SqlParameter prm2 = new SqlParameter("sifresi", txtPassword.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
                temizle();

            }
            





        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

       
    }
}
