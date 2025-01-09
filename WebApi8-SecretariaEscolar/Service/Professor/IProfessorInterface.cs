using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Service.Professor
{
    public interface IProfessorInterface
    {
        Task<ResponseModel<List<ProfessorModel>>> ListarProfessores();
        Task<ResponseModel<ProfessorModel>> BuscarProfessorId(int  idProf);
        Task<ResponseModel<ProfessorModel>> BuscarProfessorIdTurma(int idTurma);
        Task<ResponseModel<List<ProfessorModel>>> CriarProfessor(ProfessorCriacaoDto professorCriacaoDto);
        Task<ResponseModel<List<ProfessorModel>>> EditarProfessor(ProfessorEdicaoDto professorEdicaoDto);
        Task<ResponseModel<List<ProfessorModel>>> ExcluirProfessor(int idProf);
    }
}
