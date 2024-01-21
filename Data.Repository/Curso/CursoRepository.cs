using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(IContext context)
            : base(context)
        {

        }

        public async Task<List<Curso>?> ListaCursos(string? descricao, long categoria = 0, int classificacao = 0, int duracaoMin = 0, int duracaoMax = 0)
        {
            return await (from c in _context.Set<Curso>()
                              join co in _context.Set<ConteudoCurso>() on c.Id equals co.IdCurso
                          where (string.IsNullOrWhiteSpace(descricao) || c.Nome.ToLower().Contains(descricao.ToLower()))
                             && (categoria == 0 || c.IdCategoriaCurso == categoria)
                             && (classificacao == 0 || c.Classificacao >= Convert.ToDouble(classificacao))
                             && (duracaoMax == 0 || (c.ConteudoCurso.Count > 0 && c.ConteudoCurso.Sum(x => x.MinutosDuracao) >= duracaoMin * 60 && c.ConteudoCurso.Sum(x => x.MinutosDuracao) <= duracaoMax * 60))
                          select c)
                          .Distinct()
                          .Include(a => a.Usuario)
                          .Include(a => a.CategoriaCurso)
                          .Include(a => a.ConteudoCurso)
                          .ToListAsync();
        }

        public async Task<Curso?> GetCurso(long id)
        {
            return await (from c in _context.Set<Curso>()
                          join co in _context.Set<ConteudoCurso>() on c.Id equals co.IdCurso
                          where c.Id == id
                          select c)
                          .Include(a => a.Usuario)
                          .Include(a => a.CategoriaCurso)
                          .Include(a => a.ConteudoCurso)
                          .FirstOrDefaultAsync();
        }
    }
}