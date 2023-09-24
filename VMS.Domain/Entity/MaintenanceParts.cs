namespace VMS.Domain.Entity
{
    public  class MaintenanceParts:BaseEntity
    {
        public long Id { get; set; }
        public string PartsName { get; set; }
        public decimal PartsPrice{ get; set; }
        public long MaintainanceId{ get; set; }


    }
}
