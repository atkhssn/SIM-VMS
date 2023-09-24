using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Domain.Entity
{
    public class Requisition : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long MerchantId { get; set; }
        public long VehicleId { get; set; }
        public long DriverId { get; set; }
        public string VehicleType { get; set; }
        public int VehicleQuantity { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripEndDate { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Comments { get; set; }
        public string IsTripCompleted { get; set; }
    }
}
