using QuanLyDeCuongProject.Modals;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class SuaThongTinCaNhan : Form
    {
        public SuaThongTinCaNhan()
        {
            InitializeComponent();
        }
        NguoiDungQuery userQuery = new NguoiDungQuery();

        private void SuaThongTinCaNhan_Load(object sender, EventArgs e)
        {
            if (Modify.taiKhoan == null)
            {
                MessageBox.Show("Error");
                this.Close();

                return;
            }
            displayComboGender();
            displayField();
        }

        public void displayField()
        {
            txtEmail.Text = Modify.user.Email;
            txtName.Text = Modify.user.HoTen;
            txtBorn.Text = Modify.user.NgaySinh;
            txtPermission.Text = Modify.user.Quyen;
            txtAddress.Text = Modify.user.DiaChi;
            txtPhone.Text = Modify.user.SoDT;
            cbGender.Text = Modify.user.GioiTinh;

        }
        void displayComboGender()
        {
            cbGender.Items.Add("Nam");
            cbGender.Items.Add("Nữ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
        
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    this.Hide();
                    Home h = new Home();
                    h.refershUser();
                        h.Show();
                }
           
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung userEdit = new NguoiDung();
                userEdit.DiaChi = txtAddress.Text;
                userEdit.NgaySinh = txtBorn.Value.ToString("MM/dd/yyyy");
                userEdit.GioiTinh = cbGender.SelectedItem.ToString();
                userEdit.SoDT = txtPhone.Text;
                userEdit.HoTen = txtName.Text;
                MessageBox.Show(userEdit.NgaySinh + userEdit.GioiTinh);
                userQuery.UpdateUser(userEdit, Modify.taiKhoan.ma_nguoi_dung);
                MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK);
                this.Hide();
                Home h = new Home();
                h.refershUser();
                h.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cập nhật thất bài");
            }
        }
    }
}
