using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WcfService.DBUtility
{          
    public class TempTest : DbsBaseClass
    {
        public TempTest()
        {
            connectionString =  ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }    

    public class temp2:DbsBaseClass
    {
        public temp2()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        }
    }

    public class DbSQL
    {
        public string SQL;
        public SqlParameter[] Params;
    }
}
