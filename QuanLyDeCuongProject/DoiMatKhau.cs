using QuanLyDeCuongProject.Query;
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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        NguoiDungQuery userQuery = new NguoiDungQuery();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPass = userQuery.getPassword(Modify.taiKhoan.ma_nguoi_dung).Rows[0][0].ToString();
                if (currentPass != txtCurrentPassword.Text)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng", "Nhập sai mật khẩu");
                    return;
                }

                userQuery.UpdatePassword(txtNewPassword.Text, Modify.taiKhoan.ma_nguoi_dung);
                MessageBox.Show("Cập nhật mật khẩu thành công ");
                this.Hide();
                Home h = new Home();
                h.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật mật khẩu thất bại");
            }
        }

        private void ckHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienMatKhau.Checked)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtCurrentPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                txtCurrentPassword.UseSystemPasswordChar = true;
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.UseSystemPasswordChar = true;
        }
    }
}
