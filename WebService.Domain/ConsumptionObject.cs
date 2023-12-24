namespace WebService.Domain
{
    /// <summary>
    /// Объект электропотребления.
    /// </summary>
    public class ConsumptionObject : BaseEntity
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
        /// Id дочерней организации.
        /// </summary>
        public int SubsidiaryOrganizationId { get; set; }

        /// <summary>
        /// Дочерняя организация.
        /// </summary>
        public SubsidiaryOrganization SubsidiaryOrganization { get; set; } = null!;

        /// <summary>
        /// Точки измерения электроэнергии.
        /// </summary>
        public List<MeasurementPoint> MeasurementPoints { get; set; } = null!;

        /// <summary>
        /// Точки поставки электроэнергии.
        /// </summary>
        public List<SupplyPoint> SupplyPoints { get; set; } = null!;
        #endregion
    }
}