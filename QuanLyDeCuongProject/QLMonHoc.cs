
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyDeCuongProject.Consts;
using QuanLyDeCuongProject.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
namespace QuanLyDeCuongProject
{
    public partial class QLMonHoc : Form

    {

        Helpers helper = new Helpers();
        string connectionString = $@"Data Source={Const.ServerName};Initial Catalog=QuanLyDeCuong;Integrated Security=True";


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

        private void UpdateTotalCounts()
        {

            int totalPermissions = listMonHoc.Items.Count;
            lbSL.Text = $"{totalPermissions} hiện có";

            int totalActions = listMonHoc.Items.Count;
            lbSL.Text = $" {totalActions}  môn học";
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            helper.XulySangToi(true, btnThem, btnCapNhat, btnXoa, btnLuu);
            if (Modify.taiKhoan == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản?");
                this.Close();   

                return;
            }
            if (!helper.checkPermission(17, Modify.taiKhoan.ma_quyen))
            {
               
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.Close();
                return;
            }
            LoadData(); LoadComboBoxMaNganh();
            UpdateTotalCounts();

        }

        private void listMonHoc_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (listMonHoc.SelectedItems.Count > 0)
            {
                ListViewItem item = listMonHoc.SelectedItems[0];
                txtMaMon.Text = item.SubItems[0].Text;
                txtTenMon.Text = item.SubItems[1].Text;
                cbbMaNganh.Text = item.SubItems[2].Text;
                txtSoTinChi.Text = item.SubItems[3].Text;
                txtSoTietLyThuyet.Text = item.SubItems[4].Text;
                if (item.SubItems.Count > 5)  // Kiểm tra có đủ số cột không
                {
                    txtSoTietThucHanh.Text = item.SubItems[5].Text;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!helper.checkPermission(19, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(true, btnThem, btnCapNhat, btnXoa, btnLuu);
            if (listMonHoc.SelectedItems.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE MONHOC SET TenMH = @TenMH, MaNganh = @MaNganh, SoTC = @SoTinChi, SoTietLT = @SoTietLT, SoTietTH = @SoTietTH WHERE MaMH = @MaMH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaMH", txtMaMon.Text);
                    command.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                    command.Parameters.AddWithValue("@MaNganh", cbbMaNganh.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@SoTinChi", txtSoTinChi.Text);
                    command.Parameters.AddWithValue("@SoTietLT", txtSoTietLyThuyet.Text);
                    command.Parameters.AddWithValue("@SoTietTH", txtSoTietThucHanh.Text);

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
            if (!helper.checkPermission(20, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(true, btnThem, btnCapNhat, btnXoa, btnLuu);
            if (listMonHoc.SelectedItems.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Mã môn không được để trống!");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


                        // Thực hiện xóa nếu không bị khóa ngoại
                        string deleteMH = $"Delete DeCuong where MaMon='{txtMaMon.Text}'";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteMH, connection))
                        {
                    
                           deleteCommand.ExecuteNonQuery();

                           
                        }





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
          
            if (!helper.checkPermission(18, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(false, btnThem, btnCapNhat, btnXoa, btnLuu);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    string newMaMH = GenerateNewMaMH(connection);
                    txtMaMon.Text = newMaMH;
                    txtMaMon.ReadOnly = true; 
                    ClearInputFields(); 
                    txtMaMon.Text = newMaMH; 

                    MessageBox.Show($"Mã môn học mới: {newMaMH}. Hãy nhập các thông tin còn lại để thêm mới môn học!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi tạo mã môn học: {ex.Message}");
                }
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

        private void txtTenMon_TimKiem_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT MaMH, TenMH, SoTC, SoTietLT, SoTietTH FROM MONHOC WHERE TenMH LIKE N'%{txtTenMon_TimKiem.Text}%'";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                listMonHoc.Items.Clear();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    ListViewItem item = new ListViewItem(reader["MaMH"].ToString());
                    item.SubItems.Add(reader["TenMH"].ToString());
                    item.SubItems.Add(reader["SoTC"].ToString());
                    item.SubItems.Add(reader["SoTietLT"].ToString());
                    item.SubItems.Add(reader["SoTietTH"].ToString());
                    listMonHoc.Items.Add(item);
                }
                lbSL.Text = count.ToString();
            }
        }
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSoTietThucHanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text) || cbbMaNganh.SelectedIndex == -1 ||
       string.IsNullOrWhiteSpace(txtSoTinChi.Text) || string.IsNullOrWhiteSpace(txtSoTietLyThuyet.Text) ||
       string.IsNullOrWhiteSpace(txtSoTietThucHanh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string newMaMH = GenerateNewMaMH(connection);

                    string query = "INSERT INTO MONHOC (MaMH, TenMH, MaNganh, SoTC, SoTietLT, SoTietTH) " +
                                   "VALUES (@MaMH, @TenMH, @MaNganh, @SoTC, @SoTietLT, @SoTietTH)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaMH", newMaMH);
                    command.Parameters.AddWithValue("@TenMH", txtTenMon.Text);
                    command.Parameters.AddWithValue("@MaNganh", cbbMaNganh.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@SoTC", txtSoTinChi.Text);
                    command.Parameters.AddWithValue("@SoTietLT", txtSoTietLyThuyet.Text);
                    command.Parameters.AddWithValue("@SoTietTH", txtSoTietThucHanh.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.XulySangToi(true, btnThem, btnCapNhat, btnXoa, btnLuu);
                    LoadListView();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSoTinChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTietLyThuyet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoTietLyThuyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTietThucHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122) || (e.KeyChar == 8));
        }
    }
}
