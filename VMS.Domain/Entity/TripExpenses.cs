namespace VMS.Domain.Entity
{
    public class TripExpenses : BaseEntity
    {
        public long Id { get; set; }

        public decimal Fuel { get; set; }
        public decimal ExtraMileage { get; set; }
        public decimal RouteMileage { get; set; }
        public decimal AdditionalFuel { get; set; }
        public int DriverCommission { get; set; }
        public int HelperCommission { get; set; }
        public bool OvertimeStatus { get; set; }
        public int LaborTips { get; set; }
        public decimal TollFee { get; set; }
        public string TollName { get; set; }
        public int RoadCommission { get; set; }
    }
}
