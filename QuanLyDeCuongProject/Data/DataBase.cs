﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyDeCuongProject.Data
{
    internal class DataBase
    {
        SqlConnection connect;
        public DataBase(string serverName)
        {
            connect = new SqlConnection(@"Data Source="+serverName+";Initial Catalog=QuanLyDeCuong;Integrated Security=True");
        }

        public DataTable ExecuteQuery(string sql)
        {
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connect);
                da.Fill(data);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối " + ex.Message);
            }
            return data;
           
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand(sql, connect);
                cm.ExecuteNonQuery();
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Kết Nối" + ex.Message);
            }
     
        }
    }
}
