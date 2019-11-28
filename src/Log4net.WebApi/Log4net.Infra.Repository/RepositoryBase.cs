using Log4net.Core;
using Log4net.Infra.Repository.Interfaces;
using Log4net.ValueObject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Log4net.Infra.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : EntityBase
    {

        MongoClient _client;
        IMongoDatabase _db;

        /// <summary>
        /// 
        /// </summary>
        public RepositoryBase(IOptions<MongoSettings> mongoSettings)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var serverMongo = mongoSettings.Value.Server;
            var portServer = mongoSettings.Value.Port;

            var connectionString = $"mongodb://{serverMongo}:{portServer}";

            _client = new MongoClient(connectionString);
        }

        /// <summary>
        /// Configuration
        /// </summary>
        protected IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public virtual string NameTable { get; set; }

        /// <summary>
        /// Name database
        /// </summary>
        public virtual string DatabaseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long CountFields()
        {
            GetDatabase();
            var results = _db.GetCollection<TModel>(typeof(TModel).Name).Count(new FilterDefinitionBuilder<TModel>().Empty); ;

            return results;
        }


        private void GetDatabase()
        {
            _db = _client.GetDatabase(DatabaseName);
        }

        protected IMongoCollection<TModel> Collection()
        {
            GetDatabase();

            NameTable = (string.IsNullOrEmpty(NameTable) ? string.Format("Log_{0:yyyyMMdd}", DateTime.Now) : NameTable);

            var collection = _db.GetCollection<TModel>(NameTable);

            return collection;
        }

        public void Delete(Expression<Func<TModel, bool>> predicate)
        {
            var results = Collection().DeleteOneAsync<TModel>(predicate);
            //results.Result.DeletedCount
        }

        public void Delete(string query)
        {
            throw new NotImplementedException();
        }

        public TModel GetBy(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetFilterAsync(string query)
        {
            //var tags = query.ToUpper().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //var filter = Builders<TModel>.Filter.All(c => c.Tags, tags);
            //var results = await _db.GetCollection<TModel>(typeof(TModel).Name).FindAsync(filter);

            //return results.ToList();

            return null;
        }

        public async Task<long> InsertAsync(TModel entity)
        {
            await Collection().InsertOneAsync(entity);

            return 1;

        }

        public async Task<long> UpdateAsync(TModel entity)
        {
            //await Collection().UpdateOneAsync<TModel>(x=>x.)
            throw new NotImplementedException();
        }

        public async Task<long> InsertAsync(IEnumerable<TModel> entities)
        {

            await Collection().InsertManyAsync(entities);

            return 1;
        }
    }
}
