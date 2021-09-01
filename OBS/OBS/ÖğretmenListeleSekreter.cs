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
    public partial class ÖğretmenListeleSekreter : Form
    {
        public ÖğretmenListeleSekreter()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_ÖğretmenTableAdapter ds = new OBSDataSetTableAdapters.Tbl_ÖğretmenTableAdapter();
        private void ÖğretmenListeleSekreter_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖğretmenListele();
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
