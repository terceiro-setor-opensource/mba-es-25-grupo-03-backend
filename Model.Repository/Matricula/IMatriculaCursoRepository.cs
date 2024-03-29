﻿using Business.Model.ModelView;
using Data.Entity;

namespace Data.Repository.Model
{
    public interface IMatriculaCursoRepository : IRepository<MatriculaCurso>
    {
        Task<List<MatriculaModelView>> ListPorUsuario(long idUsuario);
    }
}
