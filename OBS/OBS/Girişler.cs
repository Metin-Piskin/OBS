using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS
{
    public partial class Girişler : Form
    {
        public Girişler()
        {
            InitializeComponent();
        }
        //Data Source = DESKTOP-ATVNEGK; Initial Catalog = OBS; Integrated Security = True
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ÖğrenciGiriş ög = new ÖğrenciGiriş();
            ög.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ÖğretmenGiriş ög = new ÖğretmenGiriş();
            ög.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SekreterGiriş sg = new SekreterGiriş();
            sg.Show();
            this.Hide();
        }
    }
}
