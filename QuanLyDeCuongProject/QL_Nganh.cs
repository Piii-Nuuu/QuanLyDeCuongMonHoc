using QuanLyDeCuongProject.Consts;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDeCuongProject
{
    public partial class QL_Nganh : Form
    {
        public QL_Nganh()
        {
            InitializeComponent();
        }
        //NganhQuery nganhQuery = new NganhQuery();
        //KhoaQuery khoaQuery = new KhoaQuery();
        string connectionString = $@"Data Source={Const.ServerName};Initial Catalog=QuanLyDeCuong;Integrated Security=True";

        public void hien_thi_list_view(DataTable data)
        {
            //listNganh.Items.Clear();
            //for (int i = 0; i < data.Rows.Count; i++)
            {
                //listNganh.Items.Add(data.Rows[i]["MaNganh"].ToString());
                //listNganh.Items[i].SubItems.Add(data.Rows[i]["TenNganh"].ToString());
                //listNganh.Items[i].SubItems.Add(data.Rows[i]["TruongNganh"].ToString());
                //listNganh.Items[i].SubItems.Add(data.Rows[i]["MaKhoa"].ToString());
                //listNganh.Items[i].SubItems.Add(data.Rows[i]["MaDV"].ToString());
            }
        }
        private void LoadData()
        {
            listNganh.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TruongNganh, MaDV, MaNganh, TenNganh, MaKhoa FROM NGANH";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MaNganh"].ToString());
                    item.SubItems.Add(reader["TenNganh"].ToString());
            
                    item.SubItems.Add(reader["TruongNganh"].ToString());
                    item.SubItems.Add(reader["MaKhoa"].ToString());
                    listNganh.Items.Add(item);
                    count++;
                }
                lbSL.Text = count.ToString() + " Ngành ";
                reader.Close();
                string sqlKhoa = @"select MaKhoa from Khoa";
                string sqlTruong = @"select MaGV from GiangVien where MaGV not in (select  TruongNganh from Nganh )";
                SqlDataAdapter da = new SqlDataAdapter(sqlKhoa, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbmakhoa.DataSource = dt;
                cbmakhoa.DisplayMember = "TenKhoa";
                cbmakhoa.ValueMember = "MaKhoa";
                da = new SqlDataAdapter(sqlTruong, conn);
                dt = new DataTable();
                da.Fill(dt);
                cbmatn.DataSource = dt;
                cbmatn.DisplayMember = "MaGV";
                cbmatn.ValueMember = "MaGV";

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
            //string maNganh = listNganh.SelectedItems[0].SubItems[0].Text;
            //DataTable data = nganhQuery.LayTheoMaNganh(maNganh);

            //txtMaNganh.Text = data.Rows[0]["MaNganh"].ToString();
            //txtTenNganh.Text = data.Rows[0]["TenNganh"].ToString();
            //txtMaKhoa.Text = data.Rows[0]["MaKhoa"].ToString();
            //txtMaTruongNganh.Text = data.Rows[0]["TruongNganh"].ToString();
        }

        private void cbListNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string makhoa = cbListNganh.SelectedValue.ToString();
            //DataTable data = nganhQuery.LayTheoMaKhoa(makhoa);
            //hien_thi_list_view(data);
        }
        public void resetFields()
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
            cbmatn.Text = "";
            cbmakhoa.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkForeignKeySinhVienQuery = "SELECT COUNT(*) FROM SinhVien WHERE MaNganh = @MaNganh";
                SqlCommand checkCmdSinhVien = new SqlCommand(checkForeignKeySinhVienQuery, conn);
                checkCmdSinhVien.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);

                conn.Open();
                int countSinhVien = (int)checkCmdSinhVien.ExecuteScalar();

                if (countSinhVien > 0)
                {
                    MessageBox.Show("Không thể xóa vì mã ngành đang được sử dụng trong bảng SinhVien!");
                    return;
                }
                string checkForeignKeyLopQuery = "SELECT COUNT(*) FROM Lop WHERE MaNganh = @MaNganh";
                SqlCommand checkCmdLop = new SqlCommand(checkForeignKeyLopQuery, conn);
                checkCmdLop.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);
                int countLop = (int)checkCmdLop.ExecuteScalar();
                if (countLop > 0)
                {
                    MessageBox.Show("Không thể xóa vì mã ngành đang được sử dụng trong bảng Lop!");
                    return;
                }
                string deleteQuery = "DELETE FROM NGANH WHERE MaNganh = @MaNganh";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);
                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Xóa ngành thành công!");
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE NGANH SET TenNganh = @TenNganh, TruongNganh = @TruongNganh, MaKhoa = @MaKhoa WHERE MaNganh = @MaNganh";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);
                cmd.Parameters.AddWithValue("@TenNganh", txtTenNganh.Text);
                cmd.Parameters.AddWithValue("@TruongNganh", cbmatn.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaKhoa", cbmakhoa.SelectedValue.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật ngành thành công!");
                LoadData();
            }
        }

        private void listNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNganh.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listNganh.SelectedItems[0];
                txtMaNganh.Text = selectedItem.SubItems[0].Text;
                txtTenNganh.Text = selectedItem.SubItems[1].Text;
                cbmatn.Text = selectedItem.SubItems[2].Text;
                cbmakhoa.Text = selectedItem.SubItems[3].Text;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {


        }

        private void QL_Nganh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NGANH (MaNganh, TenNganh, MaKhoa, TruongNganh, MaDV) VALUES (@MaNganh, @TenNganh, @MaKhoa, @TruongNganh, 'KTCN')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNganh", txtMaNganh.Text);
                cmd.Parameters.AddWithValue("@TenNganh", txtTenNganh.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cbmakhoa.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@TruongNganh", cbmatn.SelectedValue.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm ngành thành công!");
                LoadData();
            }
        }

        private void txtMaGv_TextChanged(object sender, EventArgs e)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = $"SELECT MaNganh, TenNganh, TruongNganh, MaKhoa FROM NGANH WHERE TenNganh LIKE (N'%{txtTenNgSearch.Text.ToString().Trim()}%')";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                listNganh.Items.Clear();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    ListViewItem item = new ListViewItem(reader["MaNganh"].ToString());
                    item.SubItems.Add(reader["TenNganh"].ToString());
                    item.SubItems.Add(reader["TruongNganh"].ToString());
                    item.SubItems.Add(reader["MaKhoa"].ToString());
                    listNganh.Items.Add(item);
                }
                lbSL.Text = count.ToString() + " Ngành ";
            }

        }

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbmakhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }
    }
}
