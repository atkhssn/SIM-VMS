using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class MerchantRepository : Repository<Merchant>, IMerchantRepository
    {

        public MerchantRepository(DbContext context) : base(context) { }
    }
}
