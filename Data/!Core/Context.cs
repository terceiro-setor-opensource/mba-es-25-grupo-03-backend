using Data.Entity;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace Data.Core
{
    public class Context : DbContext, IContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = Utils.GetConnectionString("DataBase");

            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseSqlServer(stringConexao);
        }

        #region DbSets

        public DbSet<Usuario> Usuario { get; set; }

        #endregion
    }
}