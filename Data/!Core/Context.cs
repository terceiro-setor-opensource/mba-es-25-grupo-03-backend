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

        #region Usuário

        public DbSet<Usuario> Usuario { get; set; }

        #endregion

        #region Curso

        public DbSet<Curso> Curso { get; set; }

        public DbSet<CategoriaCurso> CategoriaCurso { get; set; }

        public DbSet<ConteudoCurso> ConteudoCurso { get; set; }

        public DbSet<MatriculaCurso> MatriculaCurso { get; set; }

        #endregion

        #region Mensagem

        public DbSet<MensagemCurso> MensagemCurso { get; set; }

        public DbSet<MensagemMatricula> MensagemMatricula { get; set; }

        #endregion

        #endregion
    }
}