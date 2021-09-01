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
    public partial class ÖğrenciGiriş : Form
    {
        public ÖğrenciGiriş()
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

        private void BtnGiriş_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Öğrenci Where Öğrenciİd=@p1 and ÖğrenciŞifre=@p2", bağlantı);
            komut.Parameters.AddWithValue("@p1", Txtİd.Text);
            komut.Parameters.AddWithValue("@p2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                
                ÖğrenciSayfası frm = new ÖğrenciSayfası();
                frm.tc = MskTC.Text;
                frm.numara = Txtİd.Text;
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Öğrenci TC & Şifre", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtŞifre.Clear();
                MskTC.Clear();
                MskTC.Focus();
            }
            bağlantı.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÖğrenciListesi öl = new ÖğrenciListesi();
            öl.Show();
        }
    }
}
