namespace WebService.Domain
{
    /// <summary>
    /// Дочерняя организация.
    /// </summary>
    public class SubsidiaryOrganization : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; } = null!;


        #region Навигационные поля
        /// <summary>
        /// Id родительской организации.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Родительская организация.
        /// </summary>
        public Organization Organization { get; set; } = null!;

        /// <summary>
        /// Объекты электропотребления..
        /// </summary>
        public List<ConsumptionObject> ConsumptionObjects { get; set; } = null!;
        #endregion
    }
}