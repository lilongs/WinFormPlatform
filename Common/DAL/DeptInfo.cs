using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class DeptInfo
    {
        private TempTest sqlconn = new TempTest();

        public DataTable getAllDeptInfo(string deptname)
        {
            string sql = string.Empty;
            if (String.IsNullOrEmpty(deptname))
            {
                 sql = "select * from department";
            }
            else
            {
                sql = "select * from department where deptname like '%"+deptname+"%'";
            }
            return sqlconn.Query(sql).Tables[0];
        }

        public bool insertDeptInfo(string deptname,string remark,string createby)
        {
            string sql = "insert into department (deptname,remark,createby,createtime) values(@deptname,@remark,@createby,getdate())";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@deptname",deptname),
                new SqlParameter("@remark",remark),
                new SqlParameter("@createby",createby)
            };
            return sqlconn.ExecuteSql(sql,param)>0?true:false;
        }

        public bool updateDeptInfo(int deptno,string deptname, string remark, string updateby)
        {
            string sql = "update department set deptname=@deptname,remark=@remark,updateby=@updateby,updatetime=getdate() where deptno=@deptno";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@deptname",deptname),
                new SqlParameter("@remark",remark),
                new SqlParameter("@updateby",updateby),
                new SqlParameter("@deptno",deptno)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ? true : false;
        }
    }
}
