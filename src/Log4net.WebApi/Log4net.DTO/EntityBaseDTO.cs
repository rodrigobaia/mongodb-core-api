using System;

namespace Log4net.DTO
{
    /// <summary>
    /// Entidade base Value Objects
    /// </summary>
    public class EntityBaseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Created In
        /// </summary>
        public DateTime CreatedIn { get; set; } = DateTime.Now;
    }
}
