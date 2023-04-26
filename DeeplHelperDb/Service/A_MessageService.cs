using Dapper;
using DeeplHelperDb.Model;
using DpApiServer.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeplHelperDb.Service
{
    public class A_MessageService
    {
        private DbContext _dbContext;
        public A_MessageService(DbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public A_Message Get(string _guid)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Query<A_Message>("SELECT * FROM A_Message WHERE cUid=@id",
                    new { id = _guid }).First();
            }
        }
        public IEnumerable<A_Message> GetList(int _page, int _pageNum,int _msgType,string cUid)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Query<A_Message>("SELECT * FROM A_Message WHERE cUid=@cUid" +
                    " ORDER BY ID DESC  OFFSET @_page ROWS" +
                    " FETCH  NEXT @_pageNum ROWS ONLY",
                    new { _page = _page, _pageNum = _pageNum,cUid=cUid });
            }
        }
        //public int Update(A_Account _account)
        //{
        //    //这里不会写

        //    using (var conn = _dbContext.CreateConnection())
        //    {
        //        return conn.Execute("UPDATE A_Message SET bIs_Delete=@bIs_Delete wh ",
        //           _account);
        //    }
        //}
        public int SetMsgRead(int _id,string cUid) {
            var query = "Update A_Message SET bIs_Read=1,dRead_Time=GETDATE() WHERE id=@id AND cUid=@cUid ";
            using (var conn = _dbContext.CreateConnection()) {


                return conn.Execute(query, new { id = _id, cUid = cUid });
            }
        
        }
        public int Delete(int id, string cUid)
        {
            var query = "UPDATE A_Message SET bIs_Delete=@bIs_Delete WHERE id=@id AND cUid=@cUid ";
            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Execute(query,
                   new { id=id,cUid=cUid});
            }
        }
        public int Insert(A_Message a_Message) {
            if (a_Message == null) return 0;
            var query = "INSERT INTO A_Message (cUid=@cUid,cTitle=@cTitle,cContent=@cContent," +
                "iMessage_Type=@iMessage_Type)";
            using (var conn = _dbContext.CreateConnection()) {

                return conn.Execute(query, a_Message);
            }
        }


    }
}
