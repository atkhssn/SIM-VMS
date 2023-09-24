using System.ComponentModel.DataAnnotations;

namespace VMS.Domain.Entity
{
    public class Driver : BaseEntity
    {
        [Key]
        public long DId { get; set; }
        public string DName { get; set; }
        public string LicenceNo { get; set; }
        public DateTime LicenceValidation { get; set; }
        public string NIDNumber { get; set; }
        public string DriverShift { get; set; }
        public string DriverType { get; set; }
        public string DriverPhotoUrl { get; set; }
        public string LicenceDocumentUrl { get; set; }
        public string NIDDocumentUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
    }
}
