using TasksAPI.Models;

namespace TasksAPI.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        // get all dos usuario 
        Task<List<TarefaModel>> GetTarefas();
        // get one usuário
        Task<TarefaModel> GetTarefaById(int id);
        // create usuário
        Task<TarefaModel> PostTarefa(TarefaModel tarefa);
        // update usuário
        Task<TarefaModel> PutTarefa(TarefaModel tarefa, int id);
        // delete usuário
        Task<bool> DeleteTarefa(int id);
    }
}
