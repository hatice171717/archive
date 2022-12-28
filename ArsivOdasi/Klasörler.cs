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
    public partial class Klasorler : Form
    {

        public Klasorler()
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
            dataGridViewKlasor.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxKlasorSec.DataSource = ds.Tables[0];
        }

        private void Klasorler_Load(object sender, EventArgs e)
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
            //Bolum
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Bolum ORDER BY Bolum_Id ASC ", bag.baglanti());

            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
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
            comboBoxKlasorSec.ValueMember = "Klasor_Id";
            comboBoxKlasorSec.DisplayMember = "Klasor_Ad";
            comboBoxKlasorSec.DataSource = dt3;

        }

        private void btnKlasorGoster_Click(object sender, EventArgs e)
        {
            string sql = "select Klasor_Ad,Evrak_Ad,Evrak_Turu from Klasor inner join Evrak on Klasor.Klasor_Id=Evrak.Klasor_Id where Klasor.Klasor_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxKlasorSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewKlasor.DataSource = dt;
        }

        private void btnKlasor_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Klasor");
        }

        private void btnKlasorEkle_Click(object sender, EventArgs e)
        {
            if (txtKlasorAd.Text == "")
            {
                MessageBox.Show("Lütfen Klasör adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Klasor where Klasor_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", txtKlasorAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Klasor mevcuttur.");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Klasor(Oda_Id,Bolum_Id,Raf_Id,Klasor_Ad) values (@p1,@p2,@p3,@p4)", bag.baglanti());

                    ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                    ekle.Parameters.AddWithValue("@p2", comboBoxBolum.SelectedValue);
                    ekle.Parameters.AddWithValue("@p3", comboBoxRaf.SelectedValue);
                    ekle.Parameters.AddWithValue("@p4", txtKlasorAd.Text);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");

                }

            }
            verilerigoster("Select * from Klasor");


        }

        private void dataGridViewKlasor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewKlasor.SelectedCells[0].RowIndex;
            comboBoxOda.Text = dataGridViewKlasor.Rows[secilen].Cells[0].Value.ToString();
            comboBoxBolum.Text = dataGridViewKlasor.Rows[secilen].Cells[1].Value.ToString();
            comboBoxRaf.Text = dataGridViewKlasor.Rows[secilen].Cells[2].Value.ToString();
            txtKlasorID.Text = dataGridViewKlasor.Rows[secilen].Cells[3].Value.ToString();
            txtKlasorAd.Text = dataGridViewKlasor.Rows[secilen].Cells[4].Value.ToString();


            SqlDataAdapter da = new SqlDataAdapter("Select * from Klasor", bag.baglanti());
            DataSet ds = new DataSet("Select * from Klasor");
            da.Fill(ds);
            dataGridViewKlasor.DataSource = ds.Tables[0];
        }

        private void btnKlasorSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Klasor where Klasor_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtKlasorAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Klasör başarılı bir şekilde silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            verilerigoster("Select * from Klasor");

        }

        private void btnKlasorGuncelle_Click(object sender, EventArgs e)
        {
            string guncelle = "update Klasor set Klasor_Ad=@p2,Oda_Id=@p3,Bolum_Id=@p4,Raf_Id=@p5 where Klasor_Id=@p1 ";
            SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", txtKlasorID.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", txtKlasorAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", comboBoxOda.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p4", comboBoxBolum.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p5", comboBoxRaf.SelectedValue);

            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Klasör başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            verilerigoster("Select * from Klasor");

        }

        private void txtKlasorAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Klasor where Klasor_Ad like '%" + txtKlasorAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewKlasor.DataSource = ds.Tables[0];
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
    }
}

