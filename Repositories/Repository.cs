using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TMODEL> where TMODEL : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
           => _connection = connection;

        public IEnumerable<TMODEL> Get()
            => _connection.GetAll<TMODEL>();

        public TMODEL Get(int id)
            => _connection.Get<TMODEL>(id);

        public void Create(TMODEL model)
            => _connection.Insert<TMODEL>(model);


        public void Update(TMODEL model)
            => _connection.Update<TMODEL>(model);

        public void Delete(TMODEL model)
            => _connection.Delete<TMODEL>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<TMODEL>(id);
            _connection.Delete<TMODEL>(model);
        }
    }
}