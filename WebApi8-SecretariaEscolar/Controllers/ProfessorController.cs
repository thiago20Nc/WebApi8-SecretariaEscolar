using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Models;
using WebApi8_SecretariaEscolar.Service.Professor;

namespace WebApi8_SecretariaEscolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
       
       private readonly IProfessorInterface _professorInterface;
       public ProfessorController(IProfessorInterface professorInterface)  
       {
            _professorInterface = professorInterface;
       }

        [HttpGet("BuscarProfessoresId/{idProf}")]
        public async Task<ActionResult<ResponseModel<ProfessorModel>>> BuscarProfessoresId(int idProf)
        {
            var professor = await _professorInterface.BuscarProfessorId(idProf);
            return Ok(professor);
        }

        [HttpGet("BuscarProfessoresIdTurma/{idTurma}")]
        public async Task<ActionResult<ResponseModel<ProfessorModel>>> BuscararProfessoresIdTurma(int idTurma)
        {
            var professor = await _professorInterface.BuscarProfessorIdTurma(idTurma);
            return Ok(professor);
        }

        [HttpGet("ListarProfessores")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> ListarProfessores() 
        { 
            var professores = await _professorInterface.ListarProfessores();
            return Ok(professores);
        }

        [HttpPost("CriarProfessor")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> CriarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {
            var professor = await _professorInterface.CriarProfessor(professorCriacaoDto);
            return Ok(professor);
        }

        [HttpPut("EditarProfessor")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> EditarProfessor(ProfessorEdicaoDto professorEdicaoDto)
        {
            var professor = await _professorInterface.EditarProfessor(professorEdicaoDto);
            return Ok(professor);
        }

        [HttpDelete("ExcluirProfessor/{idProf}")]
        public async Task<ActionResult<ResponseModel<List<ProfessorModel>>>> ExcluirProfessor(int idProf)
        {
            var professor = await _professorInterface.ExcluirProfessor(idProf);
            return Ok(professor);
        }
    }
}
