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
    public partial class ÖğretmenSayfası : Form
    {
        public ÖğretmenSayfası()
        {
            InitializeComponent();
        }
        
        public string tc;

        SqlConnection bağlantı = new SqlConnection(@"Data Source=DESKTOP-ATVNEGK;Initial Catalog=OBS;Integrated Security=True");
        OBSDataSetTableAdapters.Tbl_NotTableAdapter ds = new OBSDataSetTableAdapters.Tbl_NotTableAdapter();
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ÖğretmenGiriş ög = new ÖğretmenGiriş();
            ög.Show();
            this.Close();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();
        }

        private void ÖğretmenSayfası_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;

            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select ÖğretmenAd,ÖğretmenSoyad,ÖğretmenBranş From Tbl_Öğretmen Where ÖğretmenTc=@p1", bağlantı);
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
                LblBranş.Text = dr[2].ToString();
               
            }
            bağlantı.Close();

            bağlantı.Open();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Ders", bağlantı);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DersAd";
            CmbDers.ValueMember = "Dersİd";
            CmbDers.DataSource = dt;
            bağlantı.Close();
        }
        
        private void BtnAra_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = ds.NotListele(int.Parse(Txtİd.Text));
            CmbDers.Enabled = true;
            TxtSınav1.Enabled = true;
            TxtSınav2.Enabled = true;
            TxtSınav3.Enabled = true;
            TxtProje.Enabled = true;
            Txtİd.Enabled = false;
            string numara = Txtİd.Text;
            SqlCommand komut = new SqlCommand("Select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum From Tbl_Not INNER JOIN Tbl_Ders ON Tbl_Not.Dİd = Tbl_Ders.Dersİd Where Öğrİd = @P1", bağlantı);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        int notid;
        int sınav1, sınav2, sınav3, proje;

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.NotGüncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtİd.Text), byte.Parse(TxtSınav1.Text), byte.Parse(TxtSınav2.Text), byte.Parse(TxtSınav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrt.Text), bool.Parse(TxtDurum.Text), notid);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            CmbDers.Enabled = false;
            TxtSınav1.Enabled = false;
            TxtSınav2.Enabled = false;
            TxtSınav3.Enabled = false;
            TxtProje.Enabled = false;
            Txtİd.Enabled = true;
            Txtİd.Clear();
            TxtSınav1.Clear();
            TxtSınav2.Clear();
            TxtSınav3.Clear();
            TxtProje.Clear();
            TxtOrt.Clear();
            TxtDurum.Clear();
            Txtİd.Focus();
            
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            sınav1 = Convert.ToInt16(TxtSınav1.Text);
            sınav2 = Convert.ToInt16(TxtSınav2.Text);
            sınav3 = Convert.ToInt16(TxtSınav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ort = (sınav1 + sınav2 + sınav3 + proje) / 4;
            TxtOrt.Text = ort.ToString();
            if (ort >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        double ort;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            
        }
    }
}
