namespace VMS.Domain.Entity
{
    public class TransportAgency : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
