namespace Advice.Data.IUnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISchoolRepository Schools { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
