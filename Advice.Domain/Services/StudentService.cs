using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Advice.Domain.Interfaces;

namespace Advice.Domain.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork repositories) : base(repositories)
        {
        }
    }
}