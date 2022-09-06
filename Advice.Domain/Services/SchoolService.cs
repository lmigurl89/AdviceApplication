using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Advice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Advice.Domain.Services
{
    public class SchoolService : BaseService<School>, ISchoolService
    {
        public SchoolService(IUnitOfWork repositories) : base(repositories)
        {
        }
    }
}