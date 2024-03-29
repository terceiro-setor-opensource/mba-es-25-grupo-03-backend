﻿using Data.Entity;

namespace Data.Repository.Model
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<List<Curso>?> ListaCursos(string? descricao, List<long>? categorias, int ratingMin, int ratingMax, int duracaoMin, int duracaoMax);

        Task<Curso?> GetCurso(long id);
    }
}
