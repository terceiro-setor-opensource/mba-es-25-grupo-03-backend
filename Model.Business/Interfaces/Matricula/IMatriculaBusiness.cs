namespace Business.Model
{
    public interface IMatriculaCursoBusiness : ICommonBusiness
    {
        Task<List<MatriculaModelView>?> List(long idUsuario);    
    }
}
