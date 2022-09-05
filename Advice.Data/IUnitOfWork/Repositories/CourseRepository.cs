using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;

namespace Advice.Data.IUnitOfWork.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AdviceDbContext context) : base(context)
        {
        }
    }
}
