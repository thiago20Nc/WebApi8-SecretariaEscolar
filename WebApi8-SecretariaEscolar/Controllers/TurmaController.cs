using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Dto.Turma;
using WebApi8_SecretariaEscolar.Models;
using WebApi8_SecretariaEscolar.Service.Professor;
using WebApi8_SecretariaEscolar.Service.Turma;

namespace WebApi8_SecretariaEscolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaInterface _turmaInterface;
        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }

        [HttpGet("BuscarTurmaId/{idTurma}")]
        public async Task<ActionResult<ResponseModel<TurmaModel>>> BuscarTurmaId(int idTurma)
        {
            var turma = await _turmaInterface.BuscarTurmaId(idTurma);
            return Ok(turma);
        }

        [HttpGet("BuscarTurmaIdProfessor/{idProf}")]
        public async Task<ActionResult<ResponseModel<TurmaModel>>> BuscarTurmaIdProf(int idProf)
        {
            var turma = await _turmaInterface.BuscarTurmaIdProf(idProf);
            return Ok(turma);
        }

        [HttpGet("ListarTurmas")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> ListarProfessores()
        {
            var turmas = await _turmaInterface.ListarTurmas();
            return Ok(turmas);
        }

        [HttpPost("CriarTurma")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> CriarTurma(TurmaCriacaoDto turmaCriacaoDto)
        {
            var turma = await _turmaInterface.CriarTurma(turmaCriacaoDto);
            return Ok(turma);
        }

        [HttpPut("EditarTurma")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> EditarProfessor(TurmaEdicaoDto turmaEdicaoDto)
        {
            var turma = await _turmaInterface.EditarTurma(turmaEdicaoDto);
            return Ok(turma);
        }

        [HttpDelete("ExcluirTurma/{idTurma}")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> ExcluirTurma(int idTurma)
        {
            var turma = await _turmaInterface.ExcluirTurma(idTurma);
            return Ok(turma);
        }
    }
}
