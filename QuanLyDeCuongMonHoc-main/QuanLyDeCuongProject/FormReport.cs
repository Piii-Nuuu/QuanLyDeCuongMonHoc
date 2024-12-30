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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
       public  static  string tenmh = "";
        private void FormReport_Load(object sender, EventArgs e)
        {
            string sql = $"select MaMH, TenMH, SoTC, SoTietLT, SoTietTH, MaMHTienQuyet, MaNganh from MONHOC  where TenMH = N'{tenmh}'";
            DataTable dt = KN.LayDuLieu(sql);
            CrystalReport2 cry = new CrystalReport2();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
