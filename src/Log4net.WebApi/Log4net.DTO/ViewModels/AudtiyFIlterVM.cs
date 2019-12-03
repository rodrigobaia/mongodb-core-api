using System;

namespace Log4net.DTO.ViewModels
{
    /// <summary>
    /// FIlter audit view model
    /// </summary>
    public class AudtiyFIlterVM
    {

        /// <summary>
        /// Date Init
        /// </summary>
        public DateTime InitDate { get; set; }

        /// <summary>
        /// Date End
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// TIme Begin
        /// </summary>
        public string InitTime { get; set; }

        /// <summary>
        /// Time End
        /// </summary>
        public string EndTime { get; set; }
    }
}
