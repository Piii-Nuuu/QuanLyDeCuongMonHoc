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
    public partial class DeCuong : Form
    {
        // mã môn học chuyển thành combobox
        // nút duyệt đề cương đâu

        DataBase Db  = new DataBase();

        public DeCuong()
        {
            InitializeComponent();
        }

        private void DeCuong_Load(object sender, EventArgs e)
        {
            hienthilsdanhsach();
            lbdc.Text = listDSdecuong.Items.Count.ToString();
        }

        private void List_DS_De_Cuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbdc.Text = listDSdecuong.Items.Count.ToString();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            listDSdecuong.Items.Clear();
            string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where MaDeCuong= '"+txtSearchmadecuong+"' or TenDeCuong = N'"+txtSearchtendecuong.Text+ "' and isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql);
            //MessageBox.Show(dt.Rows.Count.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());    
            }
        }
        void hienthilsdanhsach()
        {
            listDSdecuong.Items.Clear();
            string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }
        private void txtSearchDeCuong_TextChanged(object sender, EventArgs e)
        {
            listDSdecuong.Items.Clear ();
            string sql_MaDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  MaDeCuong like N'%" + txtSearchmadecuong.Text+"%'  and isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql_MaDecuong);
            for (int i = 0;i < dt.Rows.Count;i++)
            {
                listDSdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }

        private void txtGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listDSdecuong_Click(object sender, EventArgs e)
        {
            txtmadecuong.Text = listDSdecuong.SelectedItems[0].SubItems[0].Text;
            txttendecuong.Text = listDSdecuong.SelectedItems[0].SubItems[1].Text;
            txtmamonhoc.Text = listDSdecuong.SelectedItems[0].SubItems[2].Text;
        }

        private void btthem_Click(object sender, EventArgs e)
        {
       
            string sql_mangdung = "select MaGV from NguoiDung nd, GIANGVIEN gv where nd.MaNguoiDung = gv.MaND and nd.MaNguoiDung = 'ND0001'";
            DataTable dt_laymaGV = Db.ExecuteQuery(sql_mangdung);

            DialogResult kq = MessageBox.Show("Xác Nhận Thêm Mới", "Thông Báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    string sql = "insert into DeCuong (MaDeCuong, TenDeCuong, MaMon, MaGV, isAccept) values ('" + txtmadecuong.Text + "', N'" + txttendecuong.Text + "', '" + txtmamonhoc.Text + "', '" + dt_laymaGV.Rows[0][0].ToString() + "', 1)";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("Thêm thành công!");
                    hienthilsdanhsach();

                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công!");
                    throw;
                }
                
            }
        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác Nhận Cập Nhật!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "update DeCuong set TenDeCuong = N'" + txttendecuong.Text + "' , MaMon = '" + txtmamonhoc.Text + "' where MaDeCuong = '" + txtmadecuong.Text + "'";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("Cập nhật thành công!");
                    hienthilsdanhsach();

                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công!");
                    throw;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 MaDeCuong  from DeCuong order by MaDeCuong desc";
            DataTable dt = Db.ExecuteQuery(sql);
            int madc =int.Parse( dt.Rows[0][0].ToString().Substring(dt.Rows[0][0].ToString().Length - 3));
            //MessageBox.Show(madc.ToString());
            txtmadecuong.Text = "DC"+(madc+1).ToString("00#") ;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác Nhận!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "delete from DeCuong where MaDeCuong = '"+txtmadecuong.Text+"'";
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

        private void txtSearchtendecuong_TextChanged(object sender, EventArgs e)
        {
            listDSdecuong.Items.Clear();
            string sql_TenDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  TenDeCuong like N'%" + txtSearchtendecuong.Text + "%'  and isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql_TenDecuong);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDSdecuong.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                listDSdecuong.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DuyetDeCuong duyetDeCuong = new DuyetDeCuong();
            duyetDeCuong.ShowDialog();
            duyetDeCuong = null;
            this.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
