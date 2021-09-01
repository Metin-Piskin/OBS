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
    public partial class SekreterGiriş : Form
    {
        public SekreterGiriş()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Girişler g = new Girişler();
            g.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LblKaydol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SekreterKayıt sk = new SekreterKayıt();
            sk.Show();
            this.Close();
        }

        private void BtnGiriş_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTc=@p1 and SekreterŞifre=@p2", bağlantı);
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SekreterSayfası frm = new SekreterSayfası();
                frm.tc = MskTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sekreter TC & Şifre", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtŞifre.Clear();
                MskTC.Clear();
                MskTC.Focus();
            }
            bağlantı.Close();
        }
    }
}
