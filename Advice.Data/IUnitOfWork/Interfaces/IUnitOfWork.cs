using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.IUnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISchoolRepository Schools { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        DbSet<TEntity> Context<TEntity>() where TEntity : EntityBase;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
