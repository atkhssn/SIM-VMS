using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(DbContext context) : base(context) 
        {
        }
    }
}
