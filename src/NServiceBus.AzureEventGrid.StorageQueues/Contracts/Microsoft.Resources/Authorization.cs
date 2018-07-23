namespace Microsoft.Resources
{
    /// <summary>
    /// The requested authorization details.
    /// </summary>
    public class Authorization
    {
        /// <summary></summary>
        public string Scope { get; set; }
        /// <summary></summary>
        public string Action { get; set; }
        /// <summary></summary>
        public Evidence Evidence { get; set; }
    }
}