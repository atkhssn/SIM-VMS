using Microsoft.EntityFrameworkCore;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    internal class TransportAgencyRepository
        : Repository<TransportAgency>,
            ITransportAgencyRepository
    {
        public TransportAgencyRepository(DbContext context)
            : base(context) { }

        public async Task<bool> IsDuplicateAsync(string TransportName)
        {
            var result = await _Entities.Where(c => c.Owner == TransportName).AnyAsync();

            return result;
        }

        public IList<TransportAgency> GetActiveList()
        {
            var queryable = _Entities;
            return queryable.Where(c => c.IsActive == true).ToList();
        }
    }
}
