using WebApi8_SecretariaEscolar.Dto.Vinculo;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Dto.Turma
{
    public class TurmaCriacaoDto
    {
        public string Nome { get; set; }
        public ProfessorVinculoDto Professor { get; set; }
    }
}
