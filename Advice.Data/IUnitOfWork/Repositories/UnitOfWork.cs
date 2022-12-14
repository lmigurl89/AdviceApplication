using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.IUnitOfWork.Repositories
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        private readonly AdviceDbContext _context;

        public ICourseRepository Courses { get; }
        public ISchoolRepository Schools { get; }
        public IStudentRepository Students { get; }
        public ITeacherRepository Teachers { get; }

        public UnitOfWork(AdviceDbContext context)
        {
            _context = context;
            Courses = new CourseRepository(context);
            Schools = new SchoolRepository(context);
            Students = new StudentRepository(context);
            Teachers = new TeacherRepository(context);
        }

        public DbSet<TEntity> Context<TEntity>() where TEntity : EntityBase
        {
            return _context.Set<TEntity>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose() => _context.Dispose();
    }
}
