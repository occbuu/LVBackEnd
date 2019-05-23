namespace LVBackEnd.BLL.Filter
{
    /// <summary>
    /// HuyLog filter
    /// </summary>
    public class HuyLogFilter
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public HuyLogFilter() { }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Duration
        /// </summary>
        public double? Duration { get; set; }

        /// <summary>
        /// Source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Destination
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Protocol
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        #endregion
    }
}