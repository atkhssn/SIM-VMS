using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Infrastructure.Model
{
    public class FuelModel
    {
        public long Id { get; set; }
        public double InitialFuel { get; set; }
        public double loadedFuel { get; set; }
        public double FuelCost { get; set; }
        public DateTime Date { get; set; }
        public string FuelStation { get; set; }
        public string StationLocation { get; set; }
        public string Comments { get; set; }
        public string VoucherUrl { get; set; }
        public IFormFile Voucher { get; set; }
        public List<FuelModel>? Fuels { get; set; }
    }
}
