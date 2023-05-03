using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class A_Message_TypeService
    {


        private readonly DbContext dbContext;


        public A_Message_TypeService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public A_Message_TypeModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<A_Message_TypeModel>(id);
            }

        }

        public List<A_Message_TypeModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_Message_TypeModel>().ToList();
            }
        }
        public List<A_Message_TypeModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_Message_TypeModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<A_Message_TypeModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<A_Message_TypeModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<A_Message_TypeModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_Message_TypeModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<A_Message_TypeModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<A_Message_TypeModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(A_Message_TypeModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<A_Message_TypeModel>(model01);
            }
        }

        public Guid Insert(A_Message_TypeModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,A_Message_TypeModel>(model);
            }
        }

        public int Update(A_Message_TypeModel model)
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
                return conn.Delete<A_Message_TypeModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_Message_TypeModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_Message_TypeModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<A_Message_TypeModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_Message_TypeModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<A_Message_TypeModel>(query, objects);
            }
        }
    }
}
