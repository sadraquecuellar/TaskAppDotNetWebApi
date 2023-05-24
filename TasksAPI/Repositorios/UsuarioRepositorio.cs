using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Models;
using TasksAPI.Repositorios.Interfaces;

namespace TasksAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> GetUsuarioById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UsuarioModel> PostUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario; 
        }
        public async Task<UsuarioModel> PutUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel user = await GetUsuarioById(id);
            if(user == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }
            user.Name = usuario.Name;
            user.Email = usuario.Email;

            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel user = await GetUsuarioById(id);
            if (user == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.Usuarios.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        
    }
}
