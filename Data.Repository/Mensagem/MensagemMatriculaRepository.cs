using Business.Model;
using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class MensagemMatriculaRepository : Repository<MensagemMatricula>, IMensagemMatriculaRepository
    {
        public MensagemMatriculaRepository(IContext context)
            : base(context)
        {

        }

        public async Task<List<MensagemModelView>> ListaPorMatriculaUsuario(long idUsuario)
        {
            var query =  from u in _context.Set<Usuario>()
                             join mc in _context.Set<MatriculaCurso>() on u.Id equals mc.IdUsuario
                             join c in _context.Set<Curso>() on mc.IdCurso equals c.Id
                             join uc in _context.Set<Usuario>() on c.IdUsuario equals uc.Id
                             join mm in _context.Set<MensagemMatricula>() on mc.Id equals mm.IdMatricula
                             join ms in _context.Set<MensagemCurso>() on mm.IdMensagemCurso equals ms.Id
                         where u.Id == idUsuario
                         select new MensagemModelView
                         {
                             Instrutor = uc.Nome,
                             Titulo = ms.Titulo, 
                             Mensagem = ms.Mensagem, 
                             DataCriacao = ms.DataCriacao, 
                             Lida = mm.Lida == 1
                         };

            return await query.OrderBy(x => x.DataCriacao).ToListAsync();
        }
    }
}
