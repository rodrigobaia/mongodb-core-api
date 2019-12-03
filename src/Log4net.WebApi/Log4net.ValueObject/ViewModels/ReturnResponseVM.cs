namespace Log4net.ValueObject.ViewModels
{

    /// <summary>
    /// Response return View Model
    /// </summary>
    public class ReturnResponseVM<TModel>
    {
        /// <summary>
        /// Code return
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message Return
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Content Return
        /// </summary>
        public TModel Content { get; set; }
    }
}
