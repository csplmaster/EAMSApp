using EmployeeManagement.Core.Domain;
using EmployeeManagement.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace EmployeeManagement.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(EmployeeContext context) : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return EmployeeContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
        }

        public EmployeeContext EmployeeContext
        {
            get { return Context as EmployeeContext; }
        }
    }
}