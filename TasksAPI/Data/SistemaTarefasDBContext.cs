using Microsoft.EntityFrameworkCore;
using TasksAPI.Data.Map;
using TasksAPI.Models;

namespace TasksAPI.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options) { 
           // Database.EnsureCreated();   
        }

        // cria as tabelas no banco: tabela Usuarios e Tarefas
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
