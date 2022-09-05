using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;

namespace Advice.Data.IUnitOfWork.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AdviceDbContext context) : base(context)
        {
        }
    }
}
