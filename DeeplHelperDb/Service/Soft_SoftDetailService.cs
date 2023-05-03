using Dapper;
using DeeplHelperDb.Model;
namespace DeeplHelperDb.Service {

    public class Soft_SoftDetailService
    {


        private readonly DbContext dbContext;


        public Soft_SoftDetailService(DbContext _dbContext) {

            this.dbContext = _dbContext;
        }


        public Soft_SoftDetailModel GetByPK(string id)
        {
            //这里可以是ID,还可以是在模型上指定为Key [key]
            using (var conn = dbContext.GetConnection()) {
                return conn.Get<Soft_SoftDetailModel>(id);
            }

        }

        public List<Soft_SoftDetailModel> GetAll()
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftDetailModel>().ToList();
            }
        }
        public List<Soft_SoftDetailModel> GetAll(object[] _objList)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftDetailModel>(_objList).ToList();
            }
        }
        //"where age = 10 or Name like '%Smith%'"
        public List<Soft_SoftDetailModel> GetAll(string _whereQuery)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetList<Soft_SoftDetailModel>(_whereQuery).ToList();
            }
        }
        //GetListPaged<User>(1,10,"where age = 10 or Name like '%Smith%'","Name desc");
        public List<Soft_SoftDetailModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Soft_SoftDetailModel>(page, pageSizeNum, query, orderbyColumnName).ToList();
            }
        }
        //connection.GetListPaged<User>(1,10,"where age = @Age","Name desc", new {Age = 10});  
        public List<Soft_SoftDetailModel> GetAllPage(int page, int pageSizeNum, string query, string orderbyColumnName, object objects)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.GetListPaged<Soft_SoftDetailModel>(page, pageSizeNum, query, orderbyColumnName, objects).ToList();
            }
        }

        public int? Insert(Soft_SoftDetailModel model01) {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Soft_SoftDetailModel>(model01);
            }
        }

        public Guid Insert(Soft_SoftDetailModel model,Guid guid)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Insert<Guid,Soft_SoftDetailModel>(model);
            }
        }

        public int Update(Soft_SoftDetailModel model)
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
                return conn.Delete<Soft_SoftDetailModel>(id);
            }

        }


        public int DeleteList(object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftDetailModel>(objects);
            }

        }

        public int DeleteList(string query)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftDetailModel>(query);
            }

        }

        public int DeleteList(string query,object[] objects)
        {
            //删除多行数据
            using (var conn = dbContext.GetConnection())
            {
                return conn.DeleteList<Soft_SoftDetailModel>(query,objects);
            }

        }


        public int RecordCount(string query) {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Soft_SoftDetailModel>(query);
            }
        }
        public int RecordCount(string query, object[] objects)
        {

            using (var conn = dbContext.GetConnection())
            {
                return conn.RecordCount<Soft_SoftDetailModel>(query, objects);
            }
        }
    }
}
