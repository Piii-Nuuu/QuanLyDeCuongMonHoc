﻿
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
using QuanLyDeCuongProject.Consts;
using QuanLyDeCuongProject.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDeCuongProject
{
    public partial class QLMonHoc : Form

    {
       





        string connectionString = @"Data Source=MSI\MSSQLSERVER01;Initial Catalog=QuanLyDeCuong;Integrated Security=True";


        private void ClearInputFields()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            cbbMaNganh.SelectedIndex = -1;
            txtSoTinChi.Text = "";
            txtSoTietLyThuyet.Text = "";
            txtSoTietThucHanh.Text = "";
        }

        public QLMonHoc()
        {
            InitializeComponent();
            LoadListView();
            txtMaMon.ReadOnly = true;
        }

        private void LoadListView()
        {
            listMonHoc.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MONHOC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MaMH"].ToString());
                    item.SubItems.Add(reader["TenMH"].ToString());
                    item.SubItems.Add(reader["MaNganh"].ToString());
                    item.SubItems.Add(reader["SoTC"].ToString());
                    item.SubItems.Add(reader["SoTietLT"].ToString());
                    item.SubItems.Add(reader["SoTietTH"].ToString());
                    listMonHoc.Items.Add(item);
                }
                reader.Close();
            }
        }
        private string GenerateNewMaMH(SqlConnection connection)
        {
            string query = "SELECT TOP 1 MaMH FROM MONHOC ORDER BY MaMH DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            if (result != null)
            {
                string lastMaMH = result.ToString();
                int newID = int.Parse(lastMaMH.Substring(2)) + 1;
                return "MH" + newID.ToString("D3");
            }
            else
            {
                return "MH001";
            }
        }
        private void LoadComboBoxMaNganh()
        {
            try
            {
                cbbMaNganh.Items.Clear(); // Xóa danh sách cũ để tránh trùng lặp
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaNganh FROM NGANH";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cbbMaNganh.Items.Add(reader["MaNganh"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu ngành nào!", "Thông báo");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu mã ngành: {ex.Message}", "Lỗi");
            }
        }




        private void LoadData()
        {


        }



        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            LoadData(); LoadComboBoxMaNganh();

        }

        private void listMonHoc_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem item = listMonHoc.SelectedItems[0];
                txtMaMon.Text = item.SubItems[0].Text;
                txtTenMon.Text = item.SubItems[1].Text;
                cbbMaNganh.SelectedItem = item.SubItems[2].Text;
                txtSoTinChi.Text = item.SubItems[3].Text;
                txtSoTietLyThuyet.Text = item.SubItems[4].Text;
                txtSoTietThucHanh.Text = item.SubItems[5].Text;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE MONHOC SET TenMH = @TenMH, MaNganh = @MaNganh, SoTinChi = @SoTinChi, SoTietLyThuyet = @SoTietLyThuyet, SoTietThucHanh = @SoTietThucHanh WHERE MaMH = @MaMH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                    command.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                    command.Parameters.AddWithValue("@MaNganh", cbbMaNganh.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@SoTinChi", txtSoTinChi.Text);
                    command.Parameters.AddWithValue("@SoTietLyThuyet", txtSoTietLyThuyet.Text);
                    command.Parameters.AddWithValue("@SoTietThucHanh", txtSoTietThucHanh.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Cập nhật thành công!");


                    LoadListView();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Mã môn không được để trống!");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Kiểm tra khóa ngoại trước khi xóa
                        string checkQuery = "SELECT COUNT(*) FROM TABLE_REFERENCING_MONHOC WHERE MaMH = @MaMH";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                            int referenceCount = (int)checkCommand.ExecuteScalar();

                            if (referenceCount > 0)
                            {
                                MessageBox.Show("Không thể xóa vì môn học này đang được tham chiếu bởi bảng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Thực hiện xóa nếu không bị khóa ngoại
                        string deleteQuery = "DELETE FROM MONHOC WHERE MaMH = @MaMH";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công!");
                                LoadListView();
                                ClearInputFields();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã môn để xóa.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string newMaMH = GenerateNewMaMH(connection);


                string query = "INSERT INTO MONHOC (MaMH, TenMH, MaNganh, SoTinChi, SoTietLyThuyet, SoTietThucHanh) VALUES (@MaMH, @TenMH, @MaNganh, @SoTinChi, @SoTietLyThuyet, @SoTietThucHanh)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaMH", newMaMH);
                command.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                command.Parameters.AddWithValue("@MaNganh", cbbMaNganh.SelectedItem.ToString());
                command.Parameters.AddWithValue("@SoTinChi", txtSoTinChi.Text);
                command.Parameters.AddWithValue("@SoTietLyThuyet", txtSoTietLyThuyet.Text);
                command.Parameters.AddWithValue("@SoTietThucHanh", txtSoTietThucHanh.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Thêm mới thành công!");


                LoadListView();
                ClearInputFields();
            }
        }

        private void btnTim_Click_1(object sender, EventArgs e)
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
    }
}
