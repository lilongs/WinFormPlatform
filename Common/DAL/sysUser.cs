using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class sysUser
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
            return sqlconn.ExecuteSql(sql, param)>0?true:false;
        }

        public void loginlog(string username)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "insert into loginlog values(@username,@createdate)";
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter("@username",username),
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

        public bool register(string username,string password, string realname,string telephone,int deptno,int roleid,string createby)
        {
            string sql = @"insert into sysuser(username,password,realname,telephone,deptno,roleid,createtime,createby,status) 
                            values(@username,@password,@realname,@telephone,@deptno,@roleid,getdate(),@createby,1)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password),
                new SqlParameter("@realname",realname),
                new SqlParameter("@telephone",telephone),
                new SqlParameter("@deptno",deptno),
                new SqlParameter("@roleid",roleid),
                new SqlParameter("@createby",createby)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ?  true : false;
        }

        public bool updateUser(string username, string realname, string telephone, int deptno, int roleid, string updateby)
        {
            string sql = @"update sysuser set realname=@realname,telephone=@telephone,deptno=@deptno,roleid=@roleid,updatetime=getdate(),updateby=@updateby 
                            where username=@username";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username",username),
                new SqlParameter("@realname",realname),
                new SqlParameter("@telephone",telephone),
                new SqlParameter("@deptno",deptno),
                new SqlParameter("@roleid",roleid),
                new SqlParameter("@updateby",updateby)
            };
            return sqlconn.ExecuteSql(sql, param) > 0 ? true : false;
        }

        public DataTable getUserMenuInfo(string username)
        {
            string sql = @"select username,rolename,c.menuid,menuname,parentid,path 
                        from sysuser a
                        left join roleinfo b on a.roleid = b.roleid
                        left join role_menu c on a.roleid = c.roleid
                        left join menuinfo d on c.menuid = d.menuid
                        where a.username = '"+username+ "' and a.status = 1 order by sort";
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable getUserInfo(string usernane)
        {
            string sql = string.Empty;
            sql = @"select username, password, realname, telephone,a.createtime, a.createby, status, a.updateby,a.updatetime,b.deptname,c.rolename 
                        from sysuser a
                        left join department b on a.deptno = b.deptno
                        left join roleinfo c on a.roleid = c.roleid ";
            if(!String.IsNullOrEmpty(usernane))
                        sql=sql+" where a.username like '%"+usernane+"%'";
            return sqlconn.Query(sql).Tables[0];
        }

        public bool StopUser(List<string> listusername)
        {
            string param=string.Join("','", listusername);
            List<string> sql = new List<string>();
            foreach(string username in listusername)
            {
                sql.Add("update sysuser set status=0 where username ='" + username + "'");
            }
            return sqlconn.ExecuteSqlTran_SQL(sql)==listusername.Count()?true:false;
        }
    }
}
