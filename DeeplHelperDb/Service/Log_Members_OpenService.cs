using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Log_Members_OpenService
    {


        private readonly DbContext dbContext;


        public Log_Members_OpenService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Log_Members_OpenModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Log_Members_OpenModel>(id);
            }

        }

        public List<Log_Members_OpenModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Members_OpenModel>().ToList();
            }
        }
        public List<Log_Members_OpenModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Members_OpenModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Log_Members_OpenModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Members_OpenModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Log_Members_OpenModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Log_Members_OpenModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Log_Members_OpenModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Log_Members_OpenModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Log_Members_OpenModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Log_Members_OpenModel>(model01);
            }
        }

        public Guid Insert(Log_Members_OpenModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Log_Members_OpenModel>(model);
            }
        }

        public int Update(Log_Members_OpenModel model)
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
                return conn.Delete<Log_Members_OpenModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Members_OpenModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Members_OpenModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Members_OpenModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Log_Members_OpenModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Log_Members_OpenModel>(query, objects);
            }
        }
    }
}
