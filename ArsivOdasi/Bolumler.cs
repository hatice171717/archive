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

    public partial class Bolumler : Form
    {


        public Bolumler()
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
        //BURADAN BAŞLIYOR
        ArsivOdasi bag = new ArsivOdasi();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewBolum.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxBolumSec.DataSource = ds.Tables[0];
        }

        private void Bolumler_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from Oda", bag.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();

            comboBoxOda.ValueMember = "Oda_Id";
            comboBoxOda.DisplayMember = "Oda_Ad";
            comboBoxOda.DataSource = dt;

            SqlCommand komut1 = new SqlCommand("Select * from Bolum", bag.baglanti());
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            komut.ExecuteNonQuery();
            comboBoxBolumSec.ValueMember = "Bolum_Id";
            comboBoxBolumSec.DisplayMember = "Bolum_Ad";
            comboBoxBolumSec.DataSource = dt1;


        }

        private void btnOdaGoster_Click(object sender, EventArgs e)
        {
            string sql = "select Bolum_Ad,Evrak_Ad,Evrak_Turu from Bolum inner join Evrak on Bolum.Bolum_Id=Evrak.Bolum_Id where Bolum.Bolum_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxBolumSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewBolum.DataSource = dt;

        }

        private void btnBolumEkle_Click(object sender, EventArgs e)
        {
           
           
            if (txtBolumAd.Text == "")
            {
                MessageBox.Show("Lütfen bölüm adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Bolum where Bolum_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", txtBolumAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Bölüm mevcuttur.");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Bolum(Oda_Id,Bolum_Ad) values (@p1,@p2)", bag.baglanti());

                    ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                    ekle.Parameters.AddWithValue("@p2", txtBolumAd.Text);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");

                }

            }
            verilerigoster("Select * from Bolum");
        }

        private void btnBolum_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Bolum");
        }

        private void dataGridViewBolum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewBolum.SelectedCells[0].RowIndex;
            comboBoxOda.Text = dataGridViewBolum.Rows[secilen].Cells[0].Value.ToString();
            txtBolumID.Text = dataGridViewBolum.Rows[secilen].Cells[1].Value.ToString();
            txtBolumAd.Text = dataGridViewBolum.Rows[secilen].Cells[2].Value.ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Bolum", bag.baglanti());
            DataSet ds = new DataSet("Select * from Bolum");
            da.Fill(ds);
            dataGridViewBolum.DataSource = ds.Tables[0];
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Bolum where Bolum_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtBolumAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Bölüm başarılı bir şekilde silindi");
            verilerigoster("Select * from Bolum");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string guncelle = "update Bolum set Bolum_Ad=@p2 where  Oda_Id=@p1 ";
            SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p2", txtBolumAd.Text);
           
            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Bölüm başarılı bir şekilde güncellendi.");
            verilerigoster("Select * from Bolum");

        }

        private void txtBolumAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Bolum where Bolum_Ad like '%" + txtBolumAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewBolum.DataSource = ds.Tables[0];
        }
    }
}
