using Business.Model.ModelView;
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
                         where mc.IdUsuario == idUsuario
                         select new MatriculaModelView
                         {
                             IdMatricula = mc.Id,
                             IdCurso = c.Id, 
                             IdUsuario = idUsuario,
                             Curso = c.Descricao,
                             NomeInstrutor = i.Nome
                         })
                         .AsNoTracking();

            return await query.OrderBy(x => x.IdMatricula).ToListAsync();
        }
    }
}
