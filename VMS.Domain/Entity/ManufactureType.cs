namespace VMS.Domain.Entity
{
    public class ManufactureType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long VehicleTypeId { get; set; }
    }
}
