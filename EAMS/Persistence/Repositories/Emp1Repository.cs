using EAMS.Models;
using EAMS.Core.IRepositories;
using EAMS.DB_Contexts;

namespace EAMS.Persistence.Repositories
{
    public class Emp1Repository : Repository<Emp1>, IEmp1Repository
    {
        public Emp1Repository(EAMSContext context) : base(context)
        {
        }

        public void UpdateAddress(Emp1 obj)
        {
            //EAMSContext.Epm1s.Attach(obj);
            EAMSContext.Entry(obj).Property(x => x.Address).IsModified = true;
        }

        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}