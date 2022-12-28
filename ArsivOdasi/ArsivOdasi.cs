using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ArsivOdasi
{
    class ArsivOdasi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FT6FLSV\SQLEXPRESS;Initial Catalog=ArsivOdasi;Integrated Security=True");
            //SqlConnection baglanti = new SqlConnection(@"Data Source=302-03;Initial Catalog=ArsivOdasi;Persist Security Info=True;User ID=WebMobile_302; password=webmobile.302");
            baglanti.Open();
            return baglanti;
        }




    }
}
