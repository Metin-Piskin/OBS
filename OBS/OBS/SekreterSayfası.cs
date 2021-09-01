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
    public partial class SekreterSayfası : Form
    {
        public SekreterSayfası()
        {
            InitializeComponent();
        }
        public string tc;
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SekreterGiriş sg = new SekreterGiriş();
            sg.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnÖğrenciKayıt_Click(object sender, EventArgs e)
        {
            ÖğrenciKayıt ök = new ÖğrenciKayıt();
            ök.Show();
            this.Close();
        }

        private void BtnÖğretmenKayıt_Click(object sender, EventArgs e)
        {
            ÖğretmenKayıt ök = new ÖğretmenKayıt();
            ök.Show();
            this.Close();
        }

        private void BtnDuyuruOluştur_Click(object sender, EventArgs e)
        {
            DuyuruOluştur doo = new DuyuruOluştur();
            doo.Show();
            this.Close();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }

        private void SekreterSayfası_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select SekreterAd,SekreterSoyad From Tbl_Sekreter Where SekreterTc=@p1", bağlantı);
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bağlantı.Close();
        }

        private void BtnÖğrenciListesi_Click(object sender, EventArgs e)
        {
            ÖğrenciListesiSekreter öls = new ÖğrenciListesiSekreter();
            öls.Show();
            this.Close();
        }

        private void BtnÖğretmenListesi_Click(object sender, EventArgs e)
        {
            ÖğretmenListeleSekreter öls = new ÖğretmenListeleSekreter();
            öls.Show();
            this.Close();
        }

        private void BtnSekreterListesi_Click(object sender, EventArgs e)
        {
            SekreterListesi sl = new SekreterListesi();
            sl.Show();
            this.Close();
        }
    }
}
