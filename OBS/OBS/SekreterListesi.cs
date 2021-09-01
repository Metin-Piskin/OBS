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
    public partial class SekreterListesi : Form
    {
        public SekreterListesi()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_SekreterTableAdapter ds = new OBSDataSetTableAdapters.Tbl_SekreterTableAdapter();
        private void SekreterListesi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.SekreterListele();
        }

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
    }
}
