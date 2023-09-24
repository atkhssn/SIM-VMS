using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    internal class TripExpensesRepository : Repository<TripExpenses>, ITripExpensesRepository
    {
        public TripExpensesRepository(DbContext context)
            : base(context) { }
    }
}
