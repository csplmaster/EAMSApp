using EmployeeManagement.Core.Domain;
using EmployeeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmployeeManagement.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EmployeeContext context) 
            : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return EmployeeContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return EmployeeContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public EmployeeContext EmployeeContext
        {
            get { return Context as EmployeeContext; }
        }
    }
}