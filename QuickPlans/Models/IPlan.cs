namespace QuickPlans.Models
{
    /// <summary>
    /// Generalize reminder items.
    /// </summary>
    internal interface IPlan
    {
        /// <summary>
        /// Identifier of the reminder item.
        /// </summary>
        public string Id { get; set; }
    }
}
