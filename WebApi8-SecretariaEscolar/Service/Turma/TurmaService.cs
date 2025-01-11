using Microsoft.EntityFrameworkCore;
using WebApi8_SecretariaEscolar.Data;
using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Dto.Turma;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Service.Turma
{
    public class TurmaService : ITurmaInterface
    {
        public readonly AppDbContext _context;
        public TurmaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TurmaModel>>> ListarTurmas()
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            try
            {
                var turmas = await _context.Turma.Include(p => p.Professor).ToListAsync();
                resposta.Dados = turmas;
                resposta.Mensagem = "Todos as turmas foram coletados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TurmaModel>> BuscarTurmaId(int idTurma)
        {
            ResponseModel<TurmaModel> resposta = new ResponseModel<TurmaModel>();
            try
            {
                var turmas = await _context.Turma
                    .Include(p => p.Professor)
                    .FirstOrDefaultAsync(turmaBanco => turmaBanco.Id == idTurma);

                if (idTurma == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = turmas;
                resposta.Mensagem = "Turma encontrada!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TurmaModel>>> BuscarTurmaIdProf(int idProf)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            try
            {
                var turma = await _context.Turma
                    .Include(p => p.Professor)
                    .Where(turmaBanco => turmaBanco.Professor.Id == idProf)
                    .ToListAsync();

                if (turma == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = turma;
                resposta.Mensagem = "Turma encontrada!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<TurmaModel>>> CriarTurma(TurmaCriacaoDto turmaCriacaoDto)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            
            try
            {
                var professor = await _context
               .Professor.FirstOrDefaultAsync(profBanco => profBanco.Id == turmaCriacaoDto.Professor.Id); 

                if(professor == null) 
                {
                    resposta.Mensagem = "Nenhum registro de professor locallizado";
                    return resposta; 
                }

                var turma = new TurmaModel()
                {
                    Nome = turmaCriacaoDto.Nome, 
                    Professor = professor
                }; 

                _context.Add(turma);
                await _context.SaveChangesAsync(); 

                resposta.Dados = await _context.Turma.Include(p => p.Professor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TurmaModel>>> EditarTurma(TurmaEdicaoDto turmaEdicaoDto)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();

            try
            {
                var turma = await _context.Turma
                    .Include(professor => professor.Professor)
                    .FirstOrDefaultAsync(turmaBanco => turmaBanco.Id == turmaEdicaoDto.Id);

                var professor = await _context
               .Professor.FirstOrDefaultAsync(profBanco => profBanco.Id == turmaEdicaoDto.Professor.Id);

                if (turma == null) 
                {
                    resposta.Mensagem = "Nenhum registro de turma localizado";
                    return resposta;
                }

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro de professor localizado";
                    return resposta;
                }

                turma.Nome = turmaEdicaoDto.Nome;
                turma.Professor = professor;

                _context.Update(turma);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Turma.ToListAsync(); 
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TurmaModel>>> ExcluirTurma(int idTurma)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            try
            {
                var turma = await _context.Turma.FirstOrDefaultAsync(turmaBanco => turmaBanco.Id == idTurma);

                if (turma == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                _context.Remove(turma);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Turma.ToListAsync();
                resposta.Mensagem = "Turma excluida com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
