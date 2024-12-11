using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyDeCuongProject
{
    public partial class SINHVIEN : Form
    {
        public SINHVIEN()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-9TCL0NI\SQLEXPRESS;Initial Catalog=QuanLyDeCuong;Integrated Security=True"); 
        public DataTable LayDL(string cm)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm, cn);
            da.Fill(dt);
            return dt;
        }
        void hienthi(DataTable dt)
        {
            listSV.Items.Clear();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listSV.Items.Add(dt.Rows[i]["MaSV"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["Hoten"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["Email"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["SoDT"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["NgaySinh"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["NgaySinh"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["GioiTinh"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["TenLop"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["TenNganh"].ToString());
                listSV.Items[i].SubItems.Add(dt.Rows[i]["Ten"].ToString());
            }
            lbSL.Text = $"{dt.Rows.Count} Sinh viên";
        }
        private void SINHVIEN_Load(object sender, EventArgs e)
        {
            DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
            DataTable dt = LayDL("select * from LOP");
            cblop.DataSource = dt;
            cblop.DisplayMember = "TenLop";
            cblop.ValueMember = "MaLop";

            cbloc.DataSource = dt;
            cbloc.DisplayMember = "TenLop";
            cbloc.ValueMember = "MaLop";

            cbloptimkiem.DataSource = dt;
            cbloptimkiem.DisplayMember = "TenLop";
            cbloptimkiem.ValueMember = "MaLop";

            DataTable dt2 = LayDL("select * from NGANH");
            cbnganh.DataSource = dt2;
            cbnganh.DisplayMember = "TenNganh";
            cbnganh.ValueMember = "MaNganh";

            DataTable dt3 = LayDL("select * from HinhThucDaoTao");
            cbhtdt.DataSource = dt3;
            cbhtdt.DisplayMember = "Ten";
            cbhtdt.ValueMember = "Ma";
            hienthi(dt1);
        }

        private void listSV_Click(object sender, EventArgs e)
        {
            int vt = listSV.SelectedItems[0].Index;
            txtMssv.Text = listSV.Items[vt].SubItems[0].Text;
            txtHoten.Text = listSV.Items[vt].SubItems[1].Text;
            txtEmail.Text = listSV.Items[vt].SubItems[2].Text;
            txtSDT.Text = listSV.Items[vt].SubItems[3].Text;
            txtDiachi.Text = listSV.Items[vt].SubItems[4].Text;
            dtns.Value = DateTime.Parse(listSV.Items[vt].SubItems[5].Text);
            if (listSV.SelectedItems[0].SubItems[6].Text == "Nam")
            {
                ranam.Checked = true;
                ranu.Checked = false;
            }
            else
            {
                ranu.Checked = true;
                ranam.Checked = false;
            }
            cblop.Text = listSV.Items[vt].SubItems[7].Text;
            cbnganh.Text = listSV.Items[vt].SubItems[8].Text;
            cbhtdt.Text = listSV.Items[vt].SubItems[9].Text;

        }

        private void listSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbloc_SelectedIndexChanged(object sender, EventArgs e)
        {

            string malop = cbloc.SelectedValue.ToString();
            if(malop != "System.Data.DataRowView")
            {
               
                string sql = $"select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and l.MaLop = '{malop}'";
                DataTable dt = LayDL(sql);
                hienthi(dt);
            }
        }
        public void reset()
        {
            txtMssv.Text = "";
            txtHoten.Text = "";
            dtns.Text = "";
            ranam.Checked = false;
            ranu.Checked = false;
            txtSDT.Text = "";
            cbnganh.Text = "";
            txtEmail.Text = "";
            cblop.Text = "";
            cbhtdt.Text = "";
            txtDiachi.Text = "";
            
            
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 MaSV from SINHVIEN ORDER BY MaSV DESC";
            DataTable dt = LayDL(sql);
            string newMaSV = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            MessageBox.Show(newMaSV);
            
        }

        private void cblop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btghi_Click(object sender, EventArgs e)
        {
            string maND = "";
            string mssv = txtMssv.Text, hoten = txtHoten.Text, ngay = dtns.Value.ToString("MM/dd/yyyy"), sdt = txtSDT.Text, nganh = cbnganh.SelectedValue.ToString(), email = txtEmail.Text, lop = cblop.Text, diachi = txtDiachi.Text, htdt = cbhtdt.SelectedValue.ToString();
            int gt = ranam.Checked ? 1 : 0;
            try
            {
                string sql = $"insert into SINHVIEN(MSSV, MaND,MaNganh,HinhThucDaoTao,ManLop,) Values('{mssv}', '{maND}', {email}, {sdt}, N'{diachi}'),{ngay},{gt},{lop},{nganh},{htdt};";
                SqlCommand cd = new SqlCommand(sql,cn);
                cn.Open();
                cd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Ghi Thành Công");
                reset();
                DataTable dt = new DataTable();
                hienthi(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi DataBase" + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string malop = cbloptimkiem.SelectedValue.ToString();
            string masv = txtmssvtimkiem.Text;
            string sql = "select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma and l.MaLop = '"+malop+"' and sv.MaSV = '"+masv+"'";
            DataTable dt = LayDL(sql);
            hienthi(dt);
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"delete SINHVIEN where MaSV='{txtMssv.Text}';";
                string sql2 = $"select nd.MaNguoiDung  from NguoiDung nd, SINHVIEN sv where nd.MaNguoiDung = sv.MaND and sv.MaSV = '"+txtMssv.Text+"'";
                DataTable dtldl = LayDL(sql2);

                string sql3 = $"delete NguoiDung where MaNguoiDung='{dtldl.Rows[0][0].ToString()}';";

                SqlCommand cd = new SqlCommand(sql, cn);
                cn.Open();
                cd.ExecuteNonQuery();
                cn.Close();

                SqlCommand cd1 = new SqlCommand(sql3, cn);
                cn.Open();
                cd1.ExecuteNonQuery();
                cn.Close();

                DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
                hienthi(dt1);
                reset();
                MessageBox.Show("Xoa Thanh Cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi DataBase" + ex.Message);
            }
        }
    }
}
