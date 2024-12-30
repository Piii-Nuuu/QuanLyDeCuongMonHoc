using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyDeCuongProject
{
    class KN
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QuanLyDeCuong;Integrated Security=True");
        public static DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }
    }
}
