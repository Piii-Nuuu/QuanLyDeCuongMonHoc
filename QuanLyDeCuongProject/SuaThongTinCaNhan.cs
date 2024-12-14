using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class SuaThongTinCaNhan : Form
    {
        public SuaThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void SuaThongTinCaNhan_Load(object sender, EventArgs e)
        {
            displayComboGender();
        }

        void displayComboGender()
        {
            comboGender.Items.Add("Nam");
            comboGender.Items.Add("Nữ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }
    }
}
