using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.EntitiesConfigurations
{
    public class StudentDBConfiguracion
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<Student>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Student>().Property(student => student.Name)
                                         .IsRequired()
                                         .HasMaxLength(100);

            modelBuilder.Entity<Student>().Property(student => student.Age)
                                         .IsRequired()
                                         .HasMaxLength(3);

            modelBuilder.Entity<Student>().HasIndex(student => student.Name).IsUnique();

            modelBuilder.Entity<Student>().HasOne(student => student.Course)
                                         .WithMany(course=> course.Students)
                                         .HasForeignKey(student => student.CourseId)
                                         .HasPrincipalKey(course => course.Id)
                                         .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
