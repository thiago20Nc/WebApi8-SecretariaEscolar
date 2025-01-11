using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Dto.Turma
{
    public class TurmaEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ProfessorModel Professor { get; set; }
    }
}
