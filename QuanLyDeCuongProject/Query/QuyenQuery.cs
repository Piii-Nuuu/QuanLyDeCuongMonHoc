﻿using QuanLyDeCuongProject.Data;
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
        DataBase database = new DataBase();
        public QuyenQuery()
        {

        }

        public DataTable GetAllQuyen()
        {
            return database.ExecuteQuery("select * from Quyen");
        }
    }
}
