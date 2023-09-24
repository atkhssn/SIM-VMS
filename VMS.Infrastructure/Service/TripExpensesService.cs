using VMS.Infrastructure.Model;
using VMS.Persistence;
using VMS.Persistence.UnitOfWork;

namespace VMS.Infrastructure.Service
{
    public  class TripExpensesService
    {

        public IUnitOfWork _unitOfWork { get; set; }
        public TripExpensesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


       public bool create(TripExpensesModel model)
        {


            return false;
        }
    }
}
