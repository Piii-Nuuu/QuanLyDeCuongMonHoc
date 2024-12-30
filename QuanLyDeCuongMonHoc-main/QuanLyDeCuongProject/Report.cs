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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            string sql = "select MaMH, TenMH, SoTC, SoTietLT, SoTietTH, MaMHTienQuyet, MaNganh from MONHOC";
            DataTable dt = CSDL.LayDuLieu(sql);
            CrystalReport2 cry = new CrystalReport2();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
