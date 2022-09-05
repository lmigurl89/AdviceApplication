using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.EntitiesConfigurations
{
    public class CourseDBConfiguracion
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Course>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Course>().ToTable("Courses");

            modelBuilder.Entity<Course>().Property(teacher => teacher.Name)
                                         .IsRequired()
                                         .HasMaxLength(100);

            modelBuilder.Entity<Course>().HasIndex(teacher => teacher.Name).IsUnique();
          
            #endregion
        }
    }
}
