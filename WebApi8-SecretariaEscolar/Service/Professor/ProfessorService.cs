using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi8_SecretariaEscolar.Data;
using WebApi8_SecretariaEscolar.Dto.Professor;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Service.Professor
{
    public class ProfessorService : IProfessorInterface
    {
        public readonly AppDbContext _context;
        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<ProfessorModel>> BuscarProfessorId(int idProf)
        {
            ResponseModel<ProfessorModel> resposta = new ResponseModel<ProfessorModel>();
            try
            {
                var professores = await _context.Professor.FirstOrDefaultAsync(profBanco => profBanco.Id == idProf);

                if (idProf == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado!"; 
                    return resposta;
                }

                resposta.Dados = professores;
                resposta.Mensagem = "Professor encontrado!"; 

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProfessorModel>> BuscarProfessorIdTurma(int idTurma)
        {
            ResponseModel<ProfessorModel> resposta = new ResponseModel<ProfessorModel>();
            try
            {
                var turma = await _context.Turma
                    .Include(p => p.Professor)
                    .FirstOrDefaultAsync(turmaBanco => turmaBanco.Id == idTurma);

                if (turma == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = turma.Professor;
                resposta.Mensagem = "Professor encontrado!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> ListarProfessores()
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var professores = await _context.Professor.ToListAsync();
                resposta.Dados = professores;
                resposta.Mensagem = "Todos os professores foram coletados!";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> CriarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var professores = new ProfessorModel()
                {
                    Nome = professorCriacaoDto.Nome,
                    Diciplina = professorCriacaoDto.Diciplina
                };

                _context.Add(professores); 
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professor.ToListAsync();
                resposta.Mensagem = "Professor criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> EditarProfessor(ProfessorEdicaoDto professorEdicaoDto)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();

            try
            {
                var professor = await _context.Professor.FirstOrDefaultAsync(profBanco => profBanco.Id == professorEdicaoDto.Id);

                if (professor == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                professor.Nome = professorEdicaoDto.Nome;
                professor.Diciplina = professorEdicaoDto.Diciplina;

                _context.Update(professor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professor.ToListAsync();
                resposta.Mensagem = "Professor editado com sucesso!";
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProfessorModel>>> ExcluirProfessor(int idProf)
        {
            ResponseModel<List<ProfessorModel>> resposta = new ResponseModel<List<ProfessorModel>>();
            try
            {
                var professor = await _context.Professor.FirstOrDefaultAsync(profBanco => profBanco.Id == idProf);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                _context.Remove(professor); 
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professor.ToListAsync();
                resposta.Mensagem = "Professor excluido com sucesso!";

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
