using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Log4net.Core
{
    /// <summary>
    /// Log
    /// </summary>
    public class Auditoria : EntityBase
    {

        /// <summary>
        /// Exception
        /// </summary>
        [BsonElement("exception")]
        [BsonRequired()]
        public string Exception { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        [BsonElement("level")]
        [BsonRequired()]
        public string Level { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [BsonElement("message")]
        [BsonRequired()]
        public string Message { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; }

        /// <summary>
        /// Therad
        /// </summary>
        [BsonElement("therad")]
        [BsonRequired()]
        public string Therad { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        [BsonElement("method")]
        [BsonRequired()]
        public string Method { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [BsonElement("version")]
        [BsonRequired()]
        public string Version { get; set; }

        [BsonElement("org")]
        [BsonRequired()]
        public string Org { get; set; }
    }
}
