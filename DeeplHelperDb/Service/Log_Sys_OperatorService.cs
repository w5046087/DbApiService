using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Log_Sys_OperatorService
    {


        private readonly DbContext dbContext;


        public Log_Sys_OperatorService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Log_Sys_OperatorModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Log_Sys_OperatorModel>(id);
            }

        }

        public List<Log_Sys_OperatorModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Sys_OperatorModel>().ToList();
            }
        }
        public List<Log_Sys_OperatorModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Sys_OperatorModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Log_Sys_OperatorModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Log_Sys_OperatorModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Log_Sys_OperatorModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Log_Sys_OperatorModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Log_Sys_OperatorModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Log_Sys_OperatorModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Log_Sys_OperatorModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Log_Sys_OperatorModel>(model01);
            }
        }

        public Guid Insert(Log_Sys_OperatorModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Log_Sys_OperatorModel>(model);
            }
        }

        public int Update(Log_Sys_OperatorModel model)
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
                return conn.Delete<Log_Sys_OperatorModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Sys_OperatorModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Sys_OperatorModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Log_Sys_OperatorModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Log_Sys_OperatorModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Log_Sys_OperatorModel>(query, objects);
            }
        }
    }
}
