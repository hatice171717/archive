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
    public partial class Odalar : Form
    {

        public Odalar()
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
            Application.Exit();
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



        

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Kullanıcı_Bilgileri kullanıcı_Bilgileri = new Kullanıcı_Bilgileri();
            kullanıcı_Bilgileri.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        //BURADAN BAŞLIYOR
        ArsivOdasi bag = new ArsivOdasi();
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag.baglanti());
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewOda.DataSource = ds.Tables[0];
            bag.baglanti().Close();
            comboBoxOdaSec.DataSource = ds.Tables[0];
        }

        private void Odalar_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from Oda", bag.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();

            comboBoxOdaSec.ValueMember = "Oda_Id";
            comboBoxOdaSec.DisplayMember = "Oda_Ad";
            comboBoxOdaSec.DataSource = dt;
            




        }



        private void btnOdaGoster_Click(object sender, EventArgs e)
        {


            string sql = "select Oda_Ad,Evrak_Ad,Evrak_Turu from Oda inner join Evrak on Oda.Oda_Id=Evrak.Oda_Id where Oda.Oda_Id=@id";

            SqlCommand komut = new SqlCommand(sql, bag.baglanti());
            komut.Parameters.AddWithValue("@id", comboBoxOdaSec.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            komut.ExecuteNonQuery();
            dataGridViewOda.DataSource = dt;
           

        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {

            if (textBoxOdaAd.Text == "")
            {
                MessageBox.Show("Lütfen Oda adını giriniz.");
            }
            else
            {
                SqlCommand tekrar = new SqlCommand("select * from Oda where Oda_Ad=@ptekrar", bag.baglanti());
                tekrar.Parameters.AddWithValue("ptekrar", textBoxOdaAd.Text);
                SqlDataReader dr = tekrar.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu isimde bir Oda mevcuttur.");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Oda(Oda_Ad) values (@p1)", bag.baglanti());

                    
                    ekle.Parameters.AddWithValue("@p1", textBoxOdaAd.Text);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    
                    verilerigoster("Select * from Oda");
                    
                    
                }

            }

            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Oda where Oda_Ad=@p1", bag.baglanti());
            komutsil.Parameters.AddWithValue("@p1", textBoxOdaAd.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Oda başarılı bir şekilde silindi");
            verilerigoster("select * from Oda");
    

        }

        private void dataGridViewOda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewOda.SelectedCells[0].RowIndex;
            textboxOdaID.Text = dataGridViewOda.Rows[secilen].Cells[0].Value.ToString();
            textBoxOdaAd.Text = dataGridViewOda.Rows[secilen].Cells[1].Value.ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Oda", bag.baglanti());
            DataSet ds = new DataSet("Select * from Oda");
            da.Fill(ds);
            dataGridViewOda.DataSource = ds.Tables[0];
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string guncelle = "update Oda set Oda_Ad=@p1 where Oda_Id=@p2";
            SqlCommand komutGuncelle = new SqlCommand(guncelle, bag.baglanti());
            komutGuncelle.Parameters.AddWithValue("@p1", textBoxOdaAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", textboxOdaID.Text);
            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Oda başarılı bir şekilde güncellendi.");
            verilerigoster("select * from Oda");





        }



        private void txtOdaAdArama_TextChanged(object sender, EventArgs e)
        {
            string Arama = "select * from Oda where Oda_Ad like '%" + txtOdaAdArama.Text + "%'";
            SqlCommand komutArama = new SqlCommand(Arama, bag.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komutArama);
            DataSet ds = new DataSet();
            da.Fill(ds);
            komutArama.ExecuteNonQuery();
            dataGridViewOda.DataSource = ds.Tables[0];
        }

        private void btnOda_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Oda");
        }

       
    }
}
