﻿using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject.Queries
{
    internal class PermissionQuery
    {
        DataBase database = new DataBase();
        public PermissionQuery()
        {

        }


        public DataTable GetAllPermisstion()
        {
            return database.ExecuteQuery("select * from Permission");
        }

        public DataTable GetAllPermissionByQuyenId(string quyenId)
        {
            return database.ExecuteQuery($"select * from Permission p, Quyen_Permission qp, Quyen q where p.MaPermission = qp.MaPermission and qp.MaQuyen = q.MaQuyen and q.MaQuyen = {quyenId}");
        }
        public void CapNhat_Quyen(string mapermission, string maquyen, string maPermissonNew)
        {
             database.ExecuteNonQuery("update Quyen_Permission set MaPermission=" + maPermissonNew + " where MaPermission = " + mapermission + " and MaQuyen = " + maquyen + "");
        }
    }
}
