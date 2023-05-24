using TasksAPI.Models;

namespace TasksAPI.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        // get all dos usuario 
        Task<List<UsuarioModel>> GetUsuarios();
        // get one usuário
        Task<UsuarioModel> GetUsuarioById(int id);
        // create usuário
        Task<UsuarioModel> PostUsuario(UsuarioModel usuario);
        // update usuário
        Task<UsuarioModel> PutUsuario(UsuarioModel usuario, int id);
        // delete usuário
        Task<bool> DeleteUsuario(int id);
    }
}
