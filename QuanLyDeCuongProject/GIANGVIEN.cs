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
    public partial class GIANGVIEN : Form
    {
        public GIANGVIEN()
        {
            InitializeComponent();
        }
        void LaySLGV()
        {
            lbSL.Text = listDS.Items.Count.ToString() + " giảng viên";
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
                cbdonvi.Items.Add(dt.Rows[i][1].ToString()); ;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count != 0)
            {
                string txt = listDS.SelectedItems[0].SubItems[0].Text;

                string sql = "select MaGV, HoTen, NgaySinh, GioiTinh, MaDV, HocHam, HocVi, SoDT, MaDV, Email, DiaChi From GIANGVIEN gv, NGUOIDUNG nd where gv.MaND = nd.MaNguoiDung and  MaGV='" + txt + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);

                txtGV.Text = dt.Rows[0]["MaGV"].ToString();
                txtHoten.Text = dt.Rows[0]["HoTen"].ToString();
              d1.Text = dt.Rows[0][2].ToString();
                cbGioi.Text = dt.Rows[0][3].ToString();
                txtSDT.Text = dt.Rows[0][7].ToString();
                txtEmail.Text = dt.Rows[0][9].ToString();
                txtDiachi.Text = dt.Rows[0][10].ToString();
                cbdonvi1.Text = dt.Rows[0][4].ToString();
                txtHH.Text = dt.Rows[0][5].ToString();
                txtHV.Text = dt.Rows[0][6].ToString();
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
            string hocham = txtHH.Text;
            string hocvi = txtHV.Text;

            string sql = $"update GIANGVIEN set MaGV = '{gv}',HoTen = N'{hoten}',NgaySinh = '{ngaysinh}',GioiTinh = N'{gt}',SoDT= '{sdt}',Email = '{email}',DiaChi = N'{diachi}',MaDV = '{dv}',HocHam = N'{hocham}',HocVi = N'{hocvi}' where MaGV ='{gv}'  ";

            try
            {
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                MessageBox.Show("Đã sửa thông tin giảng viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sửa thông tin giảng viên mới không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }
    }
}
