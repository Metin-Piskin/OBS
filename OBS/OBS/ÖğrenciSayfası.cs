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

namespace OBS
{
    public partial class ÖğrenciSayfası : Form
    {
        public ÖğrenciSayfası()
        {
            InitializeComponent();
        }
        public string tc;
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");
        OBSDataSetTableAdapters.Tbl_NotTableAdapter ds = new OBSDataSetTableAdapters.Tbl_NotTableAdapter();
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ÖğrenciGiriş ög = new ÖğrenciGiriş();
            ög.Show();
            this.Close();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }
        public string numara;
        private void ÖğrenciSayfası_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            Lblİd.Text = numara;
             bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select ÖğrenciAd,ÖğrenciSoyad,ÖğrenciSınıf,ÖğrenciCinsiyet From Tbl_Öğrenci INNER JOIN Tbl_Sınıf ON Tbl_Öğrenci.ÖğrenciSınıf = Tbl_Sınıf.Sınıfİd Where ÖğrenciTc=@p1", bağlantı);
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
                LblCinsiyet.Text = dr[3].ToString();
                LblSınıf.Text = dr[2].ToString();
            }
            bağlantı.Close();
            
            bağlantı.Open();
            SqlCommand komut1 = new SqlCommand("Select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum From Tbl_Not INNER JOIN Tbl_Ders ON Tbl_Not.Dİd = Tbl_Ders.Dersİd Where Öğrİd = @P1", bağlantı);
            komut1.Parameters.AddWithValue("@P1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bağlantı.Close();
            
        }
    }
}
