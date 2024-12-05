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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
          
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MonHoc_Click(object sender, EventArgs e)
        {
            QLMonHoc mon_hoc_frm = new QLMonHoc();
            mon_hoc_frm.Show();
            this.Hide();
        }

        private void QLDeCuong_Click(object sender, EventArgs e)
        {
            DeCuong de_cuong_frm = new DeCuong();
            de_cuong_frm.Show();
            this.Hide();
        }

        private void QLNganh_Click(object sender, EventArgs e)
        {
            QL_Nganh nganh_frm = new QL_Nganh();
            nganh_frm.Show();
            this.Hide();
        }

        private void QLPhanQuyen_Click(object sender, EventArgs e)
        {
            QuanLyPhanQuyen phan_quyen_frm = new QuanLyPhanQuyen();
            phan_quyen_frm.Show();
            this.Hide();
        }

        private void QLGiangVien_Click(object sender, EventArgs e)
        {
            GIANGVIEN giang_vien_frm = new GIANGVIEN();
            giang_vien_frm.Show();
            this.Hide();
        }

        private void QLSinhVien_Click(object sender, EventArgs e)
        {
            SINHVIEN sinh_vien_frm = new SINHVIEN();
            sinh_vien_frm.Show();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm_password = new DoiMatKhau();
            frm_password.ShowDialog();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                       "Bạn có chắc chắn muốn đăng xuất?",
                       "Xác nhận đăng xuất",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
            if(confirmResult == DialogResult.Yes)
            {
                DangNhap frm_signIn = new DangNhap();
                frm_signIn.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuaThongTinCaNhan frm_edit = new SuaThongTinCaNhan();
            frm_edit.ShowDialog();

        }
    }
}
