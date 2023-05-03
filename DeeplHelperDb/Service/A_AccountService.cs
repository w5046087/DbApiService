using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class A_AccountService
    {
        private readonly DbContext dbContext;
       
        public A_AccountService(DbContext _dbContext) {
            this.dbContext = _dbContext;
        }









        public Guid? IsExistAccount(string open_id) {
          var accountList= GetAll(new { cWx_Openid = open_id });
            if (accountList.Count >= 1) {
                return accountList.First().cUid;
            }
            return null;
        }
        /// <summary>
        /// 获取用户信息,涵盖所需基本信息内容
        /// </summary>
        /// <param name="cUid"></param>
        /// <returns></returns>
        public string GetAccountInfo(string cUid) {

            string query = "select * from ";
        
        }




        public A_AccountModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<A_AccountModel>(id);
            }
        }
        public List<A_AccountModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_AccountModel>().ToList();
            }
        }
        public List<A_AccountModel> GetAll(object _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_AccountModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<A_AccountModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_AccountModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<A_AccountModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_AccountModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<A_AccountModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_AccountModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(A_AccountModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<A_AccountModel>(model01);
            }
        }

        public Guid Insert(A_AccountModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,A_AccountModel>(model);
            }
        }

        public int Update(A_AccountModel model)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.Update(model);
            }
        }

        public int Delete(string id)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Delete<A_AccountModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_AccountModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_AccountModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_AccountModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_AccountModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_AccountModel>(query, objects);
            }
        }
    }
}
