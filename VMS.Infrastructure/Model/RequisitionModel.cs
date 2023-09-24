using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Infrastructure.Model
{
    public class RequisitionModel
    {
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
        public List<RequisitionModel>?  RequisitionModels { get; set;}
    }
}
