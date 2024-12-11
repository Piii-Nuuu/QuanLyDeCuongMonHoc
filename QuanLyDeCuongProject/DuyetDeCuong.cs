using QuanLyDeCuongProject.Data;
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
    public partial class DuyetDeCuong : Form
    {
        DataBase Db = new DataBase();
        public DuyetDeCuong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác Nhận!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "delete from DeCuong where MaDeCuong = '" + txtDuyetDC_madecuong.Text + "'";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("Xóa thành công!");
                    hienthilsdanhsach();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa!");
                    throw;
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        void hienthilsdanhsach()
        {
            listDSDuyetdecuong.Items.Clear();
            string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where isAccept = '0'";
            DataTable dt = Db.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSDuyetdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }
        private void DuyetDeCuong_Load(object sender, EventArgs e)
        {
            

            hienthilsdanhsach();
           
            lbduyetdc.Text = listDSDuyetdecuong.Items.Count.ToString();
        }

        private void listDSDuyetdecuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbduyetdc.Text = listDSDuyetdecuong.Items.Count.ToString();
        }

        private void listDSDuyetdecuong_Click(object sender, EventArgs e)
        {
            txtDuyetDC_madecuong.Text = listDSDuyetdecuong.SelectedItems[0].SubItems[0].Text;
            txtDuyetDC_tendecuong.Text = listDSDuyetdecuong.SelectedItems[0].SubItems[1].Text;
            txtDuyetDC_mamonhoc.Text = listDSDuyetdecuong.SelectedItems[0].SubItems[2].Text;
        }

        private void txtDuyet_Searchtendecuong_TextChanged(object sender, EventArgs e)
        {
            listDSDuyetdecuong.Items.Clear();
            string sql_TenDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  TenDeCuong like N'%" + txtDuyet_Searchtendecuong.Text + "%'  and isAccept = '0'";
            DataTable dt = Db.ExecuteQuery(sql_TenDecuong);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSDuyetdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }

        private void txtDuyet_Searchmadecuong_TextChanged(object sender, EventArgs e)
        {
            listDSDuyetdecuong.Items.Clear();
            string sql_MaDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  MaDeCuong like N'%" + txtDuyet_Searchmadecuong.Text + "%'  and isAccept = '0'";
            DataTable dt = Db.ExecuteQuery(sql_MaDecuong);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSDuyetdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSDuyetdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }

        private void btDuyetDC_capnhat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác Nhận!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "update DeCuong set isAccept = '1' where MaDeCuong = '" + txtDuyetDC_madecuong.Text + "'";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("ĐÃ DUYỆT THÀNH CÔNG!");
                    hienthilsdanhsach();

                }
                catch (Exception)
                {
                    MessageBox.Show("DUYỆT KHÔNG THÀNH CÔNG!");
                    throw;
                }

            }
        }
    }
}
