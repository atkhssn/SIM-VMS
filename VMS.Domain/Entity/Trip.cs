namespace VMS.Domain.Entity
{
    public  class Trip
    {
        public long TripId { get; set; }
        public long VehicleId { get; set; }
        public long DriverId { get;set; }
        public long TripExpensesId { get; set; }
        public decimal FuelId { get; set; }
        public string RequestBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ServiceBill { get; set; }
        public string StartPoint { get; set; }
        public decimal Mileage { get; set; }
        public string EndPoint { get; set; }
        public decimal TotalBill { get; set;}
        public decimal TotalFuel { get; set;}
    }
}
