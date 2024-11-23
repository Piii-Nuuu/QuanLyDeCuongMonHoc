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
        DataBase database = new DataBase(@"MSI\MSSQLSERVER01");
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
            listPermission.Items.Clear();
            for(int i=0; i<listPermissions.Rows.Count; i++)
            {
                listPermission.Items.Add(listPermissions.Rows[i]["MaPermission"].ToString());
                listPermission.Items[i].SubItems.Add(listPermissions.Rows[i]["Actions"].ToString());
            }
        }

        private void comboBoxQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxQuyen.SelectedValue.ToString() == "System.Data.DataRowView") return;
            listPermissions = permission_query.GetAllPermissionByQuyenId(comboBoxQuyen.SelectedValue.ToString());
            displayListViewPermission();
        }

        private void listPermission_Click(object sender, EventArgs e)
        {
            comboxPermission.SelectedValue = listPermission.SelectedItems[0].Text;
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

        private void listPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
