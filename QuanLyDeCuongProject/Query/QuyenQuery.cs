using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Queries
{
    internal class QuyenQuery
    {
        DataBase database;
        public QuyenQuery()
        {
            database = new DataBase(@"MSI\MSSQLSERVER01");
        }

        public DataTable GetAllQuyen()
        {
            return database.ExecuteQuery("select * from Quyen");
        }
    }
}
