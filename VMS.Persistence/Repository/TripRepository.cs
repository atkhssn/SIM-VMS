using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(DbContext context) : base(context)
        {
        }
    }
}
