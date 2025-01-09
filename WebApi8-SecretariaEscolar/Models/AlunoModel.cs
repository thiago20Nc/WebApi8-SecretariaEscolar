namespace WebApi8_SecretariaEscolar.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TurmaModel Turma { get; set; }
    }
}
