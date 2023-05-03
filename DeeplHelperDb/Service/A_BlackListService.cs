using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class A_BlackListService
    {


        private readonly DbContext dbContext;


        public A_BlackListService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public A_BlackListModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<A_BlackListModel>(id);
            }

        }

        public List<A_BlackListModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_BlackListModel>().ToList();
            }
        }
        public List<A_BlackListModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_BlackListModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<A_BlackListModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_BlackListModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<A_BlackListModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_BlackListModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<A_BlackListModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_BlackListModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(A_BlackListModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<A_BlackListModel>(model01);
            }
        }

        public Guid Insert(A_BlackListModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,A_BlackListModel>(model);
            }
        }

        public int Update(A_BlackListModel model)
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
                return conn.Delete<A_BlackListModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_BlackListModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_BlackListModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_BlackListModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_BlackListModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_BlackListModel>(query, objects);
            }
        }
    }
}
