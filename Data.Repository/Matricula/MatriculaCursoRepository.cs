using Business.Model;
using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class MatriculaCursoRepository : Repository<MatriculaCurso>, IMatriculaCursoRepository
    {
        public MatriculaCursoRepository(IContext context)
            : base(context)
        {

        }

        public async Task<List<MatriculaModelView>> ListPorUsuario(long idUsuario)
        {
            var query = (from mc in Entity()
                         join c in _context.Set<Curso>() on mc.IdCurso equals c.Id
                         join i in _context.Set<Usuario>() on c.IdUsuario equals i.Id
                         //join cc in _context.Set<ConteudoCurso>() on c.Id equals cc.IdCurso
                         //join hmc in _context.Set<HistoricoMatriculaConteudo>() on mc.Id equals hmc.IdMatriculaCurso
                         where mc.IdUsuario == idUsuario
                             //&& hmc.IdConteudoCurso == cc.Id
                         select new MatriculaModelView
                         {
                             IdMatricula = mc.Id, 
                             Curso = c.Descricao, 
                             NomeInstrutor = i.Nome,
                             //Concluido = hmc.ConteudoCurso.Count,
                             //Total = c.ConteudoCurso.Count
                         })
                         .Distinct()
                         .AsNoTracking();

            return await query.OrderBy(x => x.IdMatricula).ToListAsync();
        }
    }
}
