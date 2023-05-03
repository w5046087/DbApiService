using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class CHServerErrorLogService
    {


        private readonly DbContext dbContext;


        public CHServerErrorLogService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public CHServerErrorLogModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<CHServerErrorLogModel>(id);
            }

        }

        public List<CHServerErrorLogModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<CHServerErrorLogModel>().ToList();
            }
        }
        public List<CHServerErrorLogModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<CHServerErrorLogModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<CHServerErrorLogModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<CHServerErrorLogModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<CHServerErrorLogModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<CHServerErrorLogModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<CHServerErrorLogModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<CHServerErrorLogModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(CHServerErrorLogModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<CHServerErrorLogModel>(model01);
            }
        }

        public Guid Insert(CHServerErrorLogModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,CHServerErrorLogModel>(model);
            }
        }

        public int Update(CHServerErrorLogModel model)
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
                return conn.Delete<CHServerErrorLogModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<CHServerErrorLogModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<CHServerErrorLogModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<CHServerErrorLogModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<CHServerErrorLogModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<CHServerErrorLogModel>(query, objects);
            }
        }
    }
}
