namespace FindATM.Models.Atm
{
    /// <summary>
    /// The nearest ATM response model.
    /// </summary>
    public class FindAtmResponseModel
    {
        /// <summary>
        /// Gets or sets AtmName.
        /// </summary>
        public string AtmName { get; set; }

        /// <summary>
        /// Gets or sets CityName.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public string Address { get; set; }
    }
}
