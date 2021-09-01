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
    public partial class SekreterKayıt : Form
    {
        public SekreterKayıt()
        {
            InitializeComponent();
        }
        OBSDataSetTableAdapters.Tbl_SekreterTableAdapter ds = new OBSDataSetTableAdapters.Tbl_SekreterTableAdapter();
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SekreterGiriş sg = new SekreterGiriş();
            sg.Show();
            this.Close();
        }

        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            ds.SekreterEkle(TxtAd.Text, TxtSoyad.Text, MskTC.Text, TxtŞifre.Text);
            MessageBox.Show("Kaydınız Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SekreterGiriş sg = new SekreterGiriş();
            sg.Show();
            this.Close();
            
        }
    }
}
