using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.DBUtility;

namespace WcfService.DAL
{
    public class ClientVersion
    {
        public static String ServerVersion()
        {
            TempTest sqlconn = new TempTest();
            string sql = "select version from sysversion where active=1";
            DataSet ds = new DataSet();
            ds = sqlconn.Query(sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return "1.0.0.0";
            }else
            {
                return ds.Tables[0].Rows[0]["version"].ToString();
            }
        }
    }
}
