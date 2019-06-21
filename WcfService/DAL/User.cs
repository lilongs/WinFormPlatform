using WcfService.DBUtility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DAL
{
    public class User
    {
        public ObjectId _id;//BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId  　　　　
        public string username { get; set; }
        public string password { set; get; }
        public string realname { get; set; }
        public string telephone { get; set; }
        public int deptno { get; set; }
        public string deptname { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public DateTime createtime { get; set; }
        public string createby { get; set; }
        public int status { get; set; }
        public string updateby { get; set; }
        public DateTime updatetime { get; set; }

        MongoDbCsharpHelper mongoDbHelper = new MongoDbCsharpHelper("mongodb://127.0.0.1:27017", "WinformPlatform",true,true);
        public void InsertUser(string collectionname,User user)
        {
            mongoDbHelper.Insert<User>(collectionname, user);
        }

        public void DeleteOneUser(string collectionname,string username)
        {
            mongoDbHelper.Delete<User>(collectionname, user => user.username == username);
        }

        public void UpdateUser(string collectionname,string oldusername, User newuser)
        {
            mongoDbHelper.Update<User>(collectionname, newuser, t => t.username == oldusername);
        }

        public List<User> SelectUser(string collectionname, string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                return mongoDbHelper.Find<User>(collectionname, t => t.username != null);
            }
            else
            {
                return mongoDbHelper.Find<User>(collectionname, t => t.username == username);
            }
        }
    }
}
