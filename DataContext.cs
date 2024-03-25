using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace Books
{
    class DataContextDapper
    {
        private readonly IConfiguration _config;
        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);
        }

        public T? LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.QuerySingleOrDefault<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRows(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql);
        }
        public List<T> LoadData2<T>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql).ToList();
        }
    }
}
