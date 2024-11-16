using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace DefaultNamespace;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private static readonly List<Pedido> Pedidos = new();
    private static readonly List<Users> Usuarios = new();
    // private static readonly Histogram PedidoDuracao = Metrics.CreateHistogram("pedido_duracao", "Duração de um pedido", new HistogramConfiguration
    // {
    //     Buckets = Histogram.LinearBuckets(start: 1, width: 1, count: 10)
    // });
    

    // Cria um novo usuário
    [HttpPost("usuario")]
    public IActionResult CriarUsuario([FromBody] Users novoUsuario)
    {
        novoUsuario.UsuarioId = Usuarios.Count + 1;
        Usuarios.Add(novoUsuario);
        return CreatedAtAction(nameof(ObterUsuario), new { id = novoUsuario.UsuarioId }, novoUsuario);
    }

    // Cria um novo pedido
    [HttpPost]
    public IActionResult CriarPedido([FromBody] Pedido novoPedido)
    {
        novoPedido.Id = Pedidos.Count + 1;
        //novoPedido.Data = DateTime.UtcNow;
        Pedidos.Add(novoPedido);
        return CreatedAtAction(nameof(ObterPedido), new { id = novoPedido.Id }, novoPedido);
    }

    // Obtém um pedido específico pelo ID
    [HttpGet("{id}")]
    public IActionResult ObterPedido(int id)
    {
        Thread.Sleep(10000);
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }

    // Obtém um usuário específico pelo ID
    [HttpGet("usuario/{id}")]
    public IActionResult ObterUsuario(int id)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    // Lista todos os pedidos
    [HttpGet]
    
    public IActionResult ListarPedidos()
    {
        //Thread.Sleep(10000);
        return Ok(Pedidos);
    }
}