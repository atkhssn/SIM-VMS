using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VMS.Infrastructure.Model
{
    public class VehicleModel
    {
        public long VehicleId { get; set; }
        [Required]
         public String RegNo { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        [Required]
        public DateTime Reg_ExpiryDate { get; set; }
        public long ModelId { get; set; }
        [Required]
        public int Modelyear { get; set; }
        public long VehicleCategoryId { get; set; }
        [Required]
        public int VehicleType { get; set; }
        [Required]
        public int VehicleMode { get; set; }
        public int VehicleCapacityId { get; set; }
        public int VehicleCapacity { get; set; }
        public decimal VehicleMileage { get; set; }
        [Required]
        public int Color { get; set; }
        public long ManufacturedBy { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile Photo { get; set; }
        public string? DocumentUrl { get; set; }
        public IFormFile Document { get; set; }
        public long fitness_TaxToken { get; set; }
        public DateTime fitnessExpireDate { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string Chassis { get; set; }
    }
}
