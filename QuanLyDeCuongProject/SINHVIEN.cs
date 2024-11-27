using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDeCuongProject
{
    public partial class SINHVIEN : Form
    {
        public SINHVIEN()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=MSI\MSSQLSERVER01;Initial Catalog=QuanLyDeCuong;Integrated Security=True"); 
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
        }
        private void SINHVIEN_Load(object sender, EventArgs e)
        {
            DataTable dt1 = LayDL("select MaSV, HoTen, Email, SoDT,DiaChi, NgaySinh, GioiTinh, TenLop, TenNganh, Ten  from SINHVIEN sv, NguoiDung nd, LOP l, NGANH n, HINHTHUCDAOTAO dt where sv.MaND = nd.MaNguoiDung and l.MaLop = sv.MaLop and n.MaNganh = sv.MaNganh and sv.HinhThucDaoTao = dt.Ma");
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nu");
            DataTable dt = LayDL("select * from LOP");
            cblop.DataSource = dt;
            cblop.DisplayMember = "TenLop";
            cblop.ValueMember = "MaLop";
            cbloc.DataSource = dt;
            cbloc.DisplayMember = "TenLop";
            cbloc.ValueMember = "MaLop";
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
            cbGioiTinh.Text = listSV.Items[vt].SubItems[6].Text;
            cblop.Text = listSV.Items[vt].SubItems[7].Text;
            txtnganh.Text = listSV.Items[vt].SubItems[8].Text;
            txthtdt.Text = listSV.Items[vt].SubItems[9].Text;

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
    }
}
