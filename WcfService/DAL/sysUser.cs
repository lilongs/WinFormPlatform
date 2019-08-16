using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.DBUtility;

namespace WcfService.DAL
{
    public class SysUser
    {
        private TempTest sqlconn = new TempTest();
        public bool login(string username, string password)
        {
            string sql = "select * from sysuser where username=@username and password=@password and status=1";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password)
            };
            DataSet ds = sqlconn.Query(sql, param);
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool UpdatePassword(string username, string password)
        {
            string sql = "update sysuser set password=@password where username=@username and status=1";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ? true : false;
        }

        public void operatelog(string username, string ip, string computername, string formname)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into operatelog values(@username,@ip,@computername,@formname,@createdate)";
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter("@username",username),
                 new SqlParameter("@ip",ip),
                new SqlParameter("@computername",computername),
                new SqlParameter("@formname",formname),
                new SqlParameter("@createdate",now)
            };
            sqlconn.ExecuteSql(sql, param);
        }

        public bool checkUsername(string username)
        {
            string sql = "select count(username) from sysuser where username='" + username + "'";
            if (sqlconn.Exists(sql))
            {
                return true;
            }
            else
                return false;
        }

        public bool register(string username, string password, string realname, string telephone, int deptno, List<int> roleid, string createby)
        {
            List<string> list = new List<string>();
            list.Add(@"insert into sysuser(username,password,realname,telephone,deptno,createtime,createby,status) 
                        values ('" + username + "','" + password + "','" + realname + "','" + telephone + "'," + deptno + ",getdate(),'" + createby + "',1)");
            foreach (int id in roleid)
            {
                list.Add(@"insert into user_role (username,roleid) values('" + username + "'," + id + ")");
            }

            return sqlconn.ExecuteSqlTran_SQL(list) > 0 ? true : false;
        }

        public bool updateUser(string username, string realname, string telephone, int deptno, List<int> roleid, string updateby)
        {
            List<string> list = new List<string>();
            list.Add(@"update sysuser set realname='" + realname + "',telephone='" + telephone + "',deptno='" + deptno + "',updatetime=getdate(),updateby='" + updateby + "' where username= '" + username + "'");
            list.Add(@"delete from user_role where username='" + username + "'");
            foreach (int id in roleid)
            {
                list.Add(@"insert into user_role (username,roleid) values('" + username + "'," + id + ")");
            }

            return sqlconn.ExecuteSqlTran_SQL(list) > 0 ? true : false;
        }

        public DataTable getUserMenuInfo(string username)
        {
            string sql = @"select a.username,rolename,c.menuid,menuname,parentid,path,image_path 
                        from sysuser a
                        left join user_role e on a.username=e.username
                        left join roleinfo b on e.roleid = b.roleid
                        left join role_menu c on e.roleid = c.roleid
                        left join menuinfo d on c.menuid = d.menuid
                        where a.username = '" + username + "' and a.status = 1 order by sort";
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable getUserInfo(string username)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select a.username, password, realname, telephone,a.createtime, a.createby, status, a.updateby,a.updatetime,b.deptname,''as rolename 
                        from sysuser a
                        left join department b on a.deptno = b.deptno ");
            if (!String.IsNullOrEmpty(username))
                sql.Append(" where a.username like '%" + username + "%'");

            sql.Append(@"select username,rolename 
                        from user_role d
                        left join roleinfo c on d.roleid = c.roleid");

            DataSet ds = new DataSet();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            ds = sqlconn.Query(sql.ToString());
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                string name = dr["username"].ToString();
                string rolename = dr["rolename"].ToString();
                if (!dic.ContainsKey(name))
                {
                    List<string> list = new List<string>();
                    list.Add(rolename);
                    dic.Add(name, list);
                }
                else
                {
                    dic[name].Add(rolename);
                }
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string name = dr["username"].ToString();
                if (dic.ContainsKey(name))
                {
                    dr["rolename"] = String.Join(",", dic[name].ToArray());
                }
            }
            return ds.Tables[0];
        }

        public bool StopUser(List<string> listusername)
        {
            string param = string.Join("','", listusername);
            List<string> sql = new List<string>();
            foreach (string username in listusername)
            {
                sql.Add("update sysuser set status=0 where username ='" + username + "'");
            }
            return sqlconn.ExecuteSqlTran_SQL(sql) == listusername.Count() ? true : false;
        }
    }
}
