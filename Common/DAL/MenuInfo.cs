using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class MenuInfo
    {
        private TempTest sqlconn = new TempTest();

        public DataTable getAllMenuInfo()
        {
            string sql = "select menuid,parentid,menuname from menuinfo";
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable getAllMenuInfo(string menuname)
        {
            string sql = string.Empty;
            if (String.IsNullOrEmpty(menuname))
            {
                sql = "select * from menuinfo order by menuid,sort";
            }
            else
            {
                sql = "select * from menuinfo where menuname like '%"+menuname+ "%' order by menuid,sort";
            } 
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable getAllGroupInfo()
        {
            string sql = "select menuid,parentid,menuname from menuinfo where parentid=0";
            return sqlconn.Query(sql).Tables[0];
        }

        public bool insertMenuInfo(string menuname,string path,int parentid,int sort,string createby)
        {
            string sql = "insert into menuinfo (menuname,path,parentid,sort,createby,createtime) values(@menuname,@path,@parentid,@sort,@createby,getdate())";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@menuname",menuname),
                new SqlParameter("@path",path),
                new SqlParameter("@parentid",parentid),
                new SqlParameter("@sort",sort),
                new SqlParameter("@createby",createby)
            };
            return sqlconn.ExecuteSql(sql,param) > 0 ? true : false;
        }

        public bool updateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby)
        {
            string sql = "update menuinfo set menuname='"+menuname+"',path='"+path+"',parentid='"+parentid+"',sort='"+sort+"',updateby='"+updateby+"',updatetime=getdate() where menuid="+menuid+" ";
            return sqlconn.ExecuteSql(sql) > 0 ? true : false;
        }

    }
}
