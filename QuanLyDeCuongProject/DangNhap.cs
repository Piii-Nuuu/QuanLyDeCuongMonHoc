using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class DangNhap : Form
    {
        DataBase db;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Sign_in_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienMatKhau.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btSIGNIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (email == "") { MessageBox.Show("Vui lòng nhập email!"); }
            else if (password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
            }
            else
            {

            }
            Home home = new Home();
            home.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grB_Enter(object sender, EventArgs e)
        {

        }
    }
}
