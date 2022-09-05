using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;

namespace Advice.Data.IUnitOfWork.Repositories
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        public SchoolRepository(AdviceDbContext context) : base(context)
        {
        }
    }
}
