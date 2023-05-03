using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Set_Sys_GlobalService
    {


        private readonly DbContext dbContext;


        public Set_Sys_GlobalService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Set_Sys_GlobalModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Set_Sys_GlobalModel>(id);
            }

        }

        public List<Set_Sys_GlobalModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Set_Sys_GlobalModel>().ToList();
            }
        }
        public List<Set_Sys_GlobalModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Set_Sys_GlobalModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Set_Sys_GlobalModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Set_Sys_GlobalModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Set_Sys_GlobalModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Set_Sys_GlobalModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Set_Sys_GlobalModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Set_Sys_GlobalModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Set_Sys_GlobalModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Set_Sys_GlobalModel>(model01);
            }
        }

        public Guid Insert(Set_Sys_GlobalModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Set_Sys_GlobalModel>(model);
            }
        }

        public int Update(Set_Sys_GlobalModel model)
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
                return conn.Delete<Set_Sys_GlobalModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Set_Sys_GlobalModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Set_Sys_GlobalModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Set_Sys_GlobalModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Set_Sys_GlobalModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Set_Sys_GlobalModel>(query, objects);
            }
        }
    }
}
