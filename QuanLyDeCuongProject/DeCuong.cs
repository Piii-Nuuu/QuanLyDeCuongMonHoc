using QuanLyDeCuongProject.Data;
using QuanLyDeCuongProject.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Helpers helper = new Helpers();
        MonHocQuery monhocQuery = new MonHocQuery();
        public DeCuong()
        {
            InitializeComponent();
        }

        private void DeCuong_Load(object sender, EventArgs e)
        {
            if (Modify.taiKhoan == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản?");
                this.Close();

                return;
            }

            if (!helper.checkPermission(21, Modify.taiKhoan.ma_quyen))
            {
                
                this.Close();
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(true, btThem, btcapnhat, btxoa, btludecuong);
            string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where isAccept = '1'";
            hienthilsdanhsach(sql);
            loadComboMonHoc();
            lbdc.Text = cbMaMH.Items.Count.ToString();
        }

        private void List_DS_De_Cuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbdc.Text = cbMaMH.Items.Count.ToString();
        }
        void laysldc()
        {
            lbdc.Text = cbMaMH.Items.Count.ToString();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void loadComboMonHoc()
        {
            cbMonHoc.DataSource = Db.ExecuteQuery("select MaMH, TenMH from MONHOC");
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "MaMH";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {

            if (!helper.checkPermission(21, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where MaDeCuong= '"+txtSearchmadecuong+"' or TenDeCuong = N'"+txtSearchtendecuong.Text+ "' and isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql);
            //MessageBox.Show(dt.Rows.Count.ToString());
            hienthilsdanhsach(sql);
            laysldc();
        }
        void hienthilsdanhsach(string sql)
        {
            cbMaMH.Items.Clear();
            //string sql = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where isAccept = '1'";
            DataTable dt = Db.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbMaMH.Items.Add(dt.Rows[i]["MaDeCuong"].ToString());
                cbMaMH.Items[i].SubItems.Add(dt.Rows[i]["TenDeCuong"].ToString());
                cbMaMH.Items[i].SubItems.Add(dt.Rows[i]["MaMon"].ToString());
            }
        }
        private void txtSearchDeCuong_TextChanged(object sender, EventArgs e)
        {
            if (!helper.checkPermission(21, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql_MaDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  MaDeCuong like N'%" + txtSearchmadecuong.Text+"%'  and isAccept = '1'";
            hienthilsdanhsach(sql_MaDecuong);
            laysldc() ;
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
            txtmadecuong.Text = cbMaMH.SelectedItems[0].SubItems[0].Text;
            txttendecuong.Text = cbMaMH.SelectedItems[0].SubItems[1].Text;
            cbMonHoc.Text = cbMaMH.SelectedItems[0].SubItems[2].Text;
            laysldc();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
        
            string sql_mangdung = $"select MaGV from NguoiDung nd, GIANGVIEN gv where nd.MaNguoiDung = gv.MaND and nd.MaNguoiDung = '{Modify.taiKhoan.ma_nguoi_dung}'";
            DataTable dt_laymaGV = Db.ExecuteQuery(sql_mangdung);

            DialogResult kq = MessageBox.Show("Xác nhận thêm mới đề cương", "Thông Báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    string sql = "insert into DeCuong (MaDeCuong, TenDeCuong, MaMon, MaGV, isAccept) values ('" + txtmadecuong.Text + "', N'" + txttendecuong.Text + "', '" + cbMonHoc.SelectedValue.ToString() + "', '" + dt_laymaGV.Rows[0][0].ToString() + "', 0)";
                    Db.ExecuteNonQuery(sql);
                    helper.XulySangToi(true, btThem, btcapnhat, btxoa, btludecuong);
                    MessageBox.Show("Thêm thành công!");
                    helper.createFile(txtmadecuong.Text, txttendecuong.Text, cbMonHoc.SelectedValue.ToString(), Modify.user.HoTen);
                  

                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công!");
             
                }
                
            }
        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            if (!helper.checkPermission(23, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(true, btThem, btcapnhat, btxoa, btludecuong);
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn cập nhật đề cương này!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "update DeCuong set TenDeCuong = N'" + txttendecuong.Text + "' , MaMon = '" + cbMonHoc.SelectedValue.ToString() + "' where MaDeCuong = '" + txtmadecuong.Text + "'";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("Cập nhật thành công!");
                    string sqlQuery = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where MaDeCuong= '" + txtSearchmadecuong + "' or TenDeCuong = N'" + txtSearchtendecuong.Text + "' and isAccept = '1'";
                    hienthilsdanhsach(sqlQuery);

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
            
            if (!helper.checkPermission(22, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            helper.XulySangToi(false, btThem, btcapnhat, btxoa, btludecuong);
            string sql = "select top 1 MaDeCuong  from DeCuong order by MaDeCuong desc";
            DataTable dt = Db.ExecuteQuery(sql);
            int madc =int.Parse( dt.Rows[0][0].ToString().Substring(dt.Rows[0][0].ToString().Length - 3));
          
            txtmadecuong.Text = "DC"+(madc+1).ToString("00#") ;
            laysldc();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (!helper.checkPermission(24, Modify.taiKhoan.ma_quyen))
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn xóa đề cương này!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            helper.XulySangToi(true, btThem, btcapnhat, btxoa, btludecuong);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    string sql = "delete from DeCuong where MaDeCuong = '"+txtmadecuong.Text+"'";
                    Db.ExecuteNonQuery(sql);
                    MessageBox.Show("Xóa thành công!");
                    string sqlQuery = "select TenDeCuong , MaDeCuong , MaMon from DeCuong where MaDeCuong= '" + txtSearchmadecuong + "' or TenDeCuong = N'" + txtSearchtendecuong.Text + "' and isAccept = '1'";
                    hienthilsdanhsach(sqlQuery);
                    laysldc();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa!");
                    laysldc();
                    throw;
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchtendecuong_TextChanged(object sender, EventArgs e)
        {
           
            string sql_TenDecuong = "select TenDeCuong , MaDeCuong , MaMon  from DeCuong where  TenDeCuong like N'%" + txtSearchtendecuong.Text + "%'  and isAccept = '1'";
            hienthilsdanhsach(sql_TenDecuong);
            laysldc();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            if (Modify.taiKhoan.ma_quyen == 3 )
            {
                this.Hide();
                DuyetDeCuong duyetDeCuong = new DuyetDeCuong();
                duyetDeCuong.ShowDialog();
                this.Show();


            }
            else
            {
                MessageBox.Show($"Bạn không có quyền vào chức năng này", "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.loadFile(txtmadecuong.Text);
            f.ShowDialog();
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonHoc.SelectedValue.ToString() == "System.Data.DataRowView")
            {

                return;
            } 
            txttendecuong.Text = monhocQuery.getSubject(cbMonHoc.SelectedValue.ToString()).Rows[0]["TenMH"].ToString();
        }
    }
}
