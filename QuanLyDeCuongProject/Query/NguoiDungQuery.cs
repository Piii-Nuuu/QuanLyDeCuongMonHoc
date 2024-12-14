using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject.Query
{
    internal class NguoiDungQuery
    {
        DataBase db = new DataBase();
        public  DataTable getDetailUser(string maND)
        {
            return db.ExecuteQuery($"\r\nselect * from NguoiDung ng, Quyen q where ng.MaQuyen = q.MaQuyen and MaNguoiDung='{maND}'");
        }
    }
}
