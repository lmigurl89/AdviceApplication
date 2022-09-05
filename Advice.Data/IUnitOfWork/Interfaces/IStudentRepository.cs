using Advice.Data.Model;

namespace Advice.Data.IUnitOfWork.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Task<Student?> FindByName(string name);
    }
}
