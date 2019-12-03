using Log4net.Core;
using Log4net.Infra.Crosscutting;
using Log4net.Infra.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Log4net.Infra.Repository
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : EntityBase
    {

        MongoClient _client;
        IMongoDatabase _db;

        /// <summary>
        /// Construtor
        /// </summary>
        public RepositoryBase(IOptions<MongoSettings> mongoSettings)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json");

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
        /// Count Fields
        /// </summary>
        /// <returns></returns>
        protected long CountFields(FilterDefinition<TModel> filter = null)
        {

            var results = Collection()
                            .CountDocuments(filter);

            return results;
        }


        private void GetDatabase()
        {
            _db = _client.GetDatabase(DatabaseName);
        }

        /// <summary>
        /// Collection
        /// </summary>
        /// <returns></returns>
        protected IMongoCollection<TModel> Collection()
        {
            GetDatabase();

            NameTable = (string.IsNullOrEmpty(NameTable) ? string.Format("_Log_{0:yyyyMMdd}", DateTime.Now) : NameTable);

            var collection = _db.GetCollection<TModel>(NameTable);

            //collection.CreateIndex(IndexKeysDefinition<TModel>.Ascending(_ => _.));

            return collection;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<long> DeleteAsync(Expression<Func<TModel, bool>> predicate)
        {
            var results = await Collection().DeleteOneAsync<TModel>(predicate);

            return results.DeletedCount;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TModel> GetByAsync(ObjectId id)
        {
            Expression<Func<TModel, bool>> filter = x => x.Id == id;
            var results = await Collection().Find(filter).FirstAsync();

            return results;
        }

        public async Task<IEnumerable<TModel>> GetFilterAsync(Expression<Func<TModel, bool>> predicate)
        {
            //var findOptions = new FindOptions { }
            var results = await Collection().Find(predicate).ToListAsync();

            return results;
        }

        public async Task<long> InsertAsync(TModel entity)
        {
            await Collection().InsertOneAsync(entity);

            return 1;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task<long> UpdateAsync(TModel entity)
        {
            //var result = await Collection().UpdateOneAsync(filter, update);

            //return result.MatchedCount;

            var filter = Builders<TModel>.Filter.Eq(c => c.Id == entity.Id, true);

            var results = await Collection().UpdateOneAsync(filter, new ObjectUpdateDefinition<TModel>(entity));

            return results.MatchedCount;

        }

        public async Task<long> InsertAsync(IEnumerable<TModel> entities)
        {

            await Collection().InsertManyAsync(entities);

            return 1;
        }

        public async Task DropCollectionAsync(string nameTable)
        {

            GetDatabase();
            await _db.DropCollectionAsync(nameTable);


        }
    }
}
