using Log4net.Infra.Crosscutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Log4net.DTO
{
   public class AplicationGetDTO:EntityBaseDTO
    {
        /// <summary>
        /// Name application
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Keep the last days
        /// </summary>
        public int KeepLastDays { get; set; }

        /// <summary>
        /// Last Modified
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public EStatus Status { get; set; }
    }
}
