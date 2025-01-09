using Microsoft.EntityFrameworkCore;
using WebApi8_SecretariaEscolar.Models;

namespace WebApi8_SecretariaEscolar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {    
        } 

        public DbSet<ProfessorModel> Professor { get; set; }
        public DbSet<TurmaModel> Turma { get; set; }
        public DbSet<AlunoModel> Aluno { get; set; }
    }
}
