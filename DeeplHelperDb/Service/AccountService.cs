using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DeeplHelperDb.Model;
using DpApiServer.DbHelper;

namespace DeeplHelperDb.Service
{
    public class AccountService
    {
        private DbContext _dbContext;
        public AccountService(DbContext dbContext) {
            _dbContext = dbContext;
        
        }
        public A_Account Get(string _guid) {
            using (var conn = _dbContext.CreateConnection()) {
                return conn.Query<A_Account>("SELECT * FROM A_Account WHERE cUid=@id", 
                    new { id = _guid }).First();
            }
        }
        public A_Account? GetByWxOpenID(string _openID)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Query<A_Account>("SELECT * FROM A_Account WHERE cWx_Openid=@cWx_Openid",
                    new { cWx_Openid = _openID}).FirstOrDefault();
            }
        }
    
        public IEnumerable<A_Account> GetList(int _page,int _pageNum)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Query<A_Account>("SELECT * FROM A_Account ORDER BY iAuto_ID  OFFSET @_page ROWS" +
                    " FETCH  NEXT @_pageNum ROWS ONLY",
                    new { _page = _page, _pageNum = _pageNum });
            }
        }
        public Task<int> Insert(A_Account a_Account) {
            var query = "INSERT INTO A_Account (cUid=@cUid,cWx_Openid=@cWx_Openid,cWx_Nick=@cWx_Nick," +
                "cWx_Img=@cWx_Img,cWx_Sex=@cWx_Sex)";
            using (var conn = _dbContext.CreateConnection()) {
                return conn.ExecuteAsync(query, a_Account);
            }
        }

        public int Update(A_Account _account) {
            //这里不会写

            using (var conn = _dbContext.CreateConnection())
            {
                return conn.Execute("UPDATE A_Account SET ",
                   _account);
            }
        }

    }
}
