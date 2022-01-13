namespace FindATM.Models.Atm
{
    /// <summary>
    /// Request model for nearest ATM.
    /// </summary>
    public class FindAtmRequestModel
    {
        /// <summary>
        /// Gets or sets Latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets Longitude.
        /// </summary>
        public double Longitude { get; set; }
    }
}
