using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Doc_Faq_CommentsService
    {


        private readonly DbContext dbContext;


        public Doc_Faq_CommentsService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Doc_Faq_CommentsModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Doc_Faq_CommentsModel>(id);
            }

        }

        public List<Doc_Faq_CommentsModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_Faq_CommentsModel>().ToList();
            }
        }
        public List<Doc_Faq_CommentsModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_Faq_CommentsModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Doc_Faq_CommentsModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Doc_Faq_CommentsModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Doc_Faq_CommentsModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Doc_Faq_CommentsModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Doc_Faq_CommentsModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Doc_Faq_CommentsModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Doc_Faq_CommentsModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Doc_Faq_CommentsModel>(model01);
            }
        }

        public Guid Insert(Doc_Faq_CommentsModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Doc_Faq_CommentsModel>(model);
            }
        }

        public int Update(Doc_Faq_CommentsModel model)
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
                return conn.Delete<Doc_Faq_CommentsModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_Faq_CommentsModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_Faq_CommentsModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Doc_Faq_CommentsModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Doc_Faq_CommentsModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Doc_Faq_CommentsModel>(query, objects);
            }
        }
    }
}
