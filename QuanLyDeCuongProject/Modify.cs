using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyDeCuongProject.Data;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace QuanLyDeCuongProject
{
    internal class Modify
    {
        DataBase db = new DataBase();
        public Modify()
        {
        }
        public List<Taikhoans> Taikhoans(string query)
        {
            List<Taikhoans> taikhoans = new List<Taikhoans>();
            DataTable dataTable= db.ExecuteQuery(query);
            foreach (DataRow dr in dataTable.Rows)
            {
                taikhoans.Add(new Taikhoans(dr["Email"].ToString(), dr["MatKhau"].ToString()));
            }
            return taikhoans;
        }
    }
}
