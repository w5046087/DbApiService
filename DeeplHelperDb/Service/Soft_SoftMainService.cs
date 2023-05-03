using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Soft_SoftMainService
    {


        private readonly DbContext dbContext;


        public Soft_SoftMainService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Soft_SoftMainModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Soft_SoftMainModel>(id);
            }

        }

        public List<Soft_SoftMainModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftMainModel>().ToList();
            }
        }
        public List<Soft_SoftMainModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftMainModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Soft_SoftMainModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftMainModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Soft_SoftMainModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Soft_SoftMainModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Soft_SoftMainModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Soft_SoftMainModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Soft_SoftMainModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Soft_SoftMainModel>(model01);
            }
        }

        public Guid Insert(Soft_SoftMainModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Soft_SoftMainModel>(model);
            }
        }

        public int Update(Soft_SoftMainModel model)
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
                return conn.Delete<Soft_SoftMainModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftMainModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftMainModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftMainModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Soft_SoftMainModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Soft_SoftMainModel>(query, objects);
            }
        }
    }
}
