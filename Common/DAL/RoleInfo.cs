using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class RoleInfo
    {
        private TempTest sqlconn = new TempTest();

        public DataTable GetAllRoleInfo(string rolename)
        {
            string sql = string.Empty;
            if(String.IsNullOrEmpty(rolename))
            {
                sql = "select * from roleinfo";
            }
            else
            {
                sql = "select * from roleinfo where rolename like '%"+rolename+"%'";
            }
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable GetRoleMenu(int roleid)
        {
            string sql = @"select a.menuid,parentid,menuname from role_menu a
                        left join menuinfo b on a.menuid=b.menuid
                        where a.roleid =" + roleid+" ";
            return sqlconn.Query(sql).Tables[0];
        }

        public int UpdateRoleMenu(int roleid, List<int> listMenuid)
        {
            List<string> listsql = new List<string>
            {
                "delete from role_menu where roleid =" + roleid + ""
            };
            foreach (int menuid in listMenuid)
            {
                listsql.Add("insert into role_menu values("+ roleid + ","+ menuid + ")");
            }
            return sqlconn.ExecuteSqlTran_SQL(listsql);
        }

        public bool InsertRoleInfo(string rolename, string remark, string createby)
        {
            string sql = "insert into roleinfo (rolename,remark,createby,createtime) values(@rolename,@remark,@createby,getdate())";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@rolename",rolename),
                new SqlParameter("@remark",remark),
                new SqlParameter("@createby",createby)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ? true : false;
        }

        public bool UpdateRoleInfo(int roleid, string rolename, string remark, string updateby)
        {
            string sql = "update roleinfo set rolename=@rolename,remark=@remark,updateby=@updateby,updatetime=getdate() where roleid=@roleid";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@rolename",rolename),
                new SqlParameter("@remark",remark),
                new SqlParameter("@updateby",updateby),
                new SqlParameter("@roleid",roleid)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ? true : false;
        }
    }
}
