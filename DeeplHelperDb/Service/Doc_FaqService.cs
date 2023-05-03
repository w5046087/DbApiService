using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Doc_FaqService
    {


        private readonly DbContext dbContext;


        public Doc_FaqService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Doc_FaqModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Doc_FaqModel>(id);
            }

        }

        public List<Doc_FaqModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_FaqModel>().ToList();
            }
        }
        public List<Doc_FaqModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_FaqModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Doc_FaqModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_FaqModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Doc_FaqModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Doc_FaqModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Doc_FaqModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Doc_FaqModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Doc_FaqModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Doc_FaqModel>(model01);
            }
        }

        public Guid Insert(Doc_FaqModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Doc_FaqModel>(model);
            }
        }

        public int Update(Doc_FaqModel model)
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
                return conn.Delete<Doc_FaqModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_FaqModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_FaqModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_FaqModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Doc_FaqModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Doc_FaqModel>(query, objects);
            }
        }
    }
}
