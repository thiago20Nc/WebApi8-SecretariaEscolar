namespace WebApi8_SecretariaEscolar.Models
{
    public class TurmaModel
    { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public ProfessorModel Professor { get; set; }
    }
}
