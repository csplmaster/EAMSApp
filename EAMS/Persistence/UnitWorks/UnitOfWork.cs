using EAMS.Core;
using EAMS.Core.IRepositories;
using EAMS.Persistence.Repositories;

namespace EAMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext _context;

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}