using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.Domain.Entity;
using VMS.Persistence.BaseRepo;
using VMS.Persistence.Repository.IRepository;

namespace VMS.Persistence.Repository
{
    public class RoadExpenseRepository : Repository<RoadExpense>, IRoadExpenseRepository
    {
        public RoadExpenseRepository(DbContext context) : base(context)
        {

        }
    }
}
