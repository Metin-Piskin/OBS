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
    public partial class ÖğrenciKayıt : Form
    {
        public ÖğrenciKayıt()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_ÖğrenciTableAdapter ds = new OBSDataSetTableAdapters.Tbl_ÖğrenciTableAdapter();
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SekreterSayfası ss = new SekreterSayfası();
            ss.Show();
            this.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.ÖğrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbSınıf.SelectedValue.ToString()), CmbCinsiyet.Text, MskTC.Text, TxtNo.Text, TxtŞifre.Text);
            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖğrenciGüncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbSınıf.SelectedValue.ToString()), CmbCinsiyet.Text, MskTC.Text, TxtNo.Text, TxtŞifre.Text, int.Parse(Txtİd.Text));
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            dataGridView1.DataSource = ds.ÖğrenciListele();
            SqlCommand komut1 = new SqlCommand("SELECT Öğrenciİd, ÖğrenciAd, ÖğrenciSoyad, ÖğrenciSınıf, ÖğrenciCinsiyet , ÖğrenciTc, ÖğrenciŞifre, ÖğrenciNo From Tbl_Öğrenci INNER JOIN Tbl_Sınıf ON Tbl_Öğrenci.ÖğrenciSınıf = Tbl_Sınıf.Sınıfİd", bağlantı);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            bağlantı.Close();
        }

        private void ÖğrenciKayıt_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sınıf", bağlantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbSınıf.DisplayMember = "Sınıf";
            CmbSınıf.ValueMember = "Sınıfİd";
            CmbSınıf.DataSource = dt;
            bağlantı.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbSınıf.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            CmbCinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            MskTC.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtŞifre.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtNo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
    }
}
