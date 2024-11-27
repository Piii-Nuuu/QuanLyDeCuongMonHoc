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
    public partial class QL_Nganh : Form
    {
        public QL_Nganh()
        {
            InitializeComponent();
        }
        NganhQuery nganhQuery = new NganhQuery();
        KhoaQuery khoaQuery = new KhoaQuery();
        private void QL_Nganh_Load(object sender, EventArgs e)
        {

            DataTable data = nganhQuery.GetAllNganh();
            DataTable danh_sach_khoa = khoaQuery.GetAllKhoa();
            cbListNganh.DataSource = danh_sach_khoa;
            cbListNganh.DisplayMember = "TenKhoa";
            cbListNganh.ValueMember = "MaKhoa";
            hien_thi_list_view(data);
        }

        public void hien_thi_list_view(DataTable data)
        {
           listNganh.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                listNganh.Items.Add(data.Rows[i]["MaNganh"].ToString());
                listNganh.Items[i].SubItems.Add(data.Rows[i]["TenNganh"].ToString());
                listNganh.Items[i].SubItems.Add(data.Rows[i]["TruongNganh"].ToString());
                listNganh.Items[i].SubItems.Add(data.Rows[i]["MaKhoa"].ToString());
                listNganh.Items[i].SubItems.Add(data.Rows[i]["MaDV"].ToString());
            }
        }
        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listDSNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtMaTruongNganh_TextChanged(object sender, EventArgs e)
        {

        }

        private void listDSNganh_Click(object sender, EventArgs e)
        {
           
        }

        private void listDSNganh_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listNganh_Click(object sender, EventArgs e)
        {
            string maNganh = listNganh.SelectedItems[0].SubItems[0].Text;
            DataTable data = nganhQuery.LayTheoMaNganh(maNganh);

            txtMaNganh.Text = data.Rows[0]["MaNganh"].ToString();
            txtTenNganh.Text = data.Rows[0]["TenNganh"].ToString();
            txtMaKhoa.Text = data.Rows[0]["MaKhoa"].ToString();
            txtMaTruongNganh.Text = data.Rows[0]["TruongNganh"].ToString();
        }

        private void cbListNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoa = cbListNganh.SelectedValue.ToString();
            DataTable data = nganhQuery.LayTheoMaKhoa(makhoa);
            hien_thi_list_view(data);
        }
    }
}
