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
    public class MenuInfo
    {

        public int menuid { get; set; }
        public string menuname { get; set; }
        public string path { get; set; }
        public int parentid { get; set; }
        public int sort { get; set; }

        private TempTest sqlconn = new TempTest();

        public DataTable GetAllMenuInfo()
        {
            string sql = "select menuid,parentid,menuname from menuinfo order by sort";
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable GetAllMenuInfo(string menuname)
        {
            string sql = string.Empty;
            if (String.IsNullOrEmpty(menuname))
            {
                sql = "select * from menuinfo order by sort";
            }
            else
            {
                sql = "select * from menuinfo where menuname like '%"+menuname+ "%' order by sort";
            } 
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable GetAllGroupInfo()
        {
            string sql = "select menuid,parentid,menuname from menuinfo where parentid=0 order by sort";
            return sqlconn.Query(sql).Tables[0];
        }

        public bool InsertMenuInfo(string menuname,string path,int parentid,int sort,string createby, string ImagePath)
        {
            string sql = "insert into menuinfo (menuname,path,parentid,sort,createby,createtime,image_path) values(@menuname,@path,@parentid,@sort,@createby,getdate(),@image_path)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@menuname",menuname),
                new SqlParameter("@path",path),
                new SqlParameter("@parentid",parentid),
                new SqlParameter("@sort",sort),
                new SqlParameter("@createby",createby),
                new SqlParameter("@image_path",ImagePath)
            };
            return sqlconn.ExecuteSql(sql,param) > 0 ? true : false;
        }

        public bool UpdateMenuInfo(int menuid, string menuname, string path, int parentid, int sort, string updateby, string ImagePath)
        {
            string sql = "update menuinfo set menuname='"+menuname+"',path='"+path+"',parentid='"+parentid+"',sort='"+sort+"',updateby='"+updateby+"'," +
                "updatetime=getdate(),image_path='"+ImagePath+"' where menuid="+menuid+" ";
            return sqlconn.ExecuteSql(sql) > 0 ? true : false;
        }

    }
}
