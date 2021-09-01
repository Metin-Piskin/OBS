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
    public partial class ÖğretmenKayıt : Form
    {
        public ÖğretmenKayıt()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_ÖğretmenTableAdapter ds = new OBSDataSetTableAdapters.Tbl_ÖğretmenTableAdapter();
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SekreterSayfası ss = new SekreterSayfası();
            ss.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.ÖğretmenEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbBranş.SelectedValue.ToString()), MskTC.Text, TxtŞifre.Text);
            MessageBox.Show("Öğretmen Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖğretmenGüncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbBranş.SelectedValue.ToString()), MskTC.Text, TxtŞifre.Text, byte.Parse(Txtİd.Text));
            MessageBox.Show("Öğretmen Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğretmenListele();
            
        }

        private void ÖğretmenKayıt_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ders", bağlantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbBranş.DisplayMember = "DersAd";
            CmbBranş.ValueMember = "Dersİd";
            CmbBranş.DataSource = dt;
            bağlantı.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbBranş.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtŞifre.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
