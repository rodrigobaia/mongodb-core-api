using System;

namespace Log4net.WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditoriaVM
    {

        ///// <summary>
        ///// Name Application
        ///// </summary>
        //public string NameApplication { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Therad
        /// </summary>
        public string Therad { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Org
        /// </summary>
        public string Org { get; set; }
    }
}
