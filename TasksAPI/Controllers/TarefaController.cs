using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;
using TasksAPI.Repositorios.Interfaces;

namespace TasksAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TarefaController : ControllerBase
  {
    private readonly ITarefaRepositorio _tarefaRepositorio;
    public TarefaController(ITarefaRepositorio tarefaRepositorio)
    {
        _tarefaRepositorio = tarefaRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> GetAll()
    {
      List<TarefaModel> tarefas = await _tarefaRepositorio.GetTarefas();
      return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaModel>> GetOne(int id)
    {
      TarefaModel tarefa = await _tarefaRepositorio.GetTarefaById(id);
      return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaModel>> Create([FromBody] TarefaModel tarefaModel)
    {
      TarefaModel tarefa = await _tarefaRepositorio.PostTarefa(tarefaModel);
      return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaModel>> Update([FromBody] TarefaModel tarefaModel, int id)
    {
       tarefaModel.Id = id;
       TarefaModel usuario = await _tarefaRepositorio.PutTarefa(tarefaModel, id);
       return Ok(usuario);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TarefaModel>> Delete( int id)
    {
       bool apagado = await _tarefaRepositorio.DeleteTarefa(id);
       return Ok(apagado);

    }


    }
}
