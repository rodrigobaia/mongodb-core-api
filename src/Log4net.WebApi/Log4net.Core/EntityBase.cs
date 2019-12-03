using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Log4net.Core
{
    /// <summary>
    /// Entity base
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId()]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        /// <summary>
        /// Created In
        /// </summary>
        [BsonElement("CreatedIn")]
        [BsonRequired()]
        public DateTime CreatedIn { get; set; } = DateTime.Now;
    }
}
