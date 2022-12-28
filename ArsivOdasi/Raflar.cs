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
    public partial class Raflar : Form
    {

        public Raflar()
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
        //CRUD işlemleri
        ArsivOdasi bag = new ArsivOdasi();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewRaf.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxRafSec.DataSource = ds.Tables[0];
        }
        private void Raflar_Load(object sender, EventArgs e)
        {
            //Oda ComboBox
            SqlCommand komut = new SqlCommand("select * from Oda", bag.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();

            comboBoxOda.ValueMember = "Oda_Id";
            comboBoxOda.DisplayMember = "Oda_Ad";
            comboBoxOda.DataSource = dt;
            //Bolum
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Bolum ORDER BY Bolum_Id ASC ", bag.baglanti());

            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBoxBolum.ValueMember = "Bolum_Id";
            comboBoxBolum.DisplayMember = "Bolum_Ad";
            comboBoxBolum.DataSource = dt1;
            //Raf

            SqlCommand komut2 = new SqlCommand("Select * from Raf", bag.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            komut2.ExecuteNonQuery();
            comboBoxRafSec.ValueMember = "Raf_Id";
            comboBoxRafSec.DisplayMember = "Raf_Ad";
            comboBoxRafSec.DataSource = dt2;

            txtRafID.Enabled = false;
        }

        private void btnRafGoster_Click(object sender, EventArgs e)
        {
            string sql = "select Raf_Ad,Evrak_Ad,Evrak_Turu from Raf inner join Evrak on Raf.Raf_Id=Evrak.Raf_Id where Raf.Raf_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxRafSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewRaf.DataSource = dt;
        }

        private void btnRaf_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Raf");
        }

        private void btnRafEkle_Click(object sender, EventArgs e)
        {

            if (txtRafAd.Text == "")
            {
                MessageBox.Show("Lütfen raf adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Raf where Raf_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", txtRafAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Raf mevcuttur.");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Raf(Oda_Id,Bolum_Id,Raf_Ad) values (@p1,@p2,@p3)", bag.baglanti());

                    ekle.Parameters.AddWithValue("@p1", comboBoxOda.SelectedValue);
                    ekle.Parameters.AddWithValue("@p2", comboBoxBolum.SelectedValue);
                    ekle.Parameters.AddWithValue("@p3", txtRafAd.Text);

                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    
                }

            }
            verilerigoster("Select * from Raf");

        }

        private void btnRafSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Raf where Raf_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtRafAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Raf başarılı bir şekilde silindi");
            verilerigoster("Select * from Raf");

        }

        private void dataGridViewRaf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewRaf.SelectedCells[0].RowIndex;
            comboBoxOda.Text = dataGridViewRaf.Rows[secilen].Cells[0].Value.ToString();
            comboBoxBolum.Text = dataGridViewRaf.Rows[secilen].Cells[1].Value.ToString();
            txtRafAd.Text = dataGridViewRaf.Rows[secilen].Cells[2].Value.ToString();
            txtRafAd.Text = dataGridViewRaf.Rows[secilen].Cells[3].Value.ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Raf", bag.baglanti());
            DataSet ds = new DataSet("Select * from Raf");
            da.Fill(ds);
            dataGridViewRaf.DataSource = ds.Tables[0];

        }

        private void btnRafGuncelle_Click(object sender, EventArgs e)
        {
            string guncelle = "update Raf set Raf_Ad=@p1,Oda_Id=@p2,Bolum_Id=@p3 where Raf_Id=@p4";
            SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", txtRafAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", comboBoxOda.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p3", comboBoxBolum.SelectedValue);
            komutGuncelle.Parameters.AddWithValue("@p4", txtRafID.Text);
            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Raf başarılı bir şekilde güncellendi.");
            verilerigoster("select * from Raf");



        }

        private void txtRafAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Raf where Raf_Ad like '%" + txtRafAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewRaf.DataSource = ds.Tables[0];
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
    }
}
