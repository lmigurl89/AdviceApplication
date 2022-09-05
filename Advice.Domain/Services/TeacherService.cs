using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Advice.Domain.Interfaces;

namespace Advice.Domain.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(IUnitOfWork repositories, IBaseRepository<Teacher> baseRepository) : base(repositories, baseRepository)
        {
        }
    }
}