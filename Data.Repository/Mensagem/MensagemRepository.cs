using Business.Model.ModelView;
using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class MensagemRepository : Repository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(IContext context)
            : base(context)
        {
                
        }

        public async Task<List<MensagemModelView>> ListPorUsuario(long idUsuario)
        {
            var query = (from m in Entity()
                         join mc in _context.Set<MatriculaCurso>() on m.IdMatriculaCurso equals mc.Id
                         join u in _context.Set<Usuario>() on mc.IdUsuario equals u.Id
                         join c in _context.Set<Curso>() on mc.IdCurso equals c.Id
                         join i in _context.Set<Usuario>() on c.IdUsuario equals i.Id
                         where u.Id == idUsuario
                         select new MensagemModelView
                         {
                             IdMatricula = mc.Id,
                             IdMensagem = m.Id,
                             Curso = c.Descricao,
                             NomeInstrutor = i.Nome,
                             Mensagem = m.Texto,
                             Instrutor = m.Instrutor == 1,
                             Lida = m.Lida == 1
                         })
                         .AsNoTracking();

            return await query.OrderBy(x => x.IdMensagem).ToListAsync();
        }
    }
}
