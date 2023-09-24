using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Infrastructure.Model
{
    public class RoadExpenseModel
    {
        public long Id { get; set; }
        [Required]
        public string DonationType { get; set; }
        [Required]
        public double DonationAmount { get; set; }
        [Required]
        public DateTime DonationDate { get; set; }
        [Required]
        public string Location { get; set; }
        public string? Comments { get; set; }
        public string? DonationDocumentUrl { get; set; }
        public IFormFile? DonationDocument { get; set; }
        public List<RoadExpenseModel>? RoadExpenseModels { get; set; }
    }
}
