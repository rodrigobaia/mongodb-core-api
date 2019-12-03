using Log4net.Business.Interfaces;

namespace Log4net.Business
{
    /// <summary>
    /// Interface base business
    /// </summary>
    public class BusinessBase : IBusinessBase
    {
        /// <summary>
        /// Name database
        /// </summary>
        public virtual string DatabaseName { get; set; }
    }
}
