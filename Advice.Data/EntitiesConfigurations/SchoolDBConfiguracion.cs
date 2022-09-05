using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.EntitiesConfigurations
{
    public class SchoolDBConfiguracion
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad
            BaseDBConfiguracion<School>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<School>().ToTable("Schools");

            modelBuilder.Entity<School>().Property(school => school.Name)
                                         .IsRequired()
                                         .HasMaxLength(100);

            modelBuilder.Entity<School>().Property(school => school.Address)
                                         .HasMaxLength(200);

            modelBuilder.Entity<School>().HasIndex(school => school.Name).IsUnique();

            modelBuilder.Entity<School>().HasMany(school => school.Teachers)
                                         .WithOne(teacher=> teacher.School)
                                         .HasForeignKey(teacher => teacher.SchoolId)
                                         .HasPrincipalKey(school => school.Id)
                                         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<School>().HasMany(school => school.Students)
                                         .WithOne(student=> student.School)
                                         .HasForeignKey(students => students.SchoolId)
                                         .HasPrincipalKey(school => school.Id)
                                         .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
