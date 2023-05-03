using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Pay_Order_TypeService
    {


        private readonly DbContext dbContext;


        public Pay_Order_TypeService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Pay_Order_TypeModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Pay_Order_TypeModel>(id);
            }

        }

        public List<Pay_Order_TypeModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Pay_Order_TypeModel>().ToList();
            }
        }
        public List<Pay_Order_TypeModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Pay_Order_TypeModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Pay_Order_TypeModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Pay_Order_TypeModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Pay_Order_TypeModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Pay_Order_TypeModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Pay_Order_TypeModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Pay_Order_TypeModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Pay_Order_TypeModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Pay_Order_TypeModel>(model01);
            }
        }

        public Guid Insert(Pay_Order_TypeModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Pay_Order_TypeModel>(model);
            }
        }

        public int Update(Pay_Order_TypeModel model)
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
                return conn.Delete<Pay_Order_TypeModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Pay_Order_TypeModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Pay_Order_TypeModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Pay_Order_TypeModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Pay_Order_TypeModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Pay_Order_TypeModel>(query, objects);
            }
        }
    }
}
