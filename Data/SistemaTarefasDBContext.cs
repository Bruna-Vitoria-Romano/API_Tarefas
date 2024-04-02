using API_Tarefas.Data.Map;
using API_Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options):base(options) 
        { 
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            // vai aplicar o mapeamento das propriedades

            base.OnModelCreating(modelBuilder);
        }
    }
}
