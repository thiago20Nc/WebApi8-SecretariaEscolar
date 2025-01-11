using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Dto.Turma;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Service.Turma
{
    public interface ITurmaInterface
    {
        Task<ResponseModel<List<TurmaModel>>> ListarTurmas();
        Task<ResponseModel<TurmaModel>> BuscarTurmaId(int idTurma);
        Task<ResponseModel<List<TurmaModel>>> BuscarTurmaIdProf(int idProf);
        Task<ResponseModel<List<TurmaModel>>> CriarTurma(TurmaCriacaoDto turmaCriacaoDto);
        Task<ResponseModel<List<TurmaModel>>> EditarTurma(TurmaEdicaoDto turmaEdicaoDto);
        Task<ResponseModel<List<TurmaModel>>> ExcluirTurma(int idTurma);
    }
}
