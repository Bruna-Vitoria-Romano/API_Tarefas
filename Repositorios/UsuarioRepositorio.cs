using API_Tarefas.Data;
using API_Tarefas.Models;
using API_Tarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Tarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscaPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscaPorId(id);

            if(usuarioPorID == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }

            usuarioPorID.Email = usuario.Email;
            usuarioPorID.Nome = usuario.Nome;

            _dbContext.Usuarios.Update(usuarioPorID);
            await _dbContext.SaveChangesAsync();

            return usuarioPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorID = await BuscaPorId(id);

            if (usuarioPorID == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(usuarioPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
