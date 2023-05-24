using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models;
using TasksAPI.Repositorios.Interfaces;

namespace TasksAPI.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<List<TarefaModel>> GetTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }
        public async Task<TarefaModel> GetTarefaById(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)                
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TarefaModel> PostTarefa(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa; 
        }
        public async Task<TarefaModel> PutTarefa(TarefaModel tarefaModel, int id)
        {
            TarefaModel tarefa = await GetTarefaById(id);
            if(tarefa == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
            }
            tarefa.Name = tarefaModel.Name;
            tarefa.Description = tarefaModel.Description;

            _dbContext.Tarefas.Update(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }
        public async Task<bool> DeleteTarefa(int id)
        {
            TarefaModel tarefa = await GetTarefaById(id);
            if (tarefa == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Tarefas.Remove(tarefa);
            await _dbContext.SaveChangesAsync();
            return true;
        }

      
    }
}
