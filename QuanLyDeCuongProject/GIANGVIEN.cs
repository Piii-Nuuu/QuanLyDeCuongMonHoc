﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QuanLyDeCuongProject
{
    public partial class GIANGVIEN : Form
    {
        string mand = "";
        public GIANGVIEN()
        {
            InitializeComponent();
        }
        void LaySLGV()
        {
            lbSL.Text = listDS.Items.Count.ToString() + " giảng viên";
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count != 0)
            {
                string txt = listDS.SelectedItems[0].SubItems[0].Text;

                string sql = "select MaGV, HoTen, NgaySinh, GioiTinh, MaDV, HocHam, HocVi, SoDT, MaDV, Email, DiaChi, MaND From GIANGVIEN gv, NGUOIDUNG nd where gv.MaND = nd.MaNguoiDung and  MaGV='" + txt + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                mand = dt.Rows[0]["MaND"].ToString();
                txtGV.Text = dt.Rows[0]["MaGV"].ToString();
                txtHoten.Text = dt.Rows[0]["HoTen"].ToString();
                d1.Text = dt.Rows[0][2].ToString();
                cbGioi.Text = dt.Rows[0][3].ToString();
                txtSDT.Text = dt.Rows[0][7].ToString();
                txtEmail.Text = dt.Rows[0][9].ToString();
                txtDiachi.Text = dt.Rows[0][10].ToString();
                cbdonvi1.Text = dt.Rows[0][4].ToString();
                cbhocham.Text = dt.Rows[0][5].ToString();
                cbhocvi.Text = dt.Rows[0][6].ToString();
            }
            LaySLGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtHoten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string gv = txtGV.Text;
            string hoten = txtHoten.Text;
            string ngaysinh = d1.Value.ToString("yyyy/MM/dd");
            string gt = cbGioi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diachi = txtDiachi.Text;
            string dv = cbdonvi1.Text;
            string hocham = cbhocham.Text;
            string hocvi = cbhocvi.Text;

            string sqlGV = $"update GIANGVIEN set MaDV = '{dv}',HocHam = N'{hocham}',HocVi = N'{hocvi}' where MaGV ='{gv}'  ";
            string sqlND = $"update NguoiDung set NgaySinh = '{ngaysinh}', HoTen = '{hoten}', GioiTinh = '{gt}', SoDT = '{sdt}', DiaChi = '{diachi}' where MaNguoiDung = '{mand}' ";

            try
            {
                CSDL.XuLy(sqlGV);
                CSDL.XuLy(sqlND);
                //CSDL.GhiLenhXuLySQL(sql);
                GIANGVIEN_Load(sender, e);
                MessageBox.Show("Đã sửa thông tin giảng viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                GIANGVIEN_Load(sender, e);
                MessageBox.Show("Sửa thông tin giảng viên mới không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button3_Click(object sender, EventArgs e)
        {
            string gv = txtGV.Text.Trim();
            string hoten = txtHoten.Text.Trim();

            if (string.IsNullOrEmpty(gv) || string.IsNullOrEmpty(hoten))
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận từ người dùng
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa giảng viên {hoten} (Mã GV: {gv}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Lấy MaND từ bảng GIANGVIEN dựa trên MaGV
                string sqlCheckMaND = $"SELECT MaND FROM GIANGVIEN WHERE MaGV = '{gv}'";
                DataTable dt = CSDL.LayDuLieu(sqlCheckMaND);

                if (dt.Rows.Count > 0)
                {
                    string maND = dt.Rows[0]["MaND"].ToString();

                    // Xóa dữ liệu trong bảng GIANGVIEN
                    string sqlDeleteGiangVien = $"DELETE FROM GIANGVIEN WHERE MaGV = '{gv}'";
                    CSDL.XuLy(sqlDeleteGiangVien);

                    // Xóa dữ liệu trong bảng NGUOIDUNG
                    string sqlDeleteNguoiDung = $"DELETE FROM NGUOIDUNG WHERE MaNguoiDung = '{maND}'";
                    CSDL.XuLy(sqlDeleteNguoiDung);

                    MessageBox.Show("Đã xóa giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách hiển thị
                    GIANGVIEN_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giảng viên với mã đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                GIANGVIEN_Load(sender, e);
                MessageBox.Show($"Lỗi khi xóa giảng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            string ma = txtMaGv.Text;
            string sql = "select MaGV , HoTen, NgaySinh, GioiTinh ,MaDV,HocHam ,HocVi, SoDT, MaDV, Email, DiaChi From GIANGVIEN gv, NGUOIDUNG nd where  gv.MaND = nd.MaNguoiDung and MaGV=N'" + ma + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            listDS.Items.Add(dt.Rows[0][0].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][1].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][2].ToString());
            LaySLGV();
        }
        private void GIANGVIEN_Load(object sender, EventArgs e)
        {
            // push: Changes => commit => SYsc
            // push: changes => commit => sync => pushdddddd
            CSDL.KetNoi();
            DataTable dt = new DataTable();
            String sql = @"select * from donvi";
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                cbdonvi1.Items.Add(dt.Rows[i][0].ToString());
            }
            cbGioi.Items.Add("Nam");
            cbGioi.Items.Add("Nữ");
            string sql1 = "select MaGV , HoTen, NgaySinh, GioiTinh ,MaDV,HocHam ,HocVi, SoDT, MaDV, Email, DiaChi From GIANGVIEN gv, NGUOIDUNG nd where  gv.MaND = nd.MaNguoiDung";
            DataTable dt1 = new DataTable();
            dt1 = CSDL.LayDuLieu(sql1);//
            listDS.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listDS.Items.Add(dt1.Rows[i]["MaGV"].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i]["HoTen"].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i]["MaDV"].ToString());
            }
            LaySLGV();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string gv = txtGV.Text;
            string hoten = txtHoten.Text;
            string ngaysinh = d1.Value.ToString("yyyy/MM/dd");
            string gt = cbGioi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diachi = txtDiachi.Text;
            string dv = cbdonvi1.Text;
            string hocham = cbhocham.Text;
            string hocvi = cbhocvi.Text;

            string sql = "select top 1 MaGV from  GIANGVIEN order by MaGV desc ";
            DataTable dt = CSDL.LayDuLieu(sql);
            string mahientai = dt.Rows[0][0].ToString();
            string phanten = mahientai.Substring(0, 2);
            string phanso = mahientai.Substring(2);
            int mamoi = Convert.ToInt32(phanso) + 1;
            txtGV.Text = phanten + mamoi.ToString();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            string gv = txtGV.Text.Trim();
            string hoten = txtHoten.Text.Trim();
            string ngaysinh = d1.Value.ToString("yyyy/MM/dd");
            string gt = cbGioi.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string dv = cbdonvi1.Text.Trim();
            string hocham = cbhocham.Text.Trim();
            string hocvi = cbhocvi.Text.Trim();

            if (string.IsNullOrEmpty(gv) || string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(gt) ||
                string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diachi) ||
                string.IsNullOrEmpty(dv) || string.IsNullOrEmpty(hocham) || string.IsNullOrEmpty(hocvi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lưu thông tin vào bảng NGUOIDUNG
            string sqlND = $"INSERT INTO NGUOIDUNG (MaNguoiDung, HoTen, NgaySinh, GioiTinh, SoDT, Email, DiaChi) " +
                           $"VALUES ('{mand}', N'{hoten}', '{ngaysinh}', N'{gt}', '{sdt}', '{email}', N'{diachi}')";
            CSDL.XuLy(sqlND);

            // Lưu thông tin vào bảng GIANGVIEN
            string sqlGV = $"INSERT INTO GIANGVIEN (MaGV, MaDV, HocHam, HocVi, MaND) " +
                           $"VALUES ('{gv}', '{dv}', N'{hocham}', N'{hocvi}', '{mand}')";
            CSDL.XuLy(sqlGV);

            MessageBox.Show("Lưu thông tin giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh dữ liệu hiển thị
            GIANGVIEN_Load(sender, e);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

