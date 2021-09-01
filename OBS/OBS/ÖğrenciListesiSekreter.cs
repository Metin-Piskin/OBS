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
    public partial class ÖğrenciListesiSekreter : Form
    {
        public ÖğrenciListesiSekreter()
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

        private void ÖğrenciListesiSekreter_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğrenciListele();
        }
    }
}
