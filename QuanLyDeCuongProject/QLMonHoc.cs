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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDeCuongProject
{
    public partial class QLMonHoc : Form
    {
        string connectionString = "";


        public QLMonHoc()
        {
            InitializeComponent();
           


        }
        private void LoadData()
        {
            listMonHoc.Items.Clear(); // Xóa danh sách cũ

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaMH, TenMH, MaNganh FROM MONHOC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Thêm dữ liệu vào ListView
                    ListViewItem item = new ListViewItem(reader["MaMH"].ToString());
                    item.SubItems.Add(reader["TenMH"].ToString());
                    item.SubItems.Add(reader["MaNganh"].ToString());
                    listMonHoc.Items.Add(item);
                }
            }
        }



        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void listMonHoc_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listMonHoc.SelectedItems[0];
                txtMaMon.Text = selectedItem.SubItems[0].Text; // Mã môn học
                txtTenMon.Text = selectedItem.SubItems[1].Text; // Tên môn học
                txtMaNganh.Text = selectedItem.SubItems[2].Text; // Mã ngành
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE MONHOC SET TenMH = @TenMH, MaNganh = @MaNganh WHERE MaMH = @MaMH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                cmd.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            listMonHoc.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaMH, TenMH, MaNganh FROM MONHOC WHERE MaMH LIKE @MaMH OR TenMH LIKE @TenMH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", "%" + txtTenMon_TimKiem.Text + "%");
                cmd.Parameters.AddWithValue("@TenMH", "%" + txtTenMon_TimKiem.Text + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MaMH"].ToString());
                    item.SubItems.Add(reader["TenMH"].ToString());
                    item.SubItems.Add(reader["MaNganh"].ToString());
                    listMonHoc.Items.Add(item);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MONHOC WHERE MaMH = @MaMH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", txtMaMon.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa môn học thành công!");
                LoadData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO MONHOC (MaMH, TenMH, MaNganh) VALUES (@MaMH, @TenMH, @MaNganh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                cmd.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm môn học thành công!");
                LoadData();
            }
        }
    }
}
