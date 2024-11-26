using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDeCuongProject.Data;

namespace QuanLyDeCuongProject
{
    public partial class QLMonHoc : Form
    {
        DataBase db;
        public QLMonHoc()
        {
            InitializeComponent();
            db = new DataBase(@"Data Source=LAPTOP-1C353TLV;Initial Catalog=QuanLyDeCuong;Integrated Security=True;");
            LoadData();


        }
        private void LoadData()
        {
            listMonHoc.Items.Clear(); 
            string sql = "SELECT MaMon, TenMon, MaNganh FROM MonHoc";
            var data = db.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaMon"].ToString());
                item.SubItems.Add(row["TenMon"].ToString());
                item.SubItems.Add(row["MaNganh"].ToString());
                listMonHoc.Items.Add(item);
            }
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {

        }

        private void listMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listMonHoc.SelectedItems[0];
                txtMaMon.Text = selectedItem.SubItems[0].Text; 
                txtTenMon.Text = selectedItem.SubItems[1].Text; 
                txtMaNganh.Text = selectedItem.SubItems[2].Text; 
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMon = txtMaMon.Text;
            string tenMon = txtTenMon.Text;
            string maNganh = txtMaNganh.Text;

            string sql = $"UPDATE MonHoc SET TenMon = N'{tenMon}', MaNganh = N'{maNganh}' WHERE MaMon = N'{maMon}'";

            try
            {
                db.ExecuteNonQuery(sql); 
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
