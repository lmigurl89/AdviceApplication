using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.EntitiesConfigurations
{
    public class TeacherDBConfiguracion
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Teacher>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Teacher>().ToTable("Teachers");

            modelBuilder.Entity<Teacher>().Property(teacher => teacher.Name)
                                         .IsRequired()
                                         .HasMaxLength(100);

            modelBuilder.Entity<Teacher>().HasIndex(teacher => teacher.Name).IsUnique();

            modelBuilder.Entity<Teacher>().HasOne(teacher => teacher.Course)
                                         .WithMany(course=> course.Teachers)
                                         .HasForeignKey(teacher => teacher.CourseId)
                                         .HasPrincipalKey(course => course.Id)
                                         .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
