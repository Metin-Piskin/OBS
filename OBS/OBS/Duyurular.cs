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
    public partial class Duyurular : Form
    {
        public Duyurular()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_DuyuruTableAdapter ds = new OBSDataSetTableAdapters.Tbl_DuyuruTableAdapter();
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Duyurular_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DuyuruListele();
        }
    }
}
