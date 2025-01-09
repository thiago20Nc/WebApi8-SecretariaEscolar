using System.Text.Json.Serialization;

namespace WebApi8_SecretariaEscolar.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string Diciplina { get; set; }

        [JsonIgnore]
        public ICollection<TurmaModel> Turmas { get; set; }
    }
}
