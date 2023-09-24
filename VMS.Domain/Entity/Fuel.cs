using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Domain.Entity
{
    public class Fuel : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public double InitialFuel { get; set; }
        public double loadedFuel { get; set; }
        public double FuelCost { get; set; }
        public DateTime Date { get; set; }
        public string FuelStation { get; set; }
        public string StationLocation { get; set; }
        public string Comments { get; set; }
        public string VoucherUrl { get; set; }
    }
}
