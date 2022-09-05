using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.DbContext
{
    public interface IAdviceDbContext
    {
        #region Entidades
        
         DbSet<School> Schools { get; set; }
         DbSet<Student> Students { get; set; }
         DbSet<Teacher> Teachers { get; set; }
         DbSet<Course> Courses { get; set; }

        #endregion
    }
}
