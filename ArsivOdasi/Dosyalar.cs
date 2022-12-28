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
    public partial class Dosyalar : Form
    {

        public Dosyalar()
        {
            InitializeComponent();
        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
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

        //Buradan başlıyoruz
        ArsivOdasi bag = new ArsivOdasi();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewDosya.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxDosyaSec.DataSource = ds.Tables[0];
        }

        private void Dosyalar_Load(object sender, EventArgs e)
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
            comboBoxDosyaSec.ValueMember = "Dosya_Id";
            comboBoxDosyaSec.DisplayMember = "Dosya_Ad";
            comboBoxDosyaSec.DataSource = dt4;
        }

        private void btnDosyaGoster_Click(object sender, EventArgs e)
        {
            string sql = "select Dosya_Ad,Evrak_Ad,Evrak_Turu from Dosya inner join Evrak on Dosya.Dosya_Id=Evrak.Dosya_Id where Dosya.Dosya_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxDosyaSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewDosya.DataSource = dt;
        }

        private void btnDosya_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Dosya");

        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {

            if (txtDosyaAd.Text == "")
            {
                MessageBox.Show("Lütfen Dosya adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Dosya where Dosya_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", txtDosyaAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Dosya mevcuttur.");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Dosya(Oda_Id,Bolum_Id,Raf_Id,Klasor_Id,Dosya_Ad) values (@p1,@p2,@p3,@p4,@p5)", bag.baglanti());

                    ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                    ekle.Parameters.AddWithValue("@p2", comboBoxBolum.SelectedValue);
                    ekle.Parameters.AddWithValue("@p3", comboBoxRaf.SelectedValue);
                    ekle.Parameters.AddWithValue("@p4", comboBoxKlasor.SelectedValue);
                    ekle.Parameters.AddWithValue("@p5", txtDosyaAd.Text);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");

                }

            }
            verilerigoster("Select * from Dosya");

        }

        private void dataGridViewDosya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewDosya.SelectedCells[0].RowIndex;
            comboBoxOda.Text = dataGridViewDosya.Rows[secilen].Cells[0].Value.ToString();
            comboBoxBolum.Text = dataGridViewDosya.Rows[secilen].Cells[1].Value.ToString();
            comboBoxRaf.Text = dataGridViewDosya.Rows[secilen].Cells[2].Value.ToString();
            comboBoxKlasor.Text = dataGridViewDosya.Rows[secilen].Cells[3].Value.ToString();
            txtDosyaID.Text = dataGridViewDosya.Rows[secilen].Cells[4].Value.ToString();

            txtDosyaAd.Text = dataGridViewDosya.Rows[secilen].Cells[5].Value.ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Dosya", bag.baglanti());
            DataSet ds = new DataSet("Select * from Dosya");
            da.Fill(ds);
            dataGridViewDosya.DataSource = ds.Tables[0];
        }

        private void btnDosyaSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Dosya where Dosya_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtDosyaAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Dosya başarılı bir şekilde silindi");
            verilerigoster("Select * from Dosya");

        }

        private void btnDosyaGuncelle_Click(object sender, EventArgs e)
        {
            string guncelle = "update Dosya set Dosya_Ad=@p2,Oda_Id=@p3,Bolum_Id=@p4,Raf_Id=@p5,Klasor_Id=@p6 where Dosya_Id=@p1 ";
            SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", txtDosyaID.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", txtDosyaAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", comboBoxOda.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p4", comboBoxBolum.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p5", comboBoxRaf.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p6", comboBoxKlasor.SelectedValue);

            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Dosya başarılı bir şekilde güncellendi.");
            verilerigoster("Select * from Dosya");

        }

        private void txtKlasorAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Dosya where Dosya_Ad like '%" + txtKlasorAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewDosya.DataSource = ds.Tables[0];
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

            if (comboBoxBolum.SelectedIndex != -1)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Klasor where Raf_Id = '" + comboBoxRaf.SelectedValue + "'", bag.baglanti());

                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxKlasor.ValueMember = "Klasor_Id";
                comboBoxKlasor.DisplayMember = "Klasor_Ad";
                comboBoxKlasor.DataSource = dt;
            }
        }
    }
}
