using System.ComponentModel.DataAnnotations;

namespace VMS.Domain.Entity
{
    public class Manufacture : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long ManufactureTypeId { get; set; }
        public long ModelTypeId { get; set; }
    }
}
