using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Domain.Entity
{
    public class RoadExpense : BaseEntity
    {
        [Key]
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
    }
}
