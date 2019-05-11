using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class pathValue
    {
        private TempTest sqlconn = new TempTest();

        public DataTable LoadData()
        {
            string sql = "select * from tbl_pathValue";
            DataTable dt = sqlconn.Query(sql).Tables[0];
            return dt;
        }
    }
}
