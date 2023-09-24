namespace VMS.Domain.Entity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string CreateBy { get; set; } = "Admin";
        public DateTime? CreatedOn { get; set; }
        public string UpdateBy { get; set; } = "Admin";
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
