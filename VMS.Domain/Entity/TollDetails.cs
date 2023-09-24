namespace VMS.Domain.Entity
{
    public  class TollDetails:BaseEntity
    {

        public long  Id { get; set; }

        public string TollName { get; set; }
        public decimal TollFee { get; set; }
        public decimal TollType { get; set; }
        public DateTime TollDate { get; set; }
        public long TripExpensesId { get; set; }  
    }
}
