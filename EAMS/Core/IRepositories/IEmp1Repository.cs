using EAMS.Models;

namespace EAMS.Core.IRepositories
{
    public interface IEmp1Repository: IRepository<Emp1>
    {
        void UpdateAddress(Emp1 obj);
    }
}
