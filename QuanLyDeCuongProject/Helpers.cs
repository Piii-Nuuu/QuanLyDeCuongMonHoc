using QuanLyDeCuongProject.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    internal class Helpers
    {
        QuyenQuery quyenQuery = new QuyenQuery();
        public bool checkPermission(int permission, int permissonUser)
        {
            
            DataTable dt = quyenQuery.getPermissionByUser(permissonUser);

            for(int i=0; i<dt.Rows.Count; i++)
            {
              
                if (int.Parse(dt.Rows[0][i].ToString()) == permission)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
