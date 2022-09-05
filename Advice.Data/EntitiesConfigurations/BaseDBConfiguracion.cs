using Advice.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Advice.Data.EntitiesConfigurations
{
    public class BaseDBConfiguracion<TEntity> where TEntity : EntityBase
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            #region Configurando Entidad

            modelBuilder.Entity<TEntity>().Property(entity => entity.Id).IsRequired()
                         .ValueGeneratedOnAdd();

            modelBuilder.Entity<TEntity>().Property(entity => entity.CreatedAt).IsRequired();            
            modelBuilder.Entity<TEntity>().Property(entity => entity.ModifiedAt).IsRequired();            

            modelBuilder.Entity<TEntity>().HasIndex(entity => entity.Id).IsUnique();

            #endregion
        }
    }
}
