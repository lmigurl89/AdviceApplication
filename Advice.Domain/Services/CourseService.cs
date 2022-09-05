using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Advice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Advice.Domain.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IUnitOfWork repositories, IBaseRepository<Course> baseRepository) : base(repositories, baseRepository)
        {
        }
    }
}