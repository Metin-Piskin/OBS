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
    public partial class ÖğrenciListesi : Form
    {
        public ÖğrenciListesi()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ÖğrenciListesi_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Öğrenciİd,ÖğrenciAd,ÖğrenciSoyad From Tbl_Öğrenci", bağlantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
