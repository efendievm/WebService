namespace WebService.Domain
{
    /// <summary>
    /// Организация.
    /// </summary>
    public class Organization : BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; } = null!;

        #region Навигационные поля
        /// <summary>
        /// Дочерние организации.
        /// </summary>
        public List<SubsidiaryOrganization> SubsidaryOrganizations { get; set; } = null!;
        #endregion
    }
}