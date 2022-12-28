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
    public partial class Evraklar : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=302-04;Initial Catalog=ArsivOdasi;Persist Security Info=True;User ID=WebMobile_302; password=webmobile.302");

        public Evraklar()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            Register yenikayit = new Register();
            yenikayit.Show();
            this.Hide();
        }

        private void toolStripTextBox2_Click_1(object sender, EventArgs e)
        {
            GirişSayfasi girişSayfasi = new GirişSayfasi();
            girişSayfasi.Show();
            this.Hide();
        }

        private void toolStripTextBox3_Click_1(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void toolStripTextBox12_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox4_Click_1(object sender, EventArgs e)
        {
            Odalar oda = new Odalar();
            oda.Show();
            this.Hide();
        }

        private void toolStripTextBox5_Click_1(object sender, EventArgs e)
        {
            Bolumler bolumler = new Bolumler();
            bolumler.Show();
            this.Hide();
        }

        private void toolStripTextBox6_Click_1(object sender, EventArgs e)
        {
            Raflar raflar = new Raflar();
            raflar.Show();
            this.Hide();
        }

        private void toolStripTextBox7_Click_1(object sender, EventArgs e)
        {
            Klasorler klasorler = new Klasorler();
            klasorler.Show();
            this.Hide();
        }

        private void toolStripTextBox8_Click_1(object sender, EventArgs e)
        {
            Dosyalar dosyalar = new Dosyalar();
            dosyalar.Show();
            this.Hide();
        }

        private void toolStripTextBox9_Click_1(object sender, EventArgs e)
        {
            Evraklar evraklar = new Evraklar();
            evraklar.Show();
            this.Hide();
        }




        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Kullanıcı_Bilgileri kullanıcı_Bilgileri = new Kullanıcı_Bilgileri();
            kullanıcı_Bilgileri.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        //Buradan başlıyoruz
        ArsivOdasi bag = new ArsivOdasi();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewEvrak.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxEvrakSec.DataSource = ds.Tables[0];
        }

        private void Evraklar_Load(object sender, EventArgs e)
        {
            //ODA
            SqlCommand komut = new SqlCommand("select * from Oda", bag.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();

            comboBoxOda.ValueMember = "Oda_Id";
            comboBoxOda.DisplayMember = "Oda_Ad";
            comboBoxOda.DataSource = dt;
            //BOLUM
            SqlCommand komut1 = new SqlCommand("Select * from Bolum ORDER BY Bolum_Id ASC ", bag.baglanti());
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            komut.ExecuteNonQuery();
            comboBoxBolum.ValueMember = "Bolum_Id";
            comboBoxBolum.DisplayMember = "Bolum_Ad";
            comboBoxBolum.DataSource = dt1;
            //RAF
            SqlCommand komut2 = new SqlCommand("Select * from Raf ORDER BY Raf_Id ASC ", bag.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            komut2.ExecuteNonQuery();
            comboBoxRaf.ValueMember = "Raf_Id";
            comboBoxRaf.DisplayMember = "Raf_Ad";
            comboBoxRaf.DataSource = dt2;
            //KLASÖR
            SqlCommand komut3 = new SqlCommand("Select * from Klasor ORDER BY Klasor_Id ASC ", bag.baglanti());
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            komut3.ExecuteNonQuery();
            comboBoxKlasor.ValueMember = "Klasor_Id";
            comboBoxKlasor.DisplayMember = "Klasor_Ad";
            comboBoxKlasor.DataSource = dt3;
            //DOSYA
            SqlCommand komut4 = new SqlCommand("Select * from Dosya ORDER BY Dosya_Id ASC ", bag.baglanti());
            SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            komut4.ExecuteNonQuery();
            comboBoxDosya.ValueMember = "Dosya_Id";
            comboBoxDosya.DisplayMember = "Dosya_Ad";
            comboBoxDosya.DataSource = dt4;
            //EVRAK
            SqlCommand komut5 = new SqlCommand("Select * from Evrak", bag.baglanti());
            SqlDataAdapter da5 = new SqlDataAdapter(komut5);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            komut5.ExecuteNonQuery();
            comboBoxEvrakSec.ValueMember = "Evrak_Id";
            comboBoxEvrakSec.DisplayMember = "Evrak_Ad";
            comboBoxEvrakSec.DataSource = dt5;
        }

        private void btnEvrakGoster_Click(object sender, EventArgs e)
        {
            string sql = "select Evrak_Ad,Evrak_Turu from Evrak where Evrak.Evrak_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxEvrakSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewEvrak.DataSource = dt;
        }

        private void btnEvrak_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Evrak");
        }

        private void btnEvrakEkle_Click(object sender, EventArgs e)
        {
            if (txtEvrakAd.Text == "")
            {
                MessageBox.Show("Lütfen Evrak adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Evrak where Evrak_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", txtEvrakAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Evrak mevcuttur.");
                }
                else
                {
                    if (radioButtonGelen.Checked == true)
                    {
                        SqlCommand ekle = new SqlCommand("insert into Evrak(Oda_Id,Bolum_Id,Raf_Id,Klasor_Id,Dosya_Id,Evrak_Ad,Evrak_Turu) values (@p1,@p2,@p3,@p4,@p5,@p6,'Gelen Evrak')", bag.baglanti());

                        ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                        ekle.Parameters.AddWithValue("@p2", comboBoxBolum.SelectedValue);
                        ekle.Parameters.AddWithValue("@p3", comboBoxRaf.SelectedValue);
                        ekle.Parameters.AddWithValue("@p4", comboBoxKlasor.SelectedValue);
                        ekle.Parameters.AddWithValue("@p5", comboBoxDosya.SelectedValue);
                        ekle.Parameters.AddWithValue("@p6", txtEvrakAd.Text);



                        ekle.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    }
                    else if (radioButtonGiden.Checked == true)
                    {
                        SqlCommand ekle = new SqlCommand("insert into Evrak(Oda_Id,Bolum_Id,Raf_Id,Klasor_Id,Dosya_Id,Evrak_Ad,Evrak_Turu) values (@p1,@p2,@p3,@p4,@p5,@p6,'Giden Evrak')", bag.baglanti());

                        ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                        ekle.Parameters.AddWithValue("@p2", comboBoxBolum.SelectedValue);
                        ekle.Parameters.AddWithValue("@p3", comboBoxRaf.SelectedValue);
                        ekle.Parameters.AddWithValue("@p4", comboBoxKlasor.SelectedValue);
                        ekle.Parameters.AddWithValue("@p5", comboBoxDosya.SelectedValue);
                        ekle.Parameters.AddWithValue("@p6", txtEvrakAd.Text);
                        ekle.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Evrak Türünü Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }

            }
            verilerigoster("Select * from Evrak");
        }

        private void dataGridViewEvrak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewEvrak.SelectedCells[0].RowIndex;
            comboBoxOda.Text = dataGridViewEvrak.Rows[secilen].Cells[0].Value.ToString();
            comboBoxBolum.Text = dataGridViewEvrak.Rows[secilen].Cells[1].Value.ToString();
            comboBoxRaf.Text = dataGridViewEvrak.Rows[secilen].Cells[2].Value.ToString();
            comboBoxKlasor.Text = dataGridViewEvrak.Rows[secilen].Cells[3].Value.ToString();
            comboBoxDosya.Text = dataGridViewEvrak.Rows[secilen].Cells[4].Value.ToString();
            
            txtEvrakID.Text = dataGridViewEvrak.Rows[secilen].Cells[5].Value.ToString();
            txtEvrakAd.Text = dataGridViewEvrak.Rows[secilen].Cells[6].Value.ToString();
            
           

            SqlDataAdapter da = new SqlDataAdapter("Select * from Evrak", bag.baglanti());
            DataSet ds = new DataSet("Select * from Evrak");
            da.Fill(ds);
            dataGridViewEvrak.DataSource = ds.Tables[0];
        }

        private void btnEvrakSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Evrak where Evrak_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtEvrakAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Evrak başarılı bir şekilde silindi");
            verilerigoster("Select * from Evrak");

        }

        private void btnEvrakGuncelle_Click(object sender, EventArgs e)
        {
            if (radioButtonGelen.Checked == true)
            {
                string guncelle = "update Evrak set Evrak_Ad=@p2,Evrak_Turu='Gelen Evrak',Oda_Id=@p3,Bolum_Id=@p4,Raf_Id=@p5,Klasor_Id=@p6,Dosya_Id=@p7 where Evrak_Id=@p1 ";
                SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
                komutGuncelle.Parameters.AddWithValue("@p1", txtEvrakID.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txtEvrakAd.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", comboBoxOda.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p4", comboBoxBolum.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p5", comboBoxRaf.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p6", comboBoxKlasor.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p7", comboBoxDosya.SelectedValue);
                komutGuncelle.ExecuteNonQuery();
                MessageBox.Show("Evrak başarılı bir şekilde güncellendi.");



            }
            else if (radioButtonGiden.Checked == true)
            {
                string guncelle = "update Evrak set Evrak_Ad=@p2,Evrak_Turu='Giden Evrak',Oda_Id=@p3,Bolum_Id=@p4,Raf_Id=@p5,Klasor_Id=@p6,Dosya_Id=@p7 where Evrak_Id=@p1 ";
                SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
                komutGuncelle.Parameters.AddWithValue("@p1", txtEvrakID.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txtEvrakAd.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", comboBoxOda.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p4", comboBoxBolum.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p5", comboBoxRaf.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p6", comboBoxKlasor.SelectedValue);
                komutGuncelle.Parameters.AddWithValue("@p7", comboBoxDosya.SelectedValue);
                komutGuncelle.ExecuteNonQuery();
                MessageBox.Show("Evrak başarılı bir şekilde güncellendi.");
            }
            else
            {
                MessageBox.Show("Lütfen Evrak Türünü Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            verilerigoster("Select * from Evrak");


        }

        private void txtEvrakAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Evrak where Evrak_Ad like '%" + txtEvrakAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewEvrak.DataSource = ds.Tables[0];
        }

        private void comboBoxOda_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Bolum Combobox

            if (comboBoxOda.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Bolum where Oda_Id = '" + comboBoxOda.SelectedValue + "'", bag.baglanti());
                da.Fill(dt);
                comboBoxBolum.ValueMember = "Bolum_Id";
                comboBoxBolum.DisplayMember = "Bolum_Ad";
                comboBoxBolum.DataSource = dt;
            }
        }

        private void comboBoxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Raf Combobox

            if (comboBoxBolum.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Raf where Bolum_Id = '" + comboBoxBolum.SelectedValue + "'", bag.baglanti());
                da.Fill(dt);
                comboBoxRaf.ValueMember = "Raf_Id";
                comboBoxRaf.DisplayMember = "Raf_Ad";
                comboBoxRaf.DataSource = dt;
            }
        }

        private void comboBoxRaf_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Klasor Combobox

            if (comboBoxRaf.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Klasor where Raf_Id = '" + comboBoxRaf.SelectedValue + "'", bag.baglanti());
                da.Fill(dt);
                comboBoxKlasor.ValueMember = "Klasor_Id";
                comboBoxKlasor.DisplayMember = "Klasor_Ad";
                comboBoxKlasor.DataSource = dt;
            }
        }

        private void comboBoxKlasor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dosya Combobox

            if (comboBoxKlasor.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from Dosya where Klasor_Id = '" + comboBoxKlasor.SelectedValue + "'", bag.baglanti());
                da.Fill(dt);
                comboBoxDosya.ValueMember = "Dosya_Id";
                comboBoxDosya.DisplayMember = "Dosya_Ad";
                comboBoxDosya.DataSource = dt;
            }
        }
    }


}

