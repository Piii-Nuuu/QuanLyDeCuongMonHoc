using QuanLyDeCuongProject.Data;
using QuanLyDeCuongProject.Queries;
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
    public partial class QuanLyPhanQuyen : Form
    {
        DataBase database = new DataBase();
        DataTable listPermissions, listQuyen;
        QuyenQuery quyen_query = new QuyenQuery();
        PermissionQuery permission_query = new PermissionQuery();
        public QuanLyPhanQuyen()
        {
            InitializeComponent();
        }

        private void comboxPermission_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void QuanLyPhanQuyen_Load(object sender, EventArgs e)
        {
            listPermissions = permission_query.GetAllPermisstion();
            listQuyen = quyen_query.GetAllQuyen();
            displayCompoBoxPermission();
            displayCompoBoxQuyen();
            UpdateTotalCounts();


        }

        public void displayCompoBoxQuyen()
        {
            comboBoxQuyen.DataSource = listQuyen;
            comboBoxQuyen.DisplayMember = "TenQuyen";
            comboBoxQuyen.ValueMember = "MaQuyen";
        }

        public void displayCompoBoxPermission()
        {
            comboxPermission.DataSource = listPermissions;
            comboxPermission.DisplayMember = "Actions";
            comboxPermission.ValueMember = "MaPermission";
        }
        public void displayListViewPermission()
        {
            listPermissions = permission_query.GetAllPermissionByQuyenId(comboBoxQuyen.SelectedValue.ToString());
            listPermission.Items.Clear();
            for (int i = 0; i < listPermissions.Rows.Count; i++)
            {
                listPermission.Items.Add(listPermissions.Rows[i]["MaPermission"].ToString());
                listPermission.Items[i].SubItems.Add(listPermissions.Rows[i]["Actions"].ToString());
            }
            UpdateTotalCounts();
        }

        private void comboBoxQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxQuyen.SelectedValue.ToString() == "System.Data.DataRowView") return;

            displayListViewPermission();
            UpdateTotalCounts();

        }
        private void UpdateTotalCounts()
        {
            
            int totalPermissions = listPermission.Items.Count;
            lbSL.Text = $"{totalPermissions} hiện có";

            int totalActions = listView1.Items.Count;
            labelTotalActions.Text = $" {totalActions} hiện có";
        }


        private void listPermission_Click(object sender, EventArgs e)
        {
            comboxPermission.SelectedValue = listPermission.SelectedItems[0].Text;
            UpdateTotalCounts();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string maquyen = comboBoxQuyen.SelectedValue.ToString();
                string mapermission = listPermission.SelectedItems[0].SubItems[0].Text;
                string newMaPermisson = comboxPermission.SelectedValue.ToString();
                if(string.IsNullOrEmpty(maquyen) || string.IsNullOrEmpty(mapermission) || string.IsNullOrEmpty(newMaPermisson))
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                permission_query.CapNhat_Quyen(mapermission, maquyen, newMaPermisson);
                displayListViewPermission();
                MessageBox.Show("Cập nhật quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateTotalCounts();

            }

            //string maquyen = comboBoxQuyen.SelectedValue.ToString();
            //string mapermission = listPermission.SelectedItems[0].SubItems[0].Text;
            //string newMaPermisson = comboxPermission.SelectedValue.ToString();
            //permission_query.CapNhat_Quyen(mapermission, maquyen, newMaPermisson);
            //displayListViewPermission();
        } //Cap nhat

        private void Button1_Click(object sender, EventArgs e) //Them
        { 
            try
            {
                string selectedPermission = comboxPermission.SelectedValue?.ToString(); 
                string selectedQuyen = comboBoxQuyen.SelectedValue?.ToString(); 
                if (string.IsNullOrEmpty(selectedPermission) || string.IsNullOrEmpty(selectedQuyen))
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }               
                permission_query.Them_Quyen(selectedQuyen, selectedPermission);
                displayListViewPermission();
                MessageBox.Show("Thêm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateTotalCounts();

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
                try
                {
                    if (listPermission.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn quyền cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string maPermission = listPermission.SelectedItems[0].SubItems[0].Text;
                    string maQuyen = comboBoxQuyen.SelectedValue.ToString(); 

                    DialogResult confirmResult = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa quyền này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        permission_query.Xoa_Quyen(maQuyen, maPermission);
                        displayListViewPermission();
                        MessageBox.Show("Xóa quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateTotalCounts();

            }
        } //Xoa

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string tk = txttimkiem.Text.Trim();

                if (string.IsNullOrEmpty(tk))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string mapermission = comboBoxQuyen.SelectedValue.ToString();
                DataTable searchResults = permission_query.TimKiem(tk);
                listView1.Items.Clear();
                for (int i = 0; i < searchResults.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(searchResults.Rows[i]["MaPermission"].ToString());
                    item.SubItems.Add(searchResults.Rows[i]["Actions"].ToString());
                    listView1.Items.Add(item);
                }
                if (searchResults.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tk = txttimkiem.Text.Trim();

                /*if (string.IsNullOrEmpty(tk))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/
               
                DataTable searchResults = permission_query.TimKiem(tk);
                listView1.Items.Clear();
                for (int i = 0; i < searchResults.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(searchResults.Rows[i]["MaPermission"].ToString());
                    item.SubItems.Add(searchResults.Rows[i]["Actions"].ToString());
                    listView1.Items.Add(item);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateTotalCounts();
        }

        private void listPermission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
