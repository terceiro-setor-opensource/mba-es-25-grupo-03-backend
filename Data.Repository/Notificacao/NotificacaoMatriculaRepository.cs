using Business.Model;
using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class NotificacaoMatriculaRepository : Repository<NotificacaoMatricula>, INotificacaoMatriculaRepository
    {
        public NotificacaoMatriculaRepository(IContext context)
            : base(context)
        {

        }

        public async Task<List<NotificacaoModelView>> ListaPorMatriculaUsuario(long idUsuario)
        {
            var query =  from u in _context.Set<Usuario>()
                             join mc in _context.Set<MatriculaCurso>() on u.Id equals mc.IdUsuario
                             join c in _context.Set<Curso>() on mc.IdCurso equals c.Id
                             join uc in _context.Set<Usuario>() on c.IdUsuario equals uc.Id
                             join nm in _context.Set<NotificacaoMatricula>() on mc.Id equals nm.IdMatricula
                             join nc in _context.Set<NotificacaoCurso>() on nm.IdNotificacaoCurso equals nc.Id
                         where u.Id == idUsuario
                         select new NotificacaoModelView
                         {
                             Id = nm.Id,
                             Instrutor = uc.Nome,
                             Titulo = nc.Titulo, 
                             Notificacao = nc.Notificacao, 
                             DataCriacao = nc.DataCriacao, 
                             Lida = nm.Lida == 1
                         };

            return await query.OrderBy(x => x.DataCriacao).ToListAsync();
        }
    }
}
