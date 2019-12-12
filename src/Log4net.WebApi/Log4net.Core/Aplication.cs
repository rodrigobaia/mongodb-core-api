using Log4net.Infra.Crosscutting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Log4net.Core
{
    /// <summary>
    /// Application
    /// </summary>
    public class Aplication : EntityBase
    {
        public Aplication()
        {
            Id = ObjectId.GenerateNewId();

        }

        /// <summary>
        /// Name application
        /// </summary>
        [BsonElement("Name")]
        [BsonRequired()]
        public string Name { get; set; }

        /// <summary>
        /// Keep the last days
        /// </summary>
        [BsonElement("KeepLastDays")]
        [BsonRequired()]
        public int KeepLastDays { get; set; }

        /// <summary>
        /// Last Modified
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [BsonElement("Status")]
        [BsonRequired()]
        public EStatus Status { get; set; }
    }
}
