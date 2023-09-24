using System.ComponentModel.DataAnnotations;

namespace VMS.Domain.Entity
{
    public class Maintenance : BaseEntity
    {
        [Key]
        public long MaintenanceId { get; set; }
        public long VehicleId { get; set; }
        public long TripId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
