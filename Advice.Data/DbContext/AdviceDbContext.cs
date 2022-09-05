using Advice.Data.DbContext;
using Advice.Data.EntitiesConfigurations;
using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.DbContext
{
    public class AdviceDbContext : Microsoft.EntityFrameworkCore.DbContext, IAdviceDbContext
    {
        #region Entidades
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

        public AdviceDbContext(DbContextOptions<AdviceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CourseDBConfiguracion.SetEntityBuilder(modelBuilder);
            SchoolDBConfiguracion.SetEntityBuilder(modelBuilder);
            StudentDBConfiguracion.SetEntityBuilder(modelBuilder);
            TeacherDBConfiguracion.SetEntityBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
