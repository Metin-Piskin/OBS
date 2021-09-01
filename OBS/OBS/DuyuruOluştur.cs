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
    public partial class DuyuruOluştur : Form
    {
        public DuyuruOluştur()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_DuyuruTableAdapter ds = new OBSDataSetTableAdapters.Tbl_DuyuruTableAdapter();
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
            ds.DuyuruEkle(RchDuyuru.Text);
            MessageBox.Show("Duyuru Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DuyuruSil(byte.Parse(Txtİd.Text));
            MessageBox.Show("Duyuru Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.DuyuruGüncelle(RchDuyuru.Text, byte.Parse(Txtİd.Text));
            MessageBox.Show("Duyuru Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DuyuruListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            RchDuyuru.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
