using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;
using TasksAPI.Repositorios.Interfaces;

namespace TasksAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
      _usuarioRepositorio = usuarioRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuario()
    {
      List<UsuarioModel> usuarios = await _usuarioRepositorio.GetUsuarios();
      return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> BuscarUsuarioById(int id)
    {
      UsuarioModel usuario = await _usuarioRepositorio.GetUsuarioById(id);
      return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> CriarUsuario([FromBody] UsuarioModel usuarioModel)
    {
      UsuarioModel usuario = await _usuarioRepositorio.PostUsuario(usuarioModel);
      return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
    {
       usuarioModel.Id = id;
       UsuarioModel usuario = await _usuarioRepositorio.PutUsuario(usuarioModel, id);
       return Ok(usuario);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioModel>> DeletarUsuario( int id)
    {
       bool apagado = await _usuarioRepositorio.DeleteUsuario(id);
       return Ok(apagado);

    }


    }
}
