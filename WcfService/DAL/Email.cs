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
    public class Email
    {
        TempTest test = new TempTest();

        public DataTable GetEmailConfig()
        {
            string sql = "select * from email_config ";
            return test.Query(sql).Tables[0];
        }

        public DataTable GetQueueInfo()
        {
            string sql = @"select * from email_queue 
                        where active = 0";
            return test.Query(sql).Tables[0];
        }

        public DataSet GetEmailInfo(string queueNo)
        {
            string sql = @"select * from email_recipients where queue_no='"+ queueNo + @"'
                           select * from email_attachs where queue_no='" + queueNo + @"' ";
            return test.Query(sql);
        }

        public bool CompletedSendEmail(string queueNo)
        {
            string sql = @"update email_queue set active=1,compelete_time=GETDATE()
                            where active = 0 and queue_no = '"+ queueNo + "'";
            return test.ExecuteSql(sql)>0?true:false;
        }

        public bool AdddEmailQueue(Queues queue,List<Recipients> recipients,List<Attachs> attachs)
        {
            List<DbData> listSql = new List<DbData>();
            Random r = new Random();
            int num = r.Next(0, 999);
            string queueNo = DateTime.Now.ToString("yyyyMMddHHmmssfff") + num.ToString("000");

            DbData data1 = new DbData();
            string sql1 = @"insert into email_queue(queue_no, subject, contents, active, create_time) 
                        values(@queue_no, @subject, @contents, 0, getdate())";
            SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@queue_no", SqlDbType.NVarChar, 20),
                new SqlParameter("@subject",SqlDbType.NVarChar,200),
                new SqlParameter("@contents",SqlDbType.NVarChar)
            };
            param1[0].Value = queueNo;
            param1[1].Value = queue.subject;
            param1[2].Value = queue.content;

            data1.SQL = sql1;
            data1.Params = param1;
            listSql.Add(data1);

            foreach(Attachs att in attachs)
            {
                DbData data2 = new DbData();
                string sql2 = @"insert into email_attachs (filename, stream, content_encoding, queue_no) 
                        values (@fileName, @stream, @content_encoding, @queue_no)";
                SqlParameter[] param2 = new SqlParameter[]
                {
                new SqlParameter("@fileName", SqlDbType.NVarChar, 50),
                new SqlParameter("@stream",SqlDbType.VarBinary),
                new SqlParameter("@content_encoding",SqlDbType.Int),
                new SqlParameter("@queue_no",SqlDbType.NVarChar,20)
                };
                param2[0].Value = att.filename;
                param2[1].Value = att.stream;
                param2[2].Value = att.contentEncoding;
                param2[3].Value = queueNo;

                data2.SQL = sql2;
                data2.Params = param2;
                listSql.Add(data2);
            }

            foreach (Recipients rec in recipients)
            {
                DbData data3 = new DbData();
                string sql3 = @"insert into email_recipients(recipient_address, recipient_name, queue_no) 
                                values(@recipient_address, @recipient_name, @queue_no)";
                SqlParameter[] param3 = new SqlParameter[]
                {
                new SqlParameter("@recipient_address",SqlDbType.NVarChar),
                new SqlParameter("@recipient_name",SqlDbType.NVarChar),
                new SqlParameter("@queue_no",SqlDbType.NVarChar,20)
                };
                param3[0].Value = rec.address;
                param3[1].Value = rec.name;
                param3[2].Value = queueNo;

                data3.SQL = sql3;
                data3.Params = param3;
                listSql.Add(data3);
            }

            return test.ExecuteSqlTrans(listSql) > 0 ? true : false;
        }
    }

    public class Recipients
    {
        public string address { get; set; }
        public string name { get; set; }
        public string queueNo { get; set; }
    }

    public class Queues
    {
        public string queueNo { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public int active { get; set; }
        public DateTime createTime { get; set; }
        public DateTime compeleteTime { get; set; }
    }

    public class Attachs
    {
        public string filename { get; set; }
        public byte[] stream { get; set; }
        public int contentEncoding { get; set; }
        public string queueNo { get; set; }
    }
}
