using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;

namespace VMS.Persistence.Repository.IRepository
{
    public interface ITransportAgencyRepository : IRepository<TransportAgency>
    {
        Task<bool> IsDuplicateAsync(string TransportName);
        IList<TransportAgency> GetActiveList();
    }
}
