using VMS.Domain.Entity;

namespace VMS.Infrastructure.Model
{
    public class MerchantModel
    {
        public long Id { get; set; }
        public string MerchantName { get; set; }
        public string DepartmentName { get; set; }
        public string ResponsiblePerson { get; set; }
        public string MerchantPhone { get; set; }
        public string MerchantEmail { get; set; }
        public Merchant marchentModel  { get; set; }
        public List<MerchantModel> MerchantList { get; set; }
    }
}
