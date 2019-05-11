using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public class RoleInfo
    {
        private TempTest sqlconn = new TempTest();

        public DataTable getAllRoleInfo()
        {
            string sql = "select * from roleinfo";
            return sqlconn.Query(sql).Tables[0];
        }

        public DataTable getRoleMenu(int roleid)
        {
            string sql = @"select a.menuid,parentid,menuname from role_menu a
                        left join menuinfo b on a.menuid=b.menuid
                        where a.roleid =" + roleid+" ";
            return sqlconn.Query(sql).Tables[0];
        }

        public int updateRoleMenu(int roleid, List<int> listMenuid)
        {
            List<string> listsql = new List<string>();
            listsql.Add("delete from role_menu where roleid ="+roleid+"");
            foreach(int menuid in listMenuid)
            {
                listsql.Add("insert into role_menu values("+ roleid + ","+ menuid + ")");
            }
            return sqlconn.ExecuteSqlTran_SQL(listsql);
        }
    }
}
